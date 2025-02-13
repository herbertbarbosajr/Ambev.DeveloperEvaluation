using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common.Security;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Handler for processing CreateSaleCommand requests
/// </summary>
public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _SaleRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of CreateSaleHandler
    /// </summary>
    /// <param name="SaleRepository">The Sale repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for CreateSaleCommand</param>
    public CreateSaleHandler(ISaleRepository SaleRepository, IMapper mapper)
    {
        _SaleRepository = SaleRepository;
        _mapper = mapper;

    }

    /// <summary>
    /// Handles the CreateSaleCommand request
    /// </summary>
    /// <param name="command">The CreateSale command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created Sale details</returns>
    public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var Sale = _mapper.Map<Sale>(command);
        BusinessRules(Sale);
        var createdSale = await _SaleRepository.CreateAsync(Sale, cancellationToken);
        var result = _mapper.Map<CreateSaleResult>(createdSale);
        return result;
    }

    private void BusinessRules(Sale sale)
    {
        foreach (var item in sale.Items)
        {
            if (item.Quantity < 4)
            {
                item.Discount = 0m;
            }
            else if (item.Quantity >= 4 && item.Quantity < 10)
            {
                item.Discount = 0.10m;
            }
            else if (item.Quantity >= 10 && item.Quantity <= 20)
            {
                item.Discount = 0.20m;
            }
            else if (item.Quantity > 20)
            {
                throw new InvalidOperationException("Não é possível vender acima de 20 itens idênticos.");
            }

            item.TotalAmount = item.Quantity * item.UnitPrice * (1 - item.Discount);
        }

        sale.TotalAmount = sale.Items.Sum(i => i.TotalAmount);
    }
}
