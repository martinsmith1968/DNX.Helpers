using DNX.Helpers.Exceptions;
using NUnit.Framework;
using Should;

namespace Test.DNX.Helpers.Exceptions
{
    [TestFixture]
    public class EnumTypeExceptionTests
    {
        [Test]
        public void Test_EnumTypeException_constructor_type()
        {
            // Arrange
            var type = typeof(int);

            // Act
            var ex = new EnumTypeException(type);

            // Assert
            ex.ShouldNotBeNull();
            ex.Type.ShouldEqual(type);
        }

        [Test]
        public void Test_EnumTypeException_constructor_type_messageTemplate()
        {
            // Arrange
            var messageTemplate = "Customer message about: {0}";
            var type = typeof(int);

            // Act
            var ex = new EnumTypeException(type, messageTemplate);

            // Assert
            ex.ShouldNotBeNull();
            ex.Type.ShouldEqual(type);
            ex.Message.ShouldEqual(ex.Message.Replace("{0}", type.Name));
        }
    }
}
