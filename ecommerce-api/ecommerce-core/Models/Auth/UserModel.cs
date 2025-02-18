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

    [BsonElement("useMfa")]
    public bool UserMfa { get; set; } = false;

    [BsonElement("attemptsPassword")]
    public int AttemptsPassword { get; set; } = 0;

    [BsonElement("blocked")]
    public bool Blocked { get; set; } = false;

    [BsonElement("blockedUntil")]
    public DateTime? BlockedUntil { get; set; } = null;

    [BsonElement("lastAccess")]
    public DateTime LastAccess { get; set; } = DateTime.UtcNow;

    [JsonConverter(typeof(MongoConverterHelper))]
    [BsonElement("attributes")]
    public BsonDocument? Attributes { get; set; }
}
