using Microsoft.Extensions.DependencyInjection;
using Reqnroll.Microsoft.Extensions.DependencyInjection;

namespace SauceDemo.TestLayer.Support;

public static class DependencyInjectionConfig
{
    [ScenarioDependencies]
    public static IServiceCollection CreateServices()
    {
        var services = new ServiceCollection();

        services.AddScoped<LoginPage>();
        services.AddScoped<DashboardPage>();
        services.AddScoped<CartPage>();

        return services;
    }
}
