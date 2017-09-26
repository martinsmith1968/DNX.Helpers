using System.Diagnostics;
using log4net;

namespace DNX.Helpers.Log4Net
{
    public static class LogManagerExtensions
    {
        public static ILog GetDefaultLogger()
        {
            return LogManager.GetLogger(string.Empty);
        }

        public static ILog GetLoggerFor(object parent)
        {
            return parent == null
                ? GetDefaultLogger()
                : LogManager.GetLogger(parent.GetType());
        }

        public static ILog GetMyLogger()
        {
            var trace = new StackTrace();
            var frame = trace.GetFrame(1);
            var caller = frame == null ? null : frame.GetMethod();

            return caller == null
                ? GetDefaultLogger()
                : LogManager.GetLogger(caller.DeclaringType);
        }

        public static ILog GetLogger<T>()
        {
            return LogManager.GetLogger(typeof(T));
        }
    }
}
