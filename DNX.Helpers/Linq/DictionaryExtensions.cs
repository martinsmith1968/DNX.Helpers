using System;
using System.Collections.Generic;
using System.Linq;

namespace DNX.Helpers.Linq
{
    /// <summary>
    /// MergeTechnique
    /// </summary>
    /// <remarks>The technique to use when merging dictionaries</remarks>
    public enum MergeTechnique
    {
        /// <summary>
        /// All keys must be unique
        /// </summary>
        Unique = 1,

        /// <summary>
        /// When keys clash, take the first found key value
        /// </summary>
        TakeFirst = 2,

        /// <summary>
        /// When keys clash, take the last found key value
        /// </summary>
        TakeLast = 3
    }

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
        /// <exception cref="System.ArgumentNullException">dictionary or keyName</exception>
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
        /// <exception cref="System.ArgumentNullException">dictionary or keyName</exception>
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
        /// <exception cref="System.ArgumentNullException">fromKeyName or toKeyName</exception>
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

        /// <summary>
        /// Merges the with.
        /// </summary>
        /// <typeparam name="TK">The type of the tk.</typeparam>
        /// <typeparam name="TV">The type of the tv.</typeparam>
        /// <param name="dict">The dictionary.</param>
        /// <param name="other">The other.</param>
        /// <param name="mergeTechnique">The merge technique.</param>
        /// <returns>Dictionary&lt;TK, TV&gt;.</returns>
        /// <remarks>Source and target dictionaries are left untouched</remarks>
        public static IDictionary<TK, TV> MergeWith<TK, TV>(this IDictionary<TK, TV> dict, IDictionary<TK, TV> other, MergeTechnique mergeTechnique = MergeTechnique.Unique)
        {
            var result = Merge(mergeTechnique, dict, other);

            return result;
        }

        /// <summary>
        /// Merges dictionaries
        /// </summary>
        /// <typeparam name="TK">The type of the tk.</typeparam>
        /// <typeparam name="TV">The type of the tv.</typeparam>
        /// <param name="mergeTechnique">The merge technique.</param>
        /// <param name="dictionaries">The dictionaries.</param>
        /// <returns>Dictionary&lt;TK, TV&gt;.</returns>
        /// <exception cref="System.ArgumentException">Invalid or unsupported Merge Technique - mergeTechnique</exception>
        public static IDictionary<TK, TV> Merge<TK, TV>(MergeTechnique mergeTechnique, params IDictionary<TK, TV>[] dictionaries)
        {
            switch (mergeTechnique)
            {
                case MergeTechnique.Unique:
                    return MergeUnique(dictionaries);

                case MergeTechnique.TakeFirst:
                    return MergeFirst(dictionaries);

                case MergeTechnique.TakeLast:
                    return MergeLast(dictionaries);

                default:
                    throw new ArgumentException("Invalid or unsupported Merge Technique", "mergeTechnique");
            }
        }

        /// <summary>
        /// Merges dictionaries assuming all keys are unique
        /// </summary>
        /// <typeparam name="TK">The type of the tk.</typeparam>
        /// <typeparam name="TV">The type of the tv.</typeparam>
        /// <param name="dictionaries">The dictionaries.</param>
        /// <returns>Dictionary&lt;TK, TV&gt;.</returns>
        public static IDictionary<TK, TV> MergeUnique<TK, TV>(params IDictionary<TK, TV>[] dictionaries)
        {
            var dict = dictionaries.SelectMany(d => d)
                .ToDictionary(pair => pair.Key, pair => pair.Value);

            return dict;
        }

        /// <summary>
        /// Merges dictionaries using the first found key value
        /// </summary>
        /// <typeparam name="TK">The type of the tk.</typeparam>
        /// <typeparam name="TV">The type of the tv.</typeparam>
        /// <param name="dictionaries">The dictionaries.</param>
        /// <returns>Dictionary&lt;TK, TV&gt;.</returns>
        public static IDictionary<TK, TV> MergeFirst<TK, TV>(params IDictionary<TK, TV>[] dictionaries)
        {
            var result = dictionaries.SelectMany(dict => dict)
                .ToLookup(pair => pair.Key, pair => pair.Value)
                .ToDictionary(group => group.Key, group => group.First());

            return result;
        }

        /// <summary>
        /// Merges dictionaries using the last found key value
        /// </summary>
        /// <typeparam name="TK">The type of the tk.</typeparam>
        /// <typeparam name="TV">The type of the tv.</typeparam>
        /// <param name="dictionaries">The dictionaries.</param>
        /// <returns>Dictionary&lt;TK, TV&gt;.</returns>
        public static IDictionary<TK, TV> MergeLast<TK, TV>(params IDictionary<TK, TV>[] dictionaries)
        {
            var result = dictionaries.SelectMany(dict => dict)
                .ToLookup(pair => pair.Key, pair => pair.Value)
                .ToDictionary(group => group.Key, group => group.Last());

            return result;
        }
    }
}
