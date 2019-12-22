using System;
using System.Collections.Generic;
using System.Reflection;
using DNX.Helpers.Reflection;
using FizzWare.NBuilder;
using NUnit.Framework;
using Shouldly;

namespace Test.DNX.Helpers.Reflection
{
    internal enum MyEnum1
    {
        Male,
        Female,
        NonBinary
    }

    internal class MyTestClass1
    {
        public string Name { get; set; }

        public int Integer { get; set; }

        public double FloatingPoint { get; set; }

        public DateTime DateAndTime { get; set; }

        public MyEnum1 Enum1Value { get; set; }

        public static int NameLength = 12; //nameof(MyTestClass1).Length;

        public static int ThisYear => DateTime.UtcNow.Year;
    }

    [TestFixture]
    public class ReflectionExtensionsTests
    {
        [Test]
        public void AsDictionary_can_convert_a_populated_instance_to_a_default_dictionary_successfully()
        {
            // Arrange
            var instance = Builder<MyTestClass1>
                .CreateNew()
                .Build();

            // Act
            var result = instance.AsDictionary();

            // Assert
            result.ShouldNotBeNull();
            result.Count.ShouldBe(5);
            result.Keys.ShouldContain(nameof(MyTestClass1.Name));
            result.Keys.ShouldContain(nameof(MyTestClass1.Integer));
            result.Keys.ShouldContain(nameof(MyTestClass1.FloatingPoint));
            result.Keys.ShouldContain(nameof(MyTestClass1.DateAndTime));
            result.Keys.ShouldContain(nameof(MyTestClass1.Enum1Value));
            result[nameof(MyTestClass1.Name)].ShouldBe(instance.Name);
            result[nameof(MyTestClass1.Integer)].ShouldBe(instance.Integer);
            result[nameof(MyTestClass1.FloatingPoint)].ShouldBe(instance.FloatingPoint);
            result[nameof(MyTestClass1.DateAndTime)].ShouldBe(instance.DateAndTime);
            result[nameof(MyTestClass1.Enum1Value)].ShouldBe(instance.Enum1Value);
        }

        [Test]
        public void AsDictionary_can_convert_a_populated_instance_to_a_dictionary_successfully_overriding_for_static_properties_and_fields()
        {
            // Arrange
            const BindingFlags propertyBindings = BindingFlags.Static | BindingFlags.Public;
            var instance = Builder<MyTestClass1>
                .CreateNew()
                .Build();

            // Act
            var result = instance.AsDictionary(propertyBindings);

            // Assert
            result.ShouldNotBeNull();
            result.Count.ShouldBe(2);
            result.Keys.ShouldContain(nameof(MyTestClass1.ThisYear));
            result.Keys.ShouldContain(nameof(MyTestClass1.NameLength));
            result[nameof(MyTestClass1.ThisYear)].ShouldBe(MyTestClass1.ThisYear);
            result[nameof(MyTestClass1.NameLength)].ShouldBe(MyTestClass1.NameLength);
        }

        [Test]
        public void ToInstance_can_convert_a_dictionary_to_a_populated_instance_successfully()
        {
            // Arrange
            var dict = new Dictionary<string, object>()
            {
                { nameof(MyTestClass1.Name), "Bob" },
                { nameof(MyTestClass1.Integer), 911 },
                { nameof(MyTestClass1.FloatingPoint), 1234.56d },
                { nameof(MyTestClass1.DateAndTime), DateTime.UtcNow },
                { nameof(MyTestClass1.Enum1Value), MyEnum1.NonBinary },
            };

            // Act
            var result = dict.AsInstance<MyTestClass1>();

            // Assert
            result.ShouldNotBeNull();
            result.Name.ShouldBe(dict[nameof(MyTestClass1.Name)]);
            result.Integer.ShouldBe(dict[nameof(MyTestClass1.Integer)]);
            result.FloatingPoint.ShouldBe(dict[nameof(MyTestClass1.FloatingPoint)]);
            result.DateAndTime.ShouldBe(dict[nameof(MyTestClass1.DateAndTime)]);
            result.Enum1Value.ShouldBe(dict[nameof(MyTestClass1.Enum1Value)]);
        }
    }
}
