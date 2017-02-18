using System.Collections.Generic;
using NUnit.Framework;

namespace Test.DNX.Helpers.Converters.BuiltInTypes.Source
{
    public class ConvertDecimalExtensionsTestsSource
    {
        public static IEnumerable<TestCaseData> IsDecimal
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

        public static IEnumerable<TestCaseData> ToDecimal
        {
            get
            {
                yield return new TestCaseData(decimal.MinValue.ToString()).Returns(decimal.MinValue);
                yield return new TestCaseData(decimal.MaxValue.ToString()).Returns(decimal.MaxValue);
                yield return new TestCaseData("0").Returns(0);
                yield return new TestCaseData("100").Returns(100);
                yield return new TestCaseData("10").Returns(10);
                yield return new TestCaseData("10 ").Returns(10);
            }
        }

        public static IEnumerable<TestCaseData> ToDecimalThrows
        {
            get
            {
                yield return new TestCaseData("abcdef").Returns(false);
                yield return new TestCaseData("50.5").Returns(true);
                yield return new TestCaseData("£-10").Returns(false);
                yield return new TestCaseData("100,000").Returns(true);
                yield return new TestCaseData(long.MaxValue.ToString()).Returns(true);
                yield return new TestCaseData("100").Returns(true);
            }
        }

        public static IEnumerable<TestCaseData> ToDecimalWithDefault
        {
            get
            {
                yield return new TestCaseData("abcdef", (decimal)25).Returns(25);
                yield return new TestCaseData("$50.5", (decimal)25).Returns(25);
                yield return new TestCaseData("100,000", (decimal)100).Returns(100000);
                yield return new TestCaseData("100", (decimal)25).Returns(100);
            }
        }
    }
}
