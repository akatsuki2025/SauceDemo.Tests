namespace SauceDemo.TestLayer.Support;

[Binding]
public static class Log4NetHooks
{
    [BeforeTestRun]
    public static void BeforeTestRun()
    {
        Log4NetConfig.Configure();
    }
}