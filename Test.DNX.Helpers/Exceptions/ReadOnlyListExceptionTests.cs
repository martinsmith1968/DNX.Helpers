using System.Linq;
using DNX.Helpers.Exceptions;
using NUnit.Framework;
using Shouldly;

namespace Test.DNX.Helpers.Exceptions
{
    [TestFixture]
    public class ReadOnlyListExceptionTests
    {
        [Test]
        public void Test_ReadOnlyListException_constructor_list()
        {
            // Arrange
            var list = "abcdefghij".ToCharArray().ToList();

            // Act
            var ex = new ReadOnlyListException<char>(list);

            // Assert
            ex.ShouldNotBeNull();
            ex.List.ShouldBe(list);
        }
    }
}
