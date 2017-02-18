﻿using DNX.Helpers.Converters.BuiltInTypes;
using DNX.Helpers.Exceptions;
using NUnit.Framework;
using Test.DNX.Helpers.Converters.BuiltInTypes.Source;

namespace Test.DNX.Helpers.Converters.BuiltInTypes
{
    [TestFixture]
    public class ConvertUShortExtensionsTests
    {
        [TestCaseSource(typeof(ConvertUShortExtensionsTestsSource), "IsUShort")]
        public bool Test_IsUShort(string text)
        {
            var result = text.IsUShort();

            return result;
        }

        [TestCaseSource(typeof(ConvertUShortExtensionsTestsSource), "ToUShort")]
        public ushort Test_ToUShort(string text)
        {
            var result = text.ToUShort();

            return result;
        }

        [TestCaseSource(typeof(ConvertUShortExtensionsTestsSource), "ToUShortThrows")]
        public bool Test_ToUShort_Throws(string text)
        {
            try
            {
                text.ToUShort();
            }
            catch (ConversionException ex)
            {
                Assert.AreEqual(text, ex.Value);

                return false;
            }

            return true;
        }

        [TestCaseSource(typeof(ConvertUShortExtensionsTestsSource), "ToUShortWithDefault")]
        public ushort Test_ToUShort_with_default(string text, ushort defaultValue)
        {
            var result = text.ToUShort(defaultValue);

            return result;
        }
    }
}
