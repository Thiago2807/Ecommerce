namespace api_ecommerce_auth.Interfaces;

public interface IAuthHandler
{
    Task<ResponseApp<AuthLoginDto>> LoginUserHandler(string email, string password);
    Task<ResponseApp<AuthInsertDto>> InsertUserHandler(AuthInsertDto user);
    Task RecoverPasswordHandler(string email);
}
