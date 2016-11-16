using System;
using System.Collections.Generic;
using System.Linq;

namespace DNX.Helpers.Linq
{
    /// <summary>
    /// Linq Extensions.
    /// </summary>
    public static class LinqExtensions
    {
        /// <summary>
        /// Get an element from a list at the specified index, or return default
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <param name="index">The index.</param>
        /// <returns>T. Or default(T)</returns>
        /// <remarks>Also available as an extension method</remarks>
        public static T GetAt<T>(this IList<T> enumerable , int index)
        {
            if (enumerable != null)
            {
                if (index < 0)
                {
                    index = enumerable.Count - Math.Abs(index % enumerable.Count);
                }

                if (index < enumerable.Count)
                {
                    return enumerable[index];
                }
            }

            return default(T);
        }

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
    }
}
