using ecommerce_core.Dtos.pct;
using ecommerce_core.Models;

namespace api_ecommerce_pct.Interfaces.Handler;

public interface IProductHandler
{
    Task<ResponseApp<object>> AddProductAsync(ProductDTO product);
    Task<ResponseApp<object>> UpdateProductAsync(ProductDTO product);
    Task<ResponseApp<ProductDTO>> GetProductById(string productId);
    Task<ResponseApp<PaginationInputModel>> GetProducts(PaginationModel pagination, IQueryCollection query);
}
