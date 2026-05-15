using MediatR;
using Shared.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Application.Features.Products.Queries
{
    public class GetAllProductsQueryRequest : IRequest<ApiResponse<List<GetAllProductsQueryResponse>>>
    {
    }
}
