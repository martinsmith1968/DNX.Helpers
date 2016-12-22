using System.Collections.Generic;

namespace DNX.Helpers.Threading
{
    /// <summary>
    /// Interface IProducerConsumerQueue
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IProducerConsumerQueue<in T> where T : class
    {
        /// <summary>
        /// A Comparer to use if the Queue is to be ordered
        /// </summary>
        /// <value>The comparer.</value>
        IComparer<T> Comparer { get; }

        /// <summary>
        /// Clear the Queue of all items
        /// </summary>
        void Clear();

        /// <summary>
        /// Add an item to the Queue to be processed
        /// </summary>
        /// <param name="item">The item to be queued.</param>
        void AddItem(T item);

        /// <summary>
        /// Adds a batch of items to the Queue to be processed
        /// </summary>
        /// <param name="items">The items to be queued.</param>
        void AddItems(T[] items);
    }
}
