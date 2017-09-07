using System;

namespace DNX.Helpers.Validation
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
            if (type == null)
            {
                return false;
            }

            if (!type.IsValueType)
            {
                return true;
            }

            return Nullable.GetUnderlyingType(type) != null;
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
