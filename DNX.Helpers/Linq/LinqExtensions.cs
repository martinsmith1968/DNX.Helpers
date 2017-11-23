using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable InvertIf
namespace DNX.Helpers.Linq
{
    /// <summary>
    /// Linq Extensions.
    /// </summary>
    public static class LinqExtensions
    {
        /// <summary>
        /// Determines whether the specified enumerable has any elements and is not null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <returns><c>true</c> if the specified enumerable has any elements; otherwise, <c>false</c>.</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static bool HasAny<T>(this IEnumerable<T> enumerable)
        {
            return enumerable != null && enumerable.Any();
        }

        /// <summary>
        /// Determines whether the specified enumerable has any elements that match the predicate and is not null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns><c>true</c> if the specified predicate has any elements that match the predicate; otherwise, <c>false</c>.</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static bool HasAny<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
        {
            return enumerable != null && enumerable.Any(predicate);
        }

        /// <summary>
        /// Determines whether the specified value is in the list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="list">The list.</param>
        /// <returns><c>true</c> if the list is not null and value is in the list; otherwise, <c>false</c>.</returns>
        public static bool IsIn<T>(this T value, params T[] list)
        {
            return value.IsIn(list.ToListOrNull());
        }

        /// <summary>
        /// Determines whether the specified value is in the list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="list">The list.</param>
        /// <param name="comparer">The comparer.</param>
        /// <param name="treatNullListAs">The value to return if the list is null</param>
        /// <returns><c>true</c> if the value is in the list; otherwise, <c>false</c>.</returns>
        public static bool IsIn<T>(this T value, IList<T> list, IEqualityComparer<T> comparer = null, bool treatNullListAs = false)
        {
            if (list == null)
            {
                return treatNullListAs;
            }

            return comparer == null
                ? list.Contains(value)
                : list.Contains(value, comparer);
        }

        /// <summary>
        /// Determines whether the specified value is not in the list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="list">The list.</param>
        /// <returns><c>true</c> if the list is not null and value is not in the list; otherwise, <c>false</c>.</returns>
        public static bool IsNotIn<T>(this T value, params T[] list)
        {
            return value.IsNotIn(list.ToListOrNull());
        }

        /// <summary>
        /// Determines whether the specified value is not in the list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="list">The list.</param>
        /// <param name="comparer">The comparer.</param>
        /// <param name="treatNullListAs">The value to return if the list is null</param>
        /// <returns><c>true</c> if the value is not in the list; otherwise, <c>false</c>.</returns>
        public static bool IsNotIn<T>(this T value, IList<T> list, IEqualityComparer<T> comparer = null, bool treatNullListAs = false)
        {
            if (list == null)
            {
                return treatNullListAs;
            }

            return comparer == null
                ? !list.Contains(value)
                : !list.Contains(value, comparer);
        }
    }
}
