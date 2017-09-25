using System;

namespace DNX.Helpers.Dates
{
    /// <summary>
    /// DateTime Extensions.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Gets the unix epoch.
        /// </summary>
        /// <value>The unix epoch.</value>
        public static DateTime UnixEpoch
        {
            get { return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); }
        }

        /// <summary>
        /// Parses the date as UTC.
        /// </summary>
        /// <param name="dateString">The date string.</param>
        /// <returns>DateTime.</returns>
        public static DateTime ParseDateAsUtc(this string dateString)
        {
            var dateTime = DateTime.Parse(dateString);

            var dateTimeUtc = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);

            return dateTimeUtc;
        }

        /// <summary>
        /// Parses the date as UTC.
        /// </summary>
        /// <param name="dateString">The date string.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>DateTime.</returns>
        public static DateTime ParseDateAsUtc(this string dateString, IFormatProvider formatProvider)
        {
            var dateTime = DateTime.Parse(dateString, formatProvider);

            var dateTimeUtc = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);

            return dateTimeUtc;
        }

        /// <summary>
        /// Parses the date as UTC.
        /// </summary>
        /// <param name="dateString">The date string.</param>
        /// <param name="defaultDateTime">The default date time.</param>
        /// <returns>DateTime.</returns>
        public static DateTime ParseDateAsUtc(this string dateString, DateTime defaultDateTime)
        {
            try
            {
                var dateTime = ParseDateAsUtc(dateString);

                return dateTime;
            }
            catch
            {
                return DateTime.SpecifyKind(defaultDateTime, DateTimeKind.Utc);
            }
        }

        /// <summary>
        /// Parses the date as UTC.
        /// </summary>
        /// <param name="dateString">The date string.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <param name="defaultDateTime">The default date time.</param>
        /// <returns>System.DateTime.</returns>
        public static DateTime ParseDateAsUtc(this string dateString, IFormatProvider formatProvider, DateTime defaultDateTime)
        {
            try
            {
                var dateTime = ParseDateAsUtc(dateString, formatProvider);

                return dateTime;
            }
            catch
            {
                return DateTime.SpecifyKind(defaultDateTime, DateTimeKind.Utc);
            }
        }
    }
}
