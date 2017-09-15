﻿using DNX.Helpers.Dates;
using DNX.Helpers.Maths.BuiltInTypes;
using NUnit.Framework;

namespace Test.DNX.Helpers.Maths.BuiltInTypes
{
    public class MathDateTimeExtensions
    {
        [TestCase("2017-06-17 12:34:56", "2017-06-01", "2017-06-30", ExpectedResult = true)]
        [TestCase("2017-06-17 12:34:56", "2017-05-01", "2017-05-30", ExpectedResult = false)]
        [TestCase("2017-06-17 12:34:56", "2017-06-17 12:00:00", "2017-06-17 13:00:00", ExpectedResult = true)]
        [TestCase("2017-06-17 12:34:56", "2017-06-17 13:00:00", "2017-06-17 14:00:00", ExpectedResult = false)]
        [TestCase("2017-06-17 12:34:56", "2017-06-17 12:34:56", "2017-06-17 12:35:00", ExpectedResult = true)]
        [TestCase("2017-06-17 12:34:56", "2017-06-17 12:34:00", "2017-06-17 12:34:56", ExpectedResult = true)]
        public bool IsBetween_InclusiveDefault(string value, string min, string max)
        {
            var dateTime = value.ParseDateAsUtc();
            var minDateTime = min.ParseDateAsUtc();
            var maxDateTime = max.ParseDateAsUtc();

            return dateTime.IsBetween(minDateTime, maxDateTime);
        }

        [TestCase("2017-06-17 12:34:56", "2017-06-01", "2017-06-30", ExpectedResult = true)]
        [TestCase("2017-06-17 12:34:56", "2017-05-01", "2017-05-30", ExpectedResult = false)]
        [TestCase("2017-06-17 12:34:56", "2017-06-17 12:00:00", "2017-06-17 13:00:00", ExpectedResult = true)]
        [TestCase("2017-06-17 12:34:56", "2017-06-17 13:00:00", "2017-06-17 14:00:00", ExpectedResult = false)]
        [TestCase("2017-06-17 12:34:56", "2017-06-17 12:34:56", "2017-06-17 12:35:00", ExpectedResult = false)]
        [TestCase("2017-06-17 12:34:56", "2017-06-17 12:34:00", "2017-06-17 12:34:56", ExpectedResult = false)]
        public bool IsBetween_NotInclusiveDefault(string value, string min, string max)
        {
            var dateTime = value.ParseDateAsUtc();
            var minDateTime = min.ParseDateAsUtc();
            var maxDateTime = max.ParseDateAsUtc();

            return dateTime.IsBetween(minDateTime, maxDateTime, false);
        }

        [TestCase("2017-06-17 12:34:56", "2017-06-01", "2017-06-30", ExpectedResult = true)]
        [TestCase("2017-06-17 12:34:56", "2017-05-01", "2017-05-30", ExpectedResult = false)]
        [TestCase("2017-06-17 12:34:56", "2017-06-30", "2017-06-01", ExpectedResult = true)]
        [TestCase("2017-06-17 12:34:56", "2017-05-30", "2017-05-01", ExpectedResult = false)]
        [TestCase("2017-06-17 12:34:56", "2017-06-17 12:00:00", "2017-06-17 13:00:00", ExpectedResult = true)]
        [TestCase("2017-06-17 12:34:56", "2017-06-17 13:00:00", "2017-06-17 14:00:00", ExpectedResult = false)]
        [TestCase("2017-06-17 12:34:56", "2017-06-17 12:34:56", "2017-06-17 12:35:00", ExpectedResult = true)]
        [TestCase("2017-06-17 12:34:56", "2017-06-17 12:34:00", "2017-06-17 12:34:56", ExpectedResult = true)]
        [TestCase("2017-06-17 12:34:56", "2017-06-17 13:00:00", "2017-06-17 12:00:00", ExpectedResult = true)]
        [TestCase("2017-06-17 12:34:56", "2017-06-17 14:00:00", "2017-06-17 13:00:00", ExpectedResult = false)]
        [TestCase("2017-06-17 12:34:56", "2017-06-17 12:35:00", "2017-06-17 12:34:56", ExpectedResult = true)]
        [TestCase("2017-06-17 12:34:56", "2017-06-17 12:34:56", "2017-06-17 12:34:00", ExpectedResult = true)]
        public bool IsBetweenEither_Inclusive(string value, string min, string max)
        {
            var dateTime = value.ParseDateAsUtc();
            var minDateTime = min.ParseDateAsUtc();
            var maxDateTime = max.ParseDateAsUtc();

            return dateTime.IsBetweenEither(minDateTime, maxDateTime);
        }

        [TestCase("2017-06-17 12:34:56", "2017-06-01", "2017-06-30", ExpectedResult = true)]
        [TestCase("2017-06-17 12:34:56", "2017-05-01", "2017-05-30", ExpectedResult = false)]
        [TestCase("2017-06-17 12:34:56", "2017-06-30", "2017-06-01", ExpectedResult = true)]
        [TestCase("2017-06-17 12:34:56", "2017-05-30", "2017-05-01", ExpectedResult = false)]
        [TestCase("2017-06-17 12:34:56", "2017-06-17 12:00:00", "2017-06-17 13:00:00", ExpectedResult = true)]
        [TestCase("2017-06-17 12:34:56", "2017-06-17 13:00:00", "2017-06-17 14:00:00", ExpectedResult = false)]
        [TestCase("2017-06-17 12:34:56", "2017-06-17 12:34:56", "2017-06-17 12:35:00", ExpectedResult = false)]
        [TestCase("2017-06-17 12:34:56", "2017-06-17 12:34:00", "2017-06-17 12:34:56", ExpectedResult = false)]
        [TestCase("2017-06-17 12:34:56", "2017-06-17 13:00:00", "2017-06-17 12:00:00", ExpectedResult = true)]
        [TestCase("2017-06-17 12:34:56", "2017-06-17 14:00:00", "2017-06-17 13:00:00", ExpectedResult = false)]
        [TestCase("2017-06-17 12:34:56", "2017-06-17 12:35:00", "2017-06-17 12:34:56", ExpectedResult = false)]
        [TestCase("2017-06-17 12:34:56", "2017-06-17 12:34:56", "2017-06-17 12:34:00", ExpectedResult = false)]
        public bool IsBetweenEither_NotInclusive(string value, string min, string max)
        {
            var dateTime = value.ParseDateAsUtc();
            var minDateTime = min.ParseDateAsUtc();
            var maxDateTime = max.ParseDateAsUtc();

            return dateTime.IsBetweenEither(minDateTime, maxDateTime, false);
        }
    }
}
