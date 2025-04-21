using api_ecommerce_loj.Services;
using ecommerce_core.Middlewares;
using ecommerce_core.Models;
using ecommerce_core.Utils;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            var errors = context.ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage);

            return new BadRequestObjectResult(new ResponseApp<object?>()
            {
                Error = true,
                Message = errors.FirstOrDefault() ?? string.Empty,
            });
        };
    });

builder.Services
    .AddValidations()
    .AddDependencyInjection(builder.Configuration);

var app = builder.Build();

app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
app.UseExceptionHandler(o => { });

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<UserIdHeaderMiddleware>();

app.MapControllers();

app.Run();
