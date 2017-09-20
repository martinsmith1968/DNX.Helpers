using DNX.Helpers.Maths;
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
        public bool IsBetween_Default(byte value, byte min, byte max)
        {
            return value.IsBetween(min, max);
        }

        [TestCase(10, 1, 20, IsBetweenBoundsType.Exclusive, ExpectedResult = true)]
        [TestCase(10, 10, 10, IsBetweenBoundsType.Exclusive, ExpectedResult = false)]
        [TestCase(10, 20, 30, IsBetweenBoundsType.Exclusive, ExpectedResult = false)]
        [TestCase(10, 10, 20, IsBetweenBoundsType.Exclusive, ExpectedResult = false)]
        [TestCase(20, 10, 20, IsBetweenBoundsType.Exclusive, ExpectedResult = false)]
        public bool IsBetween_BoundsType(byte value, byte min, byte max, IsBetweenBoundsType boundsType)
        {
            return value.IsBetween(min, max, boundsType);
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
        public bool IsBetweenEither_Default(byte value, byte min, byte max)
        {
            return value.IsBetweenEither(min, max);
        }

        [TestCase(10, 1, 20, IsBetweenBoundsType.Exclusive, ExpectedResult = true)]
        [TestCase(10, 10, 10, IsBetweenBoundsType.Exclusive, ExpectedResult = false)]
        [TestCase(10, 20, 30, IsBetweenBoundsType.Exclusive, ExpectedResult = false)]
        [TestCase(10, 10, 20, IsBetweenBoundsType.Exclusive, ExpectedResult = false)]
        [TestCase(20, 10, 20, IsBetweenBoundsType.Exclusive, ExpectedResult = false)]
        [TestCase(10, 20, 1, IsBetweenBoundsType.Exclusive, ExpectedResult = true)]
        [TestCase(10, 30, 20, IsBetweenBoundsType.Exclusive, ExpectedResult = false)]
        [TestCase(10, 20, 10, IsBetweenBoundsType.Exclusive, ExpectedResult = false)]
        [TestCase(20, 20, 10, IsBetweenBoundsType.Exclusive, ExpectedResult = false)]
        public bool IsBetweenEither_BoundsType(byte value, byte min, byte max, IsBetweenBoundsType boundsType)
        {
            return value.IsBetweenEither(min, max, boundsType);
        }
    }
}
