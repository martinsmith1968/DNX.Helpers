using System;
using System.Linq;
using DNX.Helpers.Comparisons;
using NUnit.Framework;

namespace Test.DNX.Helpers.Comparisons
{
    [TestFixture]
    public class ComparerFuncTests
    {
        [TestCase(1, 2, 3, 4, -5, ExpectedResult = -5)]
        [TestCase(3, -3, -4, -3, -3, ExpectedResult = -4)]
        public int Compare_Absolute_Tests(int a, int b, int c, int d, int e)
        {
            Func<int, int, int> absoluteComparerFunc = (x, y) =>
            {
                if (Math.Abs(x) > Math.Abs(y)) return 1;
                if (Math.Abs(x) < Math.Abs(y)) return -1;
                return 0;
            };

            var list = new[] { a, b, c, d, e };

            var sortedList = list.OrderBy(z => z, ComparerFunc<int>.Create(absoluteComparerFunc))
                .ToList();

            return sortedList.Last();
        }

        [TestCase(1, 2, 3, 4, 6, ExpectedResult = "2,4,6,1,3")]
        [TestCase(64, 25, 90, 17, 4, ExpectedResult = "4,64,90,17,25")]
        public string Compare_OrderBy_Tests(int a, int b, int c, int d, int e)
        {
            Func<int, int, int> evensFirst = (x, y) =>
            {
                if (x == y) return 0;

                if (x % 2 == y % 2)
                {
                    return x < y ? -1 : 1;
                }

                return (x % 2 == 0) ? -1 : 1;
            };

            var list = new[] { a, b, c, d, e };

            var sortedList = list.OrderBy(z => z, ComparerFunc<int>.Create(evensFirst))
                .ToList();

            return string.Join(",", sortedList.Select(x => x.ToString()));
        }
    }
}
