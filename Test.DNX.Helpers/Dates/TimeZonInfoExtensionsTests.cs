using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DNX.Helpers.Dates;
using NUnit.Framework;

namespace Test.DNX.Helpers.Dates
{
    public class TimeZonInfoExtensionsTests
    {
        private readonly ITestOutputHelper _outputHelper;

        public DateTimeExtensionsTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact]
        public void List_all_valid_TimeZones()
        {
            var allTimeZones = TimeZoneInfo.GetSystemTimeZones();

            var timeZones = allTimeZones.Select(tz => tz.StandardName)
                .Union(allTimeZones.Select(tz => tz.DisplayName))
                .Union(allTimeZones.Select(tz => tz.DaylightName))
                .Distinct()
                .ToList();

            allTimeZones
                .ToList()
                .ForEach(tz => _outputHelper.WriteLine(tz.Describe()));
        }

        [Theory]
        [MemberData(nameof(TimeZone_Name_Data))]
        public void FindTimeZoneInfo_can_find_time_zones_by_any_id(string id, bool expected)
        {
            // Arrange
            _outputHelper.WriteLine($"Looking for: {id}, expecting: {expected}");

            // Act
            var result = id.FindTimeZoneInfo();

            // Assert
            if (expected)
                result.Should().NotBeNull();
            else
                result.Should().BeNull();
        }

        [Theory]
        [MemberData(nameof(DateTime_TimeZone_Data))]
        public void ToTimeZone_can_convert_DateTime_to_expected_time_zone_time(DateTime dateTime, string timeZone, DateTime expectedDateTime, bool expectedResult)
        {
            // Arrange
            _outputHelper.WriteLine($"Converting: {dateTime:u} to: {timeZone}, expecting {(expectedResult ? "success" : "failure")}");

            // Act
            var result = dateTime.ToTimeZone(timeZone);

            // Assert
            result.Should().Be(expectedDateTime);
            result.Kind.Should().Be(expectedResult ? DateTimeKind.Unspecified : dateTime.Kind);
        }

        #region Data

        public static IEnumerable<object[]> TimeZone_Name_Data()
        {
            var data = new Dictionary<string, bool>();

            var allTimeZones = TimeZoneInfo.GetSystemTimeZones();

            allTimeZones
                .ToList()
                .ForEach(tz => data.Add(tz.StandardName, true));
            allTimeZones
                .ToList()
                .ForEach(tz => data.Add(tz.DisplayName, true));
            allTimeZones
                .Where(tz => tz.SupportsDaylightSavingTime)
                .ToList()
                .ForEach(tz => data.Add(tz.DaylightName, true));

            data.Add(Guid.NewGuid().ToString(), false);

            return data.Select(d => new object[] { d.Key, d.Value });
        }

        /// <remarks>
        /// Be careful how you specify dates here. Replacing the space with a T in a DateTime parameter looks OK, but actually generates
        /// a 'Local' time converted from UTC, not a UTC time as you might have expected.
        /// https://stackoverflow.com/questions/32824186/parsing-a-datetimeoffset-string-in-c-sharp
        /// </remarks>>
        public static IEnumerable<object[]> DateTime_TimeZone_Data()
        {
            return new List<object[]>()
            {
                new object[] { DateTime.Parse("2021-01-01 12:00Z"), "GMT Standard Time", DateTime.Parse("2021-01-01 12:00Z"), true },
                new object[] { DateTime.Parse("2021-01-01 12:00Z"), Guid.NewGuid().ToString(), DateTime.Parse("2021-01-01 12:00Z"), false },
                new object[] { DateTime.Parse("2021-01-01 18:00Z"), "Eastern Standard Time", DateTime.Parse("2021-01-01 13:00Z"), true },
                new object[] { DateTime.Parse("2021-01-01 18:00Z"), "Hawaiian Standard Time", DateTime.Parse("2021-01-01 08:00Z"), true },
                new object[] { DateTime.Parse("2021-06-01 12:00Z"), "GMT Standard Time", DateTime.Parse("2021-06-01 12:00Z"), true },
                new object[] { DateTime.Parse("2021-06-01 12:00Z"), "GMT Summer Time", DateTime.Parse("2021-06-01 13:00"), true },
            };
        }

        #endregion
    }
}
