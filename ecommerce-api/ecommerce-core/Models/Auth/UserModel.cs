namespace ecommerce_core.Models.Auth;

public sealed class UserModel : BaseModel
{
    [BsonElement("name")]
    public string Name { get; set; } = string.Empty;

    [BsonElement("nickname")]
    public string Nickname { get; set; } = string.Empty;

    [BsonElement("email")]
    public string Email { get; set; } = string.Empty;

    [BsonElement("dateBirth")]
    public DateTime DateBirth { get; set; }

    [BsonElement("hash")]
    public string Hash { get; set; } = string.Empty;

    [BsonElement("salt")]
    public string Salt { get; set; } = string.Empty;

    [BsonElement("mfaCode")]
    public string MfaCode { get; set; } = string.Empty;

    [JsonConverter(typeof(MongoConverterHelper))]
    [BsonElement("attributes")]
    public BsonDocument? Attributes { get; set; }
}
