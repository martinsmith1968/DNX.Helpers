using DNX.Helpers.Exceptions;

namespace DNX.Helpers.Converters
{
    /// <summary>
    /// Conversion Extensions.
    /// </summary>
    public static class BuiltInTypeConvertExtensions
    {
        #region bool (System.Boolean)

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
        /// <returns><c>true</c> if the specified text is a bool; otherwise, <c>false</c>.</returns>
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

        #endregion

        #region byte (System.Byte)

        /// <summary>
        /// Converts the string to a byte
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>byte</returns>
        /// <exception cref="DNX.Helpers.Exceptions.ConversionException">Unable to convert value to Type</exception>
        /// <remarks>Also available as an extension method</remarks>
        public static byte ToByte(this string text)
        {
            byte result;

            if (!byte.TryParse(text, out result))
            {
                throw new ConversionException(text, "Unable to convert value to Type", typeof(byte));
            }

            return result;
        }

        /// <summary>
        /// Converts the string to a byte, or returns the default value if the conversion fails
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>byte</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static byte ToByte(this string text, byte defaultValue)
        {
            try
            {
                var result = text.ToByte();

                return result;
            }
            catch (ConversionException)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Determines if the string can be converted to a byte or not
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns><c>true</c> if the specified text is a byte; otherwise, <c>false</c>.</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static bool IsByte(this string text)
        {
            try
            {
                text.ToByte();

                return true;
            }
            catch (ConversionException)
            {
                return false;
            }
        }

        #endregion

        #region sbyte (System.SByte)

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
                throw new ConversionException(text, "Unable to convert value to Type", typeof(byte));
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
        /// <returns><c>true</c> if the specified text is a sbyte; otherwise, <c>false</c>.</returns>
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

        #endregion

        #region short (System.Int16)

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

        #region ushort (System.UInt16)

        /// <summary>
        /// Converts the string to a ushort
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>ushort</returns>
        /// <exception cref="DNX.Helpers.Exceptions.ConversionException">Unable to convert value to Type</exception>
        /// <remarks>Also available as an extension method</remarks>
        public static ushort ToUShort(this string text)
        {
            ushort result;

            if (!ushort.TryParse(text, out result))
            {
                throw new ConversionException(text, "Unable to convert value to Type", typeof(ushort));
            }

            return result;
        }

        /// <summary>
        /// Converts the string to a ushort, or returns the default value if the conversion fails
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>ushort</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static ushort ToUShort(this string text, ushort defaultValue)
        {
            try
            {
                var result = text.ToUShort();

                return result;
            }
            catch (ConversionException)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Determines if the string can be converted to a ushort or not
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns><c>true</c> if the specified text is a ushort; otherwise, <c>false</c>.</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static bool IsUShort(this string text)
        {
            try
            {
                text.ToUShort();

                return true;
            }
            catch (ConversionException)
            {
                return false;
            }
        }

        #endregion

        #region int (System.Int32)

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

        #region uint (System.UInt32)

        /// <summary>
        /// Converts the string to an uint
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>System.UInt32.</returns>
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
        /// <returns>System.UInt32.</returns>
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
        /// <returns><c>true</c> if the specified text is a uint; otherwise, <c>false</c>.</returns>
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

        #endregion

        #region long (System.Int64)

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

        #region long (System.Int64)

        /// <summary>
        /// Converts the string to a ulong
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>ulong</returns>
        /// <exception cref="DNX.Helpers.Exceptions.ConversionException">Unable to convert value to Type</exception>
        /// <remarks>Also available as an extension method</remarks>
        public static ulong ToULong(this string text)
        {
            ulong result;

            if (!ulong.TryParse(text, out result))
            {
                throw new ConversionException(text, "Unable to convert value to Type", typeof(ulong));
            }

            return result;
        }

        /// <summary>
        /// Converts the string to a ulong, or returns the default value if the conversion fails
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>ulong</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static ulong ToULong(this string text, ulong defaultValue)
        {
            try
            {
                var result = text.ToULong();

                return result;
            }
            catch (ConversionException)
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Determines if the string can be converted to a ulong or not
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns><c>true</c> if the specified text is a ulong; otherwise, <c>false</c>.</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static bool IsULong(this string text)
        {
            try
            {
                text.ToULong();

                return true;
            }
            catch (ConversionException)
            {
                return false;
            }
        }

        #endregion

        #region object (System.Object)

        /// <summary>
        /// Returns the obj.ToString() or null if null
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>System.String.</returns>
        public static string ToStringOrNull(this object obj)
        {
            return obj == null
                ? null
                : obj.ToString();
        }

        /// <summary>
        /// Returns the obj.ToString() or Empty if null
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>System.String.</returns>
        public static string ToStringOrEmpty(this object obj)
        {
            return obj == null
                ? string.Empty
                : obj.ToString();
        }

        #endregion

        // Y bool     System.Boolean
        // Y byte     System.Byte
        // Y sbyte    System.SByte
        //   char     System.Char
        //   decimal  System.Decimal
        //   double   System.Double
        //   float    System.Single
        // Y int      System.Int32
        // Y uint     System.UInt32
        // Y long     System.Int64
        // Y ulong    System.UInt64
        // Y object   System.Object
        // Y short    System.Int16
        // Y ushort   System.UInt16
        //   string   System.String
    }
}
