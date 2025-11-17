using log4net;
using log4net.Appender;
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

            string logFileName = $"logs/test-log-{DateTime.Now:yyyyMMdd_HHmmss}.txt";

            foreach (var appender in logRepository.GetAppenders())
            {
                if (appender is RollingFileAppender fileAppender)
                {
                    fileAppender.File = logFileName;
                    fileAppender.ActivateOptions();
                }
            }
        }
    }
}
