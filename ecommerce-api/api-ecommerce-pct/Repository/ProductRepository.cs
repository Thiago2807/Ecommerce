using api_ecommerce_pct.Data;
using ecommerce_core.Helpers;
using ecommerce_core.Models.ProductsCategories;
using ecommerce_core.Models;
using Microsoft.Extensions.Primitives;
using MongoDB.Driver;
using api_ecommerce_pct.Interfaces.Repository;

namespace api_ecommerce_pct.Repository;

public class ProductRepository(AppDbContext _context) : IProductRepository
{
    private readonly IMongoCollection<ProductModel> collectionProduct = _context.GetProductModel();

    public async Task AddProductAsync(ProductModel input)
        => await collectionProduct.InsertOneAsync(input);

    public async Task UpdateProductAsync(ProductModel input)
        => await collectionProduct.ReplaceOneAsync(x => x.Id == input.Id, input);

    public async Task<PaginationInputModel> GetProductsAsync(IQueryCollection query, int page, int pageSize, string userId)
    {
        Dictionary<string, StringValues> dict = new(query) { ["userid"] = userId };

        QueryCollection enrichedQuery = new(dict);

        var skip = (page - 1) * pageSize;

        var filter = PaginationHelps.Pagination<ProductModel>(collectionProduct, enrichedQuery);

        var countItems = await collectionProduct.CountDocumentsAsync(filter);

        var documents = await collectionProduct.Find(filter)
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

    public async Task<ProductModel> GetProductAsync(string id)
    {
        FilterDefinition<ProductModel> filter;

        filter = Builders<ProductModel>.Filter.Eq(x => x.Id, id);

        var response = await collectionProduct.FindSync<ProductModel>(filter).FirstOrDefaultAsync()
            ?? throw new NotFoundExceptionCustom("Produto não encontrado.");

        return response;
    }
}
