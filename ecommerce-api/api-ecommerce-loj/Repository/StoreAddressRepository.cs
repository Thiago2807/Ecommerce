using api_ecommerce_loj.Interfaces;
using ecommerce_core.Helpers;
using ecommerce_core.Models.Store;
using ecommerce_core.Models;
using MongoDB.Driver;
using api_ecommerce_loj.Data;

namespace api_ecommerce_loj.Repository;

public class StoreAddressRepository (AppDbContext _context)
    : IStoreAddressRepository
{
    private readonly IMongoCollection<StoreAddressModel> collectionStoreAdress = _context.GetStoresAddressCollection();

    public async Task<StoreAddressModel> AddStoreAddressAsync(StoreAddressModel input)
    {
        await collectionStoreAdress.InsertOneAsync(input);

        return input;
    }

    public async Task<StoreAddressModel?> GetStoreAddressAsync(string id)
    {
        FilterDefinition<StoreAddressModel> filter;

        filter = Builders<StoreAddressModel>.Filter.Eq(x => x.Id, id);

        var response = await collectionStoreAdress.FindSync<StoreAddressModel>(filter).FirstOrDefaultAsync();

        return response;
    }

    public async Task UpdateStoreAddressAsync(string id, StoreAddressModel user)
        => await collectionStoreAdress.ReplaceOneAsync(x => x.Id == id, user);

    public async Task<PaginationInputModel> GetStoreAddressAsync(IQueryCollection query, int page, int pageSize)
    {
        var skip = (page - 1) * pageSize;

        var filter = PaginationHelps.Pagination<StoreAddressModel>(collectionStoreAdress, query);

        var countItems = await collectionStoreAdress.CountDocumentsAsync(filter);

        var documents = await collectionStoreAdress.Find(filter)
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
