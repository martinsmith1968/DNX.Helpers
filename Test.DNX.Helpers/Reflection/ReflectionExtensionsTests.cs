using System;
using System.Collections.Generic;
using System.Linq;
using DNX.Helpers.Reflection;
using FizzWare.NBuilder;
using NUnit.Framework;
using Should;

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
    }

    [TestFixture]
    public class ReflectionExtensionsTests
    {

        [Test]
        public void ToDictionary_can_convert_a_populated_instance_to_a_dictionary_successfully()
        {
            // Arrange
            var instance = Builder<MyTestClass1>
                .CreateNew()
                .Build();

            // Act
            var result = instance.ToDictionary();

            // Assert
            result.ShouldNotBeNull();
            result.ContainsKey("Name").ShouldBeTrue();
            result.ContainsKey("Integer").ShouldBeTrue();
            result.ContainsKey("FloatingPoint").ShouldBeTrue();
            result.ContainsKey("DateAndTime").ShouldBeTrue();
            result.ContainsKey("Enum1Value").ShouldBeTrue();
            result["Name"].ShouldEqual(instance.Name);
            result["Integer"].ShouldEqual(instance.Integer);
            result["FloatingPoint"].ShouldEqual(instance.FloatingPoint);
            result["DateAndTime"].ShouldEqual(instance.DateAndTime);
            result["Enum1Value"].ShouldEqual(instance.Enum1Value);
        }

        [Test]
        public void ToInstance_can_convert_a_dictionary_to_a_populated_instance_successfully()
        {
            // Arrange
            var dict = new Dictionary<string, object>()
            {
                { "Name", "Bob" },
                { "Integer", 911 },
                { "FloatingPoint", 1234.56d },
                { "DateAndTime", DateTime.UtcNow },
                { "Enum1Value", MyEnum1.NonBinary },
            };

            // Act
            var result = dict.ToInstance<MyTestClass1>();

            // Assert
            result.ShouldNotBeNull();
            result.Name.ShouldEqual(dict["Name"]);
            result.Integer.ShouldEqual(dict["Integer"]);
            result.FloatingPoint.ShouldEqual(dict["FloatingPoint"]);
            result.DateAndTime.ShouldEqual(dict["DateAndTime"]);
            result.Enum1Value.ShouldEqual(dict["Enum1Value"]);
        }
    }
}
