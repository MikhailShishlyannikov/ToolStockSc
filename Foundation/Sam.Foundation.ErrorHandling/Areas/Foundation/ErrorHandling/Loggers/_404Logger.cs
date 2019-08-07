using log4net;
using Sitecore.Diagnostics;

namespace Sam.Foundation.ErrorHandling.Areas.Foundation.ErrorHandling.Loggers
{
    public class _404Logger
    {
        public static ILog Log => LogManager.GetLogger("CustomErrors._404Logger") ?? LoggerFactory.GetLogger(typeof(_404Logger));
    }
}