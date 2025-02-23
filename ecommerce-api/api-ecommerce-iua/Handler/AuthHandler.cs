using ecommerce_core.Helpers;

namespace api_ecommerce_auth.Handler;

public class AuthHandler(IAuthRepository authRepository, IUserRepository userRepository, IConfiguration configuration)
    : IAuthHandler
{
    private readonly IAuthRepository _authRepository = authRepository;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IConfiguration _configuration = configuration;

    public async Task<ResponseApp<AuthInsertDto>> InsertUserHandler(AuthInsertDto user)
    {
        UserModel? userModel = await userRepository.GetUserAsync(email: user.Email);

        if (userModel != null)
            throw new BadRequestExceptionCustom("Não foi possível cadastrar o usuário, pois o e-mail informado já consta em nosso sistema.");

        (byte[] hash, byte[] salt) = AuthHelper.CreatePasswordHash(user.Password);

        UserModel model = user.Adapt<UserModel>();

        model.Ative = true;
        model.Deleted = false;
        model.Hash = Convert.ToBase64String(hash);
        model.Salt = Convert.ToBase64String(salt);
        user.Password = string.Empty;

        await _authRepository.InsertUserAsync(model);

        return new()
        {
            Data = user,
            Message = "Usuario cadastrado com sucesso!"
        };
    }

    public async Task<ResponseApp<AuthLoginDto>> LoginUserHandler(string email, string password)
    {
        UserModel user = await userRepository.GetUserAsync(email: email)
            ?? throw new NotFoundExceptionCustom("Nenhum usuário encontrado.");

        if (user.Blocked && user.BlockedUntil >= DateTime.UtcNow)
        {
            throw new BadRequestExceptionCustom("Usuário bloqueado, aguarde e tente novamente.");
        }
        else if (user.BlockedUntil < DateTime.UtcNow)
        {
            user.Blocked = false;
            user.BlockedUntil = null;
            user.AttemptsPassword = 0;

            await _userRepository.UpdateUserAsync(user.Id, user);
        }

        byte[] hash = Convert.FromBase64String(user.Hash);
        byte[] salt = Convert.FromBase64String(user.Salt);

        bool response = AuthHelper.VerifyPasswordHash(password, hash, salt);

        if (!response)
        {
            user.AttemptsPassword += 1;

            if (user.AttemptsPassword == 5)
            {
                user.Blocked = true;
                user.BlockedUntil = DateTime.UtcNow.AddMinutes(5);
            }

            await _userRepository.UpdateUserAsync(user.Id, user);
            throw new BadRequestExceptionCustom("Senha inválida, verifique e tente novamente.");
        }

        var secretKey = configuration.GetSection("JWT:secret-key").Value;
        var issuer = configuration.GetSection("JWT:issuer").Value;
        var audience = configuration.GetSection("JWT:audience").Value;

        string tokenJwt = AuthHelper.CreateTokenJwt(user, secretKey, issuer, audience);

        if (user.AttemptsPassword > 0)
        {
            user.AttemptsPassword = 0;
        }
        user.LastAccess = DateTime.UtcNow;

        await _userRepository.UpdateUserAsync(user.Id, user);

        return new()
        {
            Data = new()
            {
                Token = tokenJwt,
            },
        };
    }

    public async Task RecoverPasswordHandler(string email)
    {
        UserModel user = await _userRepository.GetUserAsync(email: email) 
            ?? throw new NotFoundExceptionCustom("Usuário não encontrado.");

        string randomPassword = AuthHelper.GenerateRandomPassword(10);

        (byte[] hash, byte[] salt) = AuthHelper.CreatePasswordHash(randomPassword);

        user.Hash = Convert.ToBase64String(hash);
        user.Salt = Convert.ToBase64String(salt);

        try
        {
            await _userRepository.UpdateUserAsync(user.Id, user);
        }
        catch (Exception)
        {
            throw new Exception("Não foi possível redefinir a senha.");
        }

        EmailModel emailModel = EmailHelper.GetCredentials(configuration);

        emailModel.RecipientName = user.Name;
        emailModel.EmailRecipient = user.Email;
        emailModel.Subject = "Recuperação de senha";
        emailModel.Body = $@"
            <p>Senha restaurada com sucesso!</p>
            <p>Sua nova senha temporaria é {randomPassword}</p>
        ";

        await EmailHelper.SendEmail(emailModel);
    }
}
