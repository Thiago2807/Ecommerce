namespace api_ecommerce_auth.Controllers;

[ApiController]
[Route("api/v1/user")]
public class UserController(IUserHandler userHandler) : ControllerBase
{
    private readonly IUserHandler _userHandler = userHandler;

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] string id, [FromBody] UserModel user)
    {
        await _userHandler.UpdateUserHandler(id, user);

        return Ok("Usuário atualizado com sucesso!");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute] string id)
    {
        ResponseApp<UserModel> response = await _userHandler.GetUserHandler(id);

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetUsersAsync([FromQuery] PaginationModel pagination)
    {
        var query = Request.Query;

        PaginationInputModel response = await _userHandler.GetUsersHandler(pagination, query);

        return Ok(new ResponseApp<PaginationInputModel>()
        {
            Data = response,
        });
    }
}
