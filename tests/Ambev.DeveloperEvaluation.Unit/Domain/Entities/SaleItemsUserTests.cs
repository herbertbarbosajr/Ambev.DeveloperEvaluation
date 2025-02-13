using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

/// <summary>
/// Contains unit tests for the SaleItems entity class.
/// Tests cover status changes and validation scenarios.
/// </summary>
public class SaleItemsSaleItemsTests
{
    

    /// <summary>
    /// Tests that validation passes when all SaleItems properties are valid.
    /// </summary>
    [Fact(DisplayName = "Validation should pass for valid SaleItems data")]
    public void Given_ValidSaleItemsData_When_Validated_Then_ShouldReturnValid()
    {
        // Arrange
        var SaleItems = SaleItemsTestData.GenerateValidSaleItems();

        // Act
        var result = SaleItems.Validate();

        // Assert
        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    /// <summary>
    /// Tests that validation fails when SaleItems properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid SaleItems data")]
    public void Given_InvalidSaleItemsData_When_Validated_Then_ShouldReturnInvalid()
    {
        // Arrange
        var SaleItems = new SaleItem
        {
            Quantity = 0, // Invalid: cannot be 0
            UnitPrice = 0, // Invalid: cannot be 0
            Discount = 0, // Invalid: cannot be 0
            TotalAmount = 0 // Invalid: cannot be 0
        };

        // Act
        var result = SaleItems.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }
}
