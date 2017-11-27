using System;
using DNX.Helpers.Validation;
using NUnit.Framework;

namespace Test.DNX.Helpers.Validation
{
    public enum GuardEnum1
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

        [TestCase(1, null, ExpectedResult = true)]
        [TestCase(2, null, ExpectedResult = true)]
        [TestCase(3, null, ExpectedResult = true)]
        [TestCase(4, null, ExpectedResult = true)]
        [TestCase(5, null, ExpectedResult = true)]
        [TestCase(6, "exp must be a valid GuardEnum1 value", ExpectedResult = false)]
        public bool IsValidEnum_exp_and_val_Tests(int enumValue, string messageContains)
        {
            try
            {
                var exp = GuardEnum1.Four;
                var val = (GuardEnum1)enumValue;

                Guard.IsValidEnum(() => exp, val);

                return true;
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains(messageContains));

                return false;
            }
        }

        [TestCase(GuardEnum1.One, null, ExpectedResult = true)]
        [TestCase(GuardEnum1.Two, "exp must be an allowed GuardEnum1 value: One,Three,Five", ExpectedResult = false)]
        [TestCase(GuardEnum1.Three, null, ExpectedResult = true)]
        [TestCase(GuardEnum1.Four, "exp must be an allowed GuardEnum1 value: One,Three,Five", ExpectedResult = false)]
        [TestCase(GuardEnum1.Five, null, ExpectedResult = true)]
        public bool IsEnumOneOf_exp_params_Tests(GuardEnum1 exp, string messageContains)
        {
            try
            {
                Guard.IsEnumOneOf(() => exp, GuardEnum1.One, GuardEnum1.Three, GuardEnum1.Five);

                return true;
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains(messageContains), ex.Message);

                return false;
            }
        }

        [TestCase(GuardEnum1.One, null, ExpectedResult = true)]
        [TestCase(GuardEnum1.Two, "exp must be an allowed GuardEnum1 value: One,Three,Five", ExpectedResult = false)]
        [TestCase(GuardEnum1.Three, null, ExpectedResult = true)]
        [TestCase(GuardEnum1.Four, "exp must be an allowed GuardEnum1 value: One,Three,Five", ExpectedResult = false)]
        [TestCase(GuardEnum1.Five, null, ExpectedResult = true)]
        public bool IsEnumOneOf_exp_list_Tests(GuardEnum1 exp, string messageContains)
        {
            try
            {
                var allowedList = new[] { GuardEnum1.One, GuardEnum1.Three, GuardEnum1.Five };

                Guard.IsEnumOneOf(() => exp, allowedList);

                return true;
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains(messageContains), ex.Message);

                return false;
            }
        }

        [TestCase(GuardEnum1.One, null, ExpectedResult = true)]
        [TestCase(GuardEnum1.Two, "exp must be an allowed GuardEnum1 value: One,Three,Five", ExpectedResult = false)]
        [TestCase(GuardEnum1.Three, null, ExpectedResult = true)]
        [TestCase(GuardEnum1.Four, "exp must be an allowed GuardEnum1 value: One,Three,Five", ExpectedResult = false)]
        [TestCase(GuardEnum1.Five, null, ExpectedResult = true)]
        public bool IsEnumOneOf_exp_val_list_Tests(GuardEnum1 val, string messageContains)
        {
            try
            {
                var allowedList = new[] { GuardEnum1.One, GuardEnum1.Three, GuardEnum1.Five };
                var exp = (GuardEnum1)10;
                Guard.IsEnumOneOf(() => exp, val, allowedList);

                return true;
            }
            catch (ArgumentException ex)
            {
                Assert.IsTrue(ex.Message.Contains(messageContains), ex.Message);

                return false;
            }
        }
    }
}
