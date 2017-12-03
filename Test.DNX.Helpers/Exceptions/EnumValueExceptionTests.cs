using DNX.Helpers.Exceptions;
using NUnit.Framework;
using Should;

namespace Test.DNX.Helpers.Exceptions
{
    internal enum MyEnumValueTestEnum
    {
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5
    }

    [TestFixture]
    public class EnumValueExceptionTests
    {
        [Test]
        public void Test_EnumValueException_constructor_valid_value()
        {
            // Arrange
            var value = MyEnumValueTestEnum.Four;

            // Act
            var ex = new EnumValueException<MyEnumValueTestEnum>(value);

            // Assert
            ex.ShouldNotBeNull();
            ex.Type.ShouldEqual(value.GetType());
            ex.Value.ShouldEqual(value);
            ex.Message.ShouldContain(typeof(MyEnumValueTestEnum).Name);
            ex.Message.ShouldContain(value.ToString());
        }

        [Test]
        public void Test_EnumValueException_constructor_valid_value_messageTemplate()
        {
            // Arrange
            var messageTemplate = "Customer message about: {0}";
            var value = MyEnumValueTestEnum.Three;

            // Act
            var ex = new EnumValueException<MyEnumValueTestEnum>(value, messageTemplate);

            // Assert
            ex.ShouldNotBeNull();
            ex.Type.ShouldEqual(value.GetType());
            ex.Message.ShouldEqual(ex.Message.Replace("{0}", value.ToString()).Replace("{1}", value.GetType().Name));
        }

        [Test]
        public void Test_EnumValueException_constructor_invalid_value()
        {
            // Arrange
            var value = (MyEnumValueTestEnum)int.MaxValue;

            // Act
            var ex = new EnumValueException<MyEnumValueTestEnum>(value);

            // Assert
            ex.ShouldNotBeNull();
            ex.Type.ShouldEqual(value.GetType());
            ex.Value.ShouldEqual(value);
            ex.Message.ShouldContain(typeof(MyEnumValueTestEnum).Name);
            ex.Message.ShouldContain(value.ToString());
        }

        [Test]
        public void Test_EnumValueException_constructor_invalid_value_messageTemplate()
        {
            // Arrange
            var messageTemplate = "Customer message about: {0} - {1}";
            var value = (MyEnumValueTestEnum) int.MaxValue;

            // Act
            var ex = new EnumValueException<MyEnumValueTestEnum>(value, messageTemplate);

            // Assert
            ex.ShouldNotBeNull();
            ex.Type.ShouldEqual(value.GetType());
            ex.Message.ShouldEqual(ex.Message.Replace("{0}", value.ToString()).Replace("{1}", value.GetType().Name));
        }
    }
}
