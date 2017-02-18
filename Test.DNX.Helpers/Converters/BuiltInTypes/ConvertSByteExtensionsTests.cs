using DNX.Helpers.Converters.BuiltInTypes;
using DNX.Helpers.Exceptions;
using NUnit.Framework;
using Test.DNX.Helpers.Converters.BuiltInTypes.Source;

namespace Test.DNX.Helpers.Converters.BuiltInTypes
{
    [TestFixture]
    public class ConvertSByteExtensionsTests
    {
        [TestCaseSource(typeof(ConvertSByteExtensionsTestsSource), "IsSByte")]
        public bool Test_IsSByte(string text)
        {
            var result = text.IsSByte();

            return result;
        }

        [TestCaseSource(typeof(ConvertSByteExtensionsTestsSource), "ToSByte")]
        public sbyte Test_ToSByte(string text)
        {
            var result = text.ToSByte();

            return result;
        }

        [TestCaseSource(typeof(ConvertSByteExtensionsTestsSource), "ToSByteThrows")]
        public bool Test_ToSByte_Throws(string text)
        {
            try
            {
                text.ToSByte();
            }
            catch (ConversionException ex)
            {
                Assert.AreEqual(text, ex.Value);

                return false;
            }

            return true;
        }

        [TestCaseSource(typeof(ConvertSByteExtensionsTestsSource), "ToSByteWithDefault")]
        public sbyte Test_ToSByte_with_default(string text, sbyte defaultValue)
        {
            var result = text.ToSByte(defaultValue);

            return result;
        }
    }
}
