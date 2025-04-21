var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});
 
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

app.UseCors("AllowAll");

app.UseExceptionHandler(o => { });

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
