using OpenQA.Selenium;
using SauceDemo.CoreLayer.Drivers.Enums;

namespace SauceDemo.CoreLayer.Drivers
{
    /// <summary>
    /// Manages the lifecycle of the WebDriver instance and browser type.
    /// </summary>
    public static class DriverManager
    {
        private static readonly ThreadLocal<IWebDriver?> _driver = new();
        private static readonly ThreadLocal<BrowserType?> _browserType = new();

        /// <summary>
        /// Gets or sets the WebDriver instance for the current thread.
        /// </summary>
        private static IWebDriver? Driver
        {
            get => _driver.Value;
            set => _driver.Value = value;
        }

        /// <summary>
        /// Gets or sets the browser type for the current thread.
        /// </summary>
        private static BrowserType? BrowserType
        {
            get => _browserType.Value;
            set => _browserType.Value = value;
        }


        /// <summary>
        /// Sets the browser type to be used for WebDriver creation for the current thread.
        /// </summary>
        /// <param name="browserType">The browser type to set.</param>
        public static void SetBrowser(BrowserType browserType)
        {
            BrowserType = browserType;
        }

        /// <summary>
        /// Gets the WebDriver instance for the current thread, creating it if necessary.
        /// </summary>
        /// <returns>The <see cref="IWebDriver"/> instance for the current thread.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the browser type is not set before getting the driver.</exception>
        public static IWebDriver GetDriver()
        {
            if (Driver == null)
            {
                if (BrowserType == null)
                    throw new InvalidOperationException("BrowserType must be set before getting the driver.");

                var factory = DriverFactory.GetFactory(BrowserType.Value);
                Driver = factory.CreateDriver();
            }
            return Driver!;
        }

        /// <summary>
        /// Quits and disposes the WebDriver instance for the current thread, and resets the browser type.
        /// </summary>
        public static void QuitDriver()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver.Dispose();
                Driver = null;
            }
            BrowserType = null;
        }
    }
}
