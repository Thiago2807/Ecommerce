using api_ecommerce_pct.Interfaces.Handler;
using ecommerce_core.Dtos.pct;
using ecommerce_core.Models;
using Microsoft.AspNetCore.Mvc;

namespace api_ecommerce_pct.Controllers;

[ApiController]
[Route("api/v1")]
public class CategoryController(ICategoryHandler categoryHandler) : ControllerBase
{
    [HttpPost("add")]
    public async Task<IActionResult> AddCategory([FromBody] CategoryDTO category)
    {
        string userId = Request.Headers.First(x => x.Key == "X-User-Id").Value!;

        var response = await categoryHandler.AddCategoryAsync(category, userId);

        return Created("", response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById([FromRoute] string id)
    {
        var response = await categoryHandler.GetCategoryById(id);

        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCategory([FromBody] CategoryDTO category)
    {
        var response = await categoryHandler.UpdateCategoryAsync(category);

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories([FromQuery] PaginationModel pagination)
    {
        string userId = Request.Headers.First(x => x.Key == "X-User-Id").Value!;

        var query = Request.Query;

        var response = await categoryHandler.GetCategories(pagination, query, userId);

        return Ok(response);
    }
}
