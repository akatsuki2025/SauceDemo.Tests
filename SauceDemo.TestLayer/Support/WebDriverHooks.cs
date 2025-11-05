using OpenQA.Selenium;
using SauceDemo.BusinessLayer.PageObjects;
using SauceDemo.CoreLayer.Drivers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemo.TestLayer.Support
{
    [Binding]
    public class WebDriverHooks
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            DriverManager.SetBrowser(BrowserType.Firefox); // or Chrome/Edge
            DriverManager.GetDriver();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            DriverManager.QuitDriver();
        }
    }
}
