using log4net;
using log4net.Config;
using System.Reflection;


namespace SauceDemo.TestLayer.Support
{
    public static class Log4NetConfig
    {
        public static void Configure()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
        }
    }
}
