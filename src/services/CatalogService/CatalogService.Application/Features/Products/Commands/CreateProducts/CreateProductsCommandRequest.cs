using MediatR;
using Shared.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Application.Features.Products.Commands.CreateProducts
{
    public class CreateProductsCommandRequest : IRequest<ApiResponse<object>>
    {
        public string ProductName { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public DateTime createdDate { get; set; }

    }
}
