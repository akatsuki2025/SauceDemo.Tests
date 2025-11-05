using OpenQA.Selenium;

namespace SauceDemo.BusinessLayer.PageObjects
{
    public abstract class BasePage
    {
        protected readonly IWebDriver driver;

        protected BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateTo(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public abstract bool IsAt();
    }
}
