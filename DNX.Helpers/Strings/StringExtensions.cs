

using System.Collections.Generic;
using System.Text;
using DNX.Helpers.Linq;

namespace DNX.Helpers.Strings
{
    public static class StringExtensions
    {
        public static string EnsureStartsWith(this string text, string prefix)
        {
            if (!string.IsNullOrEmpty(prefix))
            {
                if (string.IsNullOrEmpty(text) || !text.StartsWith(prefix))
                {
                    text = string.Concat(prefix, text);
                }
            }

            return text;
        }

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

        public static string EnsureStartsAndEndsWith(this string text, string prefixsuffix)
        {
            return text.EnsureStartsWith(prefixsuffix)
                .EnsureEndsWith(prefixsuffix);
        }

        public static string EnsureStartsAndEndsWith(this string text, string prefix, string suffix)
        {
            return text.EnsureStartsWith(prefix)
                .EnsureEndsWith(suffix);
        }

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

        public static string RemoveStartsAndEndsWith(this string text, string prefixsuffix)
        {
            return text.RemoveEndsWith(prefixsuffix)
                .RemoveStartsWith(prefixsuffix);
        }

        public static string RemoveStartsAndEndsWith(this string text, string prefix, string suffix)
        {
            return text.RemoveStartsWith(prefix)
                .RemoveEndsWith(suffix);
        }

        public static string RemoveAny(this string text, string charsToRemove)
        {
            return RemoveAny(text, charsToRemove.ToCharArray());
        }

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

        public static string RemoveAnyExcept(this string text, string charsToKeep)
        {
            return RemoveAnyExcept(text, (charsToKeep ?? string.Empty).ToCharArray());
        }

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
