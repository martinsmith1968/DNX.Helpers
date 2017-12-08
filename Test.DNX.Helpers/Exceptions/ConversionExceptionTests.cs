using DNX.Helpers.Exceptions;
using NUnit.Framework;
using Shouldly;

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
            value.ShouldBe(ex.Value);
            message.ShouldBe(ex.Message);
            ex.ConvertType.ShouldBeNull();
        }

        [Test]
        public void Test_ConversionException_constructor_value_message_type()
        {
            // Arrange
            var value = "abc";
            var message = "Unable to convert value";
            var type = typeof(int);

            // Act
            var ex = new ConversionException(value, message, type);

            // Assert
            ex.ShouldNotBeNull();
            value.ShouldBe(ex.Value);
            message.ShouldBe(ex.Message);
            type.ShouldBe(ex.ConvertType);

            Assert.IsNotNull(ex);
            Assert.AreEqual(value, ex.Value);
            Assert.AreEqual(message, ex.Message);
            Assert.AreEqual(type, ex.ConvertType);
        }
    }
}
