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
        /// Interpolates the with.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="instance">The instance.</param>
        /// <param name="namePrefix">The name prefix.</param>
        /// <param name="ignoreErrors">if set to <c>true</c> [ignore errors].</param>
        /// <returns>System.String.</returns>
        public static string InterpolateWith(this string text, object instance, string namePrefix = null, bool ignoreErrors = false)
        {
            var namedInstances = new List<NamedInstance>()
            {
                new NamedInstance(instance, namePrefix)
            };

            return InterpolateWith(text, namedInstances, ignoreErrors);
        }

        /// <summary>
        /// Interpolates text with properties from an object instance.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="namedInstances">The named instances.</param>
        /// <param name="ignoreErrors">if set to <c>true</c> [ignore errors].</param>
        /// <returns>System.String.</returns>
        public static string InterpolateWith(this string text, IList<NamedInstance> namedInstances, bool ignoreErrors = false)
        {
            var paramValues = new Dictionary<string, object>();

            foreach (var namedInstance in namedInstances)
            {
                BuildParameterValuesForNamedInstance(paramValues, text, namedInstance.Instance, namedInstance.Name);
            }

            if (!paramValues.Any())
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
                var formattedText = string.Format(format, paramValues.Values.ToArray());

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
        /// <param name="instance">The instance.</param>
        /// <param name="namePrefix">The name prefix.</param>
        /// <returns>System.String.</returns>
        public static void BuildParameterValuesForNamedInstance(IDictionary<string, object> parameterValues, string format, object instance, string namePrefix)
        {
            var properties = instance == null
                ? new List<InterpolatableProperty>()
                : GetInterpolatableProperties(instance.GetType());

            foreach (var property in properties)
            {
                var variableName = property.GetVariableName(namePrefix);

                var variableIdentifier = "{" + variableName;

                if (format.Contains(variableIdentifier))
                {
                    var value = property.PropertyInfo.GetValue(instance, null);

                    parameterValues.Add(variableName, value);
                }
            }
        }
    }
}
