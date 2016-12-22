using System;

namespace DNX.Helpers.Exceptions
{
    /// <summary>
    /// EnumTypeException.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class EnumTypeException : Exception
    {
        private const string MessageTemplate = "{0} is not an enumeration type";

        /// <summary>
        /// The type the exception was thrown for
        /// </summary>
        /// <value>The type.</value>
        public Type Type { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumTypeException"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <remarks>Uses the default message template</remarks>
        public EnumTypeException(Type type)
            : this(type, MessageTemplate)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumTypeException"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="messageTemplate">The message template.</param>
        public EnumTypeException(Type type, string messageTemplate)
            : base(string.Format(messageTemplate, type.Name))
        {
            Type = type;
        }
    }
}
