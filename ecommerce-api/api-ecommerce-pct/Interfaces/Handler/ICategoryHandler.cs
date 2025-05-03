using ecommerce_core.Dtos.pct;
using ecommerce_core.Models;
using ecommerce_core.Models.ProductsCategories;

namespace api_ecommerce_pct.Interfaces.Handler;

public interface ICategoryHandler
{
    Task<ResponseApp<object>> AddCategoryAsync(CategoryDTO category, string userId);
    Task<ResponseApp<object>> UpdateCategoryAsync(CategoryDTO category);
    Task<ResponseApp<CategoryModel>> GetCategoryById(string categoryId);
    Task<ResponseApp<PaginationInputModel>> GetCategories(PaginationModel pagination, IQueryCollection query, string userId);
}
