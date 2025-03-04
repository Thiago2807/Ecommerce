using ecommerce_core.Models.Bases;

namespace ecommerce_core.Models.Store;

public class StoreContactModel : BaseContactModel
{
    public string StoreId { get; set; } = string.Empty;
}
