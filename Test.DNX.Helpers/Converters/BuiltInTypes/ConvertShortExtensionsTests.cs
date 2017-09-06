using DNX.Helpers.Converters.BuiltInTypes;
using DNX.Helpers.Exceptions;
using NUnit.Framework;
using Test.DNX.Helpers.Converters.BuiltInTypes.TestsDataSource;

namespace Test.DNX.Helpers.Converters.BuiltInTypes
{
    [TestFixture]
    public class ConvertShortExtensionsTests
    {
        [TestCaseSource(typeof(ConvertShortExtensionsTestsSource), "IsShort")]
        public bool Test_IsShort(string text)
        {
            var result = text.IsShort();

            return result;
        }

        [TestCaseSource(typeof(ConvertShortExtensionsTestsSource), "ToShort")]
        public short Test_ToShort(string text)
        {
            var result = text.ToShort();

            return result;
        }

        [TestCaseSource(typeof(ConvertShortExtensionsTestsSource), "ToShortThrows")]
        public bool Test_ToShort_Throws(string text)
        {
            try
            {
                text.ToShort();
            }
            catch (ConversionException ex)
            {
                Assert.AreEqual(text, ex.Value);

                return false;
            }

            return true;
        }

        [TestCaseSource(typeof(ConvertShortExtensionsTestsSource), "ToShortWithDefault")]
        public short Test_ToShort_with_default(string text, short defaultValue)
        {
            var result = text.ToShort(defaultValue);

            return result;
        }
    }
}
