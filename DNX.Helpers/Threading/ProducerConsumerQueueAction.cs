using System;
using System.Collections.Generic;

namespace DNX.Helpers.Threading
{
    /// <summary>
    /// Class ProducerConsumerQueueAction.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="DNX.Helpers.Threading.ProducerConsumerQueue{T}" />
    public class ProducerConsumerQueueAction<T> : ProducerConsumerQueue<T> where T : class
    {
        /// <summary>
        /// The action
        /// </summary>
        private readonly Action<T> _action;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProducerConsumerQueueAction{T}" /> class.
        /// </summary>
        /// <param name="action">The action.</param>
        public ProducerConsumerQueueAction(Action<T> action)
            :base()
        {
            _action = action;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProducerConsumerQueueAction{T}" /> class.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="autoCleanUp">if set to <c>true</c> [automatic clean up].</param>
        public ProducerConsumerQueueAction(Action<T> action, bool autoCleanUp)
            : base(autoCleanUp)
        {
            _action = action;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProducerConsumerQueueAction{T}" /> class.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="autoCleanUp">if set to <c>true</c> [automatic clean up].</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="comparer">The comparer.</param>
        public ProducerConsumerQueueAction(Action<T> action, bool autoCleanUp, TimeSpan timeout, IComparer<T> comparer)
            : base(autoCleanUp, timeout, comparer)
        {
            _action = action;
        }

        /// <summary>
        /// Method for processing a queued item after being picked up by the Queue handler
        /// </summary>
        /// <param name="item">The item to be processed</param>
        protected override void ProcessItem(T item)
        {
            _action(item);
        }
    }
}
