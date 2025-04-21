using ecommerce_core.Models.Bases;

namespace ecommerce_core.Models.ProductsCategories;

public class ProductModel : BaseModel
{
    [BsonElement("name")]
    public string Name { get; set; } = string.Empty;

    [BsonElement("description")]
    public string Description { get; set; } = string.Empty;

    [BsonElement("price")]
    public decimal Price { get; set; }

    [BsonElement("sku")]
    public string Sku { get; set; } = string.Empty;
}
