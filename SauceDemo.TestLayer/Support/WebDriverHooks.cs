namespace SauceDemo.TestLayer.Support;
using log4net;
using SauceDemo.CoreLayer.Drivers.Enums;

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
        var browser = TestConfiguration.Browser;
        DriverManager.SetBrowser(Enum.Parse<BrowserType>(browser));
        DriverManager.GetDriver();
    }

    [AfterScenario]
    public void AfterScenario()
    {
        DriverManager.QuitDriver();
        LogicalThreadContext.Properties.Remove("TestName");
    }
}