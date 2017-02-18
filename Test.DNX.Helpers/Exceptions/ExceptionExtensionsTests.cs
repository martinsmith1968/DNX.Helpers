using System;
using DNX.Helpers.Exceptions;
using NUnit.Framework;
using Should;

namespace Test.DNX.Helpers.Exceptions
{
    [TestFixture]
    public class ExceptionExtensionsTests
    {
        [Test]
        public void can_extract_a_list_of_exceptions()
        {
            // Arrange
            var ex1 = new Exception("ex1");
            var ex2 = new Exception("ex2", ex1);
            var ex3 = new Exception("ex3", ex2);
            var ex4 = new Exception("ex4", ex3);

            // Act
            var list = ex4.GetExceptionList();

            // Assert
            list.ShouldNotBeNull();
            list.Count.ShouldEqual(4);
            list[0].ShouldEqual(ex4);
            list[1].ShouldEqual(ex3);
            list[2].ShouldEqual(ex2);
            list[3].ShouldEqual(ex1);
        }

        [Test]
        public void can_extract_a_list_of_exception_message()
        {
            // Arrange
            var ex1 = new Exception("ex1");
            var ex2 = new Exception("ex2", ex1);
            var ex3 = new Exception("ex3", ex2);
            var ex4 = new Exception("ex4", ex3);

            // Act
            var list = ex4.GetMessageList();

            // Assert
            list.ShouldNotBeNull();
            list.Count.ShouldEqual(4);
            list[0].ShouldEqual(ex4.Message);
            list[1].ShouldEqual(ex3.Message);
            list[2].ShouldEqual(ex2.Message);
            list[3].ShouldEqual(ex1.Message );
        }
    }
}
