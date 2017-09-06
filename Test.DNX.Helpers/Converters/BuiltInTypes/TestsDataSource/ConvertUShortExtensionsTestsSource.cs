using System.Collections.Generic;
using NUnit.Framework;

namespace Test.DNX.Helpers.Converters.BuiltInTypes.TestsDataSource
{
    public class ConvertUShortExtensionsTestsSource
    {
        public static IEnumerable<TestCaseData> IsUShort
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

        public static IEnumerable<TestCaseData> ToUShort
        {
            get
            {
                yield return new TestCaseData(ushort.MinValue.ToString()).Returns(ushort.MinValue);
                yield return new TestCaseData(ushort.MaxValue.ToString()).Returns(ushort.MaxValue);
                yield return new TestCaseData("0").Returns(0);
                yield return new TestCaseData("100").Returns(100);
                yield return new TestCaseData("10").Returns(10);
                yield return new TestCaseData("10 ").Returns(10);
                yield return new TestCaseData("-1").Returns(-1);
            }
        }

        public static IEnumerable<TestCaseData> ToUShortThrows
        {
            get
            {
                yield return new TestCaseData("abcdef").Returns(false);
                yield return new TestCaseData("50.5").Returns(false);
                yield return new TestCaseData("-10").Returns(true);
                yield return new TestCaseData("100,000").Returns(false);
                yield return new TestCaseData(double.MaxValue.ToString("0.0")).Returns(false);
                yield return new TestCaseData("100").Returns(true);
            }
        }

        public static IEnumerable<TestCaseData> ToUShortWithDefault
        {
            get
            {
                yield return new TestCaseData("abcdef", (ushort)25).Returns(25);
                yield return new TestCaseData("50.5", (ushort)25).Returns(25);
                yield return new TestCaseData("100,000", (ushort)100).Returns(100);
                yield return new TestCaseData("100", (ushort)25).Returns(100);
            }
        }
    }
}
