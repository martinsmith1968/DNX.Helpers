using DNX.Helpers.Exceptions;

namespace DNX.Helpers.Converters
{
    /// <summary>
    /// Conversion Extensions.
    /// </summary>
    public static class ConvertExtensions
    {
        #region short (Int16)

        /// <summary>
        /// Converts the string to a short
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>System.Int16.</returns>
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
        /// <returns>System.Int16.</returns>
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
        /// <returns><c>true</c> if the specified text is a short; otherwise, <c>false</c>.</returns>
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

        #endregion

        #region int (Int32)

        /// <summary>
        /// Converts the string to an int
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>System.Int32.</returns>
        /// <exception cref="DNX.Helpers.Exceptions.ConversionException">Unable to convert value to Type</exception>
        /// <remarks>Also available as an extension method</remarks>
        public static int ToInt(this string text)
        {
            int result;

            if (!int.TryParse(text, out result))
            {
                throw new ConversionException(text, "Unable to convert value to Type", typeof(int));
            }

            return result;
        }

        /// <summary>
        /// Converts the string to an int, or returns the default value if the conversion fails
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static int ToInt(this string text, int defaultValue)
        {
            try
            {
                var result = text.ToInt();

                return result;
            }
            catch (ConversionException)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Determines if the string can be converted to an int or not
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns><c>true</c> if the specified text is an int; otherwise, <c>false</c>.</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static bool IsInt(this string text)
        {
            try
            {
                text.ToInt();

                return true;
            }
            catch (ConversionException)
            {
                return false;
            }
        }

        #endregion

        #region long (Int64)

        /// <summary>
        /// Converts the string to a long
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>System.Int64.</returns>
        /// <exception cref="DNX.Helpers.Exceptions.ConversionException">Unable to convert value to Type</exception>
        /// <remarks>Also available as an extension method</remarks>
        public static long ToLong(this string text)
        {
            long result;

            if (!long.TryParse(text, out result))
            {
                throw new ConversionException(text, "Unable to convert value to Type", typeof(long));
            }

            return result;
        }

        /// <summary>
        /// Converts the string to a long, or returns the default value if the conversion fails
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>System.Int64.</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static long ToLong(this string text, long defaultValue)
        {
            try
            {
                var result = text.ToLong();

                return result;
            }
            catch (ConversionException)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Determines if the string can be converted to a long or not
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns><c>true</c> if the specified text is a long; otherwise, <c>false</c>.</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static bool IsLong(this string text)
        {
            try
            {
                text.ToLong();

                return true;
            }
            catch (ConversionException)
            {
                return false;
            }
        }

        #endregion
    }
}
