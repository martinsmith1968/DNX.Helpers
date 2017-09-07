using System;
using DNX.Helpers.Converters.BuiltInTypes;
using DNX.Helpers.Exceptions;
using NUnit.Framework;
using Test.DNX.Helpers.Converters.BuiltInTypes.TestsDataSource;

namespace Test.DNX.Helpers.Converters.BuiltInTypes
{
    [TestFixture]
    public class ConvertInt16ExtensionsTests
    {
        [TestCaseSource(typeof(ConvertInt16ExtensionsTestsSource), "IsInt16")]
        public bool Test_IsInt16(string text)
        {
            var result = text.IsInt16();

            return result;
        }

        [TestCaseSource(typeof(ConvertInt16ExtensionsTestsSource), "ToInt16")]
        public Int16 Test_ToInt16(string text)
        {
            var result = text.ToInt16();

            return result;
        }

        [TestCaseSource(typeof(ConvertInt16ExtensionsTestsSource), "ToInt16Throws")]
        public bool Test_ToInt16_Throws(string text)
        {
            try
            {
                text.ToInt16();
            }
            catch (ConversionException ex)
            {
                Assert.AreEqual(text, ex.Value);

                return false;
            }

            return true;
        }

        [TestCaseSource(typeof(ConvertInt16ExtensionsTestsSource), "ToInt16WithDefault")]
        public Int16 Test_ToInt16_with_default(string text, Int16 defaultValue)
        {
            var result = text.ToInt16(defaultValue);

            return result;
        }
    }
}
