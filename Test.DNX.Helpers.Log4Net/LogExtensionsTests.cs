using System;
using DNX.Helpers.Log4Net;
using log4net;
using Moq;
using NUnit.Framework;

namespace Test.DNX.Helpers.Log4Net
{
    [TestFixture]
    public class LogExtensionsTests
    {
        [Test]
        public void DebugIfEnabled_DebugNotEnabled_TextNotEvaluated()
        {
            // Arrange
            var called = false;

            var logger = new Mock<ILog>(MockBehavior.Strict);
            logger.Setup(l => l.IsDebugEnabled).Returns(false);

            Func<string> getText = () =>
            {
                called = true;

                return "Some text";
            };

            // Act
            logger.Object.DebugFunc(getText);

            // Assert
            Assert.IsFalse(called);
            logger.Verify(l => l.Debug(It.IsAny<object>()), Times.Never());
        }

        [Test]
        public void DebugIfEnabled_DebugEnabled_TextEvaluated()
        {
            // Arrange
            var called = false;

            var logger = new Mock<ILog>(MockBehavior.Strict);
            logger.Setup(l => l.IsDebugEnabled).Returns(true);
            logger.Setup(l => l.Debug(It.IsAny<object>()));

            Func<string> getText = () =>
            {
                called = true;

                return "Some text";
            };

            // Act
            logger.Object.DebugFunc(getText);

            // Assert
            Assert.IsTrue(called);
            logger.Verify(l => l.Debug(It.IsAny<object>()), Times.Once());
        }

        [Test]
        public void DebugIfEnabled_DebugEnabled_TextEvaluated2()
        {
            // Arrange
            var called = false;

            var logger = new Mock<ILog>();
            logger.Setup(l => l.IsDebugEnabled).Returns(true);

            Func<int> getNumber = () =>
            {
                called = true;

                return DateTime.UtcNow.Millisecond;
            };

            // Act
            logger.Object.DebugFunc(() => string.Format("Value: {0}", getNumber()));

            // Assert
            Assert.IsTrue(called);
        }

        [Test]
        public void DebugIfEnabled_DebugNotEnabled_TextNotEvaluated2()
        {
            // Arrange
            var called = false;

            var logger = new Mock<ILog>();
            logger.Setup(l => l.IsDebugEnabled).Returns(false);

            Func<int> getNumber = () =>
            {
                called = true;

                return DateTime.UtcNow.Millisecond;
            };

            // Act
            logger.Object.DebugFunc(() => string.Format("Value: {0}", getNumber));

            // Assert
            Assert.IsFalse(called);
        }
    }
}
