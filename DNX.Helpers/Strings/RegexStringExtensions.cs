using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using DNX.Helpers.Linq;

// ReSharper disable once LoopCanBeConvertedToQuery
namespace DNX.Helpers.Strings
{
    /// <summary>
    /// Regex String Extensions.
    /// </summary>
    public static class RegexStringExtensions
    {
        /// <summary>
        /// Parses to key value pair.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="regExpression">The reg expression.</param>
        /// <param name="keyGroupName">Name of the key group.</param>
        /// <param name="valueGroupName">Name of the value group.</param>
        /// <returns>KeyValuePair&lt;System.String, System.String&gt;.</returns>
        public static KeyValuePair<string, string> ParseToKeyValuePair(this string input, string regExpression, string keyGroupName = "1", string valueGroupName = "2")
        {
            var values = input.ParseFirstMatchToDictionary(regExpression);

            if (values == null)
            {
                return default(KeyValuePair<string, string>);
            }

            var result = new KeyValuePair<string, string>(
                values.GetValue(keyGroupName),
                values.GetValue(valueGroupName)
                );

            return result;
        }

        /// <summary>
        /// Parses to dictionary.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="regExpression">The reg expression.</param>
        /// <param name="keyGroupName">Name of the key group.</param>
        /// <param name="valueGroupName">Name of the value group.</param>
        /// <returns>Dictionary&lt;System.String, System.String&gt;.</returns>
        public static Dictionary<string, string> ParseToDictionary(this IEnumerable<string> input, string regExpression, string keyGroupName = "1", string valueGroupName = "2")
        {
            var values = input
                .Select(x => x.ParseToKeyValuePair(regExpression, keyGroupName, valueGroupName))
                .Where(x => !string.IsNullOrEmpty(x.Key))
                .ToDictionary(
                    a => a.Key,
                    a => a.Value
                );

            return values;
        }

        /// <summary>
        /// Parses to a list of dictionaries.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="regExpression">The reg expression.</param>
        /// <returns>List&lt;Dictionary&lt;System.String, System.String&gt;&gt;.</returns>
        public static List<Dictionary<string, string>> ParseToDictionaryList(this string input, string regExpression)
        {
            var regex = new Regex(regExpression);

            var matches = regex.Matches(input);

            var result = new List<Dictionary<string, string>>();

            foreach (Match match in matches)
            {
                var index = 0;
                var dictionary = match.Groups
                    .Cast<Group>()
                    .ToDictionary(
                        g => GetGroupName(regex, index++),
                        v => v.Value
                        );

                result.Add(dictionary);
            }

            return result;
        }

        /// <summary>
        /// Parses the first match to dictionary.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="regExpression">The regular expression.</param>
        /// <returns>Dictionary&lt;System.String, System.String&gt;.</returns>
        public static Dictionary<string, string> ParseFirstMatchToDictionary(this string input, string regExpression)
        {
            var dictionary = ParseToDictionaryList(input, regExpression);

            return dictionary.FirstOrDefault();
        }

        /// <summary>
        /// Gets the name of the group.
        /// </summary>
        /// <param name="regex">The regex.</param>
        /// <param name="index">The index.</param>
        /// <returns>System.String.</returns>
        public static string GetGroupName(this Regex regex, int index)
        {
            var groupNames = regex.GetGroupNames();

            index = groupNames.GetAbsoluteIndex(index);

            return groupNames.IsIndexValid(index)
                ? groupNames[index]
                : index.ToString();
        }
    }
}
