using System;
using DNX.Helpers.Enumerations;
using NUnit.Framework;
using Should;

namespace Test.DNX.Helpers.Enumerations
{
    internal enum MyTestEnum1
    {
        [System.ComponentModel.Description("First")]
        One = 1,

        [System.ComponentModel.Description("Second")]
        Two = 2,

        [System.ComponentModel.Description("Third")]
        Three = 3,

        [System.ComponentModel.Description("Fourth")]
        Four = 4,

        [System.ComponentModel.Description("Fifth")]
        Five = 5
    }

    [Flags]
    internal enum MyTestEnum2
    {
        Flag1 = 1,
        Flag2 = 2,
        Flag3 = 4,
        Flag4 = 8,
        Flag5 = 16
    }

    [TestFixture]
    public class EnumExtensionsTests
    {
        [TestCase("One", ExpectedResult = "One")]
        [TestCase("Four", ExpectedResult = "Four")]
        [TestCase("Five", ExpectedResult = "Five")]
        public string ParseEnumTest_can_successfully_parse_MyTestEnum1(string text)
        {
            var result = text.ParseEnum<MyTestEnum1>();

            return result.ToString();
        }

        [TestCase("ONE", ExpectedResult = false)]
        [TestCase("Twenty", ExpectedResult = false)]
        [TestCase("Six", ExpectedResult = false)]
        public bool ParseEnumTest_fails_to_parse_MyTestEnum1(string text)
        {
            try
            {
                var result = text.ParseEnum<MyTestEnum1>();

                return true;
            }
            catch (ArgumentException ex)
            {
                ex.Message.ShouldContain(string.Format("'{0}'", text));

                return false;
            }
        }

        [Test]
        public void ParseEnumTest1()
        {

        }

        [Test]
        public void ParseEnumOrDefaultTest()
        {

        }

        [Test]
        public void ParseEnumOrDefaultTest1()
        {

        }

        [TestCase(typeof(MyTestEnum1), "One", false, ExpectedResult = true)]
        [TestCase(typeof(MyTestEnum1), "Three", false, ExpectedResult = true)]
        [TestCase(typeof(MyTestEnum1), "Five", false, ExpectedResult = true)]
        [TestCase(typeof(MyTestEnum1), "5", false, ExpectedResult = false)]
        [TestCase(typeof(MyTestEnum2), "Flag3", false, ExpectedResult = true)]
        [TestCase(typeof(MyTestEnum2), "Flag4", false, ExpectedResult = true)]
        [TestCase(typeof(MyTestEnum2), "Flag5", false, ExpectedResult = true)]
        [TestCase(typeof(MyTestEnum2), "Flag6", false, ExpectedResult = false)]
        [TestCase(typeof(MyTestEnum1), "ONE", false, ExpectedResult = false)]
        [TestCase(typeof(MyTestEnum1), "ThReE", false, ExpectedResult = false)]
        [TestCase(typeof(MyTestEnum1), "five", false, ExpectedResult = false)]
        [TestCase(typeof(MyTestEnum1), "OnE", true, ExpectedResult = true)]
        [TestCase(typeof(MyTestEnum1), "ThReE", true, ExpectedResult = true)]
        [TestCase(typeof(MyTestEnum1), "FIVE", true, ExpectedResult = true)]
        [TestCase(typeof(MyTestEnum1), "Five", true, ExpectedResult = true)]
        public bool IsValidEnumTest_string(Type type, string text, bool ignoreCase)
        {
            var result = text.IsValidEnum(type, ignoreCase);

            return result;
        }

        [Test]
        public void IsValidEnumTest1()
        {

        }

        [Test]
        public void GetMaxValueTest()
        {
            var max1 = EnumExtensions.GetMaxValue<MyTestEnum1>();
            var max2 = EnumExtensions.GetMaxValue<MyTestEnum2>();

            ((int)max1).ShouldEqual((int)MyTestEnum1.Five);
            ((int)max2).ShouldEqual((int)MyTestEnum2.Flag5);
        }

        [Test]
        public void GetMinValueTest()
        {
            var max1 = EnumExtensions.GetMinValue<MyTestEnum1>();
            var max2 = EnumExtensions.GetMinValue<MyTestEnum2>();

            ((int)max1).ShouldEqual((int)MyTestEnum1.One);
            ((int)max2).ShouldEqual((int)MyTestEnum2.Flag1);
        }

        [Test]
        public void IsValueOneOfTest()
        {

        }

        [Test]
        public void IsValueOneOfTest1()
        {

        }

        [Test]
        public void ManipulateFlagTest()
        {
            // Arrange
            var flags1 = MyTestEnum2.Flag2 | MyTestEnum2.Flag4;
            var flags2 = MyTestEnum2.Flag2 | MyTestEnum2.Flag4;

            // Act
            flags1 = flags1.ManipulateFlag(MyTestEnum2.Flag3, true);
            flags2 = flags2.ManipulateFlag(MyTestEnum2.Flag4, false);

            // Assert
            flags1.ShouldEqual(MyTestEnum2.Flag2 | MyTestEnum2.Flag3 | MyTestEnum2.Flag4);
            flags2.ShouldEqual(MyTestEnum2.Flag2);
        }

        [Test]
        public void SetFlagTest()
        {
            // Arrange
            var flags = MyTestEnum2.Flag2 | MyTestEnum2.Flag4;

            // Act
            flags = flags.SetFlag(MyTestEnum2.Flag3);

            // Assert
            flags.ShouldEqual(MyTestEnum2.Flag2 | MyTestEnum2.Flag3 | MyTestEnum2.Flag4);
        }

        [Test]
        public void UnsetFlagTest()
        {
            // Arrange
            var flags = MyTestEnum2.Flag2 | MyTestEnum2.Flag4 | MyTestEnum2.Flag5;

            // Act
            flags = flags.UnsetFlag(MyTestEnum2.Flag2);

            // Assert
            flags.ShouldEqual(MyTestEnum2.Flag4 | MyTestEnum2.Flag5);
        }

        [Test]
        public void GetSetValuesListTest()
        {
            // Arrange
            var flags = MyTestEnum2.Flag2 | MyTestEnum2.Flag4 | MyTestEnum2.Flag5;

            // Act
            var setFlags = EnumExtensions.GetSetValuesList<MyTestEnum2>(flags);

            // Assert
            setFlags.Count.ShouldEqual(3);
            setFlags.Contains(MyTestEnum2.Flag2).ShouldBeTrue();
            setFlags.Contains(MyTestEnum2.Flag4).ShouldBeTrue();
            setFlags.Contains(MyTestEnum2.Flag5).ShouldBeTrue();
        }

        [Test]
        public void ToDictionaryTest_MyTestEnum1()
        {
            var dict = EnumExtensions.ToDictionaryByName<MyTestEnum1>();

            dict.ShouldNotBeNull();
            dict.Count.ShouldEqual(5);
            dict[MyTestEnum1.One.ToString()].ShouldEqual(MyTestEnum1.One);
            dict[MyTestEnum1.Two.ToString()].ShouldEqual(MyTestEnum1.Two);
            dict[MyTestEnum1.Three.ToString()].ShouldEqual(MyTestEnum1.Three);
            dict[MyTestEnum1.Four.ToString()].ShouldEqual(MyTestEnum1.Four);
            dict[MyTestEnum1.Five.ToString()].ShouldEqual(MyTestEnum1.Five);
        }

        [Test]
        public void ToDictionaryTest_MyTestEnum2()
        {
            var dict = EnumExtensions.ToDictionaryByName<MyTestEnum2>();

            dict.ShouldNotBeNull();
            dict.Count.ShouldEqual(5);
            dict[MyTestEnum2.Flag1.ToString()].ShouldEqual(MyTestEnum2.Flag1);
            dict[MyTestEnum2.Flag2.ToString()].ShouldEqual(MyTestEnum2.Flag2);
            dict[MyTestEnum2.Flag3.ToString()].ShouldEqual(MyTestEnum2.Flag3);
            dict[MyTestEnum2.Flag4.ToString()].ShouldEqual(MyTestEnum2.Flag4);
            dict[MyTestEnum2.Flag5.ToString()].ShouldEqual(MyTestEnum2.Flag5);
        }

        [TestCase(MyTestEnum1.One, ExpectedResult = "First")]
        [TestCase(MyTestEnum1.Two, ExpectedResult = "Second")]
        [TestCase(MyTestEnum1.Three, ExpectedResult = "Third")]
        [TestCase(MyTestEnum1.Four, ExpectedResult = "Fourth")]
        [TestCase(MyTestEnum1.Five, ExpectedResult = "Fifth")]
        [TestCase(MyTestEnum2.Flag2, ExpectedResult = null)]
        public string GetDescriptionTest(Enum value)
        {
            var result = value.GetDescription();

            return result;
        }
    }
}
