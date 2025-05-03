using ecommerce_core.Models;
using ecommerce_core.Models.ProductsCategories;

namespace api_ecommerce_pct.Interfaces.Repository;

public interface IProductRepository
{
    Task AddProductAsync(ProductModel input);
    Task UpdateProductAsync(ProductModel input);
    Task<PaginationInputModel> GetProductsAsync(IQueryCollection query, int page, int pageSize);

    Task<ProductModel> GetProductAsync(string id);
}
