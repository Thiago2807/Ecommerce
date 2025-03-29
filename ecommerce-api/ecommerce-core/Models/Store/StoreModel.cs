using ecommerce_core.Models.Bases;

namespace ecommerce_core.Models.Store;

public class StoreModel : BaseModel
{
    [BsonElement("name")]
    public string Name { get; set; } = string.Empty;

    [BsonElement("document")]
    public string Document { get; set; } = string.Empty;

    [BsonElement("addressId")]
    public string AddressId { get; set; } = string.Empty;

    [BsonElement("userId")]
    public string UserId { get; set; } = string.Empty;

    [BsonElement("attributes")]
    public BsonDocument? Attributes { get; set; }
}
