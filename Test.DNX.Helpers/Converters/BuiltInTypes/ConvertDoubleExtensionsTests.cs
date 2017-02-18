using DNX.Helpers.Converters.BuiltInTypes;
using DNX.Helpers.Exceptions;
using NUnit.Framework;
using Test.DNX.Helpers.Converters.BuiltInTypes.Source;

namespace Test.DNX.Helpers.Converters.BuiltInTypes
{
    [TestFixture]
    public class ConvertDoubleExtensionsTests
    {
        [TestCaseSource(typeof(ConvertDoubleExtensionsTestsSource), "IsDouble")]
        public bool Test_IsDouble(string text)
        {
            var result = text.IsDouble();

            return result;
        }

        [TestCaseSource(typeof(ConvertDoubleExtensionsTestsSource), "ToDouble")]
        public double Test_ToDouble(string text)
        {
            var result = text.ToDouble();

            return result;
        }

        [TestCaseSource(typeof(ConvertDoubleExtensionsTestsSource), "ToDoubleThrows")]
        public bool Test_ToDouble_Throws(string text)
        {
            try
            {
                text.ToDouble();
            }
            catch (ConversionException ex)
            {
                Assert.AreEqual(text, ex.Value);

                return false;
            }

            return true;
        }

        [TestCaseSource(typeof(ConvertDoubleExtensionsTestsSource), "ToDoubleWithDefault")]
        public double Test_ToDouble_with_default(string text, double defaultValue)
        {
            var result = text.ToDouble(defaultValue);

            return result;
        }
    }
}
