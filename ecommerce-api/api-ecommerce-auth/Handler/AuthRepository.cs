namespace api_ecommerce_auth.Handler;

public class AuthRepository(AppDbContext _context) : IAuthRepository
{
    private readonly IMongoCollection<UserModel> collectionUser = _context.GetCollectionUser();

    public async Task<UserModel> GetUserAsync(string id)
    {
        var filter = Builders<UserModel>.Filter.Eq(x => x.Id, id);

        var response = await collectionUser.FindSync<UserModel>(filter).FirstOrDefaultAsync();

        return response;
    }

    public async Task InsertUserAsync(UserModel user)
        => await collectionUser.InsertOneAsync(user);

    public async Task UpdateUserAsync(string id, UserModel user)
        => await collectionUser.ReplaceOneAsync(x => x.Id == id, user);
}
