using Sample.Minimal.Api.Application;

namespace Sample.Minimal.Api.Api.Configurations;

public static class AppServiceCollectionExtensions
{
    public static void ConfigureAppDependencies(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(ApplicationEntryPoint)));

        services.AddAppConections(configuration);
        services.ConfigureInterfacesDependencie();
        ////services.AddHeaderPropagation(options => options.Headers.Add("X-Correlation-Id"));
    }
}
