using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Specifications.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation for ActivesaleItemsSpecification tests
/// to ensure consistency across test cases.
/// </summary>
public static class ActiveSaleItemsSpecificationTestData
{
    /// <summary>
    /// Configures the Faker to generate valid saleItems entities.
    /// The generated saleItemss will have valid:
    /// - Quantity (valid format)
    /// - UnitPrice 
    /// - Discount
    /// - TotalAmount
    /// Status is not set here as it's the main test parameter
    /// </summary>
    private static readonly Faker<SaleItem> saleItemsFaker = new Faker<SaleItem>()
        .CustomInstantiator(f => new SaleItem {
            
            Quantity = f.Random.Number(100, 999),
            UnitPrice = f.Random.Decimal(),
            Discount = f.Random.Decimal(),
            TotalAmount = f.Random.Decimal(11, 99),
        });

    /// <summary>
    /// Generates a valid saleItems entity with the specified status.
    /// </summary>
    /// <returns>A valid saleItems entity with randomly generated data.</returns>
    public static SaleItem GeneratesaleItems()
    {
        var saleItems = saleItemsFaker.Generate();
        return saleItems;
    }
}
