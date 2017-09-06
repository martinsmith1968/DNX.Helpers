using System;
using DNX.Helpers.Exceptions;

namespace DNX.Helpers.Converters.BuiltInTypes
{
    /// <summary>
    /// Class ConvertBoolExtensions.
    /// </summary>
    public static class ConvertDateTimeExtensions
    {
        /// <summary>
        /// Converts the string to a DateTime
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>DateTime</returns>
        /// <exception cref="DNX.Helpers.Exceptions.ConversionException">Unable to convert value to Type</exception>
        /// <remarks>Also available as an extension method</remarks>
        public static DateTime ToDateTime(this string text)
        {
            DateTime result;

            if (!DateTime.TryParse(text, out result))
            {
                throw new ConversionException(text, "Unable to convert value to Type", typeof(DateTime));
            }

            return result;
        }

        /// <summary>
        /// Converts the string to a DateTime, or returns the default value if the conversion fails
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>DateTime</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static DateTime ToDateTime(this string text, DateTime defaultValue)
        {
            try
            {
                var result = text.ToDateTime();

                return result;
            }
            catch (ConversionException)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Determines if the string can be converted to a DateTime or not
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns><c>true</c> if the specified text is a #type; otherwise, <c>false</c>.</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static bool IsDateTime(this string text)
        {
            try
            {
                text.ToDateTime();

                return true;
            }
            catch (ConversionException)
            {
                return false;
            }
        }
    }
}
