using CatalogService.Infrastructure;
using CatalogService.Infrastructure.Context;
using CatalogService.Mapper;
using CatalogService.Application.Exceptions;
using EasyCookApplication;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Load configuration files early so malformed/missing environment file won't block host configuration
builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddTransient<ExceptionMiddleware>();
builder.Services.AddCustomMapper();
builder.Services.AddApplication();
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.ConfigureExceptionMiddlewareExtension();
app.UseHttpsRedirection();
//app.UseAuthorization();
app.MapControllers();

// Otomatik Migration Bloğu
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<CatalogDbContext>();
        if (context.Database.GetPendingMigrations().Any())
        {
            context.Database.Migrate();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Migration sırasında hata oluştu: {ex.Message}");
    }
}

app.Run();