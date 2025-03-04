namespace ecommerce_core.Models.Bases;

public class BaseAddressModel : BaseModel
{
    [BsonElement("postalCode")]
    public string PostalCode { get; set; } = string.Empty;

    [BsonElement("street")]
    public string Street { get; set; } = string.Empty;

    [BsonElement("complement")]
    public string Complement { get; set; } = string.Empty;

    [BsonElement("unit")]
    public string Unit { get; set; } = string.Empty;

    [BsonElement("neighborhood")]
    public string Neighborhood { get; set; } = string.Empty;

    [BsonElement("city")]
    public string City { get; set; } = string.Empty;

    [BsonElement("stateAbbreviation")]
    public string StateAbbreviation { get; set; } = string.Empty;

    [BsonElement("state")]
    public string State { get; set; } = string.Empty;

    [BsonElement("region")]
    public string Region { get; set; } = string.Empty;

    [BsonElement("ibgeCode")]
    public string IbgeCode { get; set; } = string.Empty;

    [BsonElement("giaCode")]
    public string GiaCode { get; set; } = string.Empty;

    [BsonElement("areaCode")]
    public string AreaCode { get; set; } = string.Empty;

    [BsonElement("siafiCode")]
    public string SiafiCode { get; set; } = string.Empty;
}
