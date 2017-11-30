using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace Test.DNX.Helpers.Converters.BuiltInTypes.TestsDataSource
{
    public class ConvertDateTimeExtensionsTestsSource
    {
        private static string CreateDateString(int year, int month, int day)
        {
            var dateTime = new DateTime(year, month, day);

            return dateTime.ToShortDateString();
        }

        private static string CreateDateTimeString(int year, int month, int day, int hour = 0, int minute = 0, int second = 0, DateTimeKind kind = DateTimeKind.Unspecified)
        {
            var dateTime = new DateTime(year, month, day, hour, minute, second, kind);

            return string.Format("{0} {1}", dateTime.ToShortDateString(), dateTime.ToShortTimeString());
        }

        public static IEnumerable<TestCaseData> IsDateTime
        {
            get
            {
                yield return new TestCaseData("0").Returns(false);
                yield return new TestCaseData("1").Returns(false);
                yield return new TestCaseData(CreateDateString(2017, 09, 06)).Returns(true);
                yield return new TestCaseData(CreateDateString(2017, 02, 28)).Returns(true);
                yield return new TestCaseData(CreateDateString(2017, 12, 31)).Returns(true);
                yield return new TestCaseData(CreateDateString(2017, 01, 01)).Returns(true);
                yield return new TestCaseData("Yes").Returns(false);
                yield return new TestCaseData("No").Returns(false);
            }
        }

        public static IEnumerable<TestCaseData> ToDateTime
        {
            get
            {
                yield return new TestCaseData(CreateDateString(2017, 09, 06)).Returns(new DateTime(2017, 09, 06));
                yield return new TestCaseData(CreateDateString(2017, 02, 28)).Returns(new DateTime(2017, 02, 28));
                yield return new TestCaseData(CreateDateString(2017, 12, 31)).Returns(new DateTime(2017, 12, 31));
                yield return new TestCaseData(CreateDateString(2017, 01, 01)).Returns(new DateTime(2017, 01, 01));
            }
        }

        public static IEnumerable<TestCaseData> ToDateTimeThrows
        {
            get
            {
                yield return new TestCaseData("0").Returns(false);
                yield return new TestCaseData("1").Returns(false);
                yield return new TestCaseData("abcdef").Returns(false);
                yield return new TestCaseData("50.5").Returns(false);
                yield return new TestCaseData("-10").Returns(false);
                yield return new TestCaseData("100,000").Returns(false);
                yield return new TestCaseData(short.MaxValue.ToString()).Returns(false);
            }
        }

        public static IEnumerable<TestCaseData> ToDateTimeWithDefault
        {
            get
            {
                yield return new TestCaseData(CreateDateString(2017, 09, 06), new DateTime(2017, 10, 14)).Returns(new DateTime(2017, 09, 06));
                yield return new TestCaseData("abcdef", new DateTime(2017, 09, 06)).Returns(new DateTime(2017, 09, 06));
                yield return new TestCaseData("Negatory", new DateTime(2017, 02, 28)).Returns(new DateTime(2017, 02, 28));
                yield return new TestCaseData("Affirmative", new DateTime(2017, 12, 31)).Returns(new DateTime(2017, 12, 31));
                yield return new TestCaseData("false", new DateTime(2017, 01, 01)).Returns(new DateTime(2017, 01, 01));
            }
        }
    }
}
