namespace api_ecommerce_auth.Controllers;

[ApiController]
[Route("api/v1")]
public class AuthController(IUserHandler userHandler) : ControllerBase
{
    private readonly IUserHandler _userHandler = userHandler;

    [HttpPost("register")]
    public async Task<IActionResult> InsertAsync([FromBody] AuthInsertDto user)
    {
        ResponseApp<AuthInsertDto> response = await _userHandler.InsertUserHandler(user);

        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] AuthLoginInputDto input)
    {
        ResponseApp<AuthLoginDto> response = await _userHandler.LoginUserHandler(input.Email, input.Password);

        return Ok(response);
    }
}
