using System;
using DNX.Helpers.Converters.BuiltInTypes;
using DNX.Helpers.Exceptions;
using NUnit.Framework;
using Test.DNX.Helpers.Converters.BuiltInTypes.TestsDataSource;

namespace Test.DNX.Helpers.Converters.BuiltInTypes
{
    [TestFixture]
    public class ConvertIntExtensionsTests
    {
        [TestCaseSource(typeof(ConvertIntExtensionsTestsSource), "IsInt")]
        public bool Test_IsInt(string text)
        {
            var result = text.IsInt();

            return result;
        }

        [TestCaseSource(typeof(ConvertIntExtensionsTestsSource), "ToInt")]
        public int Test_ToInt(string text)
        {
            var result = text.ToInt();

            return result;
        }

        [TestCaseSource(typeof(ConvertIntExtensionsTestsSource), "ToIntThrows")]
        public bool Test_ToInt_Throws(string text)
        {
            try
            {
                text.ToInt();
            }
            catch (ConversionException ex)
            {
                Assert.AreEqual(text, ex.Value);

                return false;
            }

            return true;
        }

        [TestCaseSource(typeof(ConvertIntExtensionsTestsSource), "ToIntWithDefault")]
        public int Test_ToInt_with_default(string text, int defaultValue)
        {
            var result = text.ToInt(defaultValue);

            return result;
        }
    }
}
