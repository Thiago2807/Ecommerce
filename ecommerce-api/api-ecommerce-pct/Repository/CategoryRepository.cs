using api_ecommerce_pct.Data;
using api_ecommerce_pct.Interfaces.Repository;
using ecommerce_core.Helpers;
using ecommerce_core.Models;
using ecommerce_core.Models.ProductsCategories;
using Microsoft.Extensions.Primitives;
using MongoDB.Driver;

namespace api_ecommerce_pct.Repository;

public class CategoryRepository(AppDbContext _context) : ICategoryRepository
{
    private readonly IMongoCollection<CategoryModel> collectionCategory = _context.GetCategoryModel();

    public async Task AddCategoryAsync(CategoryModel input) 
        => await collectionCategory.InsertOneAsync(input);

    public async Task UpdateCategoryAsync(CategoryModel input) 
        => await collectionCategory.ReplaceOneAsync(x => x.Id == input.Id, input);

    public async Task<PaginationInputModel> GetCategoriesAsync(IQueryCollection query, int page, int pageSize, string userId)
    {
        Dictionary<string, StringValues> dict = new(query) { ["userid"] = userId };

        QueryCollection enrichedQuery = new(dict);

        var skip = (page - 1) * pageSize;

        var filter = PaginationHelps.Pagination<CategoryModel>(collectionCategory, enrichedQuery);

        var countItems = await collectionCategory.CountDocumentsAsync(filter);

        var documents = await collectionCategory.Find(filter)
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

    public async Task<CategoryModel> GetCategoryAsync(string id)
    {
        FilterDefinition<CategoryModel> filter;

        filter = Builders<CategoryModel>.Filter.Eq(x => x.Id, id);

        var response = await collectionCategory.FindSync<CategoryModel>(filter).FirstOrDefaultAsync()
            ?? throw new NotFoundExceptionCustom("Categoria não encontrado.");

        return response;
    }
}
