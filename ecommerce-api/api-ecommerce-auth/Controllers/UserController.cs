namespace api_ecommerce_auth.Controllers;

[ApiController]
[Route("api/v1")]
public class UserController(IUserHandler userHandler) : ControllerBase
{
    private readonly IUserHandler _userHandler = userHandler;

    [HttpPost("register")]
    public async Task<IActionResult> InsertAsync([FromBody] AuthInsertDto user)
    {
        try
        {
            ResponseApp<AuthInsertDto> response = await _userHandler.InsertUserHandler(user);

            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new ResponseApp<object>()
            {
                Error = true,
                Message = ex.Message
            });
        }
    }

    [HttpGet("user/{id}")]
    public async Task<IActionResult> GetAsync([FromRoute] string id)
    {
        try
        {
            ResponseApp<UserModel> response = await _userHandler.GetUserHandler(id);

            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new ResponseApp<object>()
            {
                Error = true,
                Message = ex.Message
            });
        }
    }

    [HttpPut("user/{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] string id, [FromBody] UserModel user)
    {
        try
        {
            await _userHandler.UpdateUserHandler(id, user);

            return Ok("Usuário atualizado com sucesso!");
        }
        catch (Exception ex)
        {
            return BadRequest(new ResponseApp<object>()
            {
                Error = true,
                Message = ex.Message
            });
        }
    }
}
