namespace SauceDemo.TestLayer.Support;

public static class Log4NetHooks
{
    [BeforeTestRun]
    public static void BeforeTestRun()
    {
        Log4NetConfig.Configure();
    }
}