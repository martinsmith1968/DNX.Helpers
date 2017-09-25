using System;

namespace DNX.Helpers.Exceptions
{
    /// <summary>
    /// An exception for idenifying an invalid value issue with expected parameters
    /// </summary>
    /// <seealso cref="DNX.Helpers.Exceptions.ParameterException" />
    public class ParameterInvalidException : ParameterException
    {
        /// <summary>
        /// Create a ParameterInvalidException with a parameter name and a message
        /// </summary>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">The message.</param>
        public ParameterInvalidException(string paramName, string message)
            : base(paramName, message)
        {
        }

        /// <summary>
        /// Create a ParameterInvalidException with a parameter name and value, and a message
        /// </summary>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="paramValue">The parameter value.</param>
        /// <param name="message">The message.</param>
        public ParameterInvalidException(string paramName, object paramValue, string message)
            : base(paramName, paramValue, message)
        {
        }

        /// <summary>
        /// Create a ParameterInvalidException with a parameter name, message and inner Exception
        /// </summary>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public ParameterInvalidException(string paramName, string message, Exception innerException)
            : base(paramName, message, innerException)
        {
        }

        /// <summary>
        /// Create a ParameterInvalidException with a parameter name and value, message and inner Exception
        /// </summary>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="paramValue">The parameter value.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public ParameterInvalidException(string paramName, object paramValue, string message, Exception innerException)
            : base(paramName, paramValue, message, innerException)
        {
        }
    }
}
