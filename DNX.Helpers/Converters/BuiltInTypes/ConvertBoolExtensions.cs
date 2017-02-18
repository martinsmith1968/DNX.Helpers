﻿using DNX.Helpers.Exceptions;

namespace DNX.Helpers.Converters.BuiltInTypes
{
    /// <summary>
    /// Class ConvertBoolExtensions.
    /// </summary>
    public static class ConvertBoolExtensions
    {
        /// <summary>
        /// Converts the string to a bool
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>bool</returns>
        /// <exception cref="DNX.Helpers.Exceptions.ConversionException">Unable to convert value to Type</exception>
        /// <remarks>Also available as an extension method</remarks>
        public static bool ToBool(this string text)
        {
            bool result;

            if (!bool.TryParse(text, out result))
            {
                throw new ConversionException(text, "Unable to convert value to Type", typeof(bool));
            }

            return result;
        }

        /// <summary>
        /// Converts the string to a bool, or returns the default value if the conversion fails
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>bool</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static bool ToBool(this string text, bool defaultValue)
        {
            try
            {
                var result = text.ToBool();

                return result;
            }
            catch (ConversionException)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Determines if the string can be converted to a bool or not
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns><c>true</c> if the specified text is a #type; otherwise, <c>false</c>.</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static bool IsBool(this string text)
        {
            try
            {
                text.ToBool();

                return true;
            }
            catch (ConversionException)
            {
                return false;
            }
        }
    }
}
