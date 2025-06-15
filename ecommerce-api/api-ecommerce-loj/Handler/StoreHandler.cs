using api_ecommerce_loj.Interfaces;
using ecommerce_core.Dtos.loj;
using ecommerce_core.Models;
using ecommerce_core.Models.Store;
using Mapster;
using MongoDB.Bson;

namespace api_ecommerce_loj.Handler;

public class StoreHandler(
        IStoreRepository storeRepository, IStoreContactRepository storeContactRepository, IStoreAddressRepository storeAddressRepository
    )
    : IStoreHandler
{
    private readonly IStoreRepository _storeRepository = storeRepository;
    private readonly IStoreContactRepository _storeContactRepository = storeContactRepository;
    private readonly IStoreAddressRepository _storeAddressRepository = storeAddressRepository;

    public async Task<ResponseApp<object>> RegisterStoreHandler(StoreRegisterDTO input, string userId)
    {
        input.Document = input.Document.ExtractDigits();

        bool resultCheckStore = await _storeRepository.CheckStoreAsync(input.Document);

        if (resultCheckStore)
            throw new BadRequestExceptionCustom("Não é possível cadastrar esta loja, pois já existe um registro com esse documento.");

        StoreAddressModel addressModel = input.Address.Adapt<StoreAddressModel>();
        addressModel.PostalCode = addressModel.PostalCode.ExtractDigits();

        addressModel = await _storeAddressRepository.AddStoreAddressAsync(addressModel);

        StoreModel storeModel = new()
        {
            UserId = userId,
            Name = input.Name,
            Document = input.Document,
            AddressId = addressModel.Id ?? throw new BadRequestExceptionCustom("Código do endereço inválido."),
        };

        storeModel = await _storeRepository.AddStoreAsync(storeModel);

        if (input.Contacts != null && input.Contacts.Count != 0)
        {
            List<StoreContactModel> contactModel = [];

            foreach (StoreContactRegisterDTO item in input.Contacts)
            {
                contactModel.Add(new()
                {
                    Type = item.Type,
                    Contact = item.Type == "phone" ? item.Contact.ExtractDigits() : item.Contact,
                    StoreId = storeModel.Id ?? throw new BadRequestExceptionCustom("Código da loja inválido.")
                });
            }

            await _storeContactRepository.AddStoreContactAsync<List<StoreContactModel>>(null, contactModel);
        }

        return new()
        {
            Message = "Loja cadastrada com sucesso!",
            Data = new
            {
                id = storeModel.Id,
                name = storeModel.Name,
            }
        };
    }

    public async Task<ResponseApp<object>> UpdateStoreHandler(StoreUpdateDTO input)
    {
        input.Document = input.Document.ExtractDigits();

        StoreModel responseStore = await _storeRepository.GetStoreAsync(input.Id)
            ?? throw new BadRequestExceptionCustom("Não foi possível localizar a loja especificada.");

        StoreModel store = input.Adapt<StoreModel>();

        store.AddressId = responseStore.AddressId;
        store.UserId = responseStore.UserId;
        store.Attributes = responseStore.Attributes;
        store.CreatedIn = responseStore.CreatedIn;

        await _storeRepository.UpdateStoreAsync(input.Id, store);

        return new()
        {
            Message = "Loja Atualizada com sucesso!"
        };
    }

    public async Task<ResponseApp<object>> AddContactStoreHandler(List<StoreAddUpdateContactDTO> input)
    {
        List<StoreContactModel> storeContact = input.Adapt<List<StoreContactModel>>();

        var response = await _storeContactRepository.AddStoreContactAsync
            <List<StoreContactModel>>(input: null, inputList: storeContact);

        return new()
        {
            Message = $"{(input.Count <= 1 ? "Contato adicionado" : "Contatos Adicionados")} com sucesso!",
            Data = new
            {
                idStore = input.FirstOrDefault()?.StoreId ?? ""
            }
        };
    }

    public async Task<ResponseApp<object>> UpdateContactStoreHandler(StoreAddUpdateContactDTO input)
    {
        StoreContactModel contact = await _storeContactRepository.GetStoreContactAsync(input.Id!)
            ?? throw new NotFoundExceptionCustom("Contato não encontrado.");

        StoreContactModel storeContact = input.Adapt<StoreContactModel>();
        storeContact.CreatedIn = contact.CreatedIn;

        await _storeContactRepository.UpdateStoreContactAsync(storeContact.Id!, storeContact);

        return new()
        {
            Message = "Contato atualizado com sucesso!"
        };
    }

    public async Task<ResponseApp<object>> UpdateAddressStoreHandler(StoreUpdateAddressDTO input)
    {
        StoreAddressModel address = await _storeAddressRepository.GetStoreAddressAsync(input.Id!)
            ?? throw new NotFoundExceptionCustom("Endereço não encontrado.");

        StoreAddressModel storeAddress = input.Adapt<StoreAddressModel>();
        storeAddress.CreatedIn = address.CreatedIn;

        await _storeAddressRepository.UpdateStoreAddressAsync(storeAddress.Id!, storeAddress);

        return new()
        {
            Message = "Endereço atualizado com sucesso!"
        };
    }

    public async Task<ResponseApp<StoreDTO>> GetStoreHandler(string storeId)
    {
        StoreModel store = await _storeRepository.GetStoreAsync(storeId)
            ?? throw new NotFoundExceptionCustom("Loja não encontrado.");

        StoreAddressModel address = await _storeAddressRepository.GetStoreAddressAsync(store.AddressId)
            ?? throw new NotFoundExceptionCustom("Endereço não encontrado.");

        List<StoreContactModel> contact = await _storeContactRepository.GetStoreContactByStoreAsync(store.Id)
            ?? throw new NotFoundExceptionCustom("Contato não encontrado.");

        StoreDTO storeResponse = store.Adapt<StoreDTO>();
        List<StoreContactModel> storeContactResponse = contact.Adapt<List<StoreContactModel>>();

        storeResponse.Address = address;
        storeResponse.Contacts = storeContactResponse;

        return new()
        {
            Data = storeResponse
        };
    }

    public async Task<ResponseApp<StoreByUserModel>> GetStoreByUserHandler(string userId)
    {
        StoreModel store = await _storeRepository.GetStoreByUserAsync(userId)
            ?? throw new NotFoundExceptionCustom("Nenhuma empresa encontrada");

        StoreByUserModel storeResponse = store.Adapt<StoreByUserModel>();

        return new()
        {
            Data = storeResponse
        };
    }
}
