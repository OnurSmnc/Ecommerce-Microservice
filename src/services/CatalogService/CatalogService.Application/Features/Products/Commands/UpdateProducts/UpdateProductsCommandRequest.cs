using MediatR;
using Shared.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Application.Features.Products.Commands.UpdateProducts
{
    public class UpdateProductsCommandRequest : IRequest<ApiResponse<object>>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? Stock { get; set; }
        public int? CategoryId { get; set; }
        public int ProductId { get; set; }
        
    }
}
