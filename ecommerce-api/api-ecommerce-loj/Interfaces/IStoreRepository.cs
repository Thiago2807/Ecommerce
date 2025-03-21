using ecommerce_core.Models;
using ecommerce_core.Models.Store;

namespace api_ecommerce_loj.Interfaces;

public interface IStoreRepository
{
    Task<StoreModel?> GetStoreAsync(string id);
    Task<StoreModel> AddStoreAsync(StoreModel input);
    Task UpdateStoreAsync(string id, StoreModel user);
    Task<PaginationInputModel> GetStoresAsync(IQueryCollection query, int page, int pageSize);
}
