using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {       
        RuleFor(product => product.ProductName)
            .NotEmpty()
            .MinimumLength(3).WithMessage("productname must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("productname cannot be longer than 50 characters.");
              
        RuleFor(product => product.Stocked)
            .NotEqual(Stock.None)
            .WithMessage("product status cannot be None.");
        
        RuleFor(product => product.Price)
            .NotNull()
            .NotEmpty()
            .WithMessage("product status cannot be null or empty.");
    }
}
