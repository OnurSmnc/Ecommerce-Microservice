using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CatalogService.Infrastructure.Context;

public class CatalogDbContextFactory : IDesignTimeDbContextFactory<CatalogDbContext>
{
    public CatalogDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CatalogDbContext>();

        optionsBuilder.UseSqlServer(
            "Server=localhost,1433;Database=CatalogDb;User Id=sa;Password=Sifre123!;TrustServerCertificate=True");

        return new CatalogDbContext(optionsBuilder.Options);
    }
}