using DNX.Helpers.Exceptions;

namespace DNX.Helpers.Converters.BuiltInTypes
{
    /// <summary>
    /// Class ConvertBoolExtensions.
    /// </summary>
    public static class ConvertShortExtensions
    {
        /// <summary>
        /// Converts the string to a short
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>short</returns>
        /// <exception cref="DNX.Helpers.Exceptions.ConversionException">Unable to convert value to Type</exception>
        /// <remarks>Also available as an extension method</remarks>
        public static short ToShort(this string text)
        {
            short result;

            if (!short.TryParse(text, out result))
            {
                throw new ConversionException(text, "Unable to convert value to Type", typeof(short));
            }

            return result;
        }

        /// <summary>
        /// Converts the string to a short, or returns the default value if the conversion fails
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>short</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static short ToShort(this string text, short defaultValue)
        {
            try
            {
                var result = text.ToShort();

                return result;
            }
            catch (ConversionException)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Determines if the string can be converted to a short or not
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns><c>true</c> if the specified text is a #type; otherwise, <c>false</c>.</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static bool IsShort(this string text)
        {
            try
            {
                text.ToShort();

                return true;
            }
            catch (ConversionException)
            {
                return false;
            }
        }
    }
}
