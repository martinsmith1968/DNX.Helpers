using System;

namespace DNX.Helpers.Exceptions
{
    public class ConversionException : Exception
    {
        public string Value { get; private set; }

        public Type ConvertType { get; private set; }

        public ConversionException(string value, string message)
            : this(value, message, null)
        {
        }

        public ConversionException(string value, string message, Type type)
            : base(message)
        {
            Value       = value;
            ConvertType = type;
        }
    }
}
