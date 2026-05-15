using CatalogService.Application.Bases;
using CatalogService.Application.Interfaces.AutoMapper;
using CatalogService.Application.Interfaces.UnitOfWork;
using CatalogService.Domain.Entities;
using MediatR;
using Shared.Common.Models;
using System.Collections.Generic;
using System.Linq;

namespace CatalogService.Application.Features.Categories.Queries
{
    public class GetAllCategoriesQueryHandler : BaseHandler, IRequestHandler<GetAllCategoriesQueryRequest, ApiResponse<List<GetAllCategoriesQueryResponse>>>
    {
        private readonly IMapper _mapper;

        private readonly IUnitOfWork unitOfWork;
        public GetAllCategoriesQueryHandler(IMapper _mapper, IUnitOfWork unitOfWork) : base(_mapper, unitOfWork)
        {
            this._mapper = _mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<ApiResponse<List<GetAllCategoriesQueryResponse>>> Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = await unitOfWork.GetReadRepository<Category>().GetAllAsync();
            var response = _mapper.Map<GetAllCategoriesQueryResponse, Category>(categories);
            return ApiResponse<List<GetAllCategoriesQueryResponse>>.SuccessResponse(response.ToList());

        }
    }
}
