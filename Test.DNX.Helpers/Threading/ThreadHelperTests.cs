using System;
using System.Threading;
using DNX.Helpers.Threading;
using NUnit.Framework;
using Should;

namespace Test.DNX.Helpers.Threading
{
    [TestFixture]
    public class ThreadHelperTests
    {
        [Test]
        public void Start_rejects_null_ThreadStart()
        {
            // Arrange
            var start = (ThreadStart)null;

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => ThreadHelper.Start(start));

            // Assert
            ex.ParamName.ShouldEqual("start");
        }

        [Test]
        public void StartOnThreadPool_rejects_null_ThreadStart()
        {
            // Arrange
            var start = (ThreadStart)null;

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => ThreadHelper.StartOnThreadPool(start));

            // Assert
            ex.ParamName.ShouldEqual("start");
        }
    }
}
