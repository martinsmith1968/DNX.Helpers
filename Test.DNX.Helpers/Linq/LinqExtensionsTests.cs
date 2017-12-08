using System;
using System.Collections.Generic;
using DNX.Helpers.Comparisons;
using DNX.Helpers.Linq;
using NUnit.Framework;
using Shouldly;

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

        [TestCase("a,b,c", "a", ExpectedResult = true)]
        [TestCase("a,b,c", "b", ExpectedResult = true)]
        [TestCase("a,b,c", "c", ExpectedResult = true)]
        [TestCase("a,b,c", "d", ExpectedResult = false)]
        [TestCase("", "a", ExpectedResult = false)]
        [TestCase(null, "a", ExpectedResult = false)]
        public bool Test_IsIn_List(string commaDelimitedArray, string value)
        {
            var enumerable = commaDelimitedArray == null
                ? null
                : commaDelimitedArray.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            return value.IsIn(enumerable);
        }

        [TestCase("a,b,c", "A", ExpectedResult = true)]
        [TestCase("a,b,c", "B", ExpectedResult = true)]
        [TestCase("a,b,c", "c", ExpectedResult = true)]
        [TestCase("a,b,c", "d", ExpectedResult = false)]
        [TestCase("a,b,c", "D", ExpectedResult = false)]
        [TestCase("", "a", ExpectedResult = false)]
        [TestCase(null, "a", ExpectedResult = false)]
        public bool Test_IsIn_List_with_comparer(string commaDelimitedArray, string value)
        {
            var enumerable = commaDelimitedArray == null
                ? null
                : commaDelimitedArray.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var caseInsensitiveComparer = EqualityComparerFunc<string>.Create((s1, s2) => string.Equals(s1, s2, StringComparison.OrdinalIgnoreCase));

            return value.IsIn(enumerable, caseInsensitiveComparer);
        }

        [TestCase("a,b,c", "a", ExpectedResult = true)]
        [TestCase("a,b,c", "b", ExpectedResult = true)]
        [TestCase("a,b,c", "c", ExpectedResult = true)]
        [TestCase("a,b,c", "d", ExpectedResult = false)]
        [TestCase("", "a", ExpectedResult = false)]
        [TestCase(null, "a", ExpectedResult = true)]
        public bool Test_IsIn_List_with_default_return_override(string commaDelimitedArray, string value)
        {
            var enumerable = commaDelimitedArray == null
                ? null
                : commaDelimitedArray.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            return value.IsIn(enumerable, treatNullListAs: true);
        }

        [Test]
        public void Test_IsIn_Params()
        {
            "a".IsIn("a", "b", "c").ShouldBeTrue();
            "b".IsIn("a", "b", "c").ShouldBeTrue();
            "c".IsIn("a", "b", "c").ShouldBeTrue();
            "d".IsIn("a", "b", "c").ShouldBeFalse();
            "".IsIn("a", "b", "c").ShouldBeFalse();

            string nullString = null;
            nullString.IsIn("a", "b", "c").ShouldBeFalse();
        }

        [TestCase("a,b,c", "a", ExpectedResult = false)]
        [TestCase("a,b,c", "b", ExpectedResult = false)]
        [TestCase("a,b,c", "c", ExpectedResult = false)]
        [TestCase("a,b,c", "d", ExpectedResult = true)]
        [TestCase("", "a", ExpectedResult = true)]
        [TestCase(null, "a", ExpectedResult = false)]
        public bool Test_IsNotIn_List(string commaDelimitedArray, string value)
        {
            var enumerable = commaDelimitedArray == null
                ? null
                : commaDelimitedArray.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            return value.IsNotIn(enumerable);
        }

        [TestCase("a,b,c", "A", ExpectedResult = false)]
        [TestCase("a,b,c", "B", ExpectedResult = false)]
        [TestCase("a,b,c", "c", ExpectedResult = false)]
        [TestCase("a,b,c", "d", ExpectedResult = true)]
        [TestCase("", "a", ExpectedResult = true)]
        [TestCase(null, "a", ExpectedResult = false)]
        public bool Test_IsNotIn_List_with_comparer(string commaDelimitedArray, string value)
        {
            var enumerable = commaDelimitedArray == null
                ? null
                : commaDelimitedArray.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var caseInsensitiveComparer = EqualityComparerFunc<string>.Create((s1, s2) => string.Equals(s1, s2, StringComparison.OrdinalIgnoreCase));

            return value.IsNotIn(enumerable, caseInsensitiveComparer);
        }

        [TestCase("a,b,c", "a", ExpectedResult = false)]
        [TestCase("a,b,c", "b", ExpectedResult = false)]
        [TestCase("a,b,c", "c", ExpectedResult = false)]
        [TestCase("a,b,c", "d", ExpectedResult = true)]
        [TestCase("", "a", ExpectedResult = true)]
        [TestCase(null, "a", ExpectedResult = true)]
        public bool Test_IsNotIn_List_with_default_return_override(string commaDelimitedArray, string value)
        {
            var enumerable = commaDelimitedArray == null
                ? null
                : commaDelimitedArray.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            return value.IsNotIn(enumerable, treatNullListAs: true);
        }

        [Test]
        public void Test_IsNotIn_Params()
        {
            "a".IsNotIn("a", "b", "c").ShouldBeFalse();
            "b".IsNotIn("a", "b", "c").ShouldBeFalse();
            "c".IsNotIn("a", "b", "c").ShouldBeFalse();
            "d".IsNotIn("a", "b", "c").ShouldBeTrue();
            "".IsNotIn("a", "b", "c").ShouldBeTrue();

            string nullString = null;
            nullString.IsIn("a", "b", "c").ShouldBeFalse();
        }
    }
}
