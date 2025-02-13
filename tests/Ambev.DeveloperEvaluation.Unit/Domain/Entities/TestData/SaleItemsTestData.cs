using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class SaleItemsTestData
{
    /// <summary>
    /// Configures the Faker to generate valid SaleItems entities.
    /// The generated SaleItems will have valid:
    /// - Quantity 
    /// - UnitPrice 
    /// - Discount 
    /// - TotalAmount 
    /// </summary>
    private static readonly Faker<SaleItem> SaleItemsFaker = new Faker<SaleItem>()
        .RuleFor(u => u.Quantity, f => f.Random.Number())
        .RuleFor(u => u.UnitPrice, f => f.Random.Decimal())
        .RuleFor(u => u.Discount, f => f.Random.Decimal())
        .RuleFor(u => u.TotalAmount, f => f.Random.Decimal());

    /// <summary>
    /// Generates a valid SaleItems entity with randomized data.
    /// The generated SaleItems will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid SaleItems entity with randomly generated data.</returns>
    public static SaleItem GenerateValidSaleItems()
    {
        return SaleItemsFaker.Generate();
    }

    


    /// <summary>
    /// Generates a SaleItemsname that exceeds the maximum length limit.
    /// The generated SaleItemsname will:
    /// - Be longer than 50 characters
    /// - Contain random alphanumeric characters
    /// This is useful for testing SaleItemsname length validation error cases.
    /// </summary>
    /// <returns>A SaleItemsname that exceeds the maximum length limit.</returns>
    public static string GenerateLongSaleItemsname()
    {
        return new Faker().Random.String2(51);
    }
}
