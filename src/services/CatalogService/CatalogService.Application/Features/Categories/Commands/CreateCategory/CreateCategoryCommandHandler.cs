using CatalogService.Application.Bases;
using CatalogService.Application.Interfaces.AutoMapper;
using CatalogService.Application.Interfaces.UnitOfWork;
using CatalogService.Domain.Entities;
using MediatR;
using Shared.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : BaseHandler, IRequestHandler<CreateCategoryCommandRequest, ApiResponse<object>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(mapper, unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ApiResponse<object>> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var newCategory = new Category(name: request.Name, createdDate: DateTime.Today);
            await _unitOfWork.GetWriteRepository<Category>().AddAsync(newCategory);
            await _unitOfWork.SaveChangesAsync();
            return ApiResponse<object>.SuccessResponse(data: null, message: $"{newCategory.Name} category created successfully", statusCode: 201);

        }
    }
}
