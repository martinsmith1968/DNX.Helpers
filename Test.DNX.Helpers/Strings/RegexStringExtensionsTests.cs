using System.Linq;
using DNX.Helpers.Strings;
using NUnit.Framework;

namespace Test.DNX.Helpers.Strings
{
    [TestFixture]
    public class RegexStringExtensionsTests
    {
        [Test]
        public void ParseToDictionary_named_groups_with_a_single_match()
        {
            const string fieldNameRegex = @"(?<FieldName>[A-Za-z0-9]+)[\[]*(?<IndexerName>[A-Za-z0-9]*)[\]]*";

            const string input = "CustomField[Blah]";

            var result = input.ParseToDictionary(fieldNameRegex);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);

            var dictionary = result.First();
            Assert.AreEqual("CustomField", dictionary["FieldName"]);
            Assert.AreEqual("Blah", dictionary["IndexerName"]);
        }

        [Test]
        public void ParseToDictionary_unnamed_groups_with_a_single_match()
        {
            const string fieldNameRegex = @"([A-Za-z0-9]+)[\[]*([A-Za-z0-9]*)[\]]*";

            const string input = "CustomField[Blah]";

            var result = input.ParseToDictionary(fieldNameRegex);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);

            var dictionary = result.First();
            Assert.AreEqual("CustomField", dictionary["1"]);
            Assert.AreEqual("Blah", dictionary["2"]);
        }
    }
}
