using OpenQA.Selenium;
using SauceDemo.CoreLayer.Drivers.Enums;

namespace SauceDemo.CoreLayer.Drivers
{
    /// <summary>
    /// Manages the lifecycle of the WebDriver instance and browser type.
    /// </summary>
    public static class DriverManager
    {
        private static IWebDriver? _driver;
        private static BrowserType? _browserType;
        private static readonly object LockObject = new();

        /// <summary>
        /// Sets the browser type to be used for WebDriver creation.
        /// </summary>
        /// <param name="browserType">The browser type to set.</param>
        public static void SetBrowser(BrowserType browserType)
        {
            _browserType = browserType;
        }

        /// <summary>
        /// Gets the singleton WebDriver instance, creating it if necessary.
        /// </summary>
        /// <returns>The <see cref="IWebDriver"/> instance.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the browser type is not set before getting the driver.</exception>
        public static IWebDriver GetDriver()
        {
            if (_driver == null)
            {
                lock (LockObject)
                {
                    if (_driver == null)
                    {
                        if (_browserType == null)
                            throw new InvalidOperationException("BrowserType must be set before getting the driver.");

                        var factory = DriverFactory.GetFactory(_browserType.Value);
                        _driver = factory.CreateDriver();
                    }
                }
            }
            return _driver;
        }

        /// <summary>
        /// Quits and disposes the WebDriver instance, and resets the browser type.
        /// </summary>
        public static void QuitDriver()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver.Dispose();
                _driver = null;
            }
            _browserType = null;
        }
    }
}
