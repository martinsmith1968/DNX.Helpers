using System;
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
        /// <exception cref="System.ArgumentNullException"> dictionary or keyName </exception>
        public static void SetValue<TK, TV>(this IDictionary<TK, TV> dictionary, TK keyName, TV value)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException("dictionary");
            }

            if (keyName == null)
            {
                throw new ArgumentNullException("keyName");
            }

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
        /// <exception cref="System.ArgumentNullException"> dictionary or keyName </exception>
        public static TV GetValue<TK, TV>(this IDictionary<TK, TV> dictionary, TK keyName, TV defaultValue = default(TV))
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException("dictionary");
            }

            if (keyName == null)
            {
                throw new ArgumentNullException("keyName");
            }

            return dictionary.ContainsKey(keyName)
                ? dictionary[keyName]
                : defaultValue;
        }

        /// <summary>
        /// Renames the key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="fromKeyName">Name of from key.</param>
        /// <param name="toKeyName">Name of to key.</param>
        /// <exception cref="System.ArgumentNullException"> fromKeyName or toKeyName </exception>
        public static void RenameKey<T>(this IDictionary<string, T> dictionary, string fromKeyName, string toKeyName)
        {
            if (fromKeyName == null)
            {
                throw new ArgumentNullException("fromKeyName");
            }
            if (toKeyName == null)
            {
                throw new ArgumentNullException("toKeyName");
            }

            if (dictionary == null || !dictionary.ContainsKey(fromKeyName) || dictionary.ContainsKey(toKeyName))
            {
                return;
            }

            var old = dictionary[fromKeyName];
            dictionary.Remove(fromKeyName);
            dictionary.SetValue(toKeyName, old);
        }
    }
}
