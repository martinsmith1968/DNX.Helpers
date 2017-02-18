﻿using DNX.Helpers.Exceptions;

namespace DNX.Helpers.Converters.BuiltInTypes
{
    /// <summary>
    /// Class ConvertBoolExtensions.
    /// </summary>
    public static class ConvertByteExtensions
    {
        /// <summary>
        /// Converts the string to a byte
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>byte</returns>
        /// <exception cref="DNX.Helpers.Exceptions.ConversionException">Unable to convert value to Type</exception>
        /// <remarks>Also available as an extension method</remarks>
        public static byte ToByte(this string text)
        {
            byte result;

            if (!byte.TryParse(text, out result))
            {
                throw new ConversionException(text, "Unable to convert value to Type", typeof(byte));
            }

            return result;
        }

        /// <summary>
        /// Converts the string to a byte, or returns the default value if the conversion fails
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>byte</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static byte ToByte(this string text, byte defaultValue)
        {
            try
            {
                var result = text.ToByte();

                return result;
            }
            catch (ConversionException)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Determines if the string can be converted to a byte or not
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns><c>true</c> if the specified text is a #type; otherwise, <c>false</c>.</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static bool IsByte(this string text)
        {
            try
            {
                text.ToByte();

                return true;
            }
            catch (ConversionException)
            {
                return false;
            }
        }
    }
}
