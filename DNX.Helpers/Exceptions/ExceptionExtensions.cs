using System;
using System.Collections.Generic;

namespace DNX.Helpers.Exceptions
{
    /// <summary>
    /// Exception Extensions.
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Gets the list of messages from an Exception and inner exceptions
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <returns>IList&lt;System.String&gt;.</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static IList<string> GetMessageList(this Exception ex)
        {
            var list = new List<string>();

            while (ex != null)
            {
                list.Add(ex.Message);

                ex = ex.InnerException;
            }

            return list;
        }

        /// <summary>
        /// Gets the list of messages from an Exception and inner exceptions
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <returns>IList&lt;System.String&gt;.</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static IList<Exception> GetExceptionList(this Exception ex)
        {
            var list = new List<Exception>();

            while (ex != null)
            {
                list.Add(ex);

                ex = ex.InnerException;
            }

            return list;
        }
    }
}
