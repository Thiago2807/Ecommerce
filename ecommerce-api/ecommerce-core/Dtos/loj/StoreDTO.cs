using ecommerce_core.Models.Store;

namespace ecommerce_core.Dtos.loj;

public sealed class StoreDTO : StoreModel
{
    public StoreAddressModel? Address { get; set; }
    public List<StoreContactModel>? Contacts { get; set; }
}
