using DNX.Helpers.Maths.BuiltInTypes;
using NUnit.Framework;

namespace Test.DNX.Helpers.Maths.BuiltInTypes
{
    public class MathByteExtensions
    {
        [TestCase(10, 1, 20, ExpectedResult = true)]
        [TestCase(10, 10, 10, ExpectedResult = true)]
        [TestCase(10, 20, 30, ExpectedResult = false)]
        [TestCase(10, 10, 20, ExpectedResult = true)]
        [TestCase(20, 10, 20, ExpectedResult = true)]
        public bool IsBetween_InclusiveDefault(byte value, byte min, byte max)
        {
            return value.IsBetween(min, max);
        }

        [TestCase(10, 1, 20, ExpectedResult = true)]
        [TestCase(10, 10, 10, ExpectedResult = false)]
        [TestCase(10, 20, 30, ExpectedResult = false)]
        [TestCase(10, 10, 20, ExpectedResult = false)]
        [TestCase(20, 10, 20, ExpectedResult = false)]
        public bool IsBetween_NotInclusiveDefault(byte value, byte min, byte max)
        {
            return value.IsBetween(min, max, false);
        }

        [TestCase(10, 1, 20, ExpectedResult = true)]
        [TestCase(10, 10, 10, ExpectedResult = true)]
        [TestCase(10, 20, 30, ExpectedResult = false)]
        [TestCase(10, 10, 20, ExpectedResult = true)]
        [TestCase(20, 10, 20, ExpectedResult = true)]
        [TestCase(10, 20, 1, ExpectedResult = true)]
        [TestCase(10, 30, 20, ExpectedResult = false)]
        [TestCase(10, 20, 10, ExpectedResult = true)]
        [TestCase(20, 20, 10, ExpectedResult = true)]
        public bool IsBetweenEither_Inclusive(byte value, byte min, byte max)
        {
            return value.IsBetweenEither(min, max);
        }

        [TestCase(10, 1, 20, ExpectedResult = true)]
        [TestCase(10, 10, 10, ExpectedResult = false)]
        [TestCase(10, 20, 30, ExpectedResult = false)]
        [TestCase(10, 10, 20, ExpectedResult = false)]
        [TestCase(20, 10, 20, ExpectedResult = false)]
        [TestCase(10, 20, 1, ExpectedResult = true)]
        [TestCase(10, 30, 20, ExpectedResult = false)]
        [TestCase(10, 20, 10, ExpectedResult = false)]
        [TestCase(20, 20, 10, ExpectedResult = false)]
        public bool IsBetweenEither_NotInclusive(byte value, byte min, byte max)
        {
            return value.IsBetweenEither(min, max, false);
        }
    }
}
