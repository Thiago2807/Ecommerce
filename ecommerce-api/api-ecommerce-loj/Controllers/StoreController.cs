using api_ecommerce_loj.Interfaces;
using ecommerce_core.Dtos.loj;
using Microsoft.AspNetCore.Mvc;

namespace api_ecommerce_loj.Controllers;

[ApiController]
[Route("api/v1")]
public class StoreController (IStoreHandler storeHandler)
    : ControllerBase
{
    private readonly IStoreHandler _storeHandler = storeHandler;

    [HttpPost("add")]
    public async Task<IActionResult> AddStoreAsync([FromBody] StoreRegisterDTO input)
    {
        string userId = Request.Headers.First(x => x.Key == "X-User-Id").Value!;

        await _storeHandler.RegisterStoreHandler(input, userId);

        return Ok();
    }
}