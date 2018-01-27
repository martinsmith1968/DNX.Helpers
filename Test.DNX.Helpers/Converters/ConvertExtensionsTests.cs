using DNX.Helpers.Converters;
using NUnit.Framework;

namespace Test.DNX.Helpers.Converters
{
    [TestFixture]
    public class ConvertExtensionsTests
    {
        #region ChangeType

        [TestCase(int.MaxValue, ExpectedResult = int.MaxValue)]
        [TestCase(12345, ExpectedResult = 12345)]
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(-12345, ExpectedResult = -12345)]
        [TestCase(int.MinValue, ExpectedResult = int.MinValue)]
        public int ChangeType_To_Int(long value)
        {
            var result = value.ChangeType<int>();

            return result;
        }

        [TestCase(int.MaxValue, ExpectedResult = int.MaxValue)]
        [TestCase(12345, ExpectedResult = 12345)]
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(-12345, ExpectedResult = -12345)]
        [TestCase(int.MinValue, ExpectedResult = int.MinValue)]
        public object ChangeType_To_Int_by_Type(long value)
        {
            var result = value.ChangeType(typeof(int));

            return result;
        }


        [TestCase(12345, 0, ExpectedResult = 12345)]
        [TestCase(3000000000, 0, ExpectedResult = 0)]
        public int ChangeType_To_Int_with_default(long value, int defaultValue)
        {
            var result = value.ChangeType<int>(defaultValue);

            return result;
        }

        #endregion
    }
}
