using System;
using DNX.Helpers.Linq;
using NUnit.Framework;

namespace Test.DNX.Helpers.Linq
{
    [TestFixture]
    public class LinqExtensionsTests
    {
        [TestCase("a,b,c,d,e,f,g,h,i,j", 0, ExpectedResult = "a")]
        [TestCase("a,b,c,d,e,f,g,h,i,j", 5, ExpectedResult = "f")]
        [TestCase("a,b,c,d,e,f,g,h,i,j", 9, ExpectedResult = "j")]
        [TestCase("a,b,c,d,e,f,g,h,i,j", 10, ExpectedResult = null)]
        [TestCase("a,b,c,d,e,f,g,h,i,j", -1, ExpectedResult = "j")]
        [TestCase("a,b,c,d,e,f,g,h,i,j", -15, ExpectedResult = "f")]
        [TestCase("", 5, ExpectedResult = null)]
        [TestCase(null, 5, ExpectedResult = null)]
        public string Test_GetAt(string commaDelimitedArray, int index)
        {
            var array = string.IsNullOrEmpty(commaDelimitedArray)
                ? null
                : commaDelimitedArray.Split(",".ToCharArray());

            var result = array.GetAt(index);

            return result;
        }

        [TestCase("", ExpectedResult = false)]
        [TestCase(null, ExpectedResult = false)]
        [TestCase("a,b,c,d,e,f,g,h,i,j", ExpectedResult = true)]
        public bool Test_HasAny(string commaDeleimitedArray)
        {
            var enumerable = commaDeleimitedArray == null
                ? null
                : commaDeleimitedArray.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

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
