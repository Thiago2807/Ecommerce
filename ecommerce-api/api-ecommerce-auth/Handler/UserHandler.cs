namespace api_ecommerce_auth.Handler;

public class UserHandler(IAuthRepository authRepository, IConfiguration configuration) 
    : IUserHandler
{
    private readonly IAuthRepository _authRepository = authRepository;
    private readonly IConfiguration _configuration = configuration;

    public async Task<ResponseApp<UserModel>> GetUserHandler(string id)
    {
        UserModel? user = await _authRepository.GetUserAsync(id: id) 
            ?? throw new NotFoundExceptionCustom("Nenhum usuário encontrado.");

        return new() 
        { 
            Data = user,
        };
    }

    public async Task<ResponseApp<AuthInsertDto>> InsertUserHandler(AuthInsertDto user)
    {
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
        UserModel user = await _authRepository.GetUserAsync(email: email) 
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

    public async Task UpdateUserHandler(string id, UserModel user)
    {
        await _authRepository.UpdateUserAsync(id, user);
    }
}
