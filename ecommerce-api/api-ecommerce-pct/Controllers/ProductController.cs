using api_ecommerce_pct.Handler;
using api_ecommerce_pct.Interfaces.Handler;
using ecommerce_core.Dtos.pct;
using ecommerce_core.Models;
using Microsoft.AspNetCore.Mvc;

namespace api_ecommerce_pct.Controllers;

[ApiController]
[Route("api/v1/product")]
public class ProductController (IProductHandler productHandler)
    : ControllerBase
{
    [HttpPost("add")]
    public async Task<IActionResult> AddProduct([FromBody] ProductDTO product)
    {
        var response = await productHandler.AddProductAsync(product);

        return Created("", response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById([FromRoute] string id)
    {
        var response = await productHandler.GetProductById(id);

        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct([FromBody] ProductDTO product)
    {
        var response = await productHandler.UpdateProductAsync(product);

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetCProducts([FromQuery] PaginationModel pagination)
    {
        var query = Request.Query;

        var response = await productHandler.GetProducts(pagination, query);

        return Ok(response);
    }
}
