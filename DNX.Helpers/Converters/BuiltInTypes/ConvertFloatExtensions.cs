﻿using DNX.Helpers.Exceptions;

namespace DNX.Helpers.Converters.BuiltInTypes
{
    /// <summary>
    /// Class ConvertBoolExtensions.
    /// </summary>
    public static class ConvertFloatExtensions
    {
        /// <summary>
        /// Converts the string to a float
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>float</returns>
        /// <exception cref="DNX.Helpers.Exceptions.ConversionException">Unable to convert value to Type</exception>
        /// <remarks>Also available as an extension method</remarks>
        public static float ToFloat(this string text)
        {
            float result;

            if (!float.TryParse(text, out result))
            {
                throw new ConversionException(text, "Unable to convert value to Type", typeof(float));
            }

            return result;
        }

        /// <summary>
        /// Converts the string to a float, or returns the default value if the conversion fails
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>float</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static float ToFloat(this string text, float defaultValue)
        {
            try
            {
                var result = text.ToFloat();

                return result;
            }
            catch (ConversionException)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Determines if the string can be converted to a float or not
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns><c>true</c> if the specified text is a #type; otherwise, <c>false</c>.</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static bool IsFloat(this string text)
        {
            try
            {
                text.ToFloat();

                return true;
            }
            catch (ConversionException)
            {
                return false;
            }
        }
    }
}
