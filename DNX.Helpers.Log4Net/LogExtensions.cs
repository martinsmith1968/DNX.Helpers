using System;
using log4net;

namespace DNX.Helpers.Log4Net
{
    /// <summary>
    /// Class ILogExtensions.
    /// </summary>
    public static class LogExtensions
    {
        /// <summary>
        /// Debugs the function.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="messageText">The messageText.</param>
        public static void DebugFunc(this ILog logger, Func<string> messageText)
        {
            if (logger.IsDebugEnabled)
            {
                logger.Debug(messageText());
            }
        }

        /// <summary>
        /// Writes the information.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="messageText">The message text.</param>
        public static void InfoFunc(this ILog logger, Func<string> messageText)
        {
            if (logger.IsInfoEnabled)
            {
                logger.Info(messageText());
            }
        }

        /// <summary>
        /// Writes the warn.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="messageText">The message text.</param>
        public static void WarnFunc(this ILog logger, Func<string> messageText)
        {
            if (logger.IsWarnEnabled)
            {
                logger.Warn(messageText());
            }
        }

        /// <summary>
        /// Writes the warn.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="messageText">The message text.</param>
        public static void ErrorFunc(this ILog logger, Func<string> messageText)
        {
            if (logger.IsErrorEnabled)
            {
                logger.Error(messageText());
            }
        }

        /// <summary>
        /// Writes the warn.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="messageText">The message text.</param>
        public static void FatalFunc(this ILog logger, Func<string> messageText)
        {
            if (logger.IsFatalEnabled)
            {
                logger.Fatal(messageText());
            }
        }
    }
}
