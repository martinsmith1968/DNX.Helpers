using DNX.Helpers.Exceptions;
using NUnit.Framework;
using Should;

namespace Test.DNX.Helpers.Exceptions
{
    [TestFixture]
    public class ConversionExceptionTests
    {
        [Test]
        public void Test_ConversionException_constructor_value_message()
        {
            // Arrange
            var value = "abc";
            var message = "Unable to convert value";

            // Act
            var ex = new ConversionException(value, message);

            // Assert
            ex.ShouldNotBeNull();
            value.ShouldEqual(ex.Value);
            message.ShouldEqual(ex.Message);
            ex.ConvertType.ShouldBeNull();
        }

        [Test]
        public void Test_ConversionException1()
        {
            // Arrange
            var value = "abc";
            var message = "Unable to convert value";
            var type = typeof(int);

            // Act
            var ex = new ConversionException(value, message, type);

            // Assert
            ex.ShouldNotBeNull();
            value.ShouldEqual(ex.Value);
            message.ShouldEqual(ex.Message);
            type.ShouldEqual(ex.ConvertType);

            Assert.IsNotNull(ex);
            Assert.AreEqual(value, ex.Value);
            Assert.AreEqual(message, ex.Message);
            Assert.AreEqual(type, ex.ConvertType);
        }
    }
}
