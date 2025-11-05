using OpenQA.Selenium;
using SauceDemo.CoreLayer.Drivers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemo.CoreLayer.Drivers
{
    public static class DriverManager
    {
        private static IWebDriver? _driver;
        private static BrowserType? _browserType;
        private static readonly object _lock = new();

        public static void SetBrowser(BrowserType browserType)
        {
            _browserType = browserType;
        }

        public static IWebDriver GetDriver()
        {
            if (_driver == null)
            {
                lock (_lock)
                {
                    if (_driver == null)
                    {
                        if (_browserType == null)
                            throw new InvalidOperationException("BrowserType must be set before getting the driver.");

                        var factory = DriverFactory.GetFactory(_browserType.Value);
                        _driver = factory.CreateDriver();
                        _driver.Manage().Window.Maximize();
                    }
                }
            }
            return _driver;
        }

        public static void QuitDriver()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver.Dispose();
                _driver = null;
                _browserType = null;
            }
        }
    }
}
