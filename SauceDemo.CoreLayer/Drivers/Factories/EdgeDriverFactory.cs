namespace SauceDemo.CoreLayer.Drivers.Factories;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

public class EdgeDriverFactory : IWebDriverFactory
{
    public IWebDriver CreateDriver()
    {
        var options = new EdgeOptions();
        options.AddArgument("--disable-features=AutofillServerCommunication");
        options.AddExcludedArgument("--enable-autofill");
        options.AddArgument("--incognito");
        var driver = new EdgeDriver(options);
        driver.Manage().Window.Maximize();
        return driver;
    }
}