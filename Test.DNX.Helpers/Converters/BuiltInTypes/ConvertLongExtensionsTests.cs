﻿using System;
using DNX.Helpers.Converters.BuiltInTypes;
using DNX.Helpers.Exceptions;
using NUnit.Framework;
using Test.DNX.Helpers.Converters.BuiltInTypes.TestsDataSource;

namespace Test.DNX.Helpers.Converters.BuiltInTypes
{
    [TestFixture]
    public class ConvertLongExtensionsTests
    {
        [TestCaseSource(typeof(ConvertLongExtensionsTestsSource), "IsLong")]
        public bool Test_IsLong(string text)
        {
            var result = text.IsLong();

            return result;
        }

        [TestCaseSource(typeof(ConvertLongExtensionsTestsSource), "ToLong")]
        public long Test_ToLong(string text)
        {
            var result = text.ToLong();

            return result;
        }

        [TestCaseSource(typeof(ConvertLongExtensionsTestsSource), "ToLongThrows")]
        public bool Test_ToLong_Throws(string text)
        {
            try
            {
                text.ToLong();
            }
            catch (ConversionException ex)
            {
                Assert.AreEqual(text, ex.Value);

                return false;
            }

            return true;
        }

        [TestCaseSource(typeof(ConvertLongExtensionsTestsSource), "ToLongWithDefault")]
        public long Test_ToLong_with_default(string text, long defaultValue)
        {
            var result = text.ToLong(defaultValue);

            return result;
        }
    }
}