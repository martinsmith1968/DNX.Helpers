using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DNX.Helpers.Enumerations;
using DNX.Helpers.Strings.Interpolation;
using NUnit.Framework;
using Shouldly;
using Test.DNX.Helpers.Strings.Interpolation.Data;

namespace Test.DNX.Helpers.Strings.Interpolation
{
    [TestFixture]
    public class StringInterpolatorTests
    {
        [TestCase("Hello {FirstName}", "Martin", "Smith", "2017-08-11", null, ExpectedResult = "Hello Martin")]
        [TestCase("{FirstName} {LastName} {DateOfBirth:MMM-dd} {YearOfBirth}", "Martin", "Smith", "2017-08-11", null, ExpectedResult = "Martin Smith Aug-11 2017")]
        [TestCase("Hello {user.FirstName}", "Martin", "Smith", "2017-08-11", "user", ExpectedResult = "Hello Martin")]
        [TestCase("Hello {person.FirstName} {person.LastName}", "Martin", "Smith", "2017-08-11", "person", ExpectedResult = "Hello Martin Smith")]
        [TestCase("{FirstName} {LastName} <> {LastName} {FirstName}", "Martin", "Smith", "2017-08-11", null, ExpectedResult = "Martin Smith <> Smith Martin")]
        public string InterpolateWith_SinglePerson_Test(string format, string firstName, string lastName, string dateOfBirth, string instanceName)
        {
            var person = new Person()
            {
                FirstName   = firstName,
                LastName    = lastName,
                DateOfBirth = DateTime.Parse(dateOfBirth)
            };

            var result = format.InterpolateWith(person, instanceName);

            return result;
        }

        [TestCase("{FirstName} was born in {DateOfBirth:MMMM yyyy} and is {AgeInYears:0000}", "Martin", "Smith", "1968-08-11", 29, null, ExpectedResult = "Martin was born in August 1968 and is 0029")]
        public string InterpolateWith_SinglePerson_WithFormatModifiers_Test(string format, string firstName, string lastName, string dateOfBirth, int? fakeAge, string instanceName)
        {
            var person = new Person()
            {
                FirstName   = firstName,
                LastName    = lastName,
                DateOfBirth = DateTime.Parse(dateOfBirth),
            };

            if (fakeAge.HasValue)
                person.AgeInYears = fakeAge.Value;

            var result = format.InterpolateWith(person, instanceName);

            return result;
        }

        [Test]
        public void InterpolateWithAll_Environment_SpecialFolders()
        {
            // Arrange
            var text = "{SpecialFolder.System}\\Shell32.dll";

            var dict = new Dictionary<string, object>()
            {
                { $"{nameof(Environment.SpecialFolder)}.{nameof(Environment.SpecialFolder.System)}", Environment.GetFolderPath(Environment.SpecialFolder.System) }
            };

            // Act
            var result = text.InterpolateWithAll(dict);

            // Assert
            result.ShouldBe(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "Shell32.dll"));
        }

        [TestCase("{One}{Two}{Three}{Four}{Five}", "12345")]
        public void InterpolateWithAll_Dictionary(string text, string expectedValue)
        {
            // Arrange
            var dict = Enum.GetNames(typeof(OneToTen))
                    .ToDictionary(x => x, x => (int) Enum.Parse(typeof(OneToTen), x))
                ;

            // Act
            var result = text.InterpolateWithAll(dict);

            // Assert
            result.ShouldBe(expectedValue);
        }

        [TestCase("{person1.FirstName} {person1.LastName} and {person2.FirstName} {person2.LastName}", "Tommy", "Cannon", "1935-10-01", "person1", "Bobby", "Ball", "1936-07-04", "person2", ExpectedResult = "Tommy Cannon and Bobby Ball")]
        [TestCase("{artist.FirstName} {artist.LastName} and {puppet.FirstName} {puppet.LastName}", "Bob", "Carolgees", "1935-10-01", "artist", "Spit", "the Dog", "1900-01-01", "puppet", ExpectedResult = "Bob Carolgees and Spit the Dog")]
        public string InterpolateWithAll_MultiplePersons_Test(string format, string firstName1, string lastName1, string dateOfBirth1, string instanceName1, string firstName2, string lastName2, string dateOfBirth2, string instanceName2)
        {
            var person1 = new Person()
            {
                FirstName   = firstName1,
                LastName    = lastName1,
                DateOfBirth = DateTime.Parse(dateOfBirth1)
            };
            var person2 = new Person()
            {
                FirstName   = firstName2,
                LastName    = lastName2,
                DateOfBirth = DateTime.Parse(dateOfBirth2)
            };

            var instanceList = new List<NamedInstance>()
            {
                new NamedInstance(person1, instanceName1),
                new NamedInstance(person2, instanceName2),
            };

            var result = format.InterpolateWithAll(instanceList);

            return result;
        }

        [TestCase("{player.FirstName} {player.LastName} plays for {club.Name}", "Harry", "Kane", "1990-05-06", "player", "Spurs", "club", ExpectedResult = "Harry Kane plays for Spurs")]
        public string InterpolateWithAll_PersonAndClub_Test(string format, string firstName, string lastName, string dateOfBirth, string instanceName1, string clubName, string instanceName2)
        {
            var person = new Person()
            {
                FirstName   = firstName,
                LastName    = lastName,
                DateOfBirth = DateTime.Parse(dateOfBirth)
            };
            var club = new Club()
            {
                Name = clubName
            };

            var instanceList = new List<NamedInstance>()
            {
                new NamedInstance(person, instanceName1),
                new NamedInstance(club, instanceName2),
            };

            var result = format.InterpolateWithAll(instanceList);

            return result;
        }

        [Test]
        public void InterpolateWithAll_FileName_Test()
        {
            // Arrange
            const string myFileName = "myFileName.txt";
            var specialFolder = Environment.SpecialFolder.CommonProgramFiles;
            var fileName = $"{{Environment.{specialFolder}}}\\{myFileName}";

            var values = EnumExtensions.ToDictionaryByName<Environment.SpecialFolder>()
                .ToDictionary(x => x.Key, x => Environment.GetFolderPath(x.Value));
            values.Add(nameof(Environment.SystemDirectory), Environment.SystemDirectory);
            values.Add(nameof(Environment.CurrentDirectory), Environment.CurrentDirectory);

            var namedInstance = new NamedInstance(values, nameof(Environment));

            // Act
            var result = fileName.InterpolateWith(namedInstance);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBe(Path.Combine(Environment.GetFolderPath(specialFolder), myFileName));
        }
    }
}
