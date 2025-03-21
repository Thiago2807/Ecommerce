using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;

namespace ecommerce_core.Middlewares;

public class UserIdHeaderMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        var authorizationHeader = context.Request.Headers["Authorization"].FirstOrDefault();
        if (authorizationHeader != null && authorizationHeader.StartsWith("Bearer "))
        {
            var token = authorizationHeader.Substring("Bearer ".Length).Trim();
            var handler = new JwtSecurityTokenHandler();
            if (handler.CanReadToken(token))
            {
                var jwtToken = handler.ReadJwtToken(token);
                var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "nameid");
                if (userIdClaim != null)
                {
                    context.Request.Headers["X-User-Id"] = userIdClaim.Value;
                }
            }
        }

        await _next(context);
    }
}
