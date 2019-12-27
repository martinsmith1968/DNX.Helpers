using System;
using DNX.Helpers.Assemblies;
using NUnit.Framework;
using Shouldly;

namespace Test.DNX.Helpers.Assemblies
{
    [TestFixture]
    public class VersionExtensionsTests
    {
        [TestCase(1, 0, 0, 0, 1, ExpectedResult = "1")]
        [TestCase(1, 2, 0, 0, 1, ExpectedResult = "1.2")]
        [TestCase(1, 0, 3, 0, 1, ExpectedResult = "1.0.3")]
        [TestCase(1, 0, 0, 4, 4, ExpectedResult = "1.0.0.4")]
        [TestCase(1, 2, 3, 4, 1, ExpectedResult = "1.2.3.4")]
        [TestCase(1, 2, 3, 4, 2, ExpectedResult = "1.2.3.4")]
        [TestCase(1, 2, 3, 4, 3, ExpectedResult = "1.2.3.4")]
        [TestCase(1, 2, 3, 4, 4, ExpectedResult = "1.2.3.4")]
        public string SimplifyTests(int major, int minor, int build, int revision, int minimumPositions)
        {
            var version = new Version(major, minor, build, revision);

            return version.Simplify(minimumPositions);
        }

        [TestCase(1, 2, 3, 4, 0, ExpectedResult = false)]
        [TestCase(1, 2, 3, 4, 5, ExpectedResult = false)]
        [TestCase(1, 2, 3, 4, 1, ExpectedResult = true)]
        [TestCase(1, 2, 3, 4, 4, ExpectedResult = true)]
        public bool Simplify_GuardException_Tests(int major, int minor, int build, int revision, int minimumPositions)
        {
            var version = new Version(major, minor, build, revision);

            try
            {
                var text = version.Simplify(minimumPositions);

                return true;
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
        }

        [Test]
        public void Simplify_for_null_returns_expected()
        {
            // Arrange
            Version version = null;

            // Act
            var result = version.Simplify();

            // Assert
            result.ShouldBeNull();
        }
    }
}
