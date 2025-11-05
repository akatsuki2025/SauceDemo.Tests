using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SauceDemo.CoreLayer.Drivers;
using SeleniumExtras.WaitHelpers;

namespace SauceDemo.BusinessLayer.PageObjects
{
    public abstract class BasePage
    {
        protected readonly IWebDriver driver;
        protected readonly WebDriverWait wait;

        protected BasePage()
        {
            this.driver = DriverManager.GetDriver();
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        protected IWebElement WaitForElement(By locator)
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public void NavigateTo(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
    }
}
