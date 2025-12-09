using SauceDemo.TestLayer.Support;

namespace SauceDemo.TestLayer.StepDefinitions;

public abstract class BaseStepDefinitions
{
    protected readonly string BaseUrl;

    protected BaseStepDefinitions()
    {
        BaseUrl = TestConfiguration.BaseUrl;
    }
}