using DNX.Helpers.Exceptions;

namespace DNX.Helpers.Converters.BuiltInTypes
{
    /// <summary>
    /// Class ConvertBoolExtensions.
    /// </summary>
    public static class ConvertUIntExtensions
    {
        /// <summary>
        /// Converts the string to a uint
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>uint</returns>
        /// <exception cref="DNX.Helpers.Exceptions.ConversionException">Unable to convert value to Type</exception>
        /// <remarks>Also available as an extension method</remarks>
        public static uint ToUInt(this string text)
        {
            uint result;

            if (!uint.TryParse(text, out result))
            {
                throw new ConversionException(text, "Unable to convert value to Type", typeof(uint));
            }

            return result;
        }

        /// <summary>
        /// Converts the string to a uint, or returns the default value if the conversion fails
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>uint</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static uint ToUInt(this string text, uint defaultValue)
        {
            try
            {
                var result = text.ToUInt();

                return result;
            }
            catch (ConversionException)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Determines if the string can be converted to a uint or not
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns><c>true</c> if the specified text is a #type; otherwise, <c>false</c>.</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static bool IsUInt(this string text)
        {
            try
            {
                text.ToUInt();

                return true;
            }
            catch (ConversionException)
            {
                return false;
            }
        }
    }
}
