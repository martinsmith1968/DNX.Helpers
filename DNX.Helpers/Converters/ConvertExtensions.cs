using System;
using DNX.Helpers.Exceptions;

namespace DNX.Helpers.Converters
{
    public static class ConvertExtensions
    {
        #region short (Int16)

        public static short ToShort(this string s)
        {
            short result;

            if (!short.TryParse(s, out result))
            {
                throw new ConversionException(s, "Unable to convert value to Type", typeof(short));
            }

            return result;
        }

        public static short ToShort(this string s, short defaultValue)
        {
            try
            {
                var result = s.ToShort();

                return result;
            }
            catch (ConversionException)
            {
                return defaultValue;
            }
        }

        public static bool IsShort(this string s)
        {
            try
            {
                s.ToShort();

                return true;
            }
            catch (ConversionException)
            {
                return false;
            }
        }

        #endregion

        #region int (Int32)

        public static int ToInt(this string s)
        {
            int result;

            if (!int.TryParse(s, out result))
            {
                throw new ConversionException(s, "Unable to convert value to Type", typeof(int));
            }

            return result;
        }

        public static int ToInt(this string s, int defaultValue)
        {
            try
            {
                var result = s.ToInt();

                return result;
            }
            catch (ConversionException)
            {
                return defaultValue;
            }
        }

        public static bool IsInt(this string s)
        {
            try
            {
                s.ToInt();

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
