using System;
using System.Collections.Generic;
using System.Linq;
using DNX.Helpers.Linq;
using DNX.Helpers.Strings;
using NUnit.Framework;
using Should;

namespace Test.DNX.Helpers.Linq
{
    [TestFixture]
    public class DictionaryExtensionsTests
    {
        [TestCase("a=1;b=2;c=3", "b", ExpectedResult = "2")]
        [TestCase("a=1;b=2;c=3", "a", ExpectedResult = "1")]
        [TestCase("a=1;b=2;c=3", "c", ExpectedResult = "3")]
        [TestCase("a=1;b=2;c=3", "z", ExpectedResult = null)]
        [TestCase("a=1;b=2;c=3", "", ExpectedResult = null)]
        public string Test_GetValue(string dictionaryText, string key)
        {
            var dictionary = dictionaryText.Split(";")
                .Select(x => x.ParseFirstMatchToDictionary(@"([^=]+)=(.*)"))
                .ToDictionary(
                    a => a["1"],
                    a => a["2"]
                );

            var result = dictionary.GetValue(key);

            return result;
        }

        [TestCase("blah")]
        public void Test_GetValue_doesnt_allow_null_dictionary(string key)
        {
            Dictionary<string, string> dictionary = null;

            var ex = Assert.Throws<ArgumentNullException>(
                () => dictionary.GetValue(key)
                );

            ex.ShouldNotBeNull();
            ex.ParamName.ShouldEqual("dictionary");
        }

        [TestCase("a=1;b=2;c=3", null, ExpectedResult = false)]
        public bool Test_GetValue_doesnt_allow_null_keyname(string dictionaryText, string key)
        {
            try
            {
                Test_GetValue(dictionaryText, key);

                return true;
            }
            catch (ArgumentNullException ex)
            {
                ex.ParamName.ShouldEqual("keyName");

                return false;
            }
        }

        [TestCase("a=1;b=2;c=3", "b", "4", ExpectedResult = "a=1;b=4;c=3")]
        [TestCase("a=1;b=2;c=3", "a", "4", ExpectedResult = "a=4;b=2;c=3")]
        [TestCase("a=1;b=2;c=3", "c", "4", ExpectedResult = "a=1;b=2;c=4")]
        [TestCase("a=1;b=2;c=3", "z", "4", ExpectedResult = "a=1;b=2;c=3;z=4")]
        [TestCase("a=1;b=2;c=3", "", "4", ExpectedResult = "a=1;b=2;c=3;=4")]
        public string Test_SetValue(string dictionaryText, string key, string newValue)
        {
            var dictionary = dictionaryText.Split(";")
                .Select(x => x.ParseFirstMatchToDictionary(@"([^=]+)=(.*)"))
                .ToDictionary(
                    a => a["1"],
                    a => a["2"]
                );

            dictionary.SetValue(key, newValue);

            var result = string.Join(";", dictionary
                .Select(x => string.Format("{0}={1}", x.Key, x.Value))
                );

            return result;
        }
        [TestCase("blah", "blah")]
        public void Test_SetValue_doesnt_allow_null_dictionary(string key, string value)
        {
            Dictionary<string, string> dictionary = null;

            var ex = Assert.Throws<ArgumentNullException>(
                () => dictionary.SetValue(key, value)
                );

            ex.ShouldNotBeNull();
            ex.ParamName.ShouldEqual("dictionary");
        }

        [TestCase("a=1;b=2;c=3", null, "4", ExpectedResult = false)]
        public bool Test_SetValue_doesnt_allow_null_keyname(string dictionaryText, string key, string newValue)
        {
            try
            {
                Test_SetValue(dictionaryText, key, newValue);

                return true;
            }
            catch (ArgumentNullException ex)
            {
                ex.ParamName.ShouldEqual("keyName");

                return false;
            }
        }

        [TestCase("a=1;b=2;c=3", "b", "q", ExpectedResult = "a=1;c=3;q=2")]
        [TestCase("a=1;b=2;c=3", "a", "q", ExpectedResult = "b=2;c=3;q=1")]
        [TestCase("a=1;b=2;c=3", "c", "q", ExpectedResult = "a=1;b=2;q=3")]
        [TestCase("a=1;b=2;c=3", "z", "q", ExpectedResult = "a=1;b=2;c=3")]
        [TestCase("a=1;b=2;c=3", "", "q", ExpectedResult = "a=1;b=2;c=3")]
        public string Test_RenameKey(string dictionaryText, string keyName, string newKeyName)
        {
            var dictionary = dictionaryText.Split(";")
                .Select(x => x.ParseFirstMatchToDictionary(@"([^=]+)=(.*)"))
                .ToDictionary(
                    a => a["1"],
                    a => a["2"]
                );

            dictionary.RenameKey(keyName, newKeyName);

            var result = string.Join(";", dictionary
                .OrderBy(d => d.Key)
                .Select(x => string.Format("{0}={1}", x.Key, x.Value))
                );

            return result;
        }

        [TestCase("a=1;b=2;c=3", "a", null, ExpectedResult = false)]
        [TestCase("a=1;b=2;c=3", null, "a", ExpectedResult = false)]
        public bool Test_RenameKey_doesnt_allow_null_keyname(string dictionaryText, string key, string newKeyName)
        {
            try
            {
                Test_RenameKey(dictionaryText, key, newKeyName);

                return true;
            }
            catch (ArgumentNullException ex)
            {
                ex.ParamName.EndsWith("KeyName").ShouldBeTrue();    // fromKeyName, toKeyName

                return false;
            }
        }
    }
}
