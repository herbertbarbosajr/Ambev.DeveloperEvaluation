using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

/// <summary>
/// Represents a request to create a new Product in the system.
/// </summary>
public class CreateProductRequest
{
    /// <summary>
    /// Gets or sets the Productname. Must be unique and contain only valid characters.
    /// </summary>
    public string Productname { get; set; } = string.Empty;

    
    /// <summary>
    /// Gets or sets the initial status of the Product.
    /// </summary>
    public Stock Stocked { get; set; }

    /// <summary>
    /// Gets or sets the price assigned to the Product.
    /// </summary>
    public decimal Price { get; set; }
}