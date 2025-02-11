﻿using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Validator for CreateProductCommand that defines validation rules for Product creation command.
/// </summary>
public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateProductCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Productname: Required, must be between 3 and 50 characters
    /// - Stock: Cannot be set to None
    /// - Price: Cannot be set to null or empty
    /// </remarks>
    public CreateProductCommandValidator()
    {   
        RuleFor(Product => Product.Productname).NotEmpty().Length(3, 50);
        RuleFor(Product => Product.Stocked).NotEqual(Stock.None);
        RuleFor(Product => Product.Price).NotEmpty().NotNull();
    }
}