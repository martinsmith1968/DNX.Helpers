using System;
using DNX.Helpers.Exceptions;

namespace DNX.Helpers.Converters.BuiltInTypes
{
    /// <summary>
    /// Class ConvertBoolExtensions.
    /// </summary>
    public static class ConvertInt32Extensions
    {
        /// <summary>
        /// Converts the string to a int
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>int</returns>
        /// <exception cref="DNX.Helpers.Exceptions.ConversionException">Unable to convert value to Type</exception>
        /// <remarks>Also available as an extension method</remarks>
        public static int ToInt32(this string text)
        {
            int result;

            if (!int.TryParse(text, out result))
            {
                throw new ConversionException(text, "Unable to convert value to Type", typeof(int));
            }

            return result;
        }

        /// <summary>
        /// Converts the string to a int, or returns the default value if the conversion fails
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>int</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static int ToInt32(this string text, int defaultValue)
        {
            try
            {
                var result = text.ToInt32();

                return result;
            }
            catch (ConversionException)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Determines if the string can be converted to a int or not
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns><c>true</c> if the specified text is a #type; otherwise, <c>false</c>.</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static bool IsInt32(this string text)
        {
            try
            {
                text.ToInt32();

                return true;
            }
            catch (ConversionException)
            {
                return false;
            }
        }
    }
}
