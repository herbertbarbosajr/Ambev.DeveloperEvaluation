using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

/// <summary>
/// API response model for GetProduct operation
/// </summary>
public class GetProductResponse
{
    /// <summary>
    /// The unique identifier of the Product
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The Product's full name
    /// </summary>
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    /// The Product's price
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// The current status of the Product
    /// </summary>
    public Stock Stocked { get; set; }
}
