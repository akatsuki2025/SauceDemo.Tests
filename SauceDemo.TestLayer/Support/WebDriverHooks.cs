using log4net;
using SauceDemo.CoreLayer.Drivers.Enums;

namespace SauceDemo.TestLayer.Support
{
    [Binding]
    public class WebDriverHooks
    {
        private readonly ScenarioContext _scenarioContext;

        public WebDriverHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            LogicalThreadContext.Properties["TestName"] = _scenarioContext.ScenarioInfo.Title;
            DriverManager.SetBrowser(BrowserType.Firefox);
            DriverManager.GetDriver();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            DriverManager.QuitDriver();
            LogicalThreadContext.Properties.Remove("TestName");
        }
    }
}