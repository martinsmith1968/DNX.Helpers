using System.Collections.Generic;
using System.Text;
using DNX.Helpers.Linq;

namespace DNX.Helpers.Strings
{
    /// <summary>
    /// String Extensions
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Ensure a string starts with a prefix string
        /// </summary>
        /// <param name="text"></param>
        /// <param name="prefix"></param>
        /// <returns>System.String.</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static string EnsureStartsWith(this string text, string prefix)
        {
            // ReSharper disable once InvertIf
            if (!string.IsNullOrEmpty(prefix))
            {
                if (string.IsNullOrEmpty(text) || !text.StartsWith(prefix))
                {
                    text = string.Concat(prefix, text);
                }
            }

            return text;
        }

        /// <summary>
        /// Ensures a string ends with a suffix string.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="suffix">The suffix.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static string EnsureEndsWith(this string text, string suffix)
        {
            if (!string.IsNullOrEmpty(suffix))
            {
                if (string.IsNullOrEmpty(text) || !text.EndsWith(suffix))
                {
                    text = string.Concat(text, suffix);
                }
            }

            return text;
        }

        /// <summary>
        /// Ensures a string starts and ends with a prefix / suffix string.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="prefixsuffix">The prefix / suffix.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static string EnsureStartsAndEndsWith(this string text, string prefixsuffix)
        {
            return text.EnsureStartsWith(prefixsuffix)
                .EnsureEndsWith(prefixsuffix);
        }

        /// <summary>
        /// Ensures a string starts a prefix string and ends with a suffix string.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="prefix">The prefix.</param>
        /// <param name="suffix">The suffix.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static string EnsureStartsAndEndsWith(this string text, string prefix, string suffix)
        {
            return text.EnsureStartsWith(prefix)
                .EnsureEndsWith(suffix);
        }

        /// <summary>
        /// Ensures a string does not start with a prefix string
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="prefix">The prefix.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static string RemoveStartsWith(this string text, string prefix)
        {
            if (!string.IsNullOrEmpty(prefix) && !string.IsNullOrEmpty(text))
            {
                while (text.StartsWith(prefix))
                {
                    text = text.Substring(prefix.Length);
                }
            }

            return text;
        }

        /// <summary>
        /// Ensures a string does not end with a suffix string
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="suffix">The suffix.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static string RemoveEndsWith(this string text, string suffix)
        {
            if (!string.IsNullOrEmpty(suffix) && !string.IsNullOrEmpty(text))
            {
                while (text.EndsWith(suffix))
                {
                    text = text.Substring(0, text.Length - suffix.Length);
                }
            }

            return text;
        }

        /// <summary>
        /// Ensures a string does not start or end with a prefix / suffix string
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="prefixsuffix">The prefixsuffix.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static string RemoveStartsAndEndsWith(this string text, string prefixsuffix)
        {
            return text.RemoveEndsWith(prefixsuffix)
                .RemoveStartsWith(prefixsuffix);
        }

        /// <summary>
        /// Ensures a string does not start with a prefix string or end with a suffix string
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="prefix">The prefix.</param>
        /// <param name="suffix">The suffix.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static string RemoveStartsAndEndsWith(this string text, string prefix, string suffix)
        {
            return text.RemoveStartsWith(prefix)
                .RemoveEndsWith(suffix);
        }

        /// <summary>
        /// Removes any of the specified characters from a string
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="charsToRemove">The chars to remove.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static string RemoveAny(this string text, string charsToRemove)
        {
            return RemoveAny(text, charsToRemove.ToCharArray());
        }

        /// <summary>
        /// Removes any of the specified characters from a string
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="charsToRemove">The chars to remove.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static string RemoveAny(this string text, char[] charsToRemove)
        {
            if (charsToRemove.HasAny() && !string.IsNullOrEmpty(text))
            {
                foreach (var c in charsToRemove)
                {
                    text = text.Replace(c.ToString(), string.Empty);
                }
            }

            return text;
        }

        /// <summary>
        /// Removes any characters from a string so that only instances of the specified characters remain
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="charsToKeep">The chars to keep.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static string RemoveAnyExcept(this string text, string charsToKeep)
        {
            return RemoveAnyExcept(text, (charsToKeep ?? string.Empty).ToCharArray());
        }

        /// <summary>
        /// Removes any characters from a string so that only instances of the specified characters remain
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="charsToKeep">The chars to keep.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static string RemoveAnyExcept(this string text, IList<char> charsToKeep)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            var sb = new StringBuilder(text.Length);

            if (charsToKeep.HasAny())
            {
                foreach (var c in text.ToCharArray())
                {
                    if (charsToKeep.Contains(c))
                    {
                        sb.Append(c);
                    }
                }
            }

            return sb.ToString();
        }
    }
}
