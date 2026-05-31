using CatalogService.Application.Bases;
using CatalogService.Application.Features.Categories.Commands.CreateCategory;
using CatalogService.Application.Interfaces.AutoMapper;
using CatalogService.Application.Interfaces.UnitOfWork;
using MediatR;
using Shared.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Application.Features.Products.Commands.UpdateProducts
{
    public class UpdateProductsCommandHandler : BaseHandler, IRequestHandler<UpdateProductsCommandRequest, ApiResponse<object>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateProductsCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(mapper, unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;

        }
        public async Task<ApiResponse<object>> Handle(UpdateProductsCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.GetReadRepository<Domain.Entities.Product>()
                .GetAsync(predicate: p => p.Id == request.ProductId);

            product.Name = !string.IsNullOrWhiteSpace(request.Name) ? request.Name : product.Name;
            product.Description = !string.IsNullOrWhiteSpace(request.Description) ? request.Description : product.Description;
            product.Price = (request.Price.HasValue && request.Price.Value > 0m) ? request.Price.Value : product.Price;
            product.Stock = (request.Stock.HasValue && request.Stock.Value >= 0) ? request.Stock.Value : product.Stock;
            product.CategoryId = (request.CategoryId.HasValue && request.CategoryId.Value > 0) ? request.CategoryId.Value : product.CategoryId;

            await _unitOfWork.GetWriteRepository<Domain.Entities.Product>().UpdateAsync(product);
            await _unitOfWork.SaveChangesAsync();

            return ApiResponse<object>.SuccessResponse(product, "Product updated successfully");

        }
    }
}
