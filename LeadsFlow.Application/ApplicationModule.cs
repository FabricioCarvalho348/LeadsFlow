using FluentValidation;
using LeadsFlow.Application.Commands.InsertLead;
using Microsoft.Extensions.DependencyInjection;

namespace LeadsFlow.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddHandlers()
            .AddValidation();
        return services;
    }
    
    private static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblyContaining<InsertLeadCommand>();
        });
        return services;
    }

    private static IServiceCollection AddValidation(this IServiceCollection services)
    {
        services
            .AddValidatorsFromAssemblyContaining<InsertLeadCommand>();
        
        return services;
    }
}