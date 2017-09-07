using System;
using DNX.Helpers.Exceptions;

namespace DNX.Helpers.Converters.BuiltInTypes
{
    /// <summary>
    /// Class ConvertBoolExtensions.
    /// </summary>
    public static class ConvertSingleExtensions
    {
        /// <summary>
        /// Converts the string to a Single
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>Single</returns>
        /// <exception cref="DNX.Helpers.Exceptions.ConversionException">Unable to convert value to Type</exception>
        /// <remarks>Also available as an extension method</remarks>
        public static Single ToSingle(this string text)
        {
            Single result;

            if (!Single.TryParse(text, out result))
            {
                throw new ConversionException(text, "Unable to convert value to Type", typeof(Single));
            }

            return result;
        }

        /// <summary>
        /// Converts the string to a Single, or returns the default value if the conversion fails
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>Single</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static Single ToSingle(this string text, Single defaultValue)
        {
            try
            {
                var result = text.ToSingle();

                return result;
            }
            catch (ConversionException)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Determines if the string can be converted to a Single or not
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns><c>true</c> if the specified text is a #type; otherwise, <c>false</c>.</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static bool IsSingle(this string text)
        {
            try
            {
                text.ToSingle();

                return true;
            }
            catch (ConversionException)
            {
                return false;
            }
        }
    }
}
