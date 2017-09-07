using System;

namespace DNX.Helpers.Exceptions
{
    /// <summary>
    /// An exception for idenifying an invalid value issue with expected parameters
    /// </summary>
    public class ParameterInvalidException : ParameterException
    {
        /// <summary>
        /// Create a ParameterInvalidException with a parameter name and a message
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="message"></param>
        public ParameterInvalidException(string paramName, string message)
            : base(paramName, message)
        {
        }

        /// <summary>
        /// Create a ParameterInvalidException with a parameter name and value, and a message
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="paramValue"></param>
        /// <param name="message"></param>
        public ParameterInvalidException(string paramName, object paramValue, string message)
            : base(paramName, paramValue, message)
        {
        }

        /// <summary>
        /// Create a ParameterInvalidException with a parameter name, message and inner Exception
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public ParameterInvalidException(string paramName, string message, Exception innerException)
            : base(paramName, message, innerException)
        {
        }

        /// <summary>
        /// Create a ParameterInvalidException with a parameter name and value, message and inner Exception
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="paramValue"></param>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public ParameterInvalidException(string paramName, object paramValue, string message, Exception innerException)
            : base(paramName, paramValue, message, innerException)
        {
        }
    }
}
