using DNX.Helpers.Converters.BuiltInTypes;
using DNX.Helpers.Exceptions;
using NUnit.Framework;
using Test.DNX.Helpers.Converters.BuiltInTypes.Source;

namespace Test.DNX.Helpers.Converters.BuiltInTypes
{
    [TestFixture]
    public class ConvertUIntExtensionsTests
    {
        [TestCaseSource(typeof(ConvertUIntExtensionsTestsSource), "IsUInt")]
        public bool Test_IsUInt(string text)
        {
            var result = text.IsUInt();

            return result;
        }

        [TestCaseSource(typeof(ConvertUIntExtensionsTestsSource), "ToUInt")]
        public uint Test_ToUInt(string text)
        {
            var result = text.ToUInt();

            return result;
        }

        [TestCaseSource(typeof(ConvertUIntExtensionsTestsSource), "ToUIntThrows")]
        public bool Test_ToUInt_Throws(string text)
        {
            try
            {
                text.ToUInt();
            }
            catch (ConversionException ex)
            {
                Assert.AreEqual(text, ex.Value);

                return false;
            }

            return true;
        }

        [TestCaseSource(typeof(ConvertUIntExtensionsTestsSource), "ToUIntWithDefault")]
        public uint Test_ToUInt_with_default(string text, uint defaultValue)
        {
            var result = text.ToUInt(defaultValue);

            return result;
        }
    }
}
