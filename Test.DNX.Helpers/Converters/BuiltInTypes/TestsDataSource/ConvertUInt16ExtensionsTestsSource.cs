using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Test.DNX.Helpers.Converters.BuiltInTypes.TestsDataSource
{
    public class ConvertUInt16ExtensionsTestsSource
    {
        public static IEnumerable<TestCaseData> IsUInt16
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

        public static IEnumerable<TestCaseData> ToUInt16
        {
            get
            {
                yield return new TestCaseData(UInt16.MinValue.ToString()).Returns(UInt16.MinValue);
                yield return new TestCaseData(UInt16.MaxValue.ToString()).Returns(UInt16.MaxValue);
                yield return new TestCaseData("0").Returns(0);
                yield return new TestCaseData("100").Returns(100);
                yield return new TestCaseData("10").Returns(10);
                yield return new TestCaseData("10 ").Returns(10);
            }
        }

        public static IEnumerable<TestCaseData> ToUInt16Throws
        {
            get
            {
                yield return new TestCaseData("abcdef").Returns(false);
                yield return new TestCaseData("50.5").Returns(false);
                yield return new TestCaseData("-10").Returns(false);
                yield return new TestCaseData("100,000").Returns(false);
                yield return new TestCaseData(UInt32.MaxValue.ToString()).Returns(false);
                yield return new TestCaseData("100").Returns(true);
            }
        }

        public static IEnumerable<TestCaseData> ToUInt16WithDefault
        {
            get
            {
                yield return new TestCaseData("abcdef", (UInt16)25).Returns(25);
                yield return new TestCaseData("50.5", (UInt16)25).Returns(25);
                yield return new TestCaseData("100,000", (UInt16)100).Returns(100);
                yield return new TestCaseData("100", (UInt16)25).Returns(100);
            }
        }
    }
}
