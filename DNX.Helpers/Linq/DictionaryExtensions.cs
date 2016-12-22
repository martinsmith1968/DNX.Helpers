using System.Collections.Generic;

namespace DNX.Helpers.Linq
{
    /// <summary>
    /// Dictionary Extensions.
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <typeparam name="TK">The type of the tk.</typeparam>
        /// <typeparam name="TV">The type of the tv.</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="keyName">Name of the key.</param>
        /// <param name="value">The value.</param>
        public static void SetValue<TK, TV>(this IDictionary<TK, TV> dictionary, TK keyName, TV value)
        {
            if (dictionary.ContainsKey(keyName))
            {
                dictionary[keyName] = value;
            }
            else
            {
                dictionary.Add(keyName, value);
            }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <typeparam name="TK">The type of the tk.</typeparam>
        /// <typeparam name="TV">The type of the tv.</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="keyName">Name of the key.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>TV.</returns>
        public static TV GetValue<TK, TV>(this IDictionary<TK, TV> dictionary, TK keyName, TV defaultValue = default(TV))
        {
            return dictionary.ContainsKey(keyName)
                ? dictionary[keyName]
                : defaultValue;
        }

        /// <summary>
        /// Renames the key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        public static void RenameKey<T>(this IDictionary<string, T> dictionary, string from, string to)
        {
            if (dictionary == null || !dictionary.ContainsKey(from) || dictionary.ContainsKey(to))
            {
                return;
            }

            var old = dictionary[from];
            dictionary.Remove(from);
            dictionary[to] = old;
        }
    }
}
