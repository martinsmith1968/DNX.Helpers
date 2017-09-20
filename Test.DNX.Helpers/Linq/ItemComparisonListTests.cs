using System.Linq;
using DNX.Helpers.Linq;
using NUnit.Framework;
using Should;

namespace Test.DNX.Helpers.Linq
{
    public class ItemComparisonListTests
    {
        [Test]
        public void ItemComparisonList_MatchesItemsBetweenTwoListsOfDifferentTypes_Success()
        {
            // Arrange
            var list1 = new[]
            {
                new MyTestClass1() { Id = 1, Description = "One" },
                new MyTestClass1() { Id = 2, Description = "Two" },
                new MyTestClass1() { Id = 3, Description = "Three" },
                new MyTestClass1() { Id = 4, Description = "Four" },
            };

            var list2 = new[]
            {
                new MyTestClass2() { Id = 1, Name = "Bob" },
                new MyTestClass2() { Id = 2, Name = "Dave" },
                new MyTestClass2() { Id = 3, Name = "Steve" },
                new MyTestClass2() { Id = 4, Name = "Tom" },
            };

            // Act
            var itemComparisonList = ItemComparisonList.Create(list1, list2, (class1, class2) => class1.Id == class2.Id);

            // Assert
            itemComparisonList.ShouldNotBeNull();
            itemComparisonList.Count(ic => ic.Matched).ShouldEqual(4);
            itemComparisonList.Count(ic => ic.SourceOnly).ShouldEqual(0);
            itemComparisonList.Count(ic => ic.TargetOnly).ShouldEqual(0);
        }

        [Test]
        public void ItemComparisonList_CanLocateItemsInSourceOnlyBetweenTwoListsOfDifferentTypes_Success()
        {
            // Arrange
            var list1 = new[]
            {
                new MyTestClass1() { Id = 1, Description = "One" },
                new MyTestClass1() { Id = 2, Description = "Two" },
                new MyTestClass1() { Id = 3, Description = "Three" },
                new MyTestClass1() { Id = 4, Description = "Four" },
            };

            var list2 = new[]
            {
                new MyTestClass2() { Id = 2, Name = "Dave" },
                new MyTestClass2() { Id = 4, Name = "Tom" },
            };

            // Act
            var itemComparisonList = ItemComparisonList.Create(list1, list2, (class1, class2) => class1.Id == class2.Id);

            // Assert
            itemComparisonList.ShouldNotBeNull();
            itemComparisonList.Count(ic => ic.Matched).ShouldEqual(2);
            itemComparisonList.Count(ic => ic.SourceOnly).ShouldEqual(2);
            itemComparisonList.Count(ic => ic.TargetOnly).ShouldEqual(0);
        }

        [Test]
        public void ItemComparisonList_CanLocateItemsInTargetOnlyBetweenTwoListsOfDifferentTypes_Success()
        {
            // Arrange
            var list1 = new[]
            {
                new MyTestClass1() { Id = 1, Description = "One" },
                new MyTestClass1() { Id = 2, Description = "Two" },
                new MyTestClass1() { Id = 3, Description = "Three" },
                new MyTestClass1() { Id = 4, Description = "Four" },
            };

            var list2 = new[]
            {
                new MyTestClass2() { Id = 1, Name = "Bob" },
                new MyTestClass2() { Id = 2, Name = "Dave" },
                new MyTestClass2() { Id = 3, Name = "Steve" },
                new MyTestClass2() { Id = 4, Name = "Tom" },
                new MyTestClass2() { Id = 5, Name = "Mark" },
                new MyTestClass2() { Id = 6, Name = "John" },
            };

            // Act
            var itemComparisonList = ItemComparisonList.Create(list1, list2, (class1, class2) => class1.Id == class2.Id);

            // Assert
            itemComparisonList.ShouldNotBeNull();
            itemComparisonList.Count(ic => ic.Matched).ShouldEqual(4);
            itemComparisonList.Count(ic => ic.SourceOnly).ShouldEqual(0);
            itemComparisonList.Count(ic => ic.TargetOnly).ShouldEqual(2);
        }

        [Test]
        public void ItemComparisonList_MatchesItemsBetweenTwoListsOfSameTypes_Success()
        {
            // Arrange
            var list1 = new[]
            {
                new MyTestClass1() { Id = 1, Description = "One" },
                new MyTestClass1() { Id = 2, Description = "Two" },
                new MyTestClass1() { Id = 3, Description = "Three" },
                new MyTestClass1() { Id = 4, Description = "Four" },
            };

            var list2 = new[]
            {
                new MyTestClass1() { Id = 1, Description = "Bob" },
                new MyTestClass1() { Id = 2, Description = "Dave" },
                new MyTestClass1() { Id = 3, Description = "Steve" },
                new MyTestClass1() { Id = 4, Description = "Tom" },
            };

            // Act
            var itemComparisonList = ItemComparisonList.Create<MyTestClass1>(list1, list2, (class1, class2) => class1.Id == class2.Id);

            // Assert
            itemComparisonList.ShouldNotBeNull();
            itemComparisonList.Count(ic => ic.Matched).ShouldEqual(4);
            itemComparisonList.Count(ic => ic.SourceOnly).ShouldEqual(0);
            itemComparisonList.Count(ic => ic.TargetOnly).ShouldEqual(0);
        }

        [Test]
        public void ItemComparisonList_CanLocateItemsInSourceOnlyBetweenTwoListsOfSameTypes_Success()
        {
            // Arrange
            var list1 = new[]
            {
                new MyTestClass1() { Id = 1, Description = "One" },
                new MyTestClass1() { Id = 2, Description = "Two" },
                new MyTestClass1() { Id = 3, Description = "Three" },
                new MyTestClass1() { Id = 4, Description = "Four" },
            };

            var list2 = new[]
            {
                new MyTestClass1() { Id = 2, Description = "Dave" },
                new MyTestClass1() { Id = 4, Description = "Tom" },
            };

            // Act
            var itemComparisonList = ItemComparisonList.Create<MyTestClass1>(list1, list2, (class1, class2) => class1.Id == class2.Id);

            // Assert
            itemComparisonList.ShouldNotBeNull();
            itemComparisonList.Count(ic => ic.Matched).ShouldEqual(2);
            itemComparisonList.Count(ic => ic.SourceOnly).ShouldEqual(2);
            itemComparisonList.Count(ic => ic.TargetOnly).ShouldEqual(0);
        }

        [Test]
        public void ItemComparisonList_CanLocateItemsInTargetOnlyBetweenTwoListsOfSameTypes_Success()
        {
            // Arrange
            var list1 = new[]
            {
                new MyTestClass1() { Id = 1, Description = "One" },
                new MyTestClass1() { Id = 2, Description = "Two" },
                new MyTestClass1() { Id = 3, Description = "Three" },
                new MyTestClass1() { Id = 4, Description = "Four" },
            };

            var list2 = new[]
            {
                new MyTestClass1() { Id = 1, Description = "Bob" },
                new MyTestClass1() { Id = 2, Description = "Dave" },
                new MyTestClass1() { Id = 3, Description = "Steve" },
                new MyTestClass1() { Id = 4, Description = "Tom" },
                new MyTestClass1() { Id = 5, Description = "Mark" },
                new MyTestClass1() { Id = 6, Description = "John" },
            };

            // Act
            var itemComparisonList = ItemComparisonList.Create<MyTestClass1>(list1, list2, (class1, class2) => class1.Id == class2.Id);

            // Assert
            itemComparisonList.ShouldNotBeNull();
            itemComparisonList.Count(ic => ic.Matched).ShouldEqual(4);
            itemComparisonList.Count(ic => ic.SourceOnly).ShouldEqual(0);
            itemComparisonList.Count(ic => ic.TargetOnly).ShouldEqual(2);
        }
    }
}
