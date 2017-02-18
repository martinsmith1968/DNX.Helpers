﻿using DNX.Helpers.Converters.BuiltInTypes;
using DNX.Helpers.Exceptions;
using NUnit.Framework;
using Test.DNX.Helpers.Converters.BuiltInTypes.Source;

namespace Test.DNX.Helpers.Converters.BuiltInTypes
{
    [TestFixture]
    public class ConvertByteExtensionsTests
    {
        [TestCaseSource(typeof(ConvertByteExtensionsTestsSource), "IsByte")]
        public bool Test_IsByte(string text)
        {
            var result = text.IsByte();

            return result;
        }

        [TestCaseSource(typeof(ConvertByteExtensionsTestsSource), "ToByte")]
        public byte Test_ToByte(string text)
        {
            var result = text.ToByte();

            return result;
        }

        [TestCaseSource(typeof(ConvertByteExtensionsTestsSource), "ToByteThrows")]
        public bool Test_ToByte_Throws(string text)
        {
            try
            {
                text.ToByte();
            }
            catch (ConversionException ex)
            {
                Assert.AreEqual(text, ex.Value);

                return false;
            }

            return true;
        }

        [TestCaseSource(typeof(ConvertByteExtensionsTestsSource), "ToByteWithDefault")]
        public byte Test_ToByte_with_default(string text, byte defaultValue)
        {
            var result = text.ToByte(defaultValue);

            return result;
        }
    }
}
