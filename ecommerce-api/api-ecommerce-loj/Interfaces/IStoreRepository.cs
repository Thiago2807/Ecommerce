using ecommerce_core.Models;
using ecommerce_core.Models.Store;

namespace api_ecommerce_loj.Interfaces;

public interface IStoreRepository
{
    Task<StoreModel?> GetStoreAsync(string id);
    Task UpdateUserAsync(string id, StoreModel user);
    Task<PaginationInputModel> GetUsersAsync(IQueryCollection query, int page, int pageSize);
}
