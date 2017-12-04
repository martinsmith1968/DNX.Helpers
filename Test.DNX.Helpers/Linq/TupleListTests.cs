using DNX.Helpers.Linq;
using NUnit.Framework;
using Should;

namespace Test.DNX.Helpers.Linq
{
    [TestFixture]
    public class TupleListTests
    {
        [Test]
        public void TupleList_2_can_construct_easily()
        {
            // Arrange


            // Act
            // ReSharper disable once UseObjectOrCollectionInitializer
            var list = new TupleList<int, int>
            {
                { 1, 2 }
            };

            list.Add(1, 2);

            // Assert
            list.ShouldNotBeNull();
            list.Count.ShouldEqual(2);
        }

        [Test]
        public void TupleList_3_can_construct_easily()
        {
            // Arrange


            // Act
            // ReSharper disable once UseObjectOrCollectionInitializer
            var list = new TupleList<int, int, int>
            {
                { 1, 2, 3 }
            };

            list.Add(1, 2, 3);

            // Assert
            list.ShouldNotBeNull();
            list.Count.ShouldEqual(2);
        }

        [Test]
        public void TupleList_4_can_construct_easily()
        {
            // Arrange


            // Act
            // ReSharper disable once UseObjectOrCollectionInitializer
            var list = new TupleList<int, int, int, int>
            {
                { 1, 2, 3, 4 }
            };

            list.Add(1, 2, 3, 4);

            // Assert
            list.ShouldNotBeNull();
            list.Count.ShouldEqual(2);
        }

        [Test]
        public void TupleList_5_can_construct_easily()
        {
            // Arrange


            // Act
            // ReSharper disable once UseObjectOrCollectionInitializer
            var list = new TupleList<int, int, int, int, int>
            {
                { 1, 2, 3, 4, 5 }
            };

            list.Add(1, 2, 3, 4, 5);

            // Assert
            list.ShouldNotBeNull();
            list.Count.ShouldEqual(2);
        }

        [Test]
        public void TupleList_6_can_construct_easily()
        {
            // Arrange


            // Act
            // ReSharper disable once UseObjectOrCollectionInitializer
            var list = new TupleList<int, int, int, int, int, int>
            {
                { 1, 2, 3, 4, 5, 6 }
            };

            list.Add(1, 2, 3, 4, 5, 6);

            // Assert
            list.ShouldNotBeNull();
            list.Count.ShouldEqual(2);
        }
    }
}
