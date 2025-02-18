using ecommerce_core.Helpers;

namespace api_ecommerce_auth.Handler;

public class AuthRepository(AppDbContext _context) : IAuthRepository
{
    private readonly IMongoCollection<UserModel> collectionUser = _context.GetCollectionUser();

    public async Task InsertUserAsync(UserModel user)
        => await collectionUser.InsertOneAsync(user);
}
