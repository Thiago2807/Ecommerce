using ecommerce_core.Models;
using ecommerce_core.Models.Store;

namespace api_ecommerce_loj.Interfaces;

public interface IStoreAddressRepository
{
    Task<StoreAddressModel?> GetStoreAddressAsync(string id);
    Task UpdateStoreAddressAsync(string id, StoreAddressModel user);
    Task<PaginationInputModel> GetStoreAddressAsync(IQueryCollection query, int page, int pageSize);
    Task<StoreAddressModel> AddStoreAddressAsync(StoreAddressModel input);
}
