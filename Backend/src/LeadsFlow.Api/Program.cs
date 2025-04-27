using LeadsFlow.Api.ExceptionHandler;
using LeadsFlow.Application;
using LeadsFlow.Infrastructure;
using LeadsFlow.Infrastructure.Extensions;
using LeadsFlow.Infrastructure.Migrations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
ConfigureServices(builder);
builder.Services.AddExceptionHandler<ApiExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

if (builder.Configuration.IsUnitTestEnvironment() == false)
{
    await MigrateDatabase();
}

app.Run();

async Task MigrateDatabase()
{
    await using var scope = app.Services.CreateAsyncScope();

    await DataBaseMigration.MigrateDatabase(scope.ServiceProvider);
}

void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddApplication();
}