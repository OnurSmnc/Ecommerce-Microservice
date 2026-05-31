using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Price)
                   .HasPrecision(18, 2);

            builder.HasData(
                new Product("Laptop", "High performance laptop", 85.99m, 50, 1, DateTime.Today),
                new Product("Mouse", "Wireless optical mouse", 15.49m, 80, 1, DateTime.Today),
                new Product("Keyboard", "Mechanical keyboard", 45.00m, 60, 1, DateTime.Today),
                new Product("Monitor", "27 inch 4K monitor", 99.99m, 30, 2, DateTime.Today),
                new Product("Headphones", "Noise cancelling headset", 55.75m, 40, 7, DateTime.Today),
                new Product("Webcam", "1080p HD webcam", 29.99m, 70, 3, DateTime.Today),
                new Product("USB Hub", "7 port USB 3.0 hub", 18.50m, 90, 3, DateTime.Today),
                new Product("SSD", "1TB NVMe SSD", 72.00m, 25, 4, DateTime.Today),
                new Product("RAM", "16GB DDR5 RAM", 63.25m, 35, 4, DateTime.Today),
                new Product("GPU", "Gaming graphics card", 95.00m, 15, 5, DateTime.Today)
            );
        }
    }
}