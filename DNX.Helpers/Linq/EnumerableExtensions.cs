using System.Collections.Generic;
using System.Linq;

// ReSharper disable InconsistentNaming

namespace DNX.Helpers.Linq
{
    /// <summary>
    /// Class EnumerableExtensions.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Converts an Enumerable to a List or to an empty list if null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <returns>IList&lt;T&gt;.</returns>
        public static IList<T> ToConcreteList<T>(this IEnumerable<T> enumerable)
        {
            return enumerable == null
                ? new List<T>()
                : enumerable.ToList();
        }

        /// <summary>
        /// Converts an Enumerable to a List or null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <returns>IList&lt;T&gt;.</returns>
        public static IList<T> ToListOrNull<T>(this IEnumerable<T> enumerable)
        {
            return enumerable?.ToList();
        }
    }
}
