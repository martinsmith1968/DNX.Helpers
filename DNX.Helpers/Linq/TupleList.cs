using System;
using System.Collections.Generic;

// <summary>
// Class TupleExtensions.
// </summary>
// <remarks>To allow Tuple initializers
// See: https://stackoverflow.com/questions/8002455/how-to-easily-initialize-a-list-of-tuples</remarks>
namespace DNX.Helpers.Linq
{
    /// <inheritdoc />
    /// <summary>
    /// Class TupleList to allow Tuple initializers
    /// </summary>
    /// <typeparam name="T1">The type of the t1.</typeparam>
    /// <typeparam name="T2">The type of the t2.</typeparam>
    /// <seealso cref="T:System.Tuple`2" />
    public class TupleList<T1, T2> : List<Tuple<T1, T2>>
    {
        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="item2">The item2.</param>
        public void Add(T1 item, T2 item2)
        {
            Add(new Tuple<T1, T2>(item, item2));
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// Class TupleList to allow Tuple initializers
    /// </summary>
    /// <typeparam name="T1">The type of the t1.</typeparam>
    /// <typeparam name="T2">The type of the t2.</typeparam>
    /// <typeparam name="T3">The type of the t3.</typeparam>
    /// <seealso cref="T:System.Tuple`3" />
    public class TupleList<T1, T2, T3> : List<Tuple<T1, T2, T3>>
    {
        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="item2">The item2.</param>
        /// <param name="item3">The item3.</param>
        public void Add(T1 item, T2 item2, T3 item3)
        {
            Add(new Tuple<T1, T2, T3>(item, item2, item3));
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// Class TupleList to allow Tuple initializers
    /// </summary>
    /// <typeparam name="T1">The type of the t1.</typeparam>
    /// <typeparam name="T2">The type of the t2.</typeparam>
    /// <typeparam name="T3">The type of the t3.</typeparam>
    /// <typeparam name="T4">The type of the t4.</typeparam>
    /// <seealso cref="T:System.Tuple`4" />
    public class TupleList<T1, T2, T3, T4> : List<Tuple<T1, T2, T3, T4>>
    {
        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="item2">The item2.</param>
        /// <param name="item3">The item3.</param>
        /// <param name="item4">The item4.</param>
        public void Add(T1 item, T2 item2, T3 item3, T4 item4)
        {
            Add(new Tuple<T1, T2, T3, T4>(item, item2, item3, item4));
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// Class TupleList to allow Tuple initializers
    /// </summary>
    /// <typeparam name="T1">The type of the t1.</typeparam>
    /// <typeparam name="T2">The type of the t2.</typeparam>
    /// <typeparam name="T3">The type of the t3.</typeparam>
    /// <typeparam name="T4">The type of the t4.</typeparam>
    /// <typeparam name="T5">The type of the t5.</typeparam>
    /// <seealso cref="T:System.Tuple`5" />
    public class TupleList<T1, T2, T3, T4, T5> : List<Tuple<T1, T2, T3, T4, T5>>
    {
        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="item2">The item2.</param>
        /// <param name="item3">The item3.</param>
        /// <param name="item4">The item4.</param>
        /// <param name="item5">The item5.</param>
        public void Add(T1 item, T2 item2, T3 item3, T4 item4, T5 item5)
        {
            Add(new Tuple<T1, T2, T3, T4, T5>(item, item2, item3, item4, item5));
        }
    }

    /// <inheritdoc />
    /// <summary>
    /// Class TupleList to allow Tuple initializers
    /// </summary>
    /// <typeparam name="T1">The type of the t1.</typeparam>
    /// <typeparam name="T2">The type of the t2.</typeparam>
    /// <typeparam name="T3">The type of the t3.</typeparam>
    /// <typeparam name="T4">The type of the t4.</typeparam>
    /// <typeparam name="T5">The type of the t5.</typeparam>
    /// <typeparam name="T6">The type of the t6.</typeparam>
    /// <seealso cref="T:System.Tuple`6" />
    public class TupleList<T1, T2, T3, T4, T5, T6> : List<Tuple<T1, T2, T3, T4, T5, T6>>
    {
        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="item2">The item2.</param>
        /// <param name="item3">The item3.</param>
        /// <param name="item4">The item4.</param>
        /// <param name="item5">The item5.</param>
        /// <param name="item6">The item6.</param>
        public void Add(T1 item, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6)
        {
            Add(new Tuple<T1, T2, T3, T4, T5, T6>(item, item2, item3, item4, item5, item6));
        }
    }
}
