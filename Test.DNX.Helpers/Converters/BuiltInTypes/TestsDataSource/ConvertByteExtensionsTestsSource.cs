using System.Collections.Generic;
using NUnit.Framework;

namespace Test.DNX.Helpers.Converters.BuiltInTypes.TestsDataSource
{
    public class ConvertByteExtensionsTestsSource
    {
        public static IEnumerable<TestCaseData> IsByte
        {
            get
            {
                yield return new TestCaseData(byte.MinValue.ToString()).Returns(true);
                yield return new TestCaseData(byte.MaxValue.ToString()).Returns(true);
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

        public static IEnumerable<TestCaseData> ToByte
        {
            get
            {
                yield return new TestCaseData(byte.MinValue.ToString()).Returns(byte.MinValue);
                yield return new TestCaseData(byte.MaxValue.ToString()).Returns(byte.MaxValue);
                yield return new TestCaseData("0").Returns(0);
                yield return new TestCaseData("100").Returns(100);
                yield return new TestCaseData("10").Returns(10);
                yield return new TestCaseData("10 ").Returns(10);
            }
        }

        public static IEnumerable<TestCaseData> ToByteThrows
        {
            get
            {
                yield return new TestCaseData("abcdef").Returns(false);
                yield return new TestCaseData("50.5").Returns(false);
                yield return new TestCaseData("-10").Returns(false);
                yield return new TestCaseData("100,000").Returns(false);
                yield return new TestCaseData(short.MaxValue.ToString()).Returns(false);
                yield return new TestCaseData("100").Returns(true);
            }
        }

        public static IEnumerable<TestCaseData> ToByteWithDefault
        {
            get
            {
                yield return new TestCaseData("abcdef", (byte)25).Returns(25);
                yield return new TestCaseData("50.5", (byte)25).Returns(25);
                yield return new TestCaseData("100,000", (byte)100).Returns(100);
                yield return new TestCaseData("100", (byte)25).Returns(100);
            }
        }
    }
}
