using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DNX.Helpers.Validation;

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
            Guard.IsNotNull(() => type);

            var attributes = type.GetCustomAttributes(typeof(T), inherit);

            return attributes
                .Cast<T>()
                .ToList();
        }

        /// <summary>
        /// Gets the custom attributes for the type from an instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance">The object.</param>
        /// <param name="inherit">if set to <c>true</c> [inherit].</param>
        /// <returns>IList&lt;T&gt;.</returns>
        public static IList<T> GetTypeAttributesFromInstance<T>(this object instance, bool inherit)
        {
            Guard.IsNotNull(() => instance);

            var attributes = instance.GetType()
                .GetTypeAttributes<T>(inherit);

            return attributes;
        }

        /// <summary>
        /// Gets the custom attributes from a member (property / field)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="memberInfo">The member information.</param>
        /// <param name="inherit">The inherit.</param>
        /// <returns>System.Collections.Generic.IList&lt;T&gt;.</returns>
        public static IList<T> GetMemberAttributes<T>(this MemberInfo memberInfo, bool inherit)
        {
            Guard.IsNotNull(() => memberInfo);

            var attributes = memberInfo.GetCustomAttributes(typeof(T), inherit);

            return attributes
                .Cast<T>()
                .ToList();
        }

        /// <summary>
        /// Does the instance object have type attributes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type">The type.</param>
        /// <param name="inherit">if set to <c>true</c> [inherit].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool HasTypeAttributes<T>(this Type type, bool inherit)
        {
            var attributes = type.GetTypeAttributes<T>(inherit);

            return attributes.Any();
        }

        /// <summary>
        /// Does the instance object have type attributes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object.</param>
        /// <param name="inherit">if set to <c>true</c> [inherit].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool InstanceHasTypeAttributes<T>(this object obj, bool inherit)
        {
            var attributes = obj.GetTypeAttributesFromInstance<T>(inherit);

            return attributes.Any();
        }
    }
}
