using ecommerce_core.Models;
using ecommerce_core.Models.Store;

namespace api_ecommerce_loj.Interfaces;

public interface IStoreContactRepository
{
    Task<StoreContactModel?> GetStoreContactAsync(string id);
    Task UpdateStoreContactAsync(string id, StoreContactModel user);
    Task RemoveStoreContactAsync(string id);
    Task<PaginationInputModel> GetStoreContactAsync(IQueryCollection query, int page, int pageSize);
    Task<T> AddStoreContactAsync<T>(StoreContactModel? input, List<StoreContactModel> inputList);
}
