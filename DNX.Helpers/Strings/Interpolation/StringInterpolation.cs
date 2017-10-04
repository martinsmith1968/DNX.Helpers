using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DNX.Helpers.Strings.Interpolation
{
    /// <summary>
    /// StringInterpolator to simulate named string interpolation available in C# 6.0
    /// </summary>
    public static class StringInterpolator
    {
        /// <summary>
        /// Gets the list of interpolatable properties from a type
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>IList&lt;InterpolatableProperty&gt;.</returns>
        public static IList<InterpolatableProperty> GetInterpolatableProperties(Type type)
        {
            if (type == null)
            {
                return null;
            }

            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.GetField)
                .Union(type.GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.GetProperty | BindingFlags.GetField))
                .ToList();

            var propertyList = properties
                .Select(p => new InterpolatableProperty(p))
                .ToList();

            return propertyList;
        }

        /// <summary>
        /// Interpolates text with properties from an object instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="text">The text.</param>
        /// <param name="instance">The instance.</param>
        /// <param name="namePrefix">The name prefix.</param>
        /// <param name="ignoreErrors">if set to <c>true</c> [ignore errors].</param>
        /// <returns>System.String.</returns>
        public static string InterpolateWith<T>(this string text, T instance, string namePrefix, bool ignoreErrors = false)
        {
            var paramValues = new List<object>();

            var properties = GetInterpolatableProperties(typeof(T));

            var format = text;
            foreach (var property in properties)
            {
                var variableName = property.GetVariableName(namePrefix);

                var variableIdent = "{" + variableName;

                if (format.Contains(variableIdent))
                {
                    format = format
                        .Replace(variableIdent + "}", "{" + paramValues.Count + "}")
                        .Replace(variableIdent + ":", "{" + paramValues.Count + ":")
                        ;

                    var value = property.PropertyInfo.GetValue(instance, null);

                    paramValues.Add(value);
                }
            }

            try
            {
                var formattedText = paramValues.Any()
                    ? string.Format(format, paramValues.ToArray())
                    : text;

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
    }
}
