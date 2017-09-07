using System;
using DNX.Helpers.Converters.BuiltInTypes;
using DNX.Helpers.Exceptions;
using NUnit.Framework;
using Test.DNX.Helpers.Converters.BuiltInTypes.TestsDataSource;

namespace Test.DNX.Helpers.Converters.BuiltInTypes
{
    [TestFixture]
    public class ConvertInt64ExtensionsTests
    {
        [TestCaseSource(typeof(ConvertInt64ExtensionsTestsSource), "IsInt64")]
        public bool Test_IsInt64(string text)
        {
            var result = text.IsInt64();

            return result;
        }

        [TestCaseSource(typeof(ConvertInt64ExtensionsTestsSource), "ToInt64")]
        public long Test_ToInt64(string text)
        {
            var result = text.ToInt64();

            return result;
        }

        [TestCaseSource(typeof(ConvertInt64ExtensionsTestsSource), "ToInt64Throws")]
        public bool Test_ToInt64_Throws(string text)
        {
            try
            {
                text.ToInt64();
            }
            catch (ConversionException ex)
            {
                Assert.AreEqual(text, ex.Value);

                return false;
            }

            return true;
        }

        [TestCaseSource(typeof(ConvertInt64ExtensionsTestsSource), "ToInt64WithDefault")]
        public long Test_ToInt64_with_default(string text, long defaultValue)
        {
            var result = text.ToInt64(defaultValue);

            return result;
        }
    }
}
