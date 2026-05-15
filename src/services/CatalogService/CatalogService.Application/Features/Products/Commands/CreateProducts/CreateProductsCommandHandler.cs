using CatalogService.Application.Bases;
using CatalogService.Application.Interfaces.AutoMapper;
using CatalogService.Application.Interfaces.UnitOfWork;
using CatalogService.Domain.Entities;
using MediatR;
using Shared.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Application.Features.Products.Commands.CreateProducts
{
    public class CreateProductsCommandHandler : BaseHandler, IRequestHandler<CreateProductsCommandRequest, ApiResponse<object>>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        public CreateProductsCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<ApiResponse<object>> Handle(CreateProductsCommandRequest request, CancellationToken cancellationToken)
        {
            var newProduct = new Product(request.ProductName, request.Description, request.Price, request.Stock, request.CategoryId, DateTime.Today);
            
            await unitOfWork.GetWriteRepository<Product>().AddAsync(newProduct);
            await unitOfWork.SaveChangesAsync();

            return ApiResponse<object>.SuccessResponse(null, $"{newProduct.Name} product created successfully", 201);

        }
    }
}
