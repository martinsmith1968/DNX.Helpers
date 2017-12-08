using System;
using System.Collections.Generic;
using System.Linq;
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
            result["Name"].ShouldBe(instance.Name);
            result["Integer"].ShouldBe(instance.Integer);
            result["FloatingPoint"].ShouldBe(instance.FloatingPoint);
            result["DateAndTime"].ShouldBe(instance.DateAndTime);
            result["Enum1Value"].ShouldBe(instance.Enum1Value);
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
            result.Name.ShouldBe(dict["Name"]);
            result.Integer.ShouldBe(dict["Integer"]);
            result.FloatingPoint.ShouldBe(dict["FloatingPoint"]);
            result.DateAndTime.ShouldBe(dict["DateAndTime"]);
            result.Enum1Value.ShouldBe(dict["Enum1Value"]);
        }
    }
}
