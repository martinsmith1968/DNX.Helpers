using System;
using System.Collections.Specialized;
using System.Linq;
using DNX.Helpers.Linq;
using NUnit.Framework;
using Should;

namespace Test.DNX.Helpers.Linq
{
    [TestFixture]
    public class NameValueExtensionsTests
    {
        [Test]
        public void Can_convert_a_NameValueCollection_using_Unique_successfully()
        {
            // Arrange
            var collection = new NameValueCollection
            {
                { "One", "1" },
                { "Two", "2" },
                { "Three", "3" },
                { "Four", "4" },
                { "Five", "5" },
            };

            // Act
            var result = collection.ToDictionary(MergeTechnique.Unique);

            // Assert
            result.ShouldNotBeNull();
            result.Count.ShouldEqual(collection.Count);

            foreach (var key in collection.AllKeys)
            {
                result.ContainsKey(key).ShouldBeTrue();
                result[key].ShouldEqual(collection[key]);
            }
        }

        [Test]
        public void Can_convert_a_NameValueCollection_using_First_successfully()
        {
            // Arrange
            var collection = new NameValueCollection
            {
                { "One", "1" },
                { "Two", "2" },
                { "One", "3" },
                { "Two", "4" },
                { "Three", "5" },
            };

            // Act
            var result = collection.ToDictionary(MergeTechnique.TakeFirst);

            // Assert
            result.ShouldNotBeNull();
            result.Count.ShouldEqual(collection.AllKeys.Distinct().Count());

            result["One"].ShouldEqual("1");
            result["Two"].ShouldEqual("2");
            result["Three"].ShouldEqual("5");
        }

        [Test]
        public void Can_convert_a_NameValueCollection_using_Last_successfully()
        {
            // Arrange
            var collection = new NameValueCollection
            {
                { "One", "1" },
                { "Two", "2" },
                { "One", "3" },
                { "Two", "4" },
                { "Three", "5" },
            };

            // Act
            var result = collection.ToDictionary(MergeTechnique.TakeLast);

            // Assert
            result.ShouldNotBeNull();
            result.Count.ShouldEqual(collection.AllKeys.Distinct().Count());

            result["One"].ShouldEqual("3");
            result["Two"].ShouldEqual("4");
            result["Three"].ShouldEqual("5");
        }

        [Test]
        public void Converting_a_NameValueCollection_using_Unique_with_duplictes_fails()
        {
            // Arrange
            var collection = new NameValueCollection
            {
                { "One", "1" },
                { "Two", "2" },
                { "One", "3" },
                { "Two", "4" },
                { "Three", "5" },
            };

            try
            {
                // Act
                var result = collection.ToDictionary(MergeTechnique.Unique);

                Assert.Fail("Expected exception not thrown");
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldNotBeNull();
                ex.Message.ShouldNotBeEmpty();
            }
        }
    }
}
