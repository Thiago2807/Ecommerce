namespace api_ecommerce_auth.Interfaces;

public interface IAuthRepository
{
    Task InsertUserAsync(UserModel user);
}
