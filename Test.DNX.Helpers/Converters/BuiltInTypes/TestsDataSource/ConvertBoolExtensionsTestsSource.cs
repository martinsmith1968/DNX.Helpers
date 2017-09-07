using System.Collections.Generic;
using NUnit.Framework;

namespace Test.DNX.Helpers.Converters.BuiltInTypes.TestsDataSource
{
    public class ConvertBoolExtensionsTestsSource
    {
        public static IEnumerable<TestCaseData> IsBool
        {
            get
            {
                yield return new TestCaseData("0").Returns(false);
                yield return new TestCaseData("1").Returns(false);
                yield return new TestCaseData("True").Returns(true);
                yield return new TestCaseData("False").Returns(true);
                yield return new TestCaseData("true").Returns(true);
                yield return new TestCaseData("false").Returns(true);
                yield return new TestCaseData("Yes").Returns(false);
                yield return new TestCaseData("No").Returns(false);
            }
        }

        public static IEnumerable<TestCaseData> ToBool
        {
            get
            {
                yield return new TestCaseData("True").Returns(true);
                yield return new TestCaseData("False").Returns(false);
                yield return new TestCaseData("true").Returns(true);
                yield return new TestCaseData("false").Returns(false);
            }
        }

        public static IEnumerable<TestCaseData> ToBoolThrows
        {
            get
            {
                yield return new TestCaseData("0").Returns(false);
                yield return new TestCaseData("1").Returns(false);
                yield return new TestCaseData("abcdef").Returns(false);
                yield return new TestCaseData("50.5").Returns(false);
                yield return new TestCaseData("-10").Returns(false);
                yield return new TestCaseData("100,000").Returns(false);
                yield return new TestCaseData(short.MaxValue.ToString()).Returns(false);
                yield return new TestCaseData("false").Returns(true);
            }
        }

        public static IEnumerable<TestCaseData> ToBoolWithDefault
        {
            get
            {
                yield return new TestCaseData("abcdef", false).Returns(false);
                yield return new TestCaseData("Negatory", true).Returns(true);
                yield return new TestCaseData("Affirmative", false).Returns(false);
                yield return new TestCaseData("false", true).Returns(false);
            }
        }
    }
}
