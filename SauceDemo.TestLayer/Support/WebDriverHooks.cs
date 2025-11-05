using OpenQA.Selenium;
using SauceDemo.BusinessLayer.PageObjects;
using SauceDemo.CoreLayer.Drivers;
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
        private readonly ScenarioContext scenarioContext;

        public WebDriverHooks(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var factory = DriverFactory.GetFactory(BrowserType.Firefox); // or Chrome/Edge
            var driver = factory.CreateDriver();
            scenarioContext["WebDriver"] = driver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (scenarioContext.TryGetValue("WebDriver", out IWebDriver driver))
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}
