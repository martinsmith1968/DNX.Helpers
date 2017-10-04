using System;
using DNX.Helpers.Strings.Interpolation;
using NUnit.Framework;

namespace Test.DNX.Helpers.Strings.Interpolation
{
    internal class TestClass1
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int YearOfBirth
        {
            get { return DateOfBirth.Year; }
        }

        public int AgeInYears
        {
            get { return Convert.ToInt32(DateTime.UtcNow.Subtract(DateOfBirth).TotalDays / 365); }
        }

        public static int Number
        {
            get { return DateTime.UtcNow.Millisecond; }
        }
    }

    [TestFixture]
    public class StringInterpolatorTests
    {
        [Test]
        public void GetInterpolatablePropertiesTest()
        {

        }

        [TestCase("Hello {FirstName}", "Martin", "Smith", "2017-08-11", null, ExpectedResult = "Hello Martin")]
        [TestCase("{FirstName} {LastName} {DateOfBirth:MMM-dd} {YearOfBirth}", "Martin", "Smith", "2017-08-11", null, ExpectedResult = "Martin Smith Aug-11 2017")]
        [TestCase("Hello {user.FirstName}", "Martin", "Smith", "2017-08-11", "user", ExpectedResult = "Hello Martin")]
        [TestCase("Hello {person.FirstName} {person.LastName}", "Martin", "Smith", "2017-08-11", "person", ExpectedResult = "Hello Martin Smith")]
        [TestCase("{FirstName} {LastName} <> {LastName} {FirstName}", "Martin", "Smith", "2017-08-11", null, ExpectedResult = "Martin Smith <> Smith Martin")]
        public string InterpolateWithTest(string format, string firstName, string lastName, string dateofBirth, string instanceName)
        {
            var testClass = new TestClass1()
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = DateTime.Parse(dateofBirth)
            };

            var result = format.InterpolateWith(testClass, instanceName, false);

            return result;
        }
    }
}