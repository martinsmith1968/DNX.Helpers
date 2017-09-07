using System;
using DNX.Helpers.Exceptions;

namespace DNX.Helpers.Converters.BuiltInTypes
{
    /// <summary>
    /// Class ConvertBoolExtensions.
    /// </summary>
    public static class ConvertDecimalExtensions
    {
        /// <summary>
        /// Converts the string to a decimal
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>decimal</returns>
        /// <exception cref="DNX.Helpers.Exceptions.ConversionException">Unable to convert value to Type</exception>
        /// <remarks>Also available as an extension method</remarks>
        public static decimal ToDecimal(this string text)
        {
            decimal result;

            if (!decimal.TryParse(text, out result))
            {
                throw new ConversionException(text, "Unable to convert value to Type", typeof(decimal));
            }

            return result;
        }

        /// <summary>
        /// Converts the string to a decimal, or returns the default value if the conversion fails
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>decimal</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static decimal ToDecimal(this string text, decimal defaultValue)
        {
            try
            {
                var result = text.ToDecimal();

                return result;
            }
            catch (ConversionException)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Determines if the string can be converted to a decimal or not
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns><c>true</c> if the specified text is a #type; otherwise, <c>false</c>.</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static bool IsDecimal(this string text)
        {
            try
            {
                text.ToDecimal();

                return true;
            }
            catch (ConversionException)
            {
                return false;
            }
        }
    }
}
