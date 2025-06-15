using api_ecommerce_loj.Interfaces;
using ecommerce_core.Dtos.loj;
using Microsoft.AspNetCore.Mvc;

namespace api_ecommerce_loj.Controllers;

[ApiController]
[Route("api/v1")]
public class StoreController(IStoreHandler storeHandler)
    : ControllerBase
{
    [HttpPost("add")]
    public async Task<IActionResult> AddStoreAsync([FromBody] StoreRegisterDTO input)
    {
        string userId = Request.Headers.First(x => x.Key == "X-User-Id").Value!;

        var response = await storeHandler.RegisterStoreHandler(input, userId);

        return Ok(response);
    }

    [HttpPost("update-store")]
    public async Task<IActionResult> UpdateStoreAsync([FromBody] StoreUpdateDTO input)
    {
        var response = await storeHandler.UpdateStoreHandler(input);

        return Ok(response);
    }

    [HttpPost("update-contact")]
    public async Task<IActionResult> UpdateContactStoreAsync([FromBody] StoreAddUpdateContactDTO input)
    {
        var response = await storeHandler.UpdateContactStoreHandler(input);

        return Ok(response);
    }

    [HttpPost("add-contacts")]
    public async Task<IActionResult> AddStoreContactAsync([FromBody] List<StoreAddUpdateContactDTO> input)
    {
        var response = await storeHandler.AddContactStoreHandler(input);

        return Ok(response);
    }

    [HttpPost("update-address")]
    public async Task<IActionResult> UpdateStoreAddressAsync([FromBody] StoreUpdateAddressDTO input)
    {
        var response = await storeHandler.UpdateAddressStoreHandler(input);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStoreAsync([FromRoute] string id)
    {
        var response = await storeHandler.GetStoreHandler(id);

        return Ok(response);
    }
    
    [HttpGet()]
    public async Task<IActionResult> GetStoreByUserAsync()
    {
        string userId = Request.Headers.First(x => x.Key == "X-User-Id").Value!;

        var response = await storeHandler.GetStoreByUserHandler(userId);

        return Ok(response);
    }
}