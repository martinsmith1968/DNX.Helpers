using System;
using DNX.Helpers.Enumerations;
using DNX.Helpers.Exceptions;
using NUnit.Framework;
using Shouldly;

namespace Test.DNX.Helpers.Enumerations
{
    [AttributeUsage(AttributeTargets.Field)]
    internal class MultiplierAttribute : Attribute
    {
        public int Multiplier { get; set; }

        public MultiplierAttribute(int multiplier)
        {
            Multiplier = multiplier;
        }
    }

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

    internal enum MyTestEnum3
    {
        [Multiplier(10)]
        Ten = 10,

        Twenty = 20,

        [Multiplier(15)]
        Thirty = 30,

        Fourty = 40,

        [Multiplier(1000)]
        Fifty = 50
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

            ((int)max1).ShouldBe((int)MyTestEnum1.Five);
            ((int)max2).ShouldBe((int)MyTestEnum2.Flag5);
        }

        [Test]
        public void GetMinValueTest()
        {
            var max1 = EnumExtensions.GetMinValue<MyTestEnum1>();
            var max2 = EnumExtensions.GetMinValue<MyTestEnum2>();

            ((int)max1).ShouldBe((int)MyTestEnum1.One);
            ((int)max2).ShouldBe((int)MyTestEnum2.Flag1);
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
            flags1.ShouldBe(MyTestEnum2.Flag2 | MyTestEnum2.Flag3 | MyTestEnum2.Flag4);
            flags2.ShouldBe(MyTestEnum2.Flag2);
        }

        [Test]
        public void SetFlagTest()
        {
            // Arrange
            var flags = MyTestEnum2.Flag2 | MyTestEnum2.Flag4;

            // Act
            flags = flags.SetFlag(MyTestEnum2.Flag3);

            // Assert
            flags.ShouldBe(MyTestEnum2.Flag2 | MyTestEnum2.Flag3 | MyTestEnum2.Flag4);
        }

        [Test]
        public void UnsetFlagTest()
        {
            // Arrange
            var flags = MyTestEnum2.Flag2 | MyTestEnum2.Flag4 | MyTestEnum2.Flag5;

            // Act
            flags = flags.UnsetFlag(MyTestEnum2.Flag2);

            // Assert
            flags.ShouldBe(MyTestEnum2.Flag4 | MyTestEnum2.Flag5);
        }

        [Test]
        public void GetSetValuesListTest()
        {
            // Arrange
            var flags = MyTestEnum2.Flag2 | MyTestEnum2.Flag4 | MyTestEnum2.Flag5;

            // Act
            var setFlags = EnumExtensions.GetSetValuesList<MyTestEnum2>(flags);

            // Assert
            setFlags.Count.ShouldBe(3);
            setFlags.Contains(MyTestEnum2.Flag2).ShouldBeTrue();
            setFlags.Contains(MyTestEnum2.Flag4).ShouldBeTrue();
            setFlags.Contains(MyTestEnum2.Flag5).ShouldBeTrue();
        }

        [Test]
        public void ToDictionaryTest_MyTestEnum1()
        {
            var dict = EnumExtensions.ToDictionaryByName<MyTestEnum1>();

            dict.ShouldNotBeNull();
            dict.Count.ShouldBe(5);
            dict[MyTestEnum1.One.ToString()].ShouldBe(MyTestEnum1.One);
            dict[MyTestEnum1.Two.ToString()].ShouldBe(MyTestEnum1.Two);
            dict[MyTestEnum1.Three.ToString()].ShouldBe(MyTestEnum1.Three);
            dict[MyTestEnum1.Four.ToString()].ShouldBe(MyTestEnum1.Four);
            dict[MyTestEnum1.Five.ToString()].ShouldBe(MyTestEnum1.Five);
        }

        [Test]
        public void ToDictionaryTest_MyTestEnum2()
        {
            var dict = EnumExtensions.ToDictionaryByName<MyTestEnum2>();

            dict.ShouldNotBeNull();
            dict.Count.ShouldBe(5);
            dict[MyTestEnum2.Flag1.ToString()].ShouldBe(MyTestEnum2.Flag1);
            dict[MyTestEnum2.Flag2.ToString()].ShouldBe(MyTestEnum2.Flag2);
            dict[MyTestEnum2.Flag3.ToString()].ShouldBe(MyTestEnum2.Flag3);
            dict[MyTestEnum2.Flag4.ToString()].ShouldBe(MyTestEnum2.Flag4);
            dict[MyTestEnum2.Flag5.ToString()].ShouldBe(MyTestEnum2.Flag5);
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

        [TestCase(MyTestEnum3.Ten, ExpectedResult = 10)]
        [TestCase(MyTestEnum3.Twenty, ExpectedResult = null)]
        [TestCase(MyTestEnum3.Thirty, ExpectedResult = 15)]
        [TestCase(MyTestEnum3.Fourty, ExpectedResult = null)]
        [TestCase(MyTestEnum3.Fifty, ExpectedResult = 1000)]
        public int? GetAttributeTest(Enum value)
        {
            var attribute = value.GetAttribute<MultiplierAttribute>();

            return attribute == null ? (int?)null : attribute.Multiplier;
        }
    }
}
