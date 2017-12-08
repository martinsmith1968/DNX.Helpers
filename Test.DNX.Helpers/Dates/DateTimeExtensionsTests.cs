using System;
using System.Globalization;
using DNX.Helpers.Dates;
using NUnit.Framework;
using Shouldly;

namespace Test.DNX.Helpers.Dates
{
    #region DataTime Format Provider

    internal class CustomDateTimeFormatProvider : IFormatProvider, ICustomFormatter
    {
        public const string FormatString = "dd-MMM-yyyy HH:mm:ss";

        public object GetFormat(Type formatType)
        {
            return (formatType == typeof(DateTimeFormatInfo)) ? this : null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg is DateTime)
            {
                var dt = (DateTime) arg;

                // if user supplied own format use it
                return string.IsNullOrEmpty(format)
                    ? dt.ToString(FormatString)
                    : ((DateTime)arg).ToString(format);
            }

            // format everything else normally
            var formattable = arg as IFormattable;
            return formattable != null
                ? formattable.ToString(format, formatProvider)
                : arg.ToString();
        }
    }

    #endregion

    [TestFixture]
    public class DateTimeExtensionsTests
    {
        [Test]
        public void Unix_Epoch_returns_the_correct_value()
        {
            // Arrange

            // Act
            var epoch = DateTimeExtensions.UnixEpoch;

            // Assert
            epoch.Kind.ShouldBe(DateTimeKind.Utc);
            epoch.Year.ShouldBe(1970);
            epoch.Month.ShouldBe(1);
            epoch.Day.ShouldBe(1);
            epoch.Hour.ShouldBe(0);
            epoch.Minute.ShouldBe(0);
            epoch.Second.ShouldBe(0);
            epoch.Millisecond.ShouldBe(0);
        }

        [Test]
        public void ParseDateAsUtc_can_parse_a_date()
        {
            // Arrange
            var theDateTime = DateTime.Now;
            var dateTimeString = theDateTime.ToLongDateString() + " " + theDateTime.ToLongTimeString();

            // Act
            var parsedDateTime = dateTimeString.ParseDateAsUtc();

            // Assert
            theDateTime.Kind.ShouldBe(DateTimeKind.Local);
            parsedDateTime.Kind.ShouldBe(DateTimeKind.Utc);
            parsedDateTime.Year.ShouldBe(theDateTime.Year);
            parsedDateTime.Month.ShouldBe(theDateTime.Month);
            parsedDateTime.Day.ShouldBe(theDateTime.Day);
            parsedDateTime.Hour.ShouldBe(theDateTime.Hour);
            parsedDateTime.Minute.ShouldBe(theDateTime.Minute);
            parsedDateTime.Second.ShouldBe(theDateTime.Second);
            parsedDateTime.Millisecond.ShouldBe(0);
        }

        [Test]
        public void ParseDateAsUtc_with_defaultvalue_can_parse_a_date()
        {
            // Arrange
            var defaultDateTime = DateTime.Now.Subtract(TimeSpan.FromDays(60));
            var theDateTime = DateTime.Now;
            var dateTimeString = theDateTime.ToLongDateString() + " " + theDateTime.ToLongTimeString();

            // Act
            var parsedDateTime = dateTimeString.ParseDateAsUtc(defaultDateTime);

            // Assert
            parsedDateTime.Kind.ShouldBe(DateTimeKind.Utc);
            parsedDateTime.Year.ShouldBe(theDateTime.Year);
            parsedDateTime.Month.ShouldBe(theDateTime.Month);
            parsedDateTime.Day.ShouldBe(theDateTime.Day);
            parsedDateTime.Hour.ShouldBe(theDateTime.Hour);
            parsedDateTime.Minute.ShouldBe(theDateTime.Minute);
            parsedDateTime.Second.ShouldBe(theDateTime.Second);
            parsedDateTime.Millisecond.ShouldBe(0);
        }

        [Test]
        public void ParseDateAsUtc_with_defaultvalue_returns_defaultValue_when_it_fails_to_parse_a_date()
        {
            // Arrange
            var defaultDateTime = DateTime.Now;
            var dateTimeString = "Not a datetime string";

            // Act
            var parsedDateTime = dateTimeString.ParseDateAsUtc(defaultDateTime);

            // Assert
            parsedDateTime.Kind.ShouldBe(DateTimeKind.Utc);
            parsedDateTime.Year.ShouldBe(defaultDateTime.Year);
            parsedDateTime.Month.ShouldBe(defaultDateTime.Month);
            parsedDateTime.Day.ShouldBe(defaultDateTime.Day);
            parsedDateTime.Hour.ShouldBe(defaultDateTime.Hour);
            parsedDateTime.Minute.ShouldBe(defaultDateTime.Minute);
            parsedDateTime.Second.ShouldBe(defaultDateTime.Second);
            parsedDateTime.Millisecond.ShouldBe(defaultDateTime.Millisecond);
        }

        [Test]
        public void ParseDateAsUtc_can_parse_a_date_using_a_format_provider()
        {
            // Arrange
            var formatProvider = new CustomDateTimeFormatProvider();

            var theDateTime = DateTime.Now;
            var dateTimeString = theDateTime.ToString(CustomDateTimeFormatProvider.FormatString);

            // Act
            var parsedDateTime = dateTimeString.ParseDateAsUtc(formatProvider);

            // Assert
            theDateTime.Kind.ShouldBe(DateTimeKind.Local);
            parsedDateTime.Kind.ShouldBe(DateTimeKind.Utc);
            parsedDateTime.Year.ShouldBe(theDateTime.Year);
            parsedDateTime.Month.ShouldBe(theDateTime.Month);
            parsedDateTime.Day.ShouldBe(theDateTime.Day);
            parsedDateTime.Hour.ShouldBe(theDateTime.Hour);
            parsedDateTime.Minute.ShouldBe(theDateTime.Minute);
            parsedDateTime.Second.ShouldBe(theDateTime.Second);
            parsedDateTime.Millisecond.ShouldBe(0);
        }

        [Test]
        public void ParseDateAsUtc_with_defaultvalue_returns_can_parse_a_date_using_a_format_provider()
        {
            // Arrange
            var formatProvider = new CustomDateTimeFormatProvider();

            var defaultDateTime = DateTime.Now.Subtract(TimeSpan.FromDays(60));
            var theDateTime = DateTime.Now;
            var dateTimeString = theDateTime.ToString(CustomDateTimeFormatProvider.FormatString);

            // Act
            var parsedDateTime = dateTimeString.ParseDateAsUtc(formatProvider, defaultDateTime);

            // Assert
            parsedDateTime.Kind.ShouldBe(DateTimeKind.Utc);
            parsedDateTime.Year.ShouldBe(theDateTime.Year);
            parsedDateTime.Month.ShouldBe(theDateTime.Month);
            parsedDateTime.Day.ShouldBe(theDateTime.Day);
            parsedDateTime.Hour.ShouldBe(theDateTime.Hour);
            parsedDateTime.Minute.ShouldBe(theDateTime.Minute);
            parsedDateTime.Second.ShouldBe(theDateTime.Second);
            parsedDateTime.Millisecond.ShouldBe(0);
        }

        [Test]
        public void ParseDateAsUtc_with_defaultvalue_returns_defaultValue_when_it_fails_to_parse_a_date_using_a_format_provider()
        {
            // Arrange
            var formatProvider = new CustomDateTimeFormatProvider();

            var defaultDateTime = DateTime.Now;
            var dateTimeString = "Not a datetime string";

            // Act
            var parsedDateTime = dateTimeString.ParseDateAsUtc(formatProvider, defaultDateTime);

            // Assert
            parsedDateTime.Kind.ShouldBe(DateTimeKind.Utc);
            parsedDateTime.Year.ShouldBe(defaultDateTime.Year);
            parsedDateTime.Month.ShouldBe(defaultDateTime.Month);
            parsedDateTime.Day.ShouldBe(defaultDateTime.Day);
            parsedDateTime.Hour.ShouldBe(defaultDateTime.Hour);
            parsedDateTime.Minute.ShouldBe(defaultDateTime.Minute);
            parsedDateTime.Second.ShouldBe(defaultDateTime.Second);
            parsedDateTime.Millisecond.ShouldBe(defaultDateTime.Millisecond);
        }
    }
}
