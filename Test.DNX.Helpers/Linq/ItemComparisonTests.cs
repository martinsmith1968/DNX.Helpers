using DNX.Helpers.Linq;
using NUnit.Framework;
using Shouldly;

namespace Test.DNX.Helpers.Linq
{
    internal class MyTestClass1
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    internal class MyTestClass2
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    [TestFixture]
    public class ItemComparisonTests
    {
        [Test]
        public void ItemComparison_SourceAndTarget_CorrectProperties()
        {
            // Arrange
            var item1 = new MyTestClass1() { Id = 1, Description = "One" };
            var item2 = new MyTestClass1() { Id = 2, Description = "Two" };

            // Act
            var itemComparison = ItemComparison<MyTestClass1, MyTestClass1>.Create(item1, item2);

            // Assert
            item1.ShouldBeSameAs(itemComparison.Source);
            item2.ShouldBeSameAs(itemComparison.Target);
            itemComparison.Matched.ShouldBeTrue();
            itemComparison.SourceOnly.ShouldBeFalse();
            itemComparison.TargetOnly.ShouldBeFalse();
        }

        [Test]
        public void ItemComparison_SourceButNoTarget_CorrectProperties()
        {
            // Arrange
            var item1 = new MyTestClass1() { Id = 1, Description = "One" };

            // Act
            var itemComparison = ItemComparison<MyTestClass1, MyTestClass1>.Create(item1, null);

            // Assert
            item1.ShouldBeSameAs(itemComparison.Source);
            itemComparison.Target.ShouldBeNull();
            itemComparison.Matched.ShouldBeFalse();
            itemComparison.SourceOnly.ShouldBeTrue();
            itemComparison.TargetOnly.ShouldBeFalse();
        }

        [Test]
        public void ItemComparison_TargetButNoSource_CorrectProperties()
        {
            // Arrange
            var item2 = new MyTestClass1() { Id = 2, Description = "Two" };

            // Act
            var itemComparison = ItemComparison<MyTestClass1, MyTestClass1>.Create(null, item2);

            // Assert
            itemComparison.Source.ShouldBeNull();
            item2.ShouldBeSameAs(itemComparison.Target);
            itemComparison.Matched.ShouldBeFalse();
            itemComparison.SourceOnly.ShouldBeFalse();
            itemComparison.TargetOnly.ShouldBeTrue();
        }
    }
}
