using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Test.DNX.Helpers.Converters.BuiltInTypes.TestsDataSource
{
    public class ConvertSingleExtensionsTestsSource
    {
        public static IEnumerable<TestCaseData> IsSingle
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

        public static IEnumerable<TestCaseData> ToSingle
        {
            get
            {
                //yield return new TestCaseData(Single.MinValue.ToString()).Returns(Single.MinValue);
                //yield return new TestCaseData(Single.MaxValue.ToString()).Returns(Single.MaxValue);
                yield return new TestCaseData("0").Returns(0);
                yield return new TestCaseData("100").Returns(100);
                yield return new TestCaseData("10").Returns(10);
                yield return new TestCaseData("10 ").Returns(10);
            }
        }

        public static IEnumerable<TestCaseData> ToSingleThrows
        {
            get
            {
                yield return new TestCaseData(double.MinValue.ToString()).Returns(false);
                yield return new TestCaseData(double.MaxValue.ToString()).Returns(false);
                yield return new TestCaseData("abcdef").Returns(false);
                yield return new TestCaseData("50.5").Returns(true);
                yield return new TestCaseData("£-10").Returns(false);
                yield return new TestCaseData("100,000").Returns(true);
                yield return new TestCaseData(long.MaxValue.ToString()).Returns(true);
                yield return new TestCaseData("100").Returns(true);
            }
        }

        public static IEnumerable<TestCaseData> ToSingleWithDefault
        {
            get
            {
                yield return new TestCaseData(double.MinValue.ToString(), Single.MaxValue).Returns(Single.MaxValue);
                yield return new TestCaseData(double.MaxValue.ToString(), Single.MinValue).Returns(Single.MinValue);
                yield return new TestCaseData("abcdef", (Single)25).Returns(25);
                yield return new TestCaseData("$50.5", (Single)25).Returns(25);
                yield return new TestCaseData("100,000", (Single)100).Returns(100000);
                yield return new TestCaseData("100", (Single)25).Returns(100);
            }
        }
    }
}
