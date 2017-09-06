using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Test.DNX.Helpers.Converters.BuiltInTypes.TestsDataSource
{
    public class ConvertInt32ExtensionsTestsSource
    {
        public static IEnumerable<TestCaseData> IsInt32
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

        public static IEnumerable<TestCaseData> ToInt32
        {
            get
            {
                yield return new TestCaseData(Int32.MinValue.ToString()).Returns(Int32.MinValue);
                yield return new TestCaseData(Int32.MaxValue.ToString()).Returns(Int32.MaxValue);
                yield return new TestCaseData("0").Returns(0);
                yield return new TestCaseData("100").Returns(100);
                yield return new TestCaseData("10").Returns(10);
                yield return new TestCaseData("10 ").Returns(10);
                yield return new TestCaseData("-1").Returns(-1);
            }
        }

        public static IEnumerable<TestCaseData> ToInt32Throws
        {
            get
            {
                yield return new TestCaseData("abcdef").Returns(false);
                yield return new TestCaseData("50.5").Returns(false);
                yield return new TestCaseData("-10").Returns(true);
                yield return new TestCaseData("100,000").Returns(false);
                yield return new TestCaseData(Int64.MaxValue.ToString()).Returns(false);
                yield return new TestCaseData("100").Returns(true);
            }
        }

        public static IEnumerable<TestCaseData> ToInt32WithDefault
        {
            get
            {
                yield return new TestCaseData("abcdef", (Int32)25).Returns(25);
                yield return new TestCaseData("50.5", (Int32)25).Returns(25);
                yield return new TestCaseData("100,000", (Int32)100).Returns(100);
                yield return new TestCaseData("100", (Int32)25).Returns(100);
            }
        }
    }
}
