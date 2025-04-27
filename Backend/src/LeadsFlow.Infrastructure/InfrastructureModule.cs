using LeadsFlow.Domain.Repositories;
using LeadsFlow.Infrastructure.DataAccess;
using LeadsFlow.Infrastructure.DataAccess.Repositories;
using LeadsFlow.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LeadsFlow.Infrastructure;

public static class InfrastructureModule
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddRepositories(services);

        if (configuration.IsUnitTestEnvironment() == false)
        {
            AddDbContext(services, configuration);
        }
    }

    private static void AddRepositories(IServiceCollection services)
    { 
        services.AddScoped<ILeadRepository, LeadRepository>();

    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.ConnectionString();
        
        services.AddDbContext<LeadsFlowDbContext>(dbContextOptions =>
        {
            dbContextOptions.UseSqlServer(connectionString);
        });
    }
}