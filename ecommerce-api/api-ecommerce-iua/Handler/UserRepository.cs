using ecommerce_core.Helpers;

namespace api_ecommerce_auth.Handler;

public class UserRepository(AppDbContext _context) : IUserRepository
{
    private readonly IMongoCollection<UserModel> collectionUser = _context.GetCollectionUser();

    public async Task<UserModel?> GetUserAsync(string id = "", string email = "")
    {
        FilterDefinition<UserModel> filter;

        if (string.IsNullOrEmpty(id))
        {
            filter = Builders<UserModel>.Filter.Eq(x => x.Email, email);
        }
        else
        {
            filter = Builders<UserModel>.Filter.Eq(x => x.Id, id);
        }

        var response = await collectionUser.FindSync<UserModel>(filter).FirstOrDefaultAsync();

        return response;
    }

    public async Task UpdateUserAsync(string id, UserModel user)
    => await collectionUser.ReplaceOneAsync(x => x.Id == id, user);

    public async Task<PaginationInputModel> GetUsersAsync(IQueryCollection query, int page, int pageSize)
    {
        var skip = (page - 1) * pageSize;

        var filter = PaginationHelps.Pagination<UserModel>(collectionUser, query);

        var countItems = await collectionUser.CountDocumentsAsync(filter);

        var documents = await collectionUser.Find(filter)
                                .Skip(skip)
                                .Limit(pageSize)
                                .ToListAsync();

        return new()
        {
            Data = documents,
            Page = page,
            PageSize = pageSize,
            QtdTotal = countItems,
        };
    }
}
