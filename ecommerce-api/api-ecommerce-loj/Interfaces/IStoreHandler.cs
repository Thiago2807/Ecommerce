using ecommerce_core.Dtos.loj;
using ecommerce_core.Models;

namespace api_ecommerce_loj.Interfaces;

public interface IStoreHandler
{
    Task<ResponseApp<object>> RegisterStoreHandler(StoreRegisterDTO input, string userId);
    Task<ResponseApp<object>> UpdateStoreHandler(StoreUpdateDTO input);
    Task<ResponseApp<object>> AddContactStoreHandler(List<StoreAddUpdateContactDTO> input);
    Task<ResponseApp<object>> UpdateContactStoreHandler(StoreAddUpdateContactDTO input);
    Task<ResponseApp<object>> UpdateAddressStoreHandler(StoreUpdateAddressDTO input);
}
