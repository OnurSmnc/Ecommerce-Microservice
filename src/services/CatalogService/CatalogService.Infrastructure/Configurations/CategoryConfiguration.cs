using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Infrastructure.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category(1, "Electronics", DateTime.Today),
                new Category(2, "Computers", DateTime.Today),
                new Category(3, "Accessories", DateTime.Today),
                new Category(4, "Storage", DateTime.Today),
                new Category(5, "Gaming", DateTime.Today),
                new Category(6, "Networking", DateTime.Today),
                new Category(7, "Audio", DateTime.Today),
                new Category(8, "Monitors", DateTime.Today),
                new Category(9, "Printers", DateTime.Today),
                new Category(10, "Software", DateTime.Today)
            );
        }
    }
}