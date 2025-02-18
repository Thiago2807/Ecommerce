namespace api_ecommerce_auth.Interfaces;

public interface IUserRepository
{
    Task<UserModel?> GetUserAsync(string id = "", string email = "");
    Task UpdateUserAsync(string id, UserModel user);
    Task<PaginationInputModel> GetUsersAsync(IQueryCollection query, int page, int pageSize);
}
