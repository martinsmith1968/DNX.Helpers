using DNX.Helpers.Exceptions;

namespace DNX.Helpers.Converters.BuiltInTypes
{
    /// <summary>
    /// Class ConvertBoolExtensions.
    /// </summary>
    public static class ConvertDoubleExtensions
    {
        /// <summary>
        /// Converts the string to a double
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>double</returns>
        /// <exception cref="DNX.Helpers.Exceptions.ConversionException">Unable to convert value to Type</exception>
        /// <remarks>Also available as an extension method</remarks>
        public static double ToDouble(this string text)
        {
            double result;

            if (!double.TryParse(text, out result))
            {
                throw new ConversionException(text, "Unable to convert value to Type", typeof(double));
            }

            return result;
        }

        /// <summary>
        /// Converts the string to a double, or returns the default value if the conversion fails
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>double</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static double ToDouble(this string text, double defaultValue)
        {
            try
            {
                var result = text.ToDouble();

                return result;
            }
            catch (ConversionException)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Determines if the string can be converted to a double or not
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns><c>true</c> if the specified text is a #type; otherwise, <c>false</c>.</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static bool IsDouble(this string text)
        {
            try
            {
                text.ToDouble();

                return true;
            }
            catch (ConversionException)
            {
                return false;
            }
        }
    }
}
