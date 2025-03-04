namespace ecommerce_core.Models.Bases;

public class BaseContactModel : BaseModel
{
    [BsonElement("type")]
    public string Type { get; set; } = string.Empty;

    [BsonElement("contact")]
    public string Contact { get; set; } = string.Empty;
}
