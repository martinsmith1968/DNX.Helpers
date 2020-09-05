using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using DNX.Helpers.Strings;
using NUnit.Framework;
using Shouldly;

namespace Test.DNX.Helpers.Strings
{
    [TestFixture]
    public class RegexStringExtensionsTests
    {
        [TestCase("Qwerty:123", "([^:]+):(.*)", "1", "2", ExpectedResult = "Qwerty=123")]
        [TestCase("UseFlag=Yes", "(?<name>[^=]+)=(?<value>.*)", "name", "value", ExpectedResult = "UseFlag=Yes")]
        [TestCase("Notparseable", "([^=]+):(.*)", "1", "2", ExpectedResult = "=")]
        public string ParseToKeyValuePair_can_parse_the_input_successfully(string input, string regex, string keyGroupName, string valueGroupName)
        {
            var kvp = input.ParseToKeyValuePair(regex, keyGroupName, valueGroupName);

            var result = string.Format("{0}={1}", kvp.Key, kvp.Value);

            return result;
        }

        [TestCase("Qwerty:123;Blah:456;Pelham:123", "([^:]+):(.*)", "1", "2", ExpectedResult = "Blah=456;Pelham=123;Qwerty=123")]
        [TestCase("UseFlag=Yes;Compile=True;ErrorLevel=4", "(?<name>[^=]+)=(?<value>.*)", "name", "value", ExpectedResult = "Compile=True;ErrorLevel=4;UseFlag=Yes")]
        [TestCase("Notparseable", "([^=]+):(.*)", "1", "2", ExpectedResult = "")]
        public string ParseToDictionary_can_parse_the_input_successfully(string input, string regex, string keyGroupName, string valueGroupName)
        {
            var list = input.Split(";")
                .ToList();

            var dictionary = list.ParseToDictionary(regex, keyGroupName, valueGroupName);

            var result = string.Join(";",
                dictionary
                    .OrderBy(kvp => kvp.Key)
                    .Select(kvp => string.Format("{0}={1}", kvp.Key, kvp.Value))
                );

            return result;
        }

        [Test]
        public void ParseToDictionaryList_can_parse_named_groups_with_a_single_match()
        {
            const string fieldNameRegex = @"(?<FieldName>[A-Za-z0-9]+)[\[]*(?<IndexerName>[A-Za-z0-9]*)[\]]*";

            const string input = "CustomField[Blah]";

            var result = input.ParseToDictionaryList(fieldNameRegex);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);

            var dictionary = result.First();
            Assert.AreEqual("CustomField", dictionary["FieldName"]);
            Assert.AreEqual("Blah", dictionary["IndexerName"]);
        }

        [Test]
        public void ParseToDictionaryList_can_parse_unnamed_groups_with_a_single_match()
        {
            const string fieldNameRegex = @"([A-Za-z0-9]+)[\[]*([A-Za-z0-9]*)[\]]*";

            const string input = "CustomField[Blah]";

            var result = input.ParseToDictionaryList(fieldNameRegex);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);

            var dictionary = result.First();
            Assert.AreEqual("CustomField", dictionary["1"]);
            Assert.AreEqual("Blah", dictionary["2"]);
        }

        [Test]
        public void ParseFirstMatchToDictionary_can_parse_named_groups_with_a_single_match()
        {
            const string fieldNameRegex = @"(?<FieldName>[A-Za-z0-9]+)[\[]*(?<IndexerName>[A-Za-z0-9]*)[\]]*";

            const string input = "CustomField[Blah]";

            var result = input.ParseFirstMatchToDictionary(fieldNameRegex);

            Assert.IsNotNull(result);
            Assert.AreEqual("CustomField", result["FieldName"]);
            Assert.AreEqual("Blah", result["IndexerName"]);
        }

        [Test]
        public void GetGroupName_can_extract_group_names()
        {
            const string fieldNameRegex = @"(?<FieldName>[A-Za-z0-9]+)[\[]*(?<IndexerName>[A-Za-z0-9]*)[\]]*";

            var regex = new Regex(fieldNameRegex);

            regex.GetGroupName(0).ShouldBe("0");
            regex.GetGroupName(1).ShouldBe("FieldName");
            regex.GetGroupName(2).ShouldBe("IndexerName");
            regex.GetGroupName(3).ShouldBe("3");
        }

        [Test]
        [TestCaseSource(nameof(GetRegexValueByGroupName_Data))]
        public void GetValueByGroupName(string text, string pattern, string groupName, RegexOptions options, string defaultValue, string expectedValue)
        {
            var result = text.GetRegexValueByGroupName(pattern, groupName, options, defaultValue);

            result.ShouldBe(expectedValue);
        }

        [Test]
        [TestCaseSource(nameof(GetRegexValueByGroupIndex_Data))]
        public void GetValueByGroupId(string text, string pattern, int groupId, RegexOptions options, string defaultValue, string expectedValue)
        {
            var result = text.GetRegexValueByGroupIndex(pattern, groupId, options, defaultValue);

            result.ShouldBe(expectedValue);
        }

        public static IEnumerable GetRegexValueByGroupName_Data()
        {
            yield return new object[] { "Categories[4]", "^[^\\[]+\\[(?<index>[^\\]]+)\\]$", "index", RegexOptions.None, null, "4" };
            yield return new object[] { "Categories[bob]", "^[^\\[]+\\[(?<index>[^\\]]+)\\]$", "index", RegexOptions.None, null, "bob" };
            yield return new object[] { "Categories[4]", "^[^\\[]+\\[(?<index>[^\\]]+)\\]$", "index", RegexOptions.None, "dave", "4" };
            yield return new object[] { "Categories[bob]", "^[^\\[]+\\[(?<index>[^\\]]+)\\]$", "index", RegexOptions.None, "dave", "bob" };
            yield return new object[] { "Categories[bob]", "^[^\\[]+\\[(?<index>[^\\]]+)\\]$", "group1", RegexOptions.None, null, "" };
            yield return new object[] { "Categories[bob]", "^[^\\[]+\\[(?<index>[^\\]]+)\\]$", "group1", RegexOptions.None, "bob", "" };
        }

        public static IEnumerable GetRegexValueByGroupIndex_Data()
        {
            yield return new object[] { "Categories[4]", "^[^\\[]+\\[(?<index>[^\\]]+)\\]$", 1, RegexOptions.None, null, "4" };
            yield return new object[] { "Categories[bob]", "^[^\\[]+\\[(?<index>[^\\]]+)\\]$", 1, RegexOptions.None, null, "bob" };
            yield return new object[] { "Categories[4]", "^[^\\[]+\\[(?<index>[^\\]]+)\\]$", 1, RegexOptions.None, "dave", "4" };
            yield return new object[] { "Categories[bob]", "^[^\\[]+\\[(?<index>[^\\]]+)\\]$", 1, RegexOptions.None, "dave", "bob" };
            yield return new object[] { "Categories[bob]", "^[^\\[]+\\[(?<index>[^\\]]+)\\]$", 99, RegexOptions.None, null, "" };
            yield return new object[] { "Categories[bob]", "^[^\\[]+\\[(?<index>[^\\]]+)\\]$", 99, RegexOptions.None, "bob", "" };
        }
    }
}
