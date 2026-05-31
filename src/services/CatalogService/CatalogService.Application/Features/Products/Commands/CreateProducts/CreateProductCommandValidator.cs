using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Application.Features.Products.Commands.CreateProducts
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductsCommandRequest>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(100).WithMessage("Product name must not exceed 100 characters.");
            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.");
            RuleFor(x => x.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("Stock must be greater than or equal to zero.");
            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("Category ID must be greater than zero.");
           
        }
    }
}
