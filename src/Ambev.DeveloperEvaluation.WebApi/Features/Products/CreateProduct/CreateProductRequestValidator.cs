using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

/// <summary>
/// Validator for CreateProductRequest that defines validation rules for Product creation.
/// </summary>
public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateProductRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Productname: Required, length between 3 and 50 characters
    /// - Stock: Cannot be None
    /// - Price: Cannot be null or empty
    /// </remarks>
    public CreateProductRequestValidator()
    {    
        RuleFor(Product => Product.Productname).NotEmpty().Length(3, 50);
        RuleFor(Product => Product.Stocked).NotEqual(Stock.None);
        RuleFor(Product => Product.Price).NotEmpty().NotNull();
    }
}