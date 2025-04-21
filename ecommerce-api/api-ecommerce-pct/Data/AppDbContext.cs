using ecommerce_core.Models.ProductsCategories;
using MongoDB.Driver;

namespace api_ecommerce_pct.Data;

public class AppDbContext
{
    private readonly MongoClient _client;
    private readonly IMongoDatabase _database;

    public AppDbContext(IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("MongoDb")
            ?? throw new Exception("Não foi possível obter a string de conexão.");

        _client = new MongoClient(connectionString);
        _database = _client.GetDatabase("ecommerce_db");
    }

    public IMongoCollection<CategoryModel> GetCategoryModel()
        => _database.GetCollection<CategoryModel>("pct-categories");

    public IMongoCollection<ProductCategoryModel> GetProductCategoryModel()
    => _database.GetCollection<ProductCategoryModel>("pct-products-categories");

    public IMongoCollection<ProductModel> GetProductModel()
    => _database.GetCollection<ProductModel>("pct-products");
}
