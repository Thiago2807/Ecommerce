namespace ecommerce_core.Models.Bases;

public class BaseModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    [BsonElement("createdIn")]
    public DateTime CreatedIn { get; set; } = DateTime.UtcNow;

    [BsonElement("updatedIn")]
    public DateTime UpdatedIn { get; set; } = DateTime.UtcNow;

    [BsonElement("ative")]
    public bool Ative { get; set; }

    [BsonElement("deleted")]
    public bool Deleted { get; set; }
}
