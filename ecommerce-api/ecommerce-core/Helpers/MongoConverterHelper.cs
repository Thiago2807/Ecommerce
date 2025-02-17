namespace ecommerce_core.Helpers;

public class MongoConverterHelper : JsonConverter<BsonDocument>
{
    public override BsonDocument? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var document = JsonDocument.ParseValue(ref reader);
        var json = document.RootElement.GetRawText();
        return BsonDocument.Parse(json);
    }

    public override void Write(Utf8JsonWriter writer, BsonDocument value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(value.ToJson());
    }
}
