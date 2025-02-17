namespace api_ecommerce_auth.Interfaces;

public interface IUserHandler
{
    Task<ResponseApp<UserModel>> GetUserHandler(string id);
    Task<ResponseApp<AuthInsertDto>> InsertUserHandler(AuthInsertDto user);
    Task UpdateUserHandler(string id, UserModel user);
}
