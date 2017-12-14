using System;
using System.Collections.Generic;

namespace DNX.Helpers.Comparisons
{
    /// <summary>
    /// Class EqualityComparerFunc.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.Collections.Generic.IEqualityComparer{T}" />
    public class EqualityComparerFunc<T> : IEqualityComparer<T>
    {
        private readonly Func<T, T, bool> _func;

        private EqualityComparerFunc(Func<T, T, bool> func)
        {
            _func = func;
        }

        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>true if the specified objects are equal; otherwise, false.</returns>
        public bool Equals(T x, T y)
        {
            return _func(x, y);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <param name="obj">The <see cref="T:System.Object" /> for which a hash code is to be returned.</param>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public int GetHashCode(T obj)
        {
            return 0;
        }

        /// <summary>
        /// Creates a comparer for the specified type
        /// </summary>
        /// <param name="func">The function.</param>
        /// <returns>ActionEqualityComparer&lt;T&gt;.</returns>
        public static EqualityComparerFunc<T> Create(Func<T, T, bool> func)
        {
            return new EqualityComparerFunc<T>(func);
        }
    }
}
