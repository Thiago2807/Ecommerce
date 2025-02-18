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


        byte[] hash = Convert.FromBase64String(user.Hash);
        byte[] salt = Convert.FromBase64String(user.Salt);

        bool response = AuthHelper.VerifyPasswordHash(password, hash, salt);

        if (!response)
            throw new BadRequestExceptionCustom("Senha inválida, verifique e tente novamente.");

        var secretKey = configuration.GetSection("JWT:secret-key").Value;
        var issuer = configuration.GetSection("JWT:issuer").Value;
        var audience = configuration.GetSection("JWT:audience").Value;

        if (string.IsNullOrEmpty(secretKey) || string.IsNullOrEmpty(issuer) || string.IsNullOrEmpty(audience))
        {
            throw new BadRequestExceptionCustom("Informações para o token JWT inválidos, verifique o arquivo de configurações.");
        }

        string tokenJwt = AuthHelper.CreateTokenJwt(user, secretKey, issuer, audience);

        return new()
        {
            Data = new()
            {
                Token = tokenJwt,
            },
        };
    }
}
