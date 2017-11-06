using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace DNX.Helpers.Linq
{
    /// <summary>
    /// Class NameValueExtensions.
    /// </summary>
    public static class NameValueExtensions
    {
        /// <summary>
        /// Create a Dictionary from a NameValueCollection
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="mergeTechnique">The merge technique.</param>
        /// <returns>IDictionary&lt;System.String, System.String&gt;.</returns>
        public static IDictionary<string, string> ToDictionary(this NameValueCollection collection, MergeTechnique mergeTechnique)
        {
            var dictionaries = new List<IDictionary<string, string>>();

            for (var i=0; i < collection.Count; ++i)
            {
                var key    = collection.GetKey(i);
                var values = collection.GetValues(i) ?? Enumerable.Empty<string>();

                foreach (var value in values)
                {
                    var dict = new Dictionary<string, string>()
                    {
                        { key, value }
                    };

                    dictionaries.Add(dict);
                }
            }

            return DictionaryExtensions.Merge(mergeTechnique, dictionaries.ToArray());
        }
    }
}
