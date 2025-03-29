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

    public async Task<T> AddStoreContactAsync<T>(StoreContactModel? input, List<StoreContactModel> inputList)
    {
        if (input != null)
        {
            await collectionStoreContact.InsertOneAsync(input);
        }
        else
        {
            await collectionStoreContact.InsertManyAsync(inputList!);
        }
        
        return (T)(input == null ? input as object : inputList);
    }

    public async Task<StoreContactModel?> GetStoreContactAsync(string id)
    {
        FilterDefinition<StoreContactModel> filter;

        filter = Builders<StoreContactModel>.Filter.Eq(x => x.Id, id);

        var response = await collectionStoreContact.FindSync<StoreContactModel>(filter).FirstOrDefaultAsync();

        return response;
    }

    public async Task<List<StoreContactModel>?> GetStoreContactByStoreAsync(string storeId)
    {
        var filter = Builders<StoreContactModel>.Filter.Eq(x => x.StoreId, storeId);

        var response = await collectionStoreContact.FindSync(filter).ToListAsync();

        return response;
    }

    public async Task UpdateStoreContactAsync(string id, StoreContactModel user)
    => await collectionStoreContact.ReplaceOneAsync(x => x.Id == id, user);

    public async Task RemoveStoreContactAsync(string id)
        => await collectionStoreContact.DeleteOneAsync(x => x.Id == id);

    public async Task<PaginationInputModel> GetStoreContactAsync(IQueryCollection query, int page, int pageSize)
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
