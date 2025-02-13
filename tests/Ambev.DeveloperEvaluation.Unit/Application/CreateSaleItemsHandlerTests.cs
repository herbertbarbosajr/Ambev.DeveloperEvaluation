using Ambev.DeveloperEvaluation.Application.SaleItems.CreateSalesItems;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Domain;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application;

/// <summary>
/// Contains unit tests for the <see cref="CreateSalesItemsHandler"/> class.
/// </summary>
public class CreateSaleItemsHandlerTests
{
    private readonly ISaleItemRepository _saleItemRepository;
    private readonly IMapper _mapper;
    private readonly CreateSalesItemsHandler _handler;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateSaleItemsHandlerTests"/> class.
    /// Sets up the test dependencies and creates fake data generators.
    /// </summary>
    public CreateSaleItemsHandlerTests()
    {
        _saleItemRepository = Substitute.For<ISaleItemRepository>();
        _mapper = Substitute.For<IMapper>();  
        _handler = new CreateSalesItemsHandler(_saleItemRepository, _mapper);
    }

    /// <summary>
    /// Tests that a valid saleItems creation request is handled successfully.
    /// </summary>
    [Fact(DisplayName = "Given valid saleItems data When creating saleItems Then returns success response")]
    public async Task Handle_ValidRequest_ReturnsSuccessResponse()
    {
        // Given
        var command = CreateSaleItemsHandlerTestData.GenerateValidCommand();
        var saleItems = new SaleItem
        {
            Id = Guid.NewGuid(),
            Quantity = command.Quantity,
            UnitPrice = command.UnitPrice,
            Discount = command.Discount,
            TotalAmount = command.TotalAmount         
        };

        var result = new CreateSalesItemsResult
        {
            Id = saleItems.Id,
        };


        _mapper.Map<SaleItem>(command).Returns(saleItems);
        _mapper.Map<CreateSalesItemsResult>(saleItems).Returns(result);

        _saleItemRepository.CreateAsync(Arg.Any<SaleItem>(), Arg.Any<CancellationToken>())
            .Returns(saleItems);
        

        // When
        var createsaleItemsResult = await _handler.Handle(command, CancellationToken.None);

        // Then
        createsaleItemsResult.Should().NotBeNull();
        createsaleItemsResult.Id.Should().Be(saleItems.Id);
        await _saleItemRepository.Received(1).CreateAsync(Arg.Any<SaleItem>(), Arg.Any<CancellationToken>());
    }

    /// <summary>
    /// Tests that an invalid saleItems creation request throws a validation exception.
    /// </summary>
    [Fact(DisplayName = "Given invalid saleItems data When creating saleItems Then throws validation exception")]
    public async Task Handle_InvalidRequest_ThrowsValidationException()
    {
        // Given
        var command = new CreateSalesItemsCommand(); // Empty command will fail validation

        // When
        var act = () => _handler.Handle(command, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<FluentValidation.ValidationException>();
    }

    /// <summary>
    /// Tests that the password is hashed before saving the saleItems.
    /// </summary>
    [Fact(DisplayName = "Given saleItems creation request When handling Then password is hashed")]
    public async Task Handle_ValidRequest_HashesPassword()
    {
        // Given
        var command = CreateSaleItemsHandlerTestData.GenerateValidCommand();
      
        var saleItems = new SaleItem
        {
            Id = Guid.NewGuid(),
            Quantity = command.Quantity,
            UnitPrice = command.UnitPrice,
            Discount = command.Discount,
            TotalAmount = command.TotalAmount,
        };

        _mapper.Map<SaleItem>(command).Returns(saleItems);
        _saleItemRepository.CreateAsync(Arg.Any<SaleItem>(), Arg.Any<CancellationToken>())
            .Returns(saleItems);
        

        // When
        await _handler.Handle(command, CancellationToken.None);  
     
    }

    /// <summary>
    /// Tests that the mapper is called with the correct command.
    /// </summary>
    [Fact(DisplayName = "Given valid command When handling Then maps command to saleItems entity")]
    public async Task Handle_ValidRequest_MapsCommandTosaleItems()
    {
        // Given
        var command = CreateSaleItemsHandlerTestData.GenerateValidCommand();
        var saleItems = new SaleItem
        {
            Id = Guid.NewGuid(),
            Quantity = command.Quantity,
            UnitPrice = command.UnitPrice,
            Discount = command.Discount,
            TotalAmount = command.TotalAmount,
        };

        _mapper.Map<SaleItem>(command).Returns(saleItems);
        _saleItemRepository.CreateAsync(Arg.Any<SaleItem>(), Arg.Any<CancellationToken>())
            .Returns(saleItems);
       

        // When
        await _handler.Handle(command, CancellationToken.None);

        // Then
        _mapper.Received(1).Map<SaleItem>(Arg.Is<CreateSalesItemsCommand>(c =>
            c.Quantity == command.Quantity &&
            c.UnitPrice == command.UnitPrice &&
            c.Discount == command.Discount &&
            c.TotalAmount == command.TotalAmount));
    }
}
