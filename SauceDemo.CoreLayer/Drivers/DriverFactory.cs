namespace SauceDemo.CoreLayer.Drivers
{
    public static class DriverFactory
    {
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
}
