using Sample.Minimal.Api.Application.Interfaces;
using Sample.Minimal.Api.Domain.Interfaces;
using Sample.Minimal.Api.Infra.Repositories;
using Sample.Minimal.Api.Infra;
using System.Diagnostics.CodeAnalysis;

namespace Sample.Minimal.Api.Api.Configurations;

[ExcludeFromCodeCoverage]
public static class DependencyInjectionConfig
{
    public static IServiceCollection ConfigureInterfacesDependencie(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
