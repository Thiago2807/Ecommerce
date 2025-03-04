using api_ecommerce_loj.Interfaces;
using ecommerce_core.Helpers;
using ecommerce_core.Models.Store;
using ecommerce_core.Models;
using MongoDB.Driver;
using api_ecommerce_loj.Data;

namespace api_ecommerce_loj.Repository;

public class StoreContactRepository (AppDbContext _context)
    : IStoreContactRepository
{
    private readonly IMongoCollection<StoreContactModel> collectionStoreContact = _context.GeStoresContactCollection();

    public async Task<StoreContactModel?> GetStoreAsync(string id)
    {
        FilterDefinition<StoreContactModel> filter;

        filter = Builders<StoreContactModel>.Filter.Eq(x => x.Id, id);

        var response = await collectionStoreContact.FindSync<StoreContactModel>(filter).FirstOrDefaultAsync();

        return response;
    }

    public async Task UpdateUserAsync(string id, StoreContactModel user)
    => await collectionStoreContact.ReplaceOneAsync(x => x.Id == id, user);

    public async Task<PaginationInputModel> GetUsersAsync(IQueryCollection query, int page, int pageSize)
    {
        var skip = (page - 1) * pageSize;

        var filter = PaginationHelps.Pagination<StoreContactModel>(collectionStoreContact, query);

        var countItems = await collectionStoreContact.CountDocumentsAsync(filter);

        var documents = await collectionStoreContact.Find(filter)
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
