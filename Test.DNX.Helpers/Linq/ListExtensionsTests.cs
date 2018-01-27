using System;
using System.Linq;
using DNX.Helpers.Exceptions;
using DNX.Helpers.Linq;
using NUnit.Framework;
using Shouldly;

namespace Test.DNX.Helpers.Linq
{
    [TestFixture]
    public class ListExtensionsTests
    {
        [TestCase("a,b,c,d,e,f,g,h,i,j", 0, ExpectedResult = true)]
        [TestCase("a,b,c,d,e,f,g,h,i,j", 5, ExpectedResult = true)]
        [TestCase("a,b,c,d,e,f,g,h,i,j", 11, ExpectedResult = false)]
        [TestCase("a,b,c,d,e,f,g,h,i,j", 10, ExpectedResult = false)]
        [TestCase("a,b,c,d,e,f,g,h,i,j", -1, ExpectedResult = false)]
        [TestCase("a,b,c,d,e,f,g,h,i,j", -4, ExpectedResult = false)]
        [TestCase("a,b,c,d,e,f,g,h,i,j", -15, ExpectedResult = false)]
        [TestCase("", 5, ExpectedResult = false)]
        [TestCase(null, 5, ExpectedResult = false)]
        public bool Test_IsValidIndex(string commaDelimitedArray, int index)
        {
            var array = string.IsNullOrEmpty(commaDelimitedArray)
                ? null
                : commaDelimitedArray.Split(",".ToCharArray());

            var result = array.IsIndexValid(index);

            return result;
        }

        [TestCase("a,b,c,d,e,f,g,h,i,j", 0, ExpectedResult = 0)]
        [TestCase("a,b,c,d,e,f,g,h,i,j", 5, ExpectedResult = 5)]
        [TestCase("a,b,c,d,e,f,g,h,i,j", 11, ExpectedResult = 11)]
        [TestCase("a,b,c,d,e,f,g,h,i,j", 10, ExpectedResult = 10)]
        [TestCase("a,b,c,d,e,f,g,h,i,j", -1, ExpectedResult = 9)]
        [TestCase("a,b,c,d,e,f,g,h,i,j", -4, ExpectedResult = 6)]
        [TestCase("a,b,c,d,e,f,g,h,i,j", -15, ExpectedResult = 5)]
        [TestCase("", 5, ExpectedResult = 5)]
        [TestCase(null, 5, ExpectedResult = 5)]
        public int Test_GetAbsoluteIndex(string commaDelimitedArray, int index)
        {
            var array = string.IsNullOrEmpty(commaDelimitedArray)
                ? null
                : commaDelimitedArray.Split(",".ToCharArray());

            var result = array.GetAbsoluteIndex(index);

            return result;
        }

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

        [TestCase("a,b,c,d,e,f,g,h,i,j", 1, 5, ExpectedResult = "a,c,d,e,f,b,g,h,i,j")]
        [TestCase("a,b,c,d,e,f,g,h,i,j", 4, 0, ExpectedResult = "e,a,b,c,d,f,g,h,i,j")]
        [TestCase("a,b,c,d,e,f,g,h,i,j", 3, -1, ExpectedResult = "a,b,c,e,f,g,h,i,j,d")]
        public string Test_Move(string commaDelimitedArray, int oldIndex, int newIndex)
        {
            var enumerable = commaDelimitedArray == null
                ? null
                : commaDelimitedArray.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

            enumerable.Move(oldIndex, newIndex);

            return enumerable == null
                ? string.Empty
                : string.Join(",", enumerable);
        }

        [TestCase("a,b,c,d,e,f,g,h,i,j", 1, 5, ExpectedResult = false)]
        [TestCase("a,b,c,d,e,f,g,h,i,j", 4, 0, ExpectedResult = false)]
        [TestCase("a,b,c,d,e,f,g,h,i,j", 3, -1, ExpectedResult = false)]
        public bool Test_Move_ReadOnly(string commaDelimitedArray, int oldIndex, int newIndex)
        {
            var enumerable = commaDelimitedArray == null
                ? null
                : commaDelimitedArray.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            try
            {
                enumerable.Move(oldIndex, newIndex);

                return true;
            }
            catch (ReadOnlyListException<string>)
            {
                return false;
            }
        }

        [TestCase("a,b,c,d,e,f,g,h,i,j", 21, 5, ExpectedResult = false)]
        [TestCase("a,b,c,d,e,f,g,h,i,j", 14, 0, ExpectedResult = false)]
        [TestCase("a,b,c,d,e,f,g,h,i,j", 1023, -1, ExpectedResult = false)]
        public bool Test_Move_BadOldIndex(string commaDelimitedArray, int oldIndex, int newIndex)
        {
            var enumerable = commaDelimitedArray == null
                ? null
                : commaDelimitedArray.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            try
            {
                enumerable.Move(oldIndex, newIndex);

                return true;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                if (ex.ParamName != "oldIndex")
                    throw new Exception("Incorrect parameter name - " + ex.ParamName);

                return false;
            }
        }

        [TestCase("a,b,c,d,e,f,g,h,i,j", 5, 21, ExpectedResult = false)]
        [TestCase("a,b,c,d,e,f,g,h,i,j", 0, 14, ExpectedResult = false)]
        [TestCase("a,b,c,d,e,f,g,h,i,j", -1, 1023, ExpectedResult = false)]
        public bool Test_Move_BadNewIndex(string commaDelimitedArray, int oldIndex, int newIndex)
        {
            var enumerable = commaDelimitedArray == null
                ? null
                : commaDelimitedArray.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            try
            {
                enumerable.Move(oldIndex, newIndex);

                return true;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                if (ex.ParamName != "newIndex")
                    throw new Exception("Incorrect parameter name - " + ex.ParamName);

                return false;
            }
        }

        [TestCase("a,b,c,d,e,f,g,h,i,j", 1, 5, ExpectedResult = "a,f,c,d,e,b,g,h,i,j")]
        [TestCase("a,b,c,d,e,f,g,h,i,j", 4, 0, ExpectedResult = "e,b,c,d,a,f,g,h,i,j")]
        [TestCase("a,b,c,d,e,f,g,h,i,j", 3, -1, ExpectedResult = "a,b,c,j,e,f,g,h,i,d")]
        public string Test_Swap(string commaDelimitedArray, int oldIndex, int newIndex)
        {
            var enumerable = commaDelimitedArray == null
                ? null
                : commaDelimitedArray.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

            enumerable.Swap(oldIndex, newIndex);

            return enumerable == null
                ? string.Empty
                : string.Join(",", enumerable);
        }

        [TestCase("a,b,c,d,e,f,g,h,i,j", 1, 5, ExpectedResult = false)]
        [TestCase("a,b,c,d,e,f,g,h,i,j", 4, 0, ExpectedResult = false)]
        [TestCase("a,b,c,d,e,f,g,h,i,j", 3, -1, ExpectedResult = false)]
        public bool Test_Swap_ReadOnly(string commaDelimitedArray, int oldIndex, int newIndex)
        {
            var enumerable = commaDelimitedArray == null
                ? null
                : commaDelimitedArray.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            try
            {
                enumerable.Swap(oldIndex, newIndex);

                return true;
            }
            catch (ReadOnlyListException<string>)
            {
                return false;
            }
        }

        [TestCase("a,b,c,d,e,f,g,h,i,j", 21, 5, ExpectedResult = false)]
        [TestCase("a,b,c,d,e,f,g,h,i,j", 14, 0, ExpectedResult = false)]
        [TestCase("a,b,c,d,e,f,g,h,i,j", 1023, -1, ExpectedResult = false)]
        public bool Test_Swap_BadOldIndex(string commaDelimitedArray, int oldIndex, int newIndex)
        {
            var enumerable = commaDelimitedArray == null
                ? null
                : commaDelimitedArray.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

            try
            {
                enumerable.Swap(oldIndex, newIndex);

                return true;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                if (ex.ParamName != "oldIndex")
                    throw new Exception("Incorrect parameter name - " + ex.ParamName);

                return false;
            }
        }

        [TestCase("a,b,c,d,e,f,g,h,i,j", 5, 21, ExpectedResult = false)]
        [TestCase("a,b,c,d,e,f,g,h,i,j", 0, 14, ExpectedResult = false)]
        [TestCase("a,b,c,d,e,f,g,h,i,j", -1, 1023, ExpectedResult = false)]
        public bool Test_Swap_BadNewIndex(string commaDelimitedArray, int oldIndex, int newIndex)
        {
            var enumerable = commaDelimitedArray == null
                ? null
                : commaDelimitedArray.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

            try
            {
                enumerable.Swap(oldIndex, newIndex);

                return true;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                if (ex.ParamName != "newIndex")
                    throw new Exception("Incorrect parameter name - " + ex.ParamName);

                return false;
            }
        }

        [Test]
        public void CreateList_can_create_appropriate_lists()
        {
            // Arrange


            // Act
            var list1 = ListExtensions.CreateList(1);
            var list2 = ListExtensions.CreateList(1, 2);
            var list3 = ListExtensions.CreateList(1, 2, 3);
            var list4 = ListExtensions.CreateList(1, 2, 3, 4);
            var list5 = ListExtensions.CreateList(1, 2, 3, 4, 5);

            // Assert
            list1.ShouldNotBeNull();
            list1.Count.ShouldBe(1);
            list1[0].ShouldBe(1);

            list2.ShouldNotBeNull();
            list2.Count.ShouldBe(2);
            list2[0].ShouldBe(1);
            list2[1].ShouldBe(2);

            list3.ShouldNotBeNull();
            list3.Count.ShouldBe(3);
            list3[0].ShouldBe(1);
            list3[1].ShouldBe(2);
            list3[2].ShouldBe(3);

            list4.ShouldNotBeNull();
            list4.Count.ShouldBe(4);
            list4[0].ShouldBe(1);
            list4[1].ShouldBe(2);
            list4[2].ShouldBe(3);
            list4[3].ShouldBe(4);

            list5.ShouldNotBeNull();
            list5.Count.ShouldBe(5);
            list5[0].ShouldBe(1);
            list5[1].ShouldBe(2);
            list5[2].ShouldBe(3);
            list5[3].ShouldBe(4);
            list5[4].ShouldBe(5);
        }
    }
}
