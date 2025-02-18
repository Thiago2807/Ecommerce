var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
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

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddValidations();
builder.Services.AddJwt(builder.Configuration);

builder.Services.AddDependencyInjection(builder.Configuration);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
