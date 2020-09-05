using System;
using System.Collections.Generic;
using System.Linq;
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
            var enumerable = commaDelimitedArray?
                .Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

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
            var enumerable = commaDelimitedArray?
                .Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var result = enumerable.HasAny(s => s.EndsWith(suffix));

            return result;
        }

        [TestCase("1,2,3,4,5", 0, "1")]
        [TestCase("1,2,3,4,5", 2, "3")]
        [TestCase("1,2,3,4,5", 4, "5")]
        [TestCase("1,2,3,4,5", -1, "5")]
        [TestCase("1,2,3,4,5", 5, null)]
        [TestCase("1,2,3,4,5", 6, null)]
        [TestCase("1,2,3,4,5", 100, null)]
        [TestCase("1,2,3,4,5", -100, "1")]
        public void GetAt_Populated_List_repeatedly_returns_an_item_successfully(string itemList, int index, string expected)
        {
            // Arrange
            var items = itemList.Split(",", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            // Act
            var result = items.GetAt(index);

            // Assert
            result.ShouldBe(expected);
        }

        [TestCase("1,2,3,4,5", 0, "1")]
        [TestCase("1,2,3,4,5", 2, "3")]
        [TestCase("1,2,3,4,5", 4, "5")]
        [TestCase("1,2,3,4,5", -1, "5")]
        [TestCase("1,2,3,4,5", 5, null)]
        [TestCase("1,2,3,4,5", 6, null)]
        [TestCase("1,2,3,4,5", 100, null)]
        [TestCase("1,2,3,4,5", -100, "1")]
        public void GetAt_Populated_Array_repeatedly_returns_an_item_successfully(string itemList, int index, string expected)
        {
            // Arrange
            var items = itemList.Split(",", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            // Act
            var result = items.GetAt(index);

            // Assert
            result.ShouldBe(expected);
        }

        [Test]
        public void GetAt_Empty_IList_returns_default()
        {
            // Arrange
            var items = Enumerable.Empty<string>()
                .ToList();

            // Act
            var result = items.GetAt(0);

            // Assert
            result.ShouldBeNull();
        }

        [Test]
        public void GetAt_Empty_Array_returns_default()
        {
            // Arrange
            var items = Array.Empty<string>();

            // Act
            var result = items.GetAt(0);

            // Assert
            result.ShouldBeNull();
        }

        [Test]
        public void GetAt_Null_IList_returns_default()
        {
            // Arrange
            List<string> items = null;

            // Act
            var result = items.GetAt(0);

            // Assert
            result.ShouldBeNull();
        }

        [Test]
        public void GetAt_Null_Array_returns_default()
        {
            // Arrange
            string[] items = null;

            // Act
            var result = items.GetAt(0);

            // Assert
            result.ShouldBeNull();
        }

        [TestCase("a,b,c", "a", ExpectedResult = true)]
        [TestCase("a,b,c", "b", ExpectedResult = true)]
        [TestCase("a,b,c", "c", ExpectedResult = true)]
        [TestCase("a,b,c", "d", ExpectedResult = false)]
        [TestCase("", "a", ExpectedResult = false)]
        [TestCase(null, "a", ExpectedResult = false)]
        public bool Test_IsIn_List(string commaDelimitedArray, string value)
        {
            var enumerable = commaDelimitedArray?
                .Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

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
            var enumerable = commaDelimitedArray?
                .Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

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
            var enumerable = commaDelimitedArray?
                .Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

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
            var enumerable = commaDelimitedArray?
                .Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

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
            var enumerable = commaDelimitedArray?
                .Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

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
            var enumerable = commaDelimitedArray?
                .Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

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

        [TestCase("a,b,c", "d", ExpectedResult = "a,b,c,d")]
        [TestCase("a,b,c", "a", ExpectedResult = "a,b,c,a")]
        [TestCase(null, "a", ExpectedResult = "a")]
        [TestCase("", "a", ExpectedResult = "a")]
        public string Test_AppendItem(string commaDelimitedArray, string value)
        {
            var enumerable = commaDelimitedArray?
                .Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var result = enumerable.AppendItem(value);

            return string.Join(",", result);
        }

        [TestCase("a,b,c", "d", ExpectedResult = "a,b,c,d")]
        [TestCase("a,b,c,d", "D", ExpectedResult = "a,b,c,d")]
        [TestCase("a,b,c", "a", ExpectedResult = "a,b,c")]
        [TestCase(null, "a", ExpectedResult = "a")]
        [TestCase("", "a", ExpectedResult = "a")]
        public string Test_Append_CaseInsensitiveComparer(string commaDelimitedArray, string value)
        {
            var comparer = EqualityComparerFunc<string>.Create(
                (s1, s2) => string.Equals(s1, s2, StringComparison.OrdinalIgnoreCase)
            );

            var enumerable = commaDelimitedArray?
                .Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var result = enumerable.AppendItem(value, comparer);

            return string.Join(",", result);
        }
    }
}
