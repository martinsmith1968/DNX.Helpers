using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DNX.Helpers.Reflection
{
    /// <summary>
    /// Attribute Extensions.
    /// </summary>
    public static class AttributeExtensions
    {
        /// <summary>
        /// Gets the custom attributes for the Type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type">The type.</param>
        /// <param name="inherit">if set to <c>true</c> [inherit].</param>
        /// <returns>IList&lt;T&gt;.</returns>
        public static IList<T> GetTypeAttributes<T>(this Type type, bool inherit)
        {
            var attributes = type.GetCustomAttributes(typeof(T), inherit);

            return attributes
                .Cast<T>()
                .ToList();
        }

        /// <summary>
        /// Gets the custom attributes.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object.</param>
        /// <param name="inherit">if set to <c>true</c> [inherit].</param>
        /// <returns>IList&lt;T&gt;.</returns>
        public static IList<T> GetInstanceAttributes<T>(this object obj, bool inherit)
        {
            var attributes = obj.GetType()
                .GetTypeAttributes<T>(inherit);

            return attributes;
        }

        /// <summary>
        /// Gets the property attributes.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyInfo">The property information.</param>
        /// <param name="inherit">The inherit.</param>
        /// <returns>System.Collections.Generic.IList&lt;T&gt;.</returns>
        public static IList<T> GetPropertyAttributes<T>(this PropertyInfo propertyInfo, bool inherit)
        {
            var attributes = propertyInfo.GetCustomAttributes(typeof(T), inherit);

            return attributes
                .Cast<T>()
                .ToList();
        }

        /// <summary>
        /// Types the has attributes.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object.</param>
        /// <param name="inherit">if set to <c>true</c> [inherit].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool InstanceHasAttributes<T>(this object obj, bool inherit)
        {
            var attributes = obj.GetInstanceAttributes<T>(inherit);

            return attributes.Any();
        }
    }
}
