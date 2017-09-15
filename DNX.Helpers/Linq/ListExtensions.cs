using System;
using System.Collections.Generic;
using DNX.Helpers.Exceptions;

namespace DNX.Helpers.Linq
{
    /// <summary>
    /// List Extensions.
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Determines whether the index is valid for the list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <param name="index">The index.</param>
        /// <returns><c>true</c> if [is index valid] [the specified index]; otherwise, <c>false</c>.</returns>
        public static bool IsIndexValid<T>(this IList<T> list, int index)
        {
            return list.HasAny() && index >= 0 && index < list.Count;
        }

        /// <summary>
        /// Gets the absolute index value for the list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <param name="index">The index.</param>
        /// <returns>System.Int32.</returns>
        public static int GetAbsoluteIndex<T>(this IList<T> list, int index)
        {
            if (list.HasAny())
            {
                while (index < 0)
                {
                    index = (list.Count + index) % list.Count;
                }
            }

            return index;
        }

        /// <summary>
        /// Gets at.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="index">The index.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>T.</returns>
        public static T GetAt<T>(this IList<T> list, int index, T defaultValue = default(T))
        {
            index = list.GetAbsoluteIndex(index);

            if (!list.IsIndexValid(index))
            {
                return defaultValue;
            }

            return list[index];
        }

        /// <summary>
        /// Moves an item to the new specified index
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <param name="oldIndex">The old index.</param>
        /// <param name="newIndex">The new index.</param>
        public static void Move<T>(this IList<T> list, int oldIndex, int newIndex)
        {
            oldIndex = list.GetAbsoluteIndex(oldIndex);
            newIndex = list.GetAbsoluteIndex(newIndex);

            if (!list.IsIndexValid(oldIndex))
            {
                throw new ArgumentOutOfRangeException("oldIndex");
            }

            if (!list.IsIndexValid(newIndex))
            {
                throw new ArgumentOutOfRangeException("newIndex");
            }

            if (list.IsReadOnly)
            {
                throw new ReadOnlyListException<T>(list);
            }

            var item = list[oldIndex];
            list.RemoveAt(oldIndex);
            list.Insert(newIndex, item);
        }

        /// <summary>
        /// Swaps the items at the 2 specified indexes
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <param name="oldIndex">The old index.</param>
        /// <param name="newIndex">The new index.</param>
        public static void Swap<T>(this IList<T> list, int oldIndex, int newIndex)
        {
            oldIndex = list.GetAbsoluteIndex(oldIndex);
            newIndex = list.GetAbsoluteIndex(newIndex);

            if (!list.IsIndexValid(oldIndex))
            {
                throw new ArgumentOutOfRangeException("oldIndex");
            }

            if (!list.IsIndexValid(newIndex))
            {
                throw new ArgumentOutOfRangeException("newIndex");
            }

            if (list.IsReadOnly)
            {
                throw new ReadOnlyListException<T>(list);
            }

            var item = list[newIndex];
            list[newIndex] = list[oldIndex];
            list[oldIndex] = item;
        }
    }
}
