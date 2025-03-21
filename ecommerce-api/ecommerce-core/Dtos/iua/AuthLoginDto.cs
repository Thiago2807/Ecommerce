namespace ecommerce_core.Dtos.Auth;

public sealed class AuthLoginDto
{
    public string Token { get; set; } = string.Empty;
    public DateTime Expiration { get; set; } = DateTime.UtcNow.AddHours(2);
}

public sealed class AuthLoginInputDto
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
