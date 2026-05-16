using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Infrastructure.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //builder.HasData(
            //    new Category("Electronics", DateTime.Today),
            //    new Category("Computers", DateTime.Today),
            //    new Category("Accessories", DateTime.Today),
            //    new Category("Storage", DateTime.Today),
            //    new Category("Gaming", DateTime.Today),
            //    new Category("Networking", DateTime.Today),
            //    new Category("Audio", DateTime.Today),
            //    new Category("Monitors", DateTime.Today),
            //    new Category("Printers", DateTime.Today),
            //    new Category("Software", DateTime.Today)
            //);
        }
    }
}