namespace api_ecommerce_auth.Handler;

public class UserHandler(IUserRepository userRepository, IConfiguration configuration) 
    : IUserHandler
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IConfiguration _configuration = configuration;

    public async Task<ResponseApp<UserDto>> GetUserHandler(string id)
    {
        UserModel? user = await _userRepository.GetUserAsync(id: id) 
            ?? throw new NotFoundExceptionCustom("Nenhum usuário encontrado.");

        UserDto response = user.Adapt<UserDto>();

        return new() 
        { 
            Data = response,
        };
    }

    public async Task UpdateUserHandler(string id, UserModel user)
    {
        await userRepository.UpdateUserAsync(id, user);
    }

    public async Task<PaginationInputModel> GetUsersHandler(PaginationModel pagination, IQueryCollection query)
    {
        var responsePagination = await userRepository.GetUsersAsync(query, pagination.Page, pagination.PageSize);

        return responsePagination;
    }
}
