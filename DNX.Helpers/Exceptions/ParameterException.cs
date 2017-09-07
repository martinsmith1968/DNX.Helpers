using System;

namespace DNX.Helpers.Exceptions
{
    /// <summary>
    /// An exception for idenifying issues with expected parameters
    /// </summary>
    public class ParameterException : Exception
    {
        /// <summary>
        /// The Parameter Name
        /// </summary>
        public string ParamName { get; private set; }

        /// <summary>
        /// The value specified for the Parameter
        /// </summary>
        public object ParamValue { get; private set; }

        /// <summary>
        /// Create a ParameterException with a parameter name and a message
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="message"></param>
        public ParameterException(string paramName, string message)
            : base(message)
        {
            ParamName = paramName;
        }

        /// <summary>
        /// Create a ParameterException with a parameter name and value, and a message
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="paramValue"></param>
        /// <param name="message"></param>
        public ParameterException(string paramName, object paramValue, string message)
            : base(message)
        {
            ParamName  = paramName;
            ParamValue = paramValue;
        }

        /// <summary>
        /// Create a ParameterException with a parameter name, message and inner Exception
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public ParameterException(string paramName, string message, Exception innerException)
            : base(message, innerException)
        {
            ParamName = paramName;
        }

        /// <summary>
        /// Create a ParameterException with a parameter name and value, message and inner Exception
        /// </summary>
        /// <param name="paramName"></param>
        /// <param name="paramValue"></param>
        /// <param name="message"></param>
        public ParameterException(string paramName, object paramValue, string message, Exception innerException)
            : base(message, innerException)
        {
            ParamName  = paramName;
            ParamValue = paramValue;
        }
    }
}
