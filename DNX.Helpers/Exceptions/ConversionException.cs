using System;

namespace DNX.Helpers.Exceptions
{
    /// <summary>
    /// Conversion Exception.
    /// </summary>
    /// <remarks>
    /// Thrown when a conversion to a specified type fails
    /// </remarks>
    /// <seealso cref="System.Exception" />
    public class ConversionException : Exception
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value { get; private set; }

        /// <summary>
        /// Gets the type of the convert.
        /// </summary>
        /// <value>The type of the convert.</value>
        public Type ConvertType { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConversionException"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="message">The message.</param>
        public ConversionException(string value, string message)
            : this(value, message, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConversionException"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="message">The message.</param>
        /// <param name="type">The type.</param>
        public ConversionException(string value, string message, Type type)
            : base(message)
        {
            Value       = value;
            ConvertType = type;
        }
    }
}
