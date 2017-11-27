using System;
using DNX.Helpers.Validation;
using NUnit.Framework;

namespace Test.DNX.Helpers.Validation
{

    namespace Test.DNX.Helpers.Validation
    {
        [TestFixture]
        public class GuardTests
        {
            [TestCase(false, "exp must be true", ExpectedResult = false)]
            [TestCase(true, null, ExpectedResult = true)]
            public bool IsTrue_exp_Test(bool val, string messageContains)
            {
                try
                {
                    var exp = val;
                    Guard.IsTrue(() => exp);

                    return true;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Assert.IsTrue(ex.Message.Contains(messageContains));

                    return false;
                }
            }

            [TestCase(false, "exp must be true", ExpectedResult = false)]
            [TestCase(true, null, ExpectedResult = true)]
            public bool IsTrue_exp_and_val_Test(bool val, string messageContains)
            {
                try
                {
                    var exp = false;
                    Guard.IsTrue(() => exp, val);

                    return true;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Assert.IsTrue(ex.Message.Contains(messageContains));

                    return false;
                }
            }

            [TestCase(true, "exp must be false", ExpectedResult = false)]
            [TestCase(false, null, ExpectedResult = true)]
            public bool IsFalse_exp_Test(bool val, string messageContains)
            {
                try
                {
                    var exp = val;
                    Guard.IsFalse(() => exp);

                    return true;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Assert.IsTrue(ex.Message.Contains(messageContains));

                    return false;
                }
            }

            [TestCase(true, "exp must be false", ExpectedResult = false)]
            [TestCase(false, null, ExpectedResult = true)]
            public bool IsFalse_exp_and_val_Test(bool val, string messageContains)
            {
                try
                {
                    var exp = false;
                    Guard.IsFalse(() => exp, val);

                    return true;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Assert.IsTrue(ex.Message.Contains(messageContains));

                    return false;
                }
            }

            [TestCase(false, "exp must not be null", ExpectedResult = false)]
            [TestCase(true, null, ExpectedResult = true)]
            public bool IsNotNull_exp_Test(bool instance, string messageContains)
            {
                try
                {
                    var exp = instance
                        ? new Linq.MyTestClass1()
                        : null;

                    Guard.IsNotNull(() => exp);

                    return true;
                }
                catch (ArgumentNullException ex)
                {
                    Assert.IsTrue(ex.Message.Contains(messageContains));

                    return false;
                }
            }

            [TestCase(false, "exp must not be null", ExpectedResult = false)]
            [TestCase(true, null, ExpectedResult = true)]
            public bool IsNotNull_exp_and_val_Test(bool instance, string messageContains)
            {
                try
                {
                    var exp = new Linq.MyTestClass1();
                    var val = instance
                        ? new Linq.MyTestClass1()
                        : null;

                    Guard.IsNotNull(() => exp, val);

                    return true;
                }
                catch (ArgumentNullException ex)
                {
                    Assert.IsTrue(ex.Message.Contains(messageContains));

                    return false;
                }
            }

            [TestCase("some text", null, ExpectedResult = true)]
            [TestCase("", "exp must not be null or empty", ExpectedResult = false)]
            [TestCase(null, "exp must not be null or empty", ExpectedResult = false)]
            public bool IsNotNullOrEmpty_exp_Test(string exp, string messageContains)
            {
                try
                {
                    Guard.IsNotNullOrEmpty(() => exp);

                    return true;
                }
                catch (ArgumentException ex)
                {
                    Assert.IsTrue(ex.Message.Contains(messageContains));

                    return false;
                }
            }

            [TestCase("some text", null, ExpectedResult = true)]
            [TestCase("", "exp must not be null or empty", ExpectedResult = false)]
            [TestCase(null, "exp must not be null or empty", ExpectedResult = false)]
            public bool IsNotNullOrEmpty_exp_and_val_Test(string val, string messageContains)
            {
                try
                {
                    var exp = "some exp text";
                    Guard.IsNotNullOrEmpty(() => exp, val);

                    return true;
                }
                catch (ArgumentException ex)
                {
                    Assert.IsTrue(ex.Message.Contains(messageContains));

                    return false;
                }
            }

            [TestCase("some text", null, ExpectedResult = true)]
            [TestCase("", "exp must not be null or whitespace", ExpectedResult = false)]
            [TestCase("  ", "exp must not be null or whitespace", ExpectedResult = false)]
            [TestCase(null, "exp must not be null or whitespace", ExpectedResult = false)]
            public bool IsNotNullOrWhitespace_exp_Test(string exp, string messageContains)
            {
                try
                {
                    Guard.IsNotNullOrWhitespace(() => exp);

                    return true;
                }
                catch (ArgumentException ex)
                {
                    Assert.IsTrue(ex.Message.Contains(messageContains));

                    return false;
                }
            }

            [TestCase("some text", null, ExpectedResult = true)]
            [TestCase("", "exp must not be null or whitespace", ExpectedResult = false)]
            [TestCase("  ", "exp must not be null or whitespace", ExpectedResult = false)]
            [TestCase(null, "exp must not be null or whitespace", ExpectedResult = false)]
            public bool IsNotNullOrWhitespace_exp_and_val_Test(string val, string messageContains)
            {
                try
                {
                    var exp = "some exp text";
                    Guard.IsNotNullOrWhitespace(() => exp, val);

                    return true;
                }
                catch (ArgumentException ex)
                {
                    Assert.IsTrue(ex.Message.Contains(messageContains));

                    return false;
                }
            }
        }
    }
}
