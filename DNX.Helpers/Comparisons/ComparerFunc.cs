using System;
using System.Collections.Generic;

namespace DNX.Helpers.Comparisons
{
    /// <summary>
    /// Class ComparerFunc.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.Collections.Generic.IComparer{T}" />
    public class ComparerFunc<T> : IComparer<T>
    {
        private readonly Func<T, T, int> _func;

        private ComparerFunc(Func<T, T, int> func)
        {
            _func = func;
        }

        /// <summary>
        /// Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>A signed integer that indicates the relative values of <paramref name="x" /> and <paramref name="y" />, as shown in the following table.Value Meaning Less than zero<paramref name="x" /> is less than <paramref name="y" />.Zero<paramref name="x" /> equals <paramref name="y" />.Greater than zero<paramref name="x" /> is greater than <paramref name="y" />.</returns>
        public int Compare(T x, T y)
        {
            return _func(x, y);
        }

        /// <summary>
        /// Creates a comparer for the specified type
        /// </summary>
        /// <param name="func">The function.</param>
        /// <returns>ActionComparer&lt;T&gt;.</returns>
        public static ComparerFunc<T> Create(Func<T, T, int> func)
        {
            return new ComparerFunc<T>(func);
        }
    }
}
