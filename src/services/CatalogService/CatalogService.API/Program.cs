using CatalogService.Infrastructure;
using CatalogService.Infrastructure.Context;
using CatalogService.Mapper;
using CatalogService.Application.Exceptions;
using CatalogService.Application;
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

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();

    try
    {
        var context = services.GetRequiredService<CatalogDbContext>();

        var retryCount = 0;
        while (retryCount < 10)
        {
            try
            {
                logger.LogInformation("Applying migrations... Attempt {Attempt}", retryCount + 1);
                context.Database.Migrate(); // Creates DB + applies all migrations
                logger.LogInformation("Migrations applied successfully.");
                break;
            }
            catch (Exception ex)
            {
                retryCount++;
                logger.LogWarning(ex, "Migration failed. Retrying in 5s...");
                Thread.Sleep(5000); 
            }
        }
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred while migrating the database.");
        throw;
    }
}

app.Run();