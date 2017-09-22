using DNX.Helpers.Maths;
using NUnit.Framework;

namespace Test.DNX.Helpers.Maths
{
    [TestFixture]
    public class IsBetweenTypeExtensionsTests
    {
        [TestCase(IsBetweenBoundsType.Inclusive, ExpectedResult = "between {0} and {1}")]
        [TestCase(IsBetweenBoundsType.Exclusive, ExpectedResult = "between but not including {0} and {1}")]
        [TestCase(IsBetweenBoundsType.GreaterThanLowerLessThanOrEqualToUpper, ExpectedResult = "greater than {0} but less than or equal to {1}")]
        [TestCase(IsBetweenBoundsType.GreaterThanOrEqualToLowerLessThanUpper, ExpectedResult = "greater than or equal to {0} but less than {1}")]
        [TestCase(IsBetweenBoundsType.IncludeLowerAndUpper, ExpectedResult = "between {0} and {1}")]
        [TestCase(IsBetweenBoundsType.ExcludeLowerAndUpper, ExpectedResult = "between but not including {0} and {1}")]
        [TestCase(IsBetweenBoundsType.ExcludeLowerIncludeUpper, ExpectedResult = "greater than {0} but less than or equal to {1}")]
        [TestCase(IsBetweenBoundsType.IncludeLowerExcludeUpper, ExpectedResult = "greater than or equal to {0} but less than {1}")]
        public string GetLimitDescriptionFormatTest(IsBetweenBoundsType boundsType)
        {
            return boundsType.GetLimitDescriptionFormat();
        }
    }
}
