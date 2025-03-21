using api_ecommerce_loj.Interfaces;
using ecommerce_core.Dtos.loj;
using ecommerce_core.Models.Store;
using Mapster;

namespace api_ecommerce_loj.Handler;

public class StoreHandler (
        IStoreRepository storeRepository, IStoreContactRepository storeContactRepository , IStoreAddressRepository storeAddressRepository
    )
    : IStoreHandler
{
    private readonly IStoreRepository _storeRepository = storeRepository;
    private readonly IStoreContactRepository _storeContactRepository = storeContactRepository;
    private readonly IStoreAddressRepository _storeAddressRepository = storeAddressRepository;

    // Criar loja
    public async Task RegisterStoreHandler(StoreRegisterDTO input, string userId)
    {
        StoreAddressModel addressModel = input.Address.Adapt<StoreAddressModel>();

        addressModel = await _storeAddressRepository.AddStoreAddressAsync(addressModel);

        StoreModel storeModel = new()
        {
            UserId = userId,
            Name = input.Name,
            Document = input.Document,
            AddressId = addressModel.Id ?? throw new BadRequestExceptionCustom("Código do endereço inválido."),
        };

        storeModel = await _storeRepository.AddStoreAsync(storeModel);

        if (input.Contacts != null)
        {
            List<StoreContactModel> contactModel = [];

            foreach (StoreContactRegisterDTO item in input.Contacts)
            {
                contactModel.Add(new()
                {
                    Type = item.Type,
                    Contact = item.Contact,
                    StoreId = storeModel.Id ?? throw new BadRequestExceptionCustom("Código da loja inválido.")
                });
            }

            await _storeContactRepository.AddStoreContactAsync<List<StoreContactModel>>(null, contactModel);
        }
    }

    // Atualizar dados da loja
    public async Task UpdateStoreHandler(StoreRegisterDTO input)
    {
        /// Todo: Implement
    }

    // Atualizar Contato
    public async Task UpdateContactStoreHandler(StoreContactRegisterDTO input)
    {
        /// Todo: Implement
    }

    // Excluir contato
    public async Task RemoveContactStoreHandler(string contactId)
    {
        /// Todo: Implement
    }

    // Atualizar Endereço
    public async Task UpdateAddressStoreHandler(StoreAddressRegisterDTO input)
    {
        /// Todo: Implement
    }
}
