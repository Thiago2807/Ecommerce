using api_ecommerce_loj.Data;
using api_ecommerce_loj.Interfaces;
using ecommerce_core.Helpers;
using ecommerce_core.Models;
using ecommerce_core.Models.Store;
using MongoDB.Driver;

namespace api_ecommerce_loj.Repository;

public class StoreRepository (AppDbContext _context)
    : IStoreRepository
{
    private readonly IMongoCollection<StoreModel> collectionStore = _context.GetStoresCollection();

    public async Task<StoreModel?> GetStoreAsync(string id)
    {
        FilterDefinition<StoreModel> filter;

        filter = Builders<StoreModel>.Filter.Eq(x => x.Id, id);

        var response = await collectionStore.FindSync<StoreModel>(filter).FirstOrDefaultAsync();

        return response;
    }

    public async Task UpdateStoreAsync(string id, StoreModel user)
    => await collectionStore.ReplaceOneAsync(x => x.Id == id, user);

    public async Task<PaginationInputModel> GetStoresAsync(IQueryCollection query, int page, int pageSize)
    {
        var skip = (page - 1) * pageSize;

        var filter = PaginationHelps.Pagination<StoreModel>(collectionStore, query);

        var countItems = await collectionStore.CountDocumentsAsync(filter);

        var documents = await collectionStore.Find(filter)
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