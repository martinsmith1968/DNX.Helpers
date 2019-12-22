using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using DNX.Helpers.Linq;
using DNX.Helpers.Reflection;

namespace DNX.Helpers.Strings.Interpolation
{
    /// <summary>
    /// StringInterpolator to simulate and extend named string interpolation available in C# 6.0
    /// </summary>
    public static class StringInterpolator
    {
        /// <summary>
        /// Interpolates the text with the optionally named instance
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="instance">The instance.</param>
        /// <param name="namePrefix">The name prefix.</param>
        /// <param name="ignoreErrors">if set to <c>true</c> [ignore errors].</param>
        /// <returns>System.String.</returns>
        public static string InterpolateWith(this string text, object instance, string namePrefix = null, bool ignoreErrors = false)
        {
            var namedInstance = new NamedInstance(instance, namePrefix);

            return InterpolateWith(text, namedInstance, ignoreErrors);
        }

        /// <summary>
        /// Interpolates the text with the named instance
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="namedInstance">The named instance.</param>
        /// <param name="ignoreErrors">if set to <c>true</c> [ignore errors].</param>
        /// <returns>System.String.</returns>
        public static string InterpolateWith(this string text, NamedInstance namedInstance, bool ignoreErrors = false)
        {
            var namedInstances = new List<NamedInstance>()
            {
                namedInstance
            };

            return InterpolateWithAll(text, namedInstances, ignoreErrors);
        }

        /// <summary>
        /// Interpolates text with properties from a list of object instances
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="namedInstances">The named instances.</param>
        /// <param name="ignoreErrors">if set to <c>true</c> [ignore errors].</param>
        /// <returns>System.String.</returns>
        public static string InterpolateWithAll(this string text, IList<NamedInstance> namedInstances, bool ignoreErrors = false)
        {
            var dictionaries = namedInstances
                .Select(d => d.ToDictionary())
                .ToArray();

            var paramValues = DictionaryExtensions.MergeFirst(dictionaries);

            FilterParameterValues(paramValues, text);

            var result = text.InterpolateWithAll(paramValues, ignoreErrors);

            return result;
        }

        /// <summary>
        /// Interpolates text with properties from a Dictionary of parameter names and values
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="paramValues">The parameter values.</param>
        /// <param name="ignoreErrors">if set to <c>true</c> [ignore errors].</param>
        /// <returns>System.String.</returns>
        public static string InterpolateWithAll<T>(this string text, IDictionary<string, T> paramValues, bool ignoreErrors = false)
        {
            if (!paramValues.HasAny())
            {
                return text;
            }

            var format = text ?? string.Empty;

            var index = 0;
            foreach (var keyValuePair in paramValues)
            {
                var identifier = "{" + keyValuePair.Key;

                format = format
                    .Replace(identifier + "}", "{" + index + "}")
                    .Replace(identifier + ":", "{" + index + ":")
                    ;

                ++index;
            }

            try
            {
                var values = paramValues
                    .Select(x => (object)x.Value);

                var formattedText = string.Format(format, values.ToArray());

                return formattedText;
            }
            catch
            {
                if (ignoreErrors)
                {
                    return text;
                }

                throw;
            }
        }

        /// <summary>
        /// Builds the parameter values for named instance.
        /// </summary>
        /// <param name="parameterValues">The parameter values.</param>
        /// <param name="format">The format.</param>
        /// <returns>System.String.</returns>
        internal static void FilterParameterValues(IDictionary<string, object> parameterValues, string format)
        {
            if (parameterValues == null || string.IsNullOrEmpty(format))
                return;

            var unwantedKeys = parameterValues
                .Where(pv => !format.Contains("{" + pv.Key))
                .ToArray();

            foreach (var unwantedKey in unwantedKeys)
            {
                parameterValues.Remove(unwantedKey);
            }
        }
    }
}
