using Serilog;
using ReportPortal.Serilog;

namespace Costco.Utilities.Logger
{
    public static class Logger
    {
        private static ILogger? logger = null;

        public static void Init(string loggerName, string filePath)
        {
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            logger = new LoggerConfiguration()
                .WriteTo.File($"{filePath}/{loggerName}.txt", rollingInterval: RollingInterval.Day)
                .WriteTo.ReportPortal()
                .CreateLogger();
        }

        public static void Information(string message)
        {
            logger.Information(message);
        }

        public static void Warning(string message)
        {
            logger.Warning(message);
        }

        public static void Error(string message)
        {
            logger.Error(message);
        }
    }
}