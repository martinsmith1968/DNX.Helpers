using System;
using DNX.Helpers.Linq;
using NUnit.Framework;

namespace Test.DNX.Helpers.Linq
{
    [TestFixture]
    public class EnumerableExtensionsTests
    {
        [TestCase("a,b,c,d,e", ExpectedResult = 5)]
        [TestCase("", ExpectedResult = 0)]
        [TestCase(null, ExpectedResult = 0)]
        public int ToConcreteListTest(string commaSeparatedList)
        {
            var list = commaSeparatedList == null
                ? null
                : commaSeparatedList.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            return list.ToConcreteList().Count;
        }

        [TestCase("a,b,c,d,e", ExpectedResult = 5)]
        [TestCase("", ExpectedResult = 0)]
        [TestCase(null, ExpectedResult = -1)]
        public int ToListOrNullTest(string commaSeparatedList)
        {
            var list = commaSeparatedList == null
                ? null
                : commaSeparatedList.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            return list == null ? -1 : list.ToListOrNull().Count;
        }
    }
}
