namespace ecommerce_core.Models.ProductsCategories;

public class ProductCategorYModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string ProdutoId { get; set; } = string.Empty;

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string CategoryId { get; set; } = string.Empty;

    [BsonElement("createdIn")]
    public DateTime CreatedIn { get; set; } = DateTime.UtcNow;

    [BsonElement("updatedIn")]
    public DateTime UpdatedIn { get; set; } = DateTime.UtcNow;

    [BsonElement("ative")]
    public bool Ative { get; set; }
}
