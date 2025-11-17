namespace SauceDemo.CoreLayer.Drivers.Factories;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

public class FirefoxDriverFactory : IWebDriverFactory
{
    public IWebDriver CreateDriver() 
    {
        var options = new FirefoxOptions();
        options.SetPreference("signon.autofillForms", false);
        var driver = new FirefoxDriver(options);
        driver.Manage().Window.Maximize();
        return driver;
    }
}
