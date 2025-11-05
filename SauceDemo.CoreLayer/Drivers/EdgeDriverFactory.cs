using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace SauceDemo.CoreLayer.Drivers
{
    public class EdgeDriverFactory : IWebDriverFactory
    {
        public IWebDriver CreateDriver()
        {
            return new EdgeDriver();
        }
    }
}
