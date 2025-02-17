namespace api_ecommerce_auth.Handler;

public class UserHandler(IAuthRepository authRepository) : IUserHandler
{
    private readonly IAuthRepository _authRepository = authRepository;

    public async Task<ResponseApp<UserModel>> GetUserHandler(string id)
    {
        UserModel user = await _authRepository.GetUserAsync(id);

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
        model.Hash = Encoding.UTF8.GetString(hash);
        model.Salt = Encoding.UTF8.GetString(salt);
        user.Password = string.Empty;

        await _authRepository.InsertUserAsync(model);

        return new()
        {
            Data = user,
            Message = "Usuario cadastrado com sucesso!"
        };
    }

    public async Task UpdateUserHandler(string id, UserModel user)
    {
        await _authRepository.UpdateUserAsync(id, user);
    }
}
