using OpenQA.Selenium;

namespace SauceDemo.CoreLayer.Drivers
{
    public interface IWebDriverFactory
    {
        IWebDriver CreateDriver();
    }
}
