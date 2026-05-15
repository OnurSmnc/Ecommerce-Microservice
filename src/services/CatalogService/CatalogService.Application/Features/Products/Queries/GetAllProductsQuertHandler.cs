using CatalogService.Application.Bases;
using CatalogService.Application.Interfaces.AutoMapper;
using CatalogService.Application.Interfaces.UnitOfWork;
using CatalogService.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Application.Features.Products.Queries
{
    public class GetAllProductsQuertHandler : BaseHandler, IRequestHandler<GetAllProductsQueryRequest, ApiResponse<List<GetAllProductsQueryResponse>>>
    {
        private readonly IMapper _mapper;

        private readonly IUnitOfWork unitOfWork;
        public GetAllProductsQuertHandler(IMapper _mapper, IUnitOfWork unitOfWork) : base(_mapper, unitOfWork)
        {
            this._mapper = _mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<List<GetAllProductsQueryResponse>>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await unitOfWork.GetReadRepository<Product>().GetAllAsync(include: x => x.Include(p => p.Category));
            var response = _mapper.Map<GetAllProductsQueryResponse, Product>(products);
            return ApiResponse<List<GetAllProductsQueryResponse>>.SuccessResponse(response.ToList());
        }
    }
}
