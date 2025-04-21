using ecommerce_core.Models.Bases;

namespace ecommerce_core.Models.ProductsCategories;

public class CategoryModel : BaseModel
{
    [BsonElement("name")]
    public string Name { get; set; } = string.Empty;

    [BsonElement("description")]
    public string Description { get; set; } = string.Empty;
}
