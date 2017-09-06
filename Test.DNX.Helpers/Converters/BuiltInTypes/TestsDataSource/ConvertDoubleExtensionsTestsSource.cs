using System.Collections.Generic;
using NUnit.Framework;

namespace Test.DNX.Helpers.Converters.BuiltInTypes.TestsDataSource
{
    public class ConvertDoubleExtensionsTestsSource
    {
        public static IEnumerable<TestCaseData> IsDouble
        {
            get
            {
                yield return new TestCaseData("0").Returns(true);
                yield return new TestCaseData("1").Returns(true);
                yield return new TestCaseData("True").Returns(false);
                yield return new TestCaseData("False").Returns(false);
                yield return new TestCaseData("true").Returns(false);
                yield return new TestCaseData("false").Returns(false);
                yield return new TestCaseData("Yes").Returns(false);
                yield return new TestCaseData("No").Returns(false);
            }
        }

        public static IEnumerable<TestCaseData> ToDouble
        {
            get
            {
                yield return new TestCaseData(double.MinValue.ToString("r")).Returns(double.MinValue);
                yield return new TestCaseData(double.MaxValue.ToString("r")).Returns(double.MaxValue);
                yield return new TestCaseData("0").Returns(0);
                yield return new TestCaseData("100").Returns(100);
                yield return new TestCaseData("10").Returns(10);
                yield return new TestCaseData("10 ").Returns(10);
            }
        }

        public static IEnumerable<TestCaseData> ToDoubleThrows
        {
            get
            {
                yield return new TestCaseData(double.MinValue.ToString()).Returns(false);
                yield return new TestCaseData(double.MaxValue.ToString()).Returns(false);
                yield return new TestCaseData("abcdef").Returns(false);
                yield return new TestCaseData("50.5").Returns(true);
                yield return new TestCaseData("£-10").Returns(false);
                yield return new TestCaseData("100,000").Returns(true);
                yield return new TestCaseData(long.MaxValue.ToString()).Returns(true);
                yield return new TestCaseData("100").Returns(true);
            }
        }

        public static IEnumerable<TestCaseData> ToDoubleWithDefault
        {
            get
            {
                yield return new TestCaseData(double.MinValue.ToString(), double.MaxValue).Returns(double.MaxValue);
                yield return new TestCaseData(double.MaxValue.ToString(), double.MinValue).Returns(double.MinValue);
                yield return new TestCaseData("abcdef", (double)25).Returns(25);
                yield return new TestCaseData("$50.5", (double)25).Returns(25);
                yield return new TestCaseData("100,000", (double)100).Returns(100000);
                yield return new TestCaseData("100", (double)25).Returns(100);
            }
        }
    }
}
