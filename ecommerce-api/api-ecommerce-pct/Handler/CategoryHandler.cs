using api_ecommerce_pct.Interfaces.Handler;
using api_ecommerce_pct.Interfaces.Repository;
using ecommerce_core.Dtos.pct;
using ecommerce_core.Models;
using ecommerce_core.Models.ProductsCategories;
using Mapster;

namespace api_ecommerce_pct.Handler;

public class CategoryHandler (ICategoryRepository categoryRepository)
    : ICategoryHandler
{
    public async Task<ResponseApp<object>> AddCategoryAsync(CategoryDTO category, string userId)
    {
        CategoryModel categoryModel = category.Adapt<CategoryModel>();
        categoryModel.UserId = userId;

        await categoryRepository.AddCategoryAsync(categoryModel);

        return new()
        {
            Message = "Categoria criada com sucesso!",
        };
    }
    
    public async Task<ResponseApp<object>> UpdateCategoryAsync(CategoryDTO category)
    {
        if (string.IsNullOrEmpty(category.Id))
            throw new BadHttpRequestException("O id da categoria não pode ser nulo ou vazio.");

        CategoryModel categoryModel = await categoryRepository.GetCategoryAsync(category.Id);

        CategoryModel updateCategory = category.Adapt<CategoryModel>();

        categoryModel.Name = updateCategory.Name;
        categoryModel.UpdatedIn = DateTime.UtcNow;
        categoryModel.Description = updateCategory.Description;

        await categoryRepository.UpdateCategoryAsync(categoryModel);

        return new()
        {
            Message = "Categoria atualizada com sucesso!"
        };
    }

    public async Task<ResponseApp<CategoryModel>> GetCategoryById(string categoryId)
    {
        CategoryModel category = await categoryRepository.GetCategoryAsync(categoryId);

        return new()
        {
            Data = category
        };
    }

    public async Task<ResponseApp<PaginationInputModel>> GetCategories(PaginationModel pagination, IQueryCollection query, string userId)
    {
        var responsePagination = await categoryRepository.GetCategoriesAsync(query, pagination.Page, pagination.PageSize, userId);

        return new()
        {
            Data = responsePagination
        };
    }
}
