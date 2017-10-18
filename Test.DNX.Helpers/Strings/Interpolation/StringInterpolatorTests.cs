using System;
using System.Collections.Generic;
using System.Linq;
using DNX.Helpers.Strings.Interpolation;
using NUnit.Framework;

namespace Test.DNX.Helpers.Strings.Interpolation
{
    #region Internal classes

    internal class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int YearOfBirth
        {
            get { return DateOfBirth.Year; }
        }

        private int? _fakeAge;
        public int AgeInYears
        {
            get { return _fakeAge ?? Convert.ToInt32(DateTime.UtcNow.Subtract(DateOfBirth).TotalDays / 365); }
            set { _fakeAge = value; }
        }

        public static int Number
        {
            get { return DateTime.UtcNow.Millisecond; }
        }
    }

    internal class Club
    {
        public string Name { get; set; }
    }

    #endregion

    [TestFixture]
    public class StringInterpolatorTests
    {
        [TestCase(typeof(Person), ExpectedResult = "FirstName,LastName,DateOfBirth,YearOfBirth,AgeInYears,Number")]
        [TestCase(typeof(Club), ExpectedResult = "Name")]
        public string GetInterpolatablePropertiesTest(Type type)
        {
            var properties = StringInterpolator.GetInterpolatableProperties(type);

            var propertyNames = properties.Select(p => p.Name);

            return string.Join(",", propertyNames);
        }

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
    }
}
