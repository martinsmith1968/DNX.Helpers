using System.Collections.Generic;
using NUnit.Framework;

namespace Test.DNX.Helpers.Converters.BuiltInTypes.TestsDataSource
{
    public class ConvertULongExtensionsTestsSource
    {
        public static IEnumerable<TestCaseData> IsULong
        {
            get
            {
                yield return new TestCaseData("0").Returns(true);
                yield return new TestCaseData("1").Returns(true);
                yield return new TestCaseData("-1").Returns(false);
                yield return new TestCaseData("100").Returns(true);
                yield return new TestCaseData("200").Returns(true);
                yield return new TestCaseData("-100").Returns(false);
                yield return new TestCaseData("-200").Returns(false);
                yield return new TestCaseData(" 100").Returns(true);
                yield return new TestCaseData("100 ").Returns(true);
                yield return new TestCaseData("1.5").Returns(false);
                yield return new TestCaseData("£100").Returns(false);
            }
        }

        public static IEnumerable<TestCaseData> ToULong
        {
            get
            {
                yield return new TestCaseData(ulong.MinValue.ToString()).Returns(ulong.MinValue);
                yield return new TestCaseData(ulong.MaxValue.ToString()).Returns(ulong.MaxValue);
                yield return new TestCaseData("0").Returns(0);
                yield return new TestCaseData("100").Returns(100);
                yield return new TestCaseData("10").Returns(10);
                yield return new TestCaseData("10 ").Returns(10);
            }
        }

        public static IEnumerable<TestCaseData> ToULongThrows
        {
            get
            {
                yield return new TestCaseData("abcdef").Returns(false);
                yield return new TestCaseData("50.5").Returns(false);
                yield return new TestCaseData("-10").Returns(false);
                yield return new TestCaseData("100,000").Returns(false);
                yield return new TestCaseData(double.MaxValue.ToString("0.0")).Returns(false);
                yield return new TestCaseData("100").Returns(true);
            }
        }

        public static IEnumerable<TestCaseData> ToULongWithDefault
        {
            get
            {
                yield return new TestCaseData("abcdef", (ulong)25).Returns(25);
                yield return new TestCaseData("50.5", (ulong)25).Returns(25);
                yield return new TestCaseData("100,000", (ulong)100).Returns(100);
                yield return new TestCaseData("100", (ulong)25).Returns(100);
            }
        }
    }
}
