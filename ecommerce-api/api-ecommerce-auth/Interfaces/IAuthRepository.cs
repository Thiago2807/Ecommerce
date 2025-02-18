namespace api_ecommerce_auth.Interfaces;

public interface IAuthRepository
{
    Task<UserModel?> GetUserAsync(string id = "", string email = "");
    Task InsertUserAsync(UserModel user);
    Task UpdateUserAsync(string id, UserModel user);
}
