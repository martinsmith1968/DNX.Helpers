using System.Collections.Generic;
using NUnit.Framework;

namespace Test.DNX.Helpers.Converters.BuiltInTypes.Source
{
    public class ConvertSByteExtensionsTestsSource
    {
        public static IEnumerable<TestCaseData> IsSByte
        {
            get
            {
                yield return new TestCaseData(sbyte.MinValue.ToString()).Returns(true);
                yield return new TestCaseData(sbyte.MaxValue.ToString()).Returns(true);
                yield return new TestCaseData("0").Returns(true);
                yield return new TestCaseData("1").Returns(true);
                yield return new TestCaseData("-1").Returns(true);
                yield return new TestCaseData("100").Returns(true);
                yield return new TestCaseData("200").Returns(false);
                yield return new TestCaseData("-100").Returns(true);
                yield return new TestCaseData("-200").Returns(false);
                yield return new TestCaseData(" 100").Returns(true);
                yield return new TestCaseData("100 ").Returns(true);
                yield return new TestCaseData("1.5").Returns(false);
                yield return new TestCaseData("£100").Returns(false);
            }
        }

        public static IEnumerable<TestCaseData> ToSByte
        {
            get
            {
                yield return new TestCaseData(sbyte.MinValue.ToString()).Returns(sbyte.MinValue);
                yield return new TestCaseData(sbyte.MaxValue.ToString()).Returns(sbyte.MaxValue);
                yield return new TestCaseData("0").Returns(0);
                yield return new TestCaseData("100").Returns(100);
                yield return new TestCaseData("-100").Returns(-100);
                yield return new TestCaseData("10").Returns(10);
                yield return new TestCaseData("10 ").Returns(10);
            }
        }

        public static IEnumerable<TestCaseData> ToSByteThrows
        {
            get
            {
                yield return new TestCaseData("abcdef").Returns(false);
                yield return new TestCaseData("50.5").Returns(false);
                yield return new TestCaseData("130").Returns(false);
                yield return new TestCaseData("-130").Returns(false);
                yield return new TestCaseData("-10").Returns(true);
                yield return new TestCaseData("100,000").Returns(false);
                yield return new TestCaseData(byte.MaxValue.ToString()).Returns(false);
                yield return new TestCaseData("100").Returns(true);
            }
        }

        public static IEnumerable<TestCaseData> ToSByteWithDefault
        {
            get
            {
                yield return new TestCaseData("abcdef", (sbyte)25).Returns(25);
                yield return new TestCaseData("50.5", (sbyte)25).Returns(25);
                yield return new TestCaseData("100,000", (sbyte)100).Returns(100);
                yield return new TestCaseData("100", (sbyte)25).Returns(100);
            }
        }
    }
}
