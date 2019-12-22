using System;

namespace Test.DNX.Helpers.Strings.Interpolation.Data
{
    internal class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int YearOfBirth => DateOfBirth.Year;

        private int? _fakeAge;

        public int AgeInYears
        {
            get => _fakeAge ?? Convert.ToInt32(DateTime.UtcNow.Subtract(DateOfBirth).TotalDays / 365);
            set => _fakeAge = value;
        }

        public static int Number => DateTime.UtcNow.Millisecond;
    }
}