using System;

namespace DNX.Helpers.Exceptions
{
    /// <summary>
    /// Class EnumValueException.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class EnumValueException<T> : Exception
    {
        /// <summary>
        /// The message template
        /// </summary>
        private const string MessageTemplate = "{0} is not a valid {1} value";

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public Type Type { get; private set; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public T Value { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumValueException{T}"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public EnumValueException(T value)
            : this(value, MessageTemplate)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumValueException{T}"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="messageTemplate">The message template.</param>
        public EnumValueException(T value, string messageTemplate)
            : base(string.Format(messageTemplate, value, typeof(T).Name))
        {
            Type  = typeof(T);
            Value = value;
        }
    }
}
