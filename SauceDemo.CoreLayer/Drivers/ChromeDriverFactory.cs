using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SauceDemo.CoreLayer.Drivers
{
    public class ChromeDriverFactory : IWebDriverFactory
    {
        public IWebDriver CreateDriver()
        {
            return new ChromeDriver();
        }
    }
}
