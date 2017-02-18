using System.Collections.Generic;
using NUnit.Framework;

namespace Test.DNX.Helpers.Converters.BuiltInTypes.Source
{
    public class ConvertIntExtensionsTestsSource
    {
        public static IEnumerable<TestCaseData> IsInt
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

        public static IEnumerable<TestCaseData> ToInt
        {
            get
            {
                yield return new TestCaseData(int.MinValue.ToString()).Returns(int.MinValue);
                yield return new TestCaseData(int.MaxValue.ToString()).Returns(int.MaxValue);
                yield return new TestCaseData("0").Returns(0);
                yield return new TestCaseData("100").Returns(100);
                yield return new TestCaseData("10").Returns(10);
                yield return new TestCaseData("10 ").Returns(10);
                yield return new TestCaseData("-1").Returns(-1);
            }
        }

        public static IEnumerable<TestCaseData> ToIntThrows
        {
            get
            {
                yield return new TestCaseData("abcdef").Returns(false);
                yield return new TestCaseData("50.5").Returns(false);
                yield return new TestCaseData("-10").Returns(true);
                yield return new TestCaseData("100,000").Returns(false);
                yield return new TestCaseData(long.MaxValue.ToString()).Returns(false);
                yield return new TestCaseData("100").Returns(true);
            }
        }

        public static IEnumerable<TestCaseData> ToIntWithDefault
        {
            get
            {
                yield return new TestCaseData("abcdef", (int)25).Returns(25);
                yield return new TestCaseData("50.5", (int)25).Returns(25);
                yield return new TestCaseData("100,000", (int)100).Returns(100);
                yield return new TestCaseData("100", (int)25).Returns(100);
            }
        }
    }
}
