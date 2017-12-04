using System;
using System.Collections.Generic;

namespace DNX.Helpers.Linq
{
    /// <summary>
    /// Class TupleListExtensions.
    /// </summary>
    public static class TupleExtensions
    {
        /// <summary>
        /// Adds the specified item1.
        /// </summary>
        /// <typeparam name="T1">The type of the t1.</typeparam>
        /// <typeparam name="T2">The type of the t2.</typeparam>
        /// <param name="list">The list.</param>
        /// <param name="item1">The item1.</param>
        /// <param name="item2">The item2.</param>
        public static void Add<T1, T2>(this IList<Tuple<T1, T2>> list, T1 item1, T2 item2)
        {
            list.Add(Tuple.Create(item1, item2));
        }

        /// <summary>
        /// Adds the specified item1.
        /// </summary>
        /// <typeparam name="T1">The type of the t1.</typeparam>
        /// <typeparam name="T2">The type of the t2.</typeparam>
        /// <typeparam name="T3">The type of the t3.</typeparam>
        /// <param name="list">The list.</param>
        /// <param name="item1">The item1.</param>
        /// <param name="item2">The item2.</param>
        /// <param name="item3">The item3.</param>
        public static void Add<T1, T2, T3>(this IList<Tuple<T1, T2, T3>> list, T1 item1, T2 item2, T3 item3)
        {
            list.Add(Tuple.Create(item1, item2, item3));
        }

        /// <summary>
        /// Adds the specified item1.
        /// </summary>
        /// <typeparam name="T1">The type of the t1.</typeparam>
        /// <typeparam name="T2">The type of the t2.</typeparam>
        /// <typeparam name="T3">The type of the t3.</typeparam>
        /// <typeparam name="T4">The type of the t4.</typeparam>
        /// <param name="list">The list.</param>
        /// <param name="item1">The item1.</param>
        /// <param name="item2">The item2.</param>
        /// <param name="item3">The item3.</param>
        /// <param name="item4">The item4.</param>
        public static void Add<T1, T2, T3, T4>(this IList<Tuple<T1, T2, T3, T4>> list, T1 item1, T2 item2, T3 item3, T4 item4)
        {
            list.Add(Tuple.Create(item1, item2, item3, item4));
        }

        /// <summary>
        /// Adds the specified item1.
        /// </summary>
        /// <typeparam name="T1">The type of the t1.</typeparam>
        /// <typeparam name="T2">The type of the t2.</typeparam>
        /// <typeparam name="T3">The type of the t3.</typeparam>
        /// <typeparam name="T4">The type of the t4.</typeparam>
        /// <typeparam name="T5">The type of the t5.</typeparam>
        /// <param name="list">The list.</param>
        /// <param name="item1">The item1.</param>
        /// <param name="item2">The item2.</param>
        /// <param name="item3">The item3.</param>
        /// <param name="item4">The item4.</param>
        /// <param name="item5">The item5.</param>
        public static void Add<T1, T2, T3, T4, T5>(this IList<Tuple<T1, T2, T3, T4, T5>> list, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5)
        {
            list.Add(Tuple.Create(item1, item2, item3, item4, item5));
        }

        /// <summary>
        /// Adds the specified item1.
        /// </summary>
        /// <typeparam name="T1">The type of the t1.</typeparam>
        /// <typeparam name="T2">The type of the t2.</typeparam>
        /// <typeparam name="T3">The type of the t3.</typeparam>
        /// <typeparam name="T4">The type of the t4.</typeparam>
        /// <typeparam name="T5">The type of the t5.</typeparam>
        /// <typeparam name="T6">The type of the t6.</typeparam>
        /// <param name="list">The list.</param>
        /// <param name="item1">The item1.</param>
        /// <param name="item2">The item2.</param>
        /// <param name="item3">The item3.</param>
        /// <param name="item4">The item4.</param>
        /// <param name="item5">The item5.</param>
        /// <param name="item6">The item6.</param>
        public static void Add<T1, T2, T3, T4, T5, T6>(this IList<Tuple<T1, T2, T3, T4, T5, T6>> list, T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6)
        {
            list.Add(Tuple.Create(item1, item2, item3, item4, item5, item6));
        }
    }
}
