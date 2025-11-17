namespace SauceDemo.CoreLayer.Drivers;
using SauceDemo.CoreLayer.Drivers.Enums;
using SauceDemo.CoreLayer.Drivers.Factories;

/// <summary>
/// Provides a factory method to obtain the appropriate <see cref="IWebDriverFactory"/> based on the specified browser type.
/// </summary>
public static class DriverFactory
{
    /// <summary>
    /// Returns an <see cref="IWebDriverFactory"/> instance for the specified browser type.
    /// </summary>
    /// <param name="browserType">The type of browser for which to get the factory.</param>
    /// <returns>An implementation of <see cref="IWebDriverFactory"/>.</returns>
    /// <exception cref="ArgumentException">Thrown if the browser type is not supported.</exception>
    public static IWebDriverFactory GetFactory(BrowserType browserType)
    {
        return browserType switch
        {
            BrowserType.Chrome => new ChromeDriverFactory(),
            BrowserType.Firefox => new FirefoxDriverFactory(),
            BrowserType.Edge => new EdgeDriverFactory(),
            _ => throw new ArgumentException($"Unsupported browser: {browserType}")
        };
    }
}