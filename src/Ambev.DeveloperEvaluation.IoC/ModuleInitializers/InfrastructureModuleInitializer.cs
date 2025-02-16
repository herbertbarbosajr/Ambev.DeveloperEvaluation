using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.BusinessRolesValidations;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM;
using Ambev.DeveloperEvaluation.ORM.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ambev.DeveloperEvaluation.IoC.ModuleInitializers;

public class InfrastructureModuleInitializer : IModuleInitializer
{
    public void Initialize(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<DefaultContext>());
        builder.Services.AddScoped<ISaleItemRepository, SaleItemRepository>();
        builder.Services.AddScoped<ISaleRepository, SaleRepository>();
        builder.Services.AddTransient<IBusinessRules, NoDiscountRule>();
        builder.Services.AddTransient<IBusinessRules, TenPercentDiscountRule>();
        builder.Services.AddTransient<IBusinessRules, TwentyPercentDiscountRule>();
        builder.Services.AddTransient<IBusinessRules, QuantityValidationRule>();
        builder.Services.AddTransient<DiscountBusinessRuleHandler>();
        builder.Services.AddTransient<IValidator<CreateSaleCommand>, CreateSaleCommandValidator>();
    }
}