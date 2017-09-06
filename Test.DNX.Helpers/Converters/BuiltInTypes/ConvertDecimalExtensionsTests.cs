using System;
using DNX.Helpers.Converters.BuiltInTypes;
using DNX.Helpers.Exceptions;
using NUnit.Framework;
using Test.DNX.Helpers.Converters.BuiltInTypes.TestsDataSource;

namespace Test.DNX.Helpers.Converters.BuiltInTypes
{
    [TestFixture]
    public class ConvertDecimalExtensionsTests
    {
        [TestCaseSource(typeof(ConvertDecimalExtensionsTestsSource), "IsDecimal")]
        public bool Test_IsDecimal(string text)
        {
            var result = text.IsDecimal();

            return result;
        }

        [TestCaseSource(typeof(ConvertDecimalExtensionsTestsSource), "ToDecimal")]
        public decimal Test_ToDecimal(string text)
        {
            var result = text.ToDecimal();

            return result;
        }

        [TestCaseSource(typeof(ConvertDecimalExtensionsTestsSource), "ToDecimalThrows")]
        public bool Test_ToDecimal_Throws(string text)
        {
            try
            {
                text.ToDecimal();
            }
            catch (ConversionException ex)
            {
                Assert.AreEqual(text, ex.Value);

                return false;
            }

            return true;
        }

        [TestCaseSource(typeof(ConvertDecimalExtensionsTestsSource), "ToDecimalWithDefault")]
        public decimal Test_ToDecimal_with_default(string text, decimal defaultValue)
        {
            var result = text.ToDecimal(defaultValue);

            return result;
        }
    }
}
