using ecommerce_core.Models;
using ecommerce_core.Models.ProductsCategories;

namespace api_ecommerce_pct.Interfaces.Repository;

public interface ICategoryRepository
{
    Task AddCategoryAsync(CategoryModel input);
    Task UpdateCategoryAsync(CategoryModel input);
    Task<CategoryModel> GetCategoryAsync(string id);
    Task<PaginationInputModel> GetCategoriesAsync(IQueryCollection query, int page, int pageSize);
}