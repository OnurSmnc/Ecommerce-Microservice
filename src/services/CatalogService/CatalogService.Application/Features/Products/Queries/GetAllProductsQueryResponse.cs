using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Application.Features.Products.Queries
{
    public class GetAllProductsQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

    }
}
