namespace api_ecommerce_auth.Controllers;

[ApiController]
[Route("api/v1")]
public class AuthController(IUserHandler userHandler, IAuthHandler authHandler) : ControllerBase
{
    private readonly IUserHandler _userHandler = userHandler;

    [HttpPost("register")]
    public async Task<IActionResult> InsertAsync([FromBody] AuthInsertDto user)
    {
        ResponseApp<AuthInsertDto> response = await authHandler.InsertUserHandler(user);

        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] AuthLoginInputDto input)
    {
        ResponseApp<AuthLoginDto> response = await authHandler.LoginUserHandler(input.Email, input.Password);

        return Ok(response);
    }

    [HttpPost("recover-password")]
    public async Task<IActionResult> RecoverPasswordAsync([FromBody] RecoverPasswordDto input)
    {
        await authHandler.RecoverPasswordHandler(input.Email);

        return Ok(new ResponseApp<object>()
        {
            Message = "Sua senha temporária foi enviada para o e-mail cadastrado em sua conta."
        });
    }
}
