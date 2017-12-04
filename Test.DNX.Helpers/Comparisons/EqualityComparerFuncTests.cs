using System;
using System.Linq;
using DNX.Helpers.Comparisons;
using NUnit.Framework;

namespace Test.DNX.Helpers.Comparisons
{
    [TestFixture]
    public class EqualityComparerFuncTests
    {
        [TestCase(1, 2, -2, 3, -5, 3, ExpectedResult = true)]
        [TestCase(3, 3, -4, 3, -3, 4, ExpectedResult = true)]
        [TestCase(1, 2, -2, 3, -5, 0, ExpectedResult = false)]
        [TestCase(3, 3, -4, 3, -3, 2, ExpectedResult = false)]
        public bool Compare_Contains_Tests(int a, int b, int c, int d, int e, int search)
        {
            Func<int, int, bool> absoluteEqualityFunc = (x, y) =>
            {
                return Math.Abs(x) == Math.Abs(y);
            };

            var list = new[] { a, b, c, d, e };

            var contains = list.Contains(search, EqualityComparerFunc<int>.Create(absoluteEqualityFunc));

            return contains;
        }

        [TestCase("1,2,3,4,5", ExpectedResult = 5)]
        [TestCase("2,-2,2,-2,2", ExpectedResult = 2)]
        public int GetHashCode_generates_consistent_and_unique_values(string valueList)
        {
            Func<int, int, bool> absoluteEqualityFunc = (x, y) =>
            {
                return Math.Abs(x) == Math.Abs(y);
            };

            var comparer = EqualityComparerFunc<int>.Create(absoluteEqualityFunc);

            var list = valueList.Split(",".ToCharArray())
                .Select(x => Convert.ToInt32(x))
                .ToList();

            var hashCodes = list.Select(x => comparer.GetHashCode(x));

            return hashCodes.Distinct().Count();
        }
    }
}
