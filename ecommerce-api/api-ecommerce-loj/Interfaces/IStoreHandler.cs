using ecommerce_core.Dtos.loj;

namespace api_ecommerce_loj.Interfaces;

public interface IStoreHandler
{
    Task RegisterStoreHandler(StoreRegisterDTO input, string userId);
}
