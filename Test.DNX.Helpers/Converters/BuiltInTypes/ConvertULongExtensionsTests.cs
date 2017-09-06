using DNX.Helpers.Converters.BuiltInTypes;
using DNX.Helpers.Exceptions;
using NUnit.Framework;
using Test.DNX.Helpers.Converters.BuiltInTypes.TestsDataSource;

namespace Test.DNX.Helpers.Converters.BuiltInTypes
{
    [TestFixture]
    public class ConvertULongExtensionsTests
    {
        [TestCaseSource(typeof(ConvertULongExtensionsTestsSource), "IsULong")]
        public bool Test_IsULong(string text)
        {
            var result = text.IsULong();

            return result;
        }

        [TestCaseSource(typeof(ConvertULongExtensionsTestsSource), "ToULong")]
        public ulong Test_ToULong(string text)
        {
            var result = text.ToULong();

            return result;
        }

        [TestCaseSource(typeof(ConvertULongExtensionsTestsSource), "ToULongThrows")]
        public bool Test_ToULong_Throws(string text)
        {
            try
            {
                text.ToULong();
            }
            catch (ConversionException ex)
            {
                Assert.AreEqual(text, ex.Value);

                return false;
            }

            return true;
        }

        [TestCaseSource(typeof(ConvertULongExtensionsTestsSource), "ToULongWithDefault")]
        public ulong Test_ToULong_with_default(string text, ulong defaultValue)
        {
            var result = text.ToULong(defaultValue);

            return result;
        }
    }
}
