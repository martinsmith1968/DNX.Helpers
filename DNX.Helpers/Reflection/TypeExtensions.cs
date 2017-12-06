using System;
using DNX.Helpers.Validation;

namespace DNX.Helpers.Reflection
{
    /// <summary>
    /// Type Extensions.
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Determines whether the specified type is nullable.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if the specified type is nullable; otherwise, <c>false</c>.</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static bool IsNullable(this Type type)
        {
            Guard.IsNotNull(() => type);

            if (!type.IsValueType)
            {
                return true;
            }

            return Nullable.GetUnderlyingType(type) != null;
        }

        /// <summary>
        /// Determines whether the specified type is a.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type">The type.</param>
        /// <returns><c>true</c> if the specified type is a; otherwise, <c>false</c>.</returns>
        public static bool IsA<T>(this Type type)
        {
            return type.IsA(typeof(T));
        }

        /// <summary>
        /// Determines whether the specified type is a.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="baseClassOrInterface">The base class or interface.</param>
        /// <returns>System.Boolean.</returns>
        public static bool IsA(this Type type, Type baseClassOrInterface)
        {
            return baseClassOrInterface.IsAssignableFrom(type);
        }

        /// <summary>
        /// Gets the default value.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>System.Object.</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static object GetDefaultValue(this Type type)
        {
            return type.IsValueType
                ? Activator.CreateInstance(type)
                : null;
        }

        /// <summary>
        /// Gets a default instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>System.Object.</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static T CreateDefaultInstance<T>()
        {
            return Activator.CreateInstance<T>();
        }

        /// <summary>
        /// Gets a default instance.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>System.Object.</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static object CreateDefaultInstance(this Type type)
        {
            return Activator.CreateInstance(type);
        }
    }
}
