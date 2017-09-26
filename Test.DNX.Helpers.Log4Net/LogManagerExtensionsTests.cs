using DNX.Helpers.Log4Net;
using NUnit.Framework;

namespace Test.DNX.Helpers.Log4Net
{
    internal class MyClass1
    {
    }

    [TestFixture]
    public class LogManagerExtensionsTests
    {
        [Test]
        public void GetDefaultLogger_Test()
        {
            var logger = LogManagerExtensions.GetDefaultLogger();

            Assert.IsNotNull(logger);
            Assert.AreEqual(string.Empty, logger.Logger.Name);
        }

        [Test]
        public void GetLoggerFor_Test()
        {
            var myClass1 = new MyClass1();
            var logger = LogManagerExtensions.GetLoggerFor(myClass1);

            Assert.IsNotNull(logger);
            Assert.AreEqual(myClass1.GetType().FullName, logger.Logger.Name);
        }

        [Test]
        public void GetMyLoggerTest()
        {
            var logger = LogManagerExtensions.GetMyLogger();

            Assert.IsNotNull(logger);
            Assert.AreEqual(this.GetType().FullName, logger.Logger.Name);
        }

        [Test]
        public void GetLoggerTest()
        {
            var logger = LogManagerExtensions.GetLogger<MyClass1>();

            Assert.IsNotNull(logger);
            Assert.AreEqual(typeof(MyClass1).FullName, logger.Logger.Name);
        }
    }
}
