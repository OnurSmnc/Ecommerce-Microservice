using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogService.Application.Features.Products.Commands.UpdateProducts
{
    public class UpdateProductsCommandValidator : AbstractValidator<UpdateProductsCommandRequest>
    {
        public UpdateProductsCommandValidator()
        {
            RuleFor(x => x.ProductId).NotNull().GreaterThan(0).WithMessage("Product Id must be greater than 0");
            RuleFor(x => x.Name)
                .MaximumLength(100).WithMessage("Product name must not exceed 100 characters.");
            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");
            RuleFor(x => x.Price)
                .GreaterThan(0).When(x => x.Price.HasValue).WithMessage("Price must be greater than zero.");
            RuleFor(x => x.Stock)
                .GreaterThanOrEqualTo(0).When(x => x.Stock.HasValue).WithMessage("Stock must be greater than or equal to zero.");
            RuleFor(x => x.CategoryId)
                .GreaterThan(0).When(x => x.CategoryId.HasValue).WithMessage("Category ID must be greater than zero.");

        }
    }
}
