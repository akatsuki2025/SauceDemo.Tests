using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SauceDemo.CoreLayer.Drivers;
using SeleniumExtras.WaitHelpers;

namespace SauceDemo.BusinessLayer.PageObjects
{
    public abstract class BasePage
    {
        protected IWebDriver Driver { get; }
        protected WebDriverWait Wait { get; }

        protected BasePage()
        {
            Driver = DriverManager.GetDriver();
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Waits for the element specified by the locator to be visible and returns it.
        /// </summary>
        /// <param name="locator">The locator used to find the element.</param>
        /// <returns>The visible <see cref="IWebElement"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="locator"/> is null.</exception>
        /// <exception cref="WebDriverTimeoutException">Thrown if the element is not visible within the timeout period.</exception>
        protected IWebElement WaitForElement(By locator)
        {
            ArgumentNullException.ThrowIfNull(locator);
            return Wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        /// <summary>
        /// Navigates the browser to the specified URL.
        /// </summary>
        /// <param name="url">The URL to navigate to.</param>
        /// <exception cref="ArgumentNullException">Thrown if the URL is null or empty.</exception>
        public void NavigateTo(string url)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(url);
            Driver.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Clears the specified input field by simulating backspace key presses for each character in its current value.
        /// </summary>
        /// <param name="locator">The locator used to find the input element.</param>
        protected void ClearField(By locator)
        {
            var element = WaitForElement(locator);
            element.Click();
            while (!string.IsNullOrEmpty(element.GetAttribute("value")))
            {
                element.SendKeys(Keys.Backspace);
            }
        }
    }
}
