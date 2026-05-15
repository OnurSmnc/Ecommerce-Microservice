using MediatR;
using Shared.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Application.Features.Categories.Queries
{
    public class GetAllCategoriesQueryRequest : IRequest<ApiResponse<List<GetAllCategoriesQueryResponse>>>
    {
    }
}
