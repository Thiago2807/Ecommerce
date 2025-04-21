using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

builder.Configuration.AddJsonFile("configuration.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer("Bearer", options =>
{
    var secretKey = builder.Configuration.GetSection("JWT:secret-key").Value;
    var issuer = builder.Configuration.GetSection("JWT:issuer").Value;
    var audience = builder.Configuration.GetSection("JWT:audience").Value;

    if (string.IsNullOrEmpty(secretKey) || string.IsNullOrEmpty(issuer) || string.IsNullOrEmpty(audience))
    {
        throw new Exception("Informa��es para o token JWT inv�lidos, verifique o arquivo de configura��es.");
    }

    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.MapInboundClaims = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = issuer,       // Altere para o issuer definido
        ValidAudience = audience,   // Altere para o audience definido
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)) // Chave secreta
    };
});

builder.Services
    .AddOcelot(builder.Configuration);

var app = builder.Build();

app.UseCors("AllowAll");

app.UseAuthentication();
await app.UseOcelot();

app.Run();
