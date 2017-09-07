using System.Collections.Generic;
using NUnit.Framework;

namespace Test.DNX.Helpers.Converters.BuiltInTypes.TestsDataSource
{
    public class ConvertFloatExtensionsTestsSource
    {
        private const float ParsedMinValue = -3.40282306E+38f;
        private const float ParsedMaxValue = 3.40282306E+38f;

        public static IEnumerable<TestCaseData> IsFloat
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

        public static IEnumerable<TestCaseData> ToFloat
        {
            get
            {
                yield return new TestCaseData(float.MinValue.ToString("R")).Returns(float.MinValue);
                yield return new TestCaseData(float.MaxValue.ToString("R")).Returns(float.MaxValue);
                yield return new TestCaseData(float.MinValue.ToString("")).Returns(ParsedMinValue);
                yield return new TestCaseData(float.MaxValue.ToString("")).Returns(ParsedMaxValue);
                yield return new TestCaseData("0").Returns(0);
                yield return new TestCaseData("100").Returns(100);
                yield return new TestCaseData("10").Returns(10);
                yield return new TestCaseData("10 ").Returns(10);
            }
        }

        public static IEnumerable<TestCaseData> ToFloatThrows
        {
            get
            {
                yield return new TestCaseData("abcdef").Returns(false);
                yield return new TestCaseData("50.5").Returns(true);
                yield return new TestCaseData("£-10").Returns(false);
                yield return new TestCaseData("100,000").Returns(true);
                yield return new TestCaseData(long.MaxValue.ToString()).Returns(true);
                yield return new TestCaseData("100").Returns(true);
            }
        }

        public static IEnumerable<TestCaseData> ToFloatWithDefault
        {
            get
            {
                yield return new TestCaseData(float.MinValue.ToString(), 0).Returns(ParsedMinValue);
                yield return new TestCaseData(float.MaxValue.ToString(), 0).Returns(ParsedMaxValue);
                yield return new TestCaseData("abcdef", (float)25).Returns(25);
                yield return new TestCaseData("$50.5", (float)25).Returns(25);
                yield return new TestCaseData("100,000", (float)100).Returns(100000);
                yield return new TestCaseData("100", (float)25).Returns(100);
            }
        }
    }
}
