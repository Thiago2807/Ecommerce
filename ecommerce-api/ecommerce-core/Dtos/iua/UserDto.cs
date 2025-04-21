namespace ecommerce_core.Dtos.Auth;

public class UserDto {
    public string Name { get; set; } = string.Empty;
    public string Nickname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime DateBirth { get; set; }
    public bool UserMfa { get; set; } = false;
    public bool Blocked { get; set; } = false;
    public DateTime? BlockedUntil { get; set; } = null;
    public DateTime LastAccess { get; set; } = DateTime.UtcNow;

    [JsonConverter(typeof(MongoConverterHelper))]
    public BsonDocument? Attributes { get; set; }
}