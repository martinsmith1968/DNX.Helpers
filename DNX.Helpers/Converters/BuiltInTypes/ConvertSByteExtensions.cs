using DNX.Helpers.Exceptions;

namespace DNX.Helpers.Converters.BuiltInTypes
{
    /// <summary>
    /// Class ConvertBoolExtensions.
    /// </summary>
    public static class ConvertSByteExtensions
    {
        /// <summary>
        /// Converts the string to a sbyte
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>sbyte</returns>
        /// <exception cref="DNX.Helpers.Exceptions.ConversionException">Unable to convert value to Type</exception>
        /// <remarks>Also available as an extension method</remarks>
        public static sbyte ToSByte(this string text)
        {
            sbyte result;

            if (!sbyte.TryParse(text, out result))
            {
                throw new ConversionException(text, "Unable to convert value to Type", typeof(sbyte));
            }

            return result;
        }

        /// <summary>
        /// Converts the string to a sbyte, or returns the default value if the conversion fails
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>sbyte</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static sbyte ToSByte(this string text, sbyte defaultValue)
        {
            try
            {
                var result = text.ToSByte();

                return result;
            }
            catch (ConversionException)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Determines if the string can be converted to a sbyte or not
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns><c>true</c> if the specified text is a #type; otherwise, <c>false</c>.</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static bool IsSByte(this string text)
        {
            try
            {
                text.ToSByte();

                return true;
            }
            catch (ConversionException)
            {
                return false;
            }
        }
    }
}
