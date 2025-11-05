using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SauceDemo.CoreLayer.Drivers
{
    public class FirefoxDriverFactory : IWebDriverFactory
    {
        public IWebDriver CreateDriver() 
        {
            return new FirefoxDriver();
        }
    }
}
