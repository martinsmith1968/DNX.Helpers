using NUnit.Framework;
using System.Collections.Generic;

namespace Test.DNX.Helpers.Converters.BuiltInTypes.TestsDataSource
{
    public class ConvertShortExtensionsTestsSource
    {
        public static IEnumerable<TestCaseData> IsShort
        {
            get
            {
                yield return new TestCaseData("0").Returns(true);
                yield return new TestCaseData("1").Returns(true);
                yield return new TestCaseData("-1").Returns(true);
                yield return new TestCaseData("100").Returns(true);
                yield return new TestCaseData("200").Returns(true);
                yield return new TestCaseData("-100").Returns(true);
                yield return new TestCaseData("-200").Returns(true);
                yield return new TestCaseData(" 100").Returns(true);
                yield return new TestCaseData("100 ").Returns(true);
                yield return new TestCaseData("1.5").Returns(false);
                yield return new TestCaseData("£100").Returns(false);
            }
        }

        public static IEnumerable<TestCaseData> ToShort
        {
            get
            {
                yield return new TestCaseData(short.MinValue.ToString()).Returns(short.MinValue);
                yield return new TestCaseData(short.MaxValue.ToString()).Returns(short.MaxValue);
                yield return new TestCaseData("0").Returns(0);
                yield return new TestCaseData("100").Returns(100);
                yield return new TestCaseData("10").Returns(10);
                yield return new TestCaseData("10 ").Returns(10);
                yield return new TestCaseData("-1").Returns(-1);
            }
        }

        public static IEnumerable<TestCaseData> ToShortThrows
        {
            get
            {
                yield return new TestCaseData("abcdef").Returns(false);
                yield return new TestCaseData("50.5").Returns(false);
                yield return new TestCaseData("-10").Returns(true);
                yield return new TestCaseData("100,000").Returns(false);
                yield return new TestCaseData(int.MaxValue.ToString()).Returns(false);
                yield return new TestCaseData("100").Returns(true);
            }
        }

        public static IEnumerable<TestCaseData> ToShortWithDefault
        {
            get
            {
                yield return new TestCaseData("abcdef", (short)25).Returns(25);
                yield return new TestCaseData("50.5", (short)25).Returns(25);
                yield return new TestCaseData("100,000", (short)100).Returns(100);
                yield return new TestCaseData("100", (short)25).Returns(100);
            }
        }
    }
}
