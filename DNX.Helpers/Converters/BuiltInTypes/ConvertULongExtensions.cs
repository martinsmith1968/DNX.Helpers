﻿using DNX.Helpers.Exceptions;

namespace DNX.Helpers.Converters.BuiltInTypes
{
    /// <summary>
    /// Class ConvertBoolExtensions.
    /// </summary>
    public static class ConvertULongExtensions
    {
        /// <summary>
        /// Converts the string to a ulong
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>ulong</returns>
        /// <exception cref="DNX.Helpers.Exceptions.ConversionException">Unable to convert value to Type</exception>
        /// <remarks>Also available as an extension method</remarks>
        public static ulong ToULong(this string text)
        {
            ulong result;

            if (!ulong.TryParse(text, out result))
            {
                throw new ConversionException(text, "Unable to convert value to Type", typeof(ulong));
            }

            return result;
        }

        /// <summary>
        /// Converts the string to a ulong, or returns the default value if the conversion fails
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>ulong</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static ulong ToULong(this string text, ulong defaultValue)
        {
            try
            {
                var result = text.ToULong();

                return result;
            }
            catch (ConversionException)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Determines if the string can be converted to a ulong or not
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns><c>true</c> if the specified text is a #type; otherwise, <c>false</c>.</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static bool IsULong(this string text)
        {
            try
            {
                text.ToULong();

                return true;
            }
            catch (ConversionException)
            {
                return false;
            }
        }
    }
}
