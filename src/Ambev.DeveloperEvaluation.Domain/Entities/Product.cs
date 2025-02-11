using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Product : BaseEntity, IProduct
{

    /// <summary>
    /// Gets the product's full name.
    /// Must not be null or empty and should contain both first and last names.
    /// </summary>
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    /// Gets the product's price.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Get the product's stock.
    /// </summary>
    public Stock Stocked { get; set; }

    /// <summary>
    /// Gets the date and time when the product was created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets the date and time of the last update to the product's information.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Gets the unique identifier of the product.
    /// </summary>
    /// <returns>The product's ID as a string.</returns>
    string IProduct.Id => Id.ToString();

    /// <summary>
    /// Gets the ProductName.
    /// </summary>
    /// <returns>The ProductName.</returns>
    string IProduct.ProductName => ProductName;

   

    /// <summary>
    /// Initializes a new instance of the product class.
    /// </summary>
    public Product()
    {
        CreatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Performs validation of the product entity using the productValidator rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet">ProductName format and length</list>
    /// <list type="bullet">Price format</list>
    /// <list type="bullet">Stocked validity</list>
    /// 
    /// </remarks>
    public ValidationResultDetail Validate()
    {
        var validator = new ProductValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }

    /// <summary>
    /// Activates the product account.
    /// Changes the product's status to Active.
    /// </summary>
    public void Activate()
    {
        Stocked = Stock.Disponivel;
        UpdatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Desactivates the product account.
    /// Changes the product's status to Inactive.
    /// </summary>
    public void Deactivate()
    {
        Stocked = Stock.Indisponivel;
        UpdatedAt = DateTime.UtcNow;
    }

}
