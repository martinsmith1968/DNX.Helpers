using System.Dynamic;
using DNX.Helpers.Reflection;
using FizzWare.NBuilder;
using NUnit.Framework;
using Shouldly;
using Test.DNX.Helpers.Strings.Interpolation.Data;

namespace Test.DNX.Helpers.Strings.Interpolation
{
    public class NamedInstanceTests
    {
        [Test]
        public void AsDictionary_handles_nulls()
        {
            // Arrange
            Person instance = null;

            // Act
            var properties = instance.AsDictionary();

            // Assert
            properties.ShouldBeNull();
        }

        [Test]
        public void AsDictionary_can_detect_all_default_properties_of_POCO_Person()
        {
            // Arrange
            var instance = Builder<Person>
                .CreateNew()
                .Build();

            // Act
            var properties = instance.AsDictionary();

            // Assert
            properties.ShouldNotBeNull();
            properties.Count.ShouldBe(5);
            properties.Keys.ShouldContain(nameof(Person.FirstName));
            properties.Keys.ShouldContain(nameof(Person.LastName));
            properties.Keys.ShouldContain(nameof(Person.DateOfBirth));
            properties.Keys.ShouldContain(nameof(Person.AgeInYears));
            properties.Keys.ShouldContain(nameof(Person.YearOfBirth));
            properties[nameof(Person.FirstName)].ShouldBe(instance.FirstName);
            properties[nameof(Person.LastName)].ShouldBe(instance.LastName);
            properties[nameof(Person.DateOfBirth)].ShouldBe(instance.DateOfBirth);
            properties[nameof(Person.AgeInYears)].ShouldBe(instance.AgeInYears);
            properties[nameof(Person.YearOfBirth)].ShouldBe(instance.YearOfBirth);
        }

        [Test]
        public void AsDictionary_can_detect_all_default_properties_of_Expando()
        {
            // Arrange
            var sample = Builder<Person>
                .CreateNew()
                .Build();

            dynamic instance = new ExpandoObject();
            instance.FirstName = sample.FirstName;
            instance.LastName = sample.LastName;
            instance.DateOfBirth = sample.DateOfBirth;
            instance.AgeInYears = sample.AgeInYears;
            instance.YearOfBirth = sample.YearOfBirth;

            // Act
            var properties = (instance as ExpandoObject).AsDictionary();

            // Assert
            properties.ShouldNotBeNull();
            properties.Count.ShouldBe(5);
            properties.Keys.ShouldContain(nameof(Person.FirstName));
            properties.Keys.ShouldContain(nameof(Person.LastName));
            properties.Keys.ShouldContain(nameof(Person.DateOfBirth));
            properties.Keys.ShouldContain(nameof(Person.AgeInYears));
            properties.Keys.ShouldContain(nameof(Person.YearOfBirth));
            properties[nameof(Person.FirstName)].ShouldBe(sample.FirstName);
            properties[nameof(Person.LastName)].ShouldBe(sample.LastName);
            properties[nameof(Person.DateOfBirth)].ShouldBe(sample.DateOfBirth);
            properties[nameof(Person.AgeInYears)].ShouldBe(sample.AgeInYears);
            properties[nameof(Person.YearOfBirth)].ShouldBe(sample.YearOfBirth);
        }

        [Test]
        public void AsDictionary_can_detect_all_default_properties_of_Dictionary()
        {
            // Arrange
            var sample = Builder<Person>
                .CreateNew()
                .Build();

            var dict = sample.AsDictionary();

            // Act
            var properties = dict.AsDictionary();

            // Assert
            properties.ShouldNotBeNull();
            properties.Count.ShouldBe(5);
            properties.Keys.ShouldContain(nameof(Person.FirstName));
            properties.Keys.ShouldContain(nameof(Person.LastName));
            properties.Keys.ShouldContain(nameof(Person.DateOfBirth));
            properties.Keys.ShouldContain(nameof(Person.AgeInYears));
            properties.Keys.ShouldContain(nameof(Person.YearOfBirth));
            properties[nameof(Person.FirstName)].ShouldBe(sample.FirstName);
            properties[nameof(Person.LastName)].ShouldBe(sample.LastName);
            properties[nameof(Person.DateOfBirth)].ShouldBe(sample.DateOfBirth);
            properties[nameof(Person.AgeInYears)].ShouldBe(sample.AgeInYears);
            properties[nameof(Person.YearOfBirth)].ShouldBe(sample.YearOfBirth);
        }
    }
}
