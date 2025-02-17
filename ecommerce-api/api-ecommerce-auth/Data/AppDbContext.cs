namespace api_ecommerce_auth.Data;

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

    // Retornar a coleção
    public IMongoCollection<UserModel> GetCollectionUser() 
        => _database.GetCollection<UserModel>("users");
}
