namespace api_ecommerce_auth.Interfaces;

public interface IUserHandler
{
    Task<ResponseApp<UserDto>> GetUserHandler(string id);
    Task UpdateUserHandler(string id, UserModel user);
    Task<PaginationInputModel> GetUsersHandler(PaginationModel pagination, IQueryCollection query);
}
