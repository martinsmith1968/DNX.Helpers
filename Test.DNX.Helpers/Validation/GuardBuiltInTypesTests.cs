using DNX.Helpers.Validation;
using NUnit.Framework;
using System;
using DNX.Helpers.Maths;

namespace Test.DNX.Helpers.Validation
{
    [TestFixture]
    public class GuardBuiltInTypesTests
    {
        [TestCase(150, 100, 200, ExpectedResult = true)]
        [TestCase(101, 100, 200, ExpectedResult = true)]
        [TestCase(199, 100, 200, ExpectedResult = true)]
        [TestCase(100, 100, 200, ExpectedResult = true)]
        [TestCase(200, 100, 200, ExpectedResult = true)]
        [TestCase(-150, -100, -200, ExpectedResult = false)]
        [TestCase(-150, -200, -100, ExpectedResult = true)]
        [TestCase(-101, -200, -100, ExpectedResult = true)]
        [TestCase(-199, -200, -100, ExpectedResult = true)]
        [TestCase(-100, -200, -100, ExpectedResult = true)]
        [TestCase(-200, -200, -100, ExpectedResult = true)]
        [TestCase(50, 100, 200, ExpectedResult = false)]
        [TestCase(250, 100, 200, ExpectedResult = false)]
        [TestCase(100, 100, 200, ExpectedResult = true)]
        [TestCase(200, 100, 200, ExpectedResult = true)]
        [TestCase(100, 100, 100, ExpectedResult = true)]
        public bool IsBetween_InclusiveDefault(int number, int min, int max)
        {
            try
            {
                // Act
                Guard.IsBetween(() => number, min, max);

                return true;
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
            catch (Exception ex)
            {
                // Assert
                Assert.Fail(ex.Message);
                return false;
            }
        }

        [TestCase(150, 100, 200, ExpectedResult = true)]
        [TestCase(101, 100, 200, ExpectedResult = true)]
        [TestCase(199, 100, 200, ExpectedResult = true)]
        [TestCase(100, 100, 200, ExpectedResult = false)]
        [TestCase(200, 100, 200, ExpectedResult = false)]
        [TestCase(-150, -100, -200, ExpectedResult = false)]
        [TestCase(-150, -200, -100, ExpectedResult = true)]
        [TestCase(-101, -200, -100, ExpectedResult = true)]
        [TestCase(-199, -200, -100, ExpectedResult = true)]
        [TestCase(-100, -200, -100, ExpectedResult = false)]
        [TestCase(-200, -200, -100, ExpectedResult = false)]
        [TestCase(50, 100, 200, ExpectedResult = false)]
        [TestCase(250, 100, 200, ExpectedResult = false)]
        [TestCase(100, 100, 200, ExpectedResult = false)]
        [TestCase(200, 100, 200, ExpectedResult = false)]
        [TestCase(100, 100, 100, ExpectedResult = false)]
        public bool IsBetween_NotInclusive(int number, int min, int max)
        {
            try
            {
                // Act
                Guard.IsBetween(() => number, min, max, IsBetweenBoundsType.Exclusive);

                return true;
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
            catch (Exception ex)
            {
                // Assert
                Assert.Fail(ex.Message);
                return false;
            }
        }

        [TestCase(150, 100, 200, ExpectedResult = true)]
        [TestCase(101, 100, 200, ExpectedResult = true)]
        [TestCase(199, 100, 200, ExpectedResult = true)]
        [TestCase(100, 100, 200, ExpectedResult = true)]
        [TestCase(200, 100, 200, ExpectedResult = true)]
        [TestCase(150, 200, 100, ExpectedResult = true)]
        [TestCase(101, 200, 100, ExpectedResult = true)]
        [TestCase(199, 200, 100, ExpectedResult = true)]
        [TestCase(100, 200, 100, ExpectedResult = true)]
        [TestCase(200, 200, 100, ExpectedResult = true)]
        [TestCase(-150, -100, -200, ExpectedResult = true)]
        [TestCase(-150, -200, -100, ExpectedResult = true)]
        [TestCase(-101, -200, -100, ExpectedResult = true)]
        [TestCase(-199, -200, -100, ExpectedResult = true)]
        [TestCase(-100, -200, -100, ExpectedResult = true)]
        [TestCase(-200, -200, -100, ExpectedResult = true)]
        [TestCase(-150, -200, -100, ExpectedResult = true)]
        [TestCase(-150, -100, -200, ExpectedResult = true)]
        [TestCase(-101, -100, -200, ExpectedResult = true)]
        [TestCase(-199, -100, -200, ExpectedResult = true)]
        [TestCase(-100, -100, -200, ExpectedResult = true)]
        [TestCase(-200, -100, -200, ExpectedResult = true)]
        [TestCase(50, 100, 200, ExpectedResult = false)]
        [TestCase(250, 100, 200, ExpectedResult = false)]
        [TestCase(50, 200, 100, ExpectedResult = false)]
        [TestCase(250, 200, 100, ExpectedResult = false)]
        [TestCase(100, 100, 200, ExpectedResult = true)]
        [TestCase(200, 100, 200, ExpectedResult = true)]
        [TestCase(100, 200, 100, ExpectedResult = true)]
        [TestCase(200, 200, 100, ExpectedResult = true)]
        [TestCase(100, 100, 100, ExpectedResult = true)]
        public bool IsBetweenEither_InclusiveDefault(int number, int min, int max)
        {
            try
            {
                // Act
                //Guard.IsBetweenEither(() => number, min, max);

                return true;
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
            catch (Exception ex)
            {
                // Assert
                Assert.Fail(ex.Message);
                return false;
            }
        }

        [TestCase(150, 100, 200, ExpectedResult = true)]
        [TestCase(101, 100, 200, ExpectedResult = true)]
        [TestCase(199, 100, 200, ExpectedResult = true)]
        [TestCase(100, 100, 200, ExpectedResult = false)]
        [TestCase(200, 100, 200, ExpectedResult = false)]
        [TestCase(150, 200, 100, ExpectedResult = true)]
        [TestCase(101, 200, 100, ExpectedResult = true)]
        [TestCase(199, 200, 100, ExpectedResult = true)]
        [TestCase(100, 200, 100, ExpectedResult = false)]
        [TestCase(200, 200, 100, ExpectedResult = false)]
        [TestCase(-150, -100, -200, ExpectedResult = true)]
        [TestCase(-150, -200, -100, ExpectedResult = true)]
        [TestCase(-101, -200, -100, ExpectedResult = true)]
        [TestCase(-199, -200, -100, ExpectedResult = true)]
        [TestCase(-100, -200, -100, ExpectedResult = false)]
        [TestCase(-200, -200, -100, ExpectedResult = false)]
        [TestCase(-150, -200, -100, ExpectedResult = true)]
        [TestCase(-150, -100, -200, ExpectedResult = true)]
        [TestCase(-101, -100, -200, ExpectedResult = true)]
        [TestCase(-199, -100, -200, ExpectedResult = true)]
        [TestCase(-100, -100, -200, ExpectedResult = false)]
        [TestCase(-200, -100, -200, ExpectedResult = false)]
        [TestCase(50, 100, 200, ExpectedResult = false)]
        [TestCase(250, 100, 200, ExpectedResult = false)]
        [TestCase(50, 200, 100, ExpectedResult = false)]
        [TestCase(250, 200, 100, ExpectedResult = false)]
        [TestCase(100, 100, 200, ExpectedResult = false)]
        [TestCase(200, 100, 200, ExpectedResult = false)]
        [TestCase(100, 200, 100, ExpectedResult = false)]
        [TestCase(200, 200, 100, ExpectedResult = false)]
        [TestCase(100, 100, 100, ExpectedResult = false)]
        public bool IsBetweenEither_NotInclusive(int number, int min, int max)
        {
            try
            {
                // Act
                //Guard.IsBetweenEither(() => number, min, max, false);

                return true;
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
            catch (Exception ex)
            {
                // Assert
                Assert.Fail(ex.Message);
                return false;
            }
        }

#if TODO
        [Test]
        public void IsNotNullTest()
        {
            Assert.Fail();
        }

        [Test]
        public void IsNotNullTest1()
        {
            Assert.Fail();
        }

        [Test]
        public void IsNotNullOrEmptyTest()
        {
            Assert.Fail();
        }

        [Test]
        public void IsNotNullOrEmptyTest1()
        {
            Assert.Fail();
        }

        [Test]
        public void IsNotNullOrWhitespaceTest()
        {
            Assert.Fail();
        }

        [Test]
        public void IsNotNullOrWhitespaceTest1()
        {
            Assert.Fail();
        }
#endif
    }
}
