using System;
using DNX.Helpers.Converters.BuiltInTypes;
using DNX.Helpers.Exceptions;
using NUnit.Framework;
using Test.DNX.Helpers.Converters.BuiltInTypes.TestsDataSource;

namespace Test.DNX.Helpers.Converters.BuiltInTypes
{
    [TestFixture]
    public class ConvertDateTimeExtensionsTests
    {
        [TestCaseSource(typeof(ConvertDateTimeExtensionsTestsSource), "IsDateTime")]
        public bool Test_IsDateTime(string text)
        {
            var result = text.IsDateTime();

            return result;
        }

        [TestCaseSource(typeof(ConvertDateTimeExtensionsTestsSource), "ToDateTime")]
        public DateTime Test_ToDateTime(string text)
        {
            var result = text.ToDateTime();

            return result;
        }

        [TestCaseSource(typeof(ConvertDateTimeExtensionsTestsSource), "ToDateTimeThrows")]
        public bool Test_ToDateTime_Throws(string text)
        {
            try
            {
                text.ToDateTime();
            }
            catch (ConversionException ex)
            {
                Assert.AreEqual(text, ex.Value);

                return false;
            }

            return true;
        }

        [TestCaseSource(typeof(ConvertDateTimeExtensionsTestsSource), "ToDateTimeWithDefault")]
        public DateTime Test_ToDateTime_with_default(string text, DateTime defaultValue)
        {
            var result = text.ToDateTime(defaultValue);

            return result;
        }
    }
}
