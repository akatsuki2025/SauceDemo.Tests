namespace SauceDemo.CoreLayer.Drivers.Factories;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class ChromeDriverFactory : IWebDriverFactory
{
    public IWebDriver CreateDriver()
    {
        var options = new ChromeOptions();
        options.AddArgument("--disable-features=AutofillServerCommunication");
        options.AddExcludedArgument("--enable-autofill");
        options.AddArgument("--incognito");
        var driver = new ChromeDriver(options);
        driver.Manage().Window.Maximize();
        return driver;
    }
}