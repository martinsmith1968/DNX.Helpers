using DNX.Helpers.Converters;
using NUnit.Framework;

namespace Test.DNX.Helpers.Converters
{
    [TestFixture]
    public class BuiltInTypeConvertExtensionsTests
    {
        [TestCase(25, ExpectedResult = "25")]
        [TestCase(49, ExpectedResult = "49")]
        [TestCase(null, ExpectedResult = null)]
        [TestCase("", ExpectedResult = "")]
        public string Test_object_ToStringOrNull(object obj)
        {
            var result = obj.ToStringOrNull();

            return result;
        }

        [TestCase(25, "52", ExpectedResult = "25")]
        [TestCase(49, "94", ExpectedResult = "49")]
        [TestCase(null, "Hello", ExpectedResult = "Hello")]
        [TestCase("", "Hello", ExpectedResult = "")]
        public string Test_object_ToStringOrDefault(object obj, string defaultValue)
        {
            var result = obj.ToStringOrDefault(defaultValue);

            return result;
        }

        [TestCase(25, ExpectedResult = "25")]
        [TestCase(49, ExpectedResult = "49")]
        [TestCase(null, ExpectedResult = "")]
        [TestCase("", ExpectedResult = "")]
        public string Test_object_ToStringOrEmpty(object obj)
        {
            var result = obj.ToStringOrEmpty();

            return result;
        }
    }
}
