using System;
using System.Collections.Generic;

namespace DNX.Helpers.Exceptions
{
    /// <summary>
    /// Class ReadOnlyListException.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.Exception" />
    public class ReadOnlyListException<T> : Exception
    {
        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <value>The list.</value>
        public IList<T> List { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadOnlyListException{T}"/> class.
        /// </summary>
        /// <param name="list">The list.</param>
        public ReadOnlyListException(IList<T> list)
        {
            List = list;
        }
    }
}
