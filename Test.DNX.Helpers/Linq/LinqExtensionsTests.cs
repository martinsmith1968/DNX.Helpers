using System;
using DNX.Helpers.Linq;
using NUnit.Framework;

namespace Test.DNX.Helpers.Linq
{
    [TestFixture]
    public class LinqExtensionsTests
    {
        [TestCase("", ExpectedResult = false)]
        [TestCase(null, ExpectedResult = false)]
        [TestCase("a,b,c,d,e,f,g,h,i,j", ExpectedResult = true)]
        public bool Test_HasAny(string commaDelimitedArray)
        {
            var enumerable = commaDelimitedArray == null
                ? null
                : commaDelimitedArray.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var result = enumerable.HasAny();

            return result;
        }

        [TestCase("", "1", ExpectedResult = false)]
        [TestCase(null, "1", ExpectedResult = false)]
        [TestCase("a1,b2,c1,d2,e1,f2,g1,h2,i1,j2", "1", ExpectedResult = true)]
        [TestCase("a1,b2,c1,d2,e1,f2,g1,h2,i1,j2", "2", ExpectedResult = true)]
        [TestCase("a1,b2,c1,d2,e1,f2,g1,h2,i1,j2", "0", ExpectedResult = false)]
        public bool Test_HasAny_predicate(string commaDelimitedArray, string suffix)
        {
            var enumerable = commaDelimitedArray == null
                ? null
                : commaDelimitedArray.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var result = enumerable.HasAny(s => s.EndsWith(suffix));

            return result;
        }
    }
}
