using Ambev.DeveloperEvaluation.Application.SaleItems.CreateSalesItems;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class CreateSaleItemsHandlerTestData
{
    /// <summary>
    /// Configures the Faker to generate valid SaleItems entities.
    /// The generated SaleItemss will have valid:
    /// - SaleItemsname (using internet SaleItemsnames)
    /// - Password (meeting complexity requirements)
    /// - Email (valid format)
    /// - Phone (Brazilian format)
    /// - Status (Active or Suspended)
    /// - Role (Customer or Admin)
    /// </summary>
    private static readonly Faker<CreateSalesItemsCommand> createSaleItemsHandlerFaker = new Faker<CreateSalesItemsCommand>()
        .RuleFor(u => u.Quantity, f => f.Random.Number(100, 999))
        .RuleFor(u => u.UnitPrice, f => f.Random.Decimal())
        .RuleFor(u => u.Discount, f => f.Random.Decimal())
        .RuleFor(u => u.TotalAmount, f => f.Random.Decimal(11, 99));
    
    /// <summary>
    /// Generates a valid SaleItems entity with randomized data.
    /// The generated SaleItems will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid SaleItems entity with randomly generated data.</returns>
    public static CreateSalesItemsCommand GenerateValidCommand()
    {
        return createSaleItemsHandlerFaker.Generate();
    }
}
