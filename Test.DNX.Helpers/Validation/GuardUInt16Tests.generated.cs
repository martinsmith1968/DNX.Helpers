// Code generated by a Template
using System;
using DNX.Helpers.Maths;
using DNX.Helpers.Validation;
using NUnit.Framework;
using Shouldly;
using Test.DNX.Helpers.Validation.TestsDataSource;

namespace Test.DNX.Helpers.Validation
{
    [TestFixture]
    public class GuardUInt16Tests
    {
        [TestCaseSource(typeof(GuardUInt16TestsSource), "IsBetween_Default")]
        public bool Guard_IsBetween_Default(ushort value, ushort min, ushort max, string messageText)
        {
            try
            {
                // Act
                Guard.IsBetween(() => value, min, max);

                return true;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.IsNotNull(messageText);
                Assert.IsNotEmpty(messageText);
                ex.Message.ShouldStartWith(messageText);
                return false;
            }
            catch (Exception ex)
            {
                // Assert
                Assert.Fail(ex.Message);
                return false;
            }
        }

        [TestCaseSource(typeof(GuardUInt16TestsSource), "IsBetween_BoundsType")]
        public bool Guard_IsBetween_BoundsType(ushort value, ushort min, ushort max, IsBetweenBoundsType boundsType, string messageText)
        {
            try
            {
                // Act
                Guard.IsBetween(() => value, min, max, boundsType);

                return true;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.IsNotNull(messageText);
                Assert.IsNotEmpty(messageText);
                ex.Message.ShouldStartWith(messageText);
                return false;
            }
            catch (Exception ex)
            {
                // Assert
                Assert.Fail(ex.Message);
                return false;
            }
        }

        [TestCaseSource(typeof(GuardUInt16TestsSource), "IsBetween")]
        public bool Guard_IsBetween(ushort value, ushort min, ushort max, bool allowEitherOrder, IsBetweenBoundsType boundsType, string messageText)
        {
            try
            {
                // Act
                Guard.IsBetween(() => value, min, max, allowEitherOrder, boundsType);

                return true;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.IsNotNull(messageText);
                Assert.IsNotEmpty(messageText);
                ex.Message.ShouldStartWith(messageText);
                return false;
            }
            catch (Exception ex)
            {
                // Assert
                Assert.Fail(ex.Message);
                return false;
            }
        }

        [TestCaseSource(typeof(GuardUInt16TestsSource), "IsGreaterThan")]
        public bool Guard_IsGreaterThan_Expr(ushort value, ushort min, string messageText)
        {
            try
            {
                // Act
                Guard.IsGreaterThan(() => value, min);

                return true;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.IsNotNull(messageText);
                Assert.IsNotEmpty(messageText);
                ex.Message.ShouldStartWith(messageText);
                return false;
            }
            catch (Exception ex)
            {
                // Assert
                Assert.Fail(ex.Message);
                return false;
            }
        }

        [TestCaseSource(typeof(GuardUInt16TestsSource), "IsGreaterThan")]
        public bool Guard_IsGreaterThan_Value(ushort actualValue, ushort min, string messageText)
        {
            try
            {
                // Act
                ushort value = min;
                Guard.IsGreaterThan(() => value, actualValue, min);

                return true;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.IsNotNull(messageText);
                Assert.IsNotEmpty(messageText);
                ex.Message.ShouldStartWith(messageText);
                return false;
            }
            catch (Exception ex)
            {
                // Assert
                Assert.Fail(ex.Message);
                return false;
            }
        }

        [TestCaseSource(typeof(GuardUInt16TestsSource), "IsGreaterThanOrEqualTo")]
        public bool Guard_IsGreaterThanOrEqualTo_Expr(ushort value, ushort min, string messageText)
        {
            try
            {
                // Act
                Guard.IsGreaterThanOrEqualTo(() => value, min);

                return true;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.IsNotNull(messageText);
                Assert.IsNotEmpty(messageText);
                ex.Message.ShouldStartWith(messageText);
                return false;
            }
            catch (Exception ex)
            {
                // Assert
                Assert.Fail(ex.Message);
                return false;
            }
        }

        [TestCaseSource(typeof(GuardUInt16TestsSource), "IsGreaterThanOrEqualTo")]
        public bool Guard_IsGreaterThanOrEqualTo_Value(ushort actualValue, ushort min, string messageText)
        {
            try
            {
                // Act
                ushort value = min;
                Guard.IsGreaterThanOrEqualTo(() => value, actualValue, min);

                return true;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.IsNotNull(messageText);
                Assert.IsNotEmpty(messageText);
                ex.Message.ShouldStartWith(messageText);
                return false;
            }
            catch (Exception ex)
            {
                // Assert
                Assert.Fail(ex.Message);
                return false;
            }
        }

        [TestCaseSource(typeof(GuardUInt16TestsSource), "IsLessThan")]
        public bool Guard_IsLessThan_Expr(ushort value, ushort max, string messageText)
        {
            try
            {
                // Act
                Guard.IsLessThan(() => value, max);

                return true;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.IsNotNull(messageText);
                Assert.IsNotEmpty(messageText);
                ex.Message.ShouldStartWith(messageText);
                return false;
            }
            catch (Exception ex)
            {
                // Assert
                Assert.Fail(ex.Message);
                return false;
            }
        }

        [TestCaseSource(typeof(GuardUInt16TestsSource), "IsLessThan")]
        public bool Guard_IsLessThan_Value(ushort actualValue, ushort max, string messageText)
        {
            try
            {
                // Act
                ushort value = max;
                Guard.IsLessThan(() => value, actualValue, max);

                return true;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.IsNotNull(messageText);
                Assert.IsNotEmpty(messageText);
                ex.Message.ShouldStartWith(messageText);
                return false;
            }
            catch (Exception ex)
            {
                // Assert
                Assert.Fail(ex.Message);
                return false;
            }
        }

        [TestCaseSource(typeof(GuardUInt16TestsSource), "IsLessThanOrEqualTo")]
        public bool Guard_IsLessThanOrEqualTo_Expr(ushort value, ushort max, string messageText)
        {
            try
            {
                // Act
                Guard.IsLessThanOrEqualTo(() => value, max);

                return true;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.IsNotNull(messageText);
                Assert.IsNotEmpty(messageText);
                ex.Message.ShouldStartWith(messageText);
                return false;
            }
            catch (Exception ex)
            {
                // Assert
                Assert.Fail(ex.Message);
                return false;
            }
        }

        [TestCaseSource(typeof(GuardUInt16TestsSource), "IsLessThanOrEqualTo")]
        public bool Guard_IsLessThanOrEqualTo_Value(ushort actualValue, ushort max, string messageText)
        {
            try
            {
                // Act
                ushort value = max;
                Guard.IsLessThanOrEqualTo(() => value, actualValue, max);

                return true;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.IsNotNull(messageText);
                Assert.IsNotEmpty(messageText);
                ex.Message.ShouldStartWith(messageText);
                return false;
            }
            catch (Exception ex)
            {
                // Assert
                Assert.Fail(ex.Message);
                return false;
            }
        }
    }
}
