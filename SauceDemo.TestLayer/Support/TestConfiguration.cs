namespace SauceDemo.TestLayer.Support;
using Microsoft.Extensions.Configuration;

public static class TestConfiguration
{
    private static readonly IConfigurationRoot? _config =
        new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true)
            .Build();

    public static string Browser => _config?["TestSettings:Browser"] ?? "Firefox";
    public static string BaseUrl => _config?["TestSettings:BaseUrl"] ?? "https://www.saucedemo.com/";
    public static string DefaultUsername => _config?["TestSettings:DefaultUsername"] ?? "standard_user";
    public static string DefaultPassword => _config?["TestSettings:DefaultPassword"] ?? "secret_sauce";
}
