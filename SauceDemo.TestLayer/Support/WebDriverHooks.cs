using SauceDemo.CoreLayer.Drivers.Enums;

namespace SauceDemo.TestLayer.Support
{
    [Binding]
    public class WebDriverHooks
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            DriverManager.SetBrowser(BrowserType.Firefox);
            DriverManager.GetDriver();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            DriverManager.QuitDriver();
        }
    }
}