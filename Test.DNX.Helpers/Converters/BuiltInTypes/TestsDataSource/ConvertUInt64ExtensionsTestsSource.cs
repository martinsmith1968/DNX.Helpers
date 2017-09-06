using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Test.DNX.Helpers.Converters.BuiltInTypes.TestsDataSource
{
    public class ConvertUInt64ExtensionsTestsSource
    {
        public static IEnumerable<TestCaseData> IsUInt64
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

        public static IEnumerable<TestCaseData> ToUInt64
        {
            get
            {
                yield return new TestCaseData(UInt64.MinValue.ToString()).Returns(UInt64.MinValue);
                yield return new TestCaseData(UInt64.MaxValue.ToString()).Returns(UInt64.MaxValue);
                yield return new TestCaseData("0").Returns(0);
                yield return new TestCaseData("100").Returns(100);
                yield return new TestCaseData("10").Returns(10);
                yield return new TestCaseData("10 ").Returns(10);
                yield return new TestCaseData("-1").Returns(-1);
            }
        }

        public static IEnumerable<TestCaseData> ToUInt64Throws
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

        public static IEnumerable<TestCaseData> ToUInt64WithDefault
        {
            get
            {
                yield return new TestCaseData("abcdef", (UInt64)25).Returns(25);
                yield return new TestCaseData("50.5", (UInt64)25).Returns(25);
                yield return new TestCaseData("100,000", (UInt64)100).Returns(100);
                yield return new TestCaseData("100", (UInt64)25).Returns(100);
            }
        }
    }
}
