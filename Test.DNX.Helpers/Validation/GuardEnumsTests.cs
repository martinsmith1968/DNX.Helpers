using System;
using DNX.Helpers.Validation;
using NUnit.Framework;

namespace Test.DNX.Helpers.Validation
{
    internal enum GuardEnum1
    {
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5
    }

    [TestFixture]
    public class GuardEnumsTests
    {
        [TestCase(1, null, ExpectedResult = true)]
        [TestCase(2, null, ExpectedResult = true)]
        [TestCase(3, null, ExpectedResult = true)]
        [TestCase(4, null, ExpectedResult = true)]
        [TestCase(5, null, ExpectedResult = true)]
        [TestCase(6, "exp must be a valid GuardEnum1 value", ExpectedResult = false)]
        public bool IsValidEnum_exp_Tests(int enumValue, string messageContains)
        {
            try
            {
                var exp = (GuardEnum1)enumValue;

                Guard.IsValidEnum(() => exp);

                return true;
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains(messageContains));

                return false;
            }
        }

        [Test]
        public void IsValidEnumTests1()
        {
            Assert.Fail();
        }

        [Test]
        public void IsEnumOneOfTests()
        {
            Assert.Fail();
        }

        [Test]
        public void IsEnumOneOfTests1()
        {
            Assert.Fail();
        }

        [Test]
        public void IsEnumOneOfTests2()
        {
            Assert.Fail();
        }

        [Test]
        public void IsEnumOneOfTests3()
        {
            Assert.Fail();
        }
    }
}
