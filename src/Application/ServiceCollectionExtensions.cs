using Microsoft.Extensions.DependencyInjection;
using stfc.MitigationCalculator.Application.Services;

namespace stfc.MitigationCalculator.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationLayerServices(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));
        services.AddRatioLogisticFunctionService();
        services.AddDefenderTypeWeightFactorsService();
        return services;
    }
    
    
    public static IServiceCollection AddRatioLogisticFunctionService(this IServiceCollection services)
    {
        services.AddScoped<RatioLogisticFunctionService>();
        return services;
    }

    public static IServiceCollection AddDefenderTypeWeightFactorsService(this IServiceCollection services)
    {
        services.AddScoped<DefenderTypeWeightFactorsService>();
        return services;
    }
}