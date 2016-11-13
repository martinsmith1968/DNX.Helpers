using DNX.Helpers.Converters;
using DNX.Helpers.Exceptions;
using NUnit.Framework;

namespace Test.DNX.Helpers.Converters
{
    [TestFixture]
    public class ConvertExtensionsTests
    {
        [TestCase("0", ExpectedResult = true)]
        [TestCase(int.MinValue, ExpectedResult = true)]
        [TestCase(int.MaxValue, ExpectedResult = true)]
        [TestCase("12345", ExpectedResult = true)]
        [TestCase("10", ExpectedResult = true)]
        [TestCase("-10", ExpectedResult = true)]
        [TestCase("abcdef", ExpectedResult = false)]
        [TestCase("10 ", ExpectedResult = true)]
        [TestCase(" 10", ExpectedResult = true)]
        [TestCase("100,000", ExpectedResult = false)]
        [TestCase("100.0", ExpectedResult = false)]
        public bool Test_IsInt(object text)
        {
            var result = text.ToString().IsInt();

            return result;
        }

        [TestCase("0", ExpectedResult = 0)]
        [TestCase(int.MinValue, ExpectedResult = int.MinValue)]
        [TestCase(int.MaxValue, ExpectedResult = int.MaxValue)]
        [TestCase("12345", ExpectedResult = 12345)]
        [TestCase("10", ExpectedResult = 10)]
        [TestCase("-10", ExpectedResult = -10)]
        [TestCase("10 ", ExpectedResult = 10)]
        [TestCase(" 10", ExpectedResult = 10)]
        public int Test_ToInt(object text)
        {
            var result = text.ToString().ToInt();

            return result;
        }

        [TestCase(true, "abcdef")]
        [TestCase(true, "50.5")]
        [TestCase(true, "100,000")]
        [TestCase(false, "100000")]
        public void Test_ToInt_Throws(bool fail, string text)
        {
            try
            {
                text.ToInt();

                Assert.IsFalse(fail);
            }
            catch (ConversionException ex)
            {
                Assert.IsTrue(fail);
                Assert.IsNotNull(ex);
            }
        }

        [TestCase("abcdef", 25, ExpectedResult = 25)]
        [TestCase("50.5", 49, ExpectedResult = 49)]
        [TestCase("100,000", 1000, ExpectedResult = 1000)]
        [TestCase("100000", 1000, ExpectedResult = 100000)]
        public int Test_ToInt_with_default(string text, int defaultValue)
        {
            var result = text.ToInt(defaultValue);

            return result;
        }
    }
}
