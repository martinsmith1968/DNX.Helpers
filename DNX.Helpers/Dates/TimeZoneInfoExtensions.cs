using System;
using System.Linq;

namespace DNX.Helpers.Dates
{
    /// <summary>
    /// Time Zone Information Extensions
    /// </summary>
    public static class TimeZoneInfoExtensions
    {
        /// <summary>
        /// Finds the TimeZoneInfo by Id, DisplayName, StandardName or DaylightName
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public static TimeZoneInfo FindTimeZoneInfo(this string id)
        {
            try
            {
                return TimeZoneInfo.FindSystemTimeZoneById(id);
            }
            catch (Exception)
            {
                var allTimeZones = TimeZoneInfo.GetSystemTimeZones();

                return allTimeZones.FirstOrDefault(tz => tz.DisplayName.Equals(id, StringComparison.CurrentCultureIgnoreCase))
                       ?? allTimeZones.FirstOrDefault(tz => tz.DaylightName.Equals(id, StringComparison.CurrentCultureIgnoreCase)
                                                            && tz.SupportsDaylightSavingTime)
                       ?? allTimeZones.FirstOrDefault(tz => tz.StandardName.Equals(id, StringComparison.CurrentCultureIgnoreCase));
            }
        }

        /// <summary>
        /// Describes the specified TimeZoneInfo
        /// </summary>
        /// <param name="timeZoneInfo">The time zone information.</param>
        /// <returns></returns>
        public static string Describe(this TimeZoneInfo timeZoneInfo)
        {
            if (timeZoneInfo == null)
                return string.Empty;

            var description = timeZoneInfo.Id == timeZoneInfo.StandardName
                ? null
                : $" ({timeZoneInfo.StandardName})";

            return $"{timeZoneInfo.Id}{description}: ({timeZoneInfo.BaseUtcOffset:hh:mm})";
        }
    }
}
