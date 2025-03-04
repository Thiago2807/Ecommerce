using ecommerce_core.Models.Store;
using MongoDB.Driver;

namespace api_ecommerce_loj.Data;

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

    public IMongoCollection<StoreModel> GetStoresCollection()
        => _database.GetCollection<StoreModel>("loj-stores");

    public IMongoCollection<StoreAddressModel> GetStoresAddressCollection()
        => _database.GetCollection<StoreAddressModel>("loj-stores-address");

    public IMongoCollection<StoreContactModel> GeStoresContactCollection()
        => _database.GetCollection<StoreContactModel>("loj-stores-contact");
}
