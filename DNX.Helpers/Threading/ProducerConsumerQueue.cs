using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace DNX.Helpers.Threading
{
    /// <summary>
    /// Generic Producer/Consumer Queue object
    /// </summary>
    /// <typeparam name="T">class / interface type of objects to queue</typeparam>
    /// <seealso cref="System.IDisposable" />
    /// <seealso cref="DNX.Helpers.Threading.IProducerConsumerQueue{T}" />
    /// <remarks><para>Provides virtual methods hooks to allow a descendant class to vary the behaviour.</para>
    /// <para>Allows an <see cref="IComparer{T}" /> to process queued items in a defined order.</para>
    /// <para>Abstract to allow implementor to provide ProcessItem method to handle a queued item.</para></remarks>
    // ReSharper disable LoopCanBeConvertedToQuery
    public abstract class ProducerConsumerQueue<T> : IDisposable, IProducerConsumerQueue<T> where T : class
    {
        #region Fields

        /// <summary>
        /// Locking control object to regulate access to the queue objects
        /// </summary>
        private readonly object _lockerQueue = new object();

        /// <summary>
        /// Locking control object to regulate access to the process executing count.
        /// </summary>
        private readonly object _lockerExecuting = new object();

        /// <summary>
        /// WaitHandle for synchronising threads
        /// </summary>
        private readonly EventWaitHandle _waitHandle = new AutoResetEvent(false);

        /// <summary>
        /// Queue processor thread
        /// </summary>
        private readonly Thread _workerThread;

        /// <summary>
        /// The queued items
        /// </summary>
        private List<T> _queuedItems = new List<T>();

        /// <summary>
        /// The currently executing items
        /// </summary>
        private readonly List<T> _executingItems = new List<T>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether items are automatically disposed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if items are to be automatically disposed; otherwise, <c>false</c>.
        /// </value>
        public bool AutoCleanupItems
        {
            get;
            set;
        }

        /// <summary>
        /// Gets a value indicating whether this queue operates on a timeout.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is on a timeout; otherwise, <c>false</c>.
        /// </value>
        public bool IsTimed
        {
            get { return Timeout < TimeSpan.MaxValue; }
        }

        /// <summary>
        /// Gets the timeout.
        /// </summary>
        /// <value>The timeout.</value>
        public TimeSpan Timeout
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the items.
        /// </summary>
        public T[] Items
        {
            get
            {
                T[] items = null;

                lock (_lockerQueue)
                {
                    if (_queuedItems != null)
                    {
                        items = _queuedItems.ToArray();
                    }
                }

                return items;
            }
        }

        /// <summary>
        /// Gets the executing items.
        /// </summary>
        public T[] ExecutingItems
        {
            get
            {
                T[] items;

                lock (_lockerExecuting)
                {
                    items = _executingItems.ToArray();
                }

                return items;
            }
        }

        /// <summary>
        /// Gets the executing count.
        /// </summary>
        public int ExecutingCount
        {
            get
            {
                lock (_lockerExecuting)
                {
                    return _executingItems.Count;
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is executing.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is executing; otherwise, <c>false</c>.
        /// </value>
        public bool IsExecuting
        {
            get { return ExecutingCount > 0; }
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Describes the specified exception.
        /// </summary>
        /// <param name="ex">The exception.</param>
        /// <returns>A text representation of the Exception</returns>
        protected static string Describe(Exception ex)
        {
            var sb = new StringBuilder();

            if (ex != null)
            {
                sb.AppendFormat("Message: {0}\nSource: {1}\nStackTrace: {2}\n",
                    ex.Message,
                    ex.Source,
                    ex.StackTrace
                    );
            }

            return sb.ToString();
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        protected ProducerConsumerQueue()
            : this(true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProducerConsumerQueue&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="autoCleanup">if set to <c>true</c> items will be automatically disposed.</param>
        protected ProducerConsumerQueue(bool autoCleanup)
            : this(autoCleanup, TimeSpan.MaxValue, null)
        {
        }

        /// <summary>
        /// Constructor accepting a Wake timeout and a Comparer (for Ordered Queue)
        /// </summary>
        /// <param name="autoCleanup">if set to <c>true</c> [auto cleanup].</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="comparer">The comparer.</param>
        protected ProducerConsumerQueue(bool autoCleanup, TimeSpan timeout, IComparer<T> comparer)
        {
            AutoCleanupItems = autoCleanup;
            Timeout = timeout;
            Comparer = comparer;

            _workerThread = new Thread(Work);
            _workerThread.Start();
        }

        #endregion

        #region Internal Methods

        /// <summary>
        /// Queue an item to be processed
        /// </summary>
        /// <param name="item">The item to be queued.</param>
        /// <remarks>
        /// Internal use only.
        /// </remarks>
        private void EnqueueItem(T item)
        {
            EnqueueItems(
                item == null
                    ? null
                    : new [] { item }
                );
        }

        /// <summary>
        /// Queue a batch of items to be processed
        /// </summary>
        /// <param name="items">The items.</param>
        /// <remarks>
        /// Internal use only.
        /// </remarks>
        private void EnqueueItems(IReadOnlyCollection<T> items)
        {
            lock (_lockerQueue)
            {
                if (items == null)
                {
                    _queuedItems.Clear();
                    _queuedItems = null;
                }
                else
                {
                    // Just in case someone tries to add while we're dying
                    if (_queuedItems != null)
                    {
                        // Add each item
                        foreach (var item in items)
                        {
                            _queuedItems.Add(item);
                            ItemAdded(item);
                        }

                        // Sort them, if we have a Comparer
                        if (Comparer != null)
                        {
                            _queuedItems.Sort(Comparer);
                        }
                    }
                }
            }

            _waitHandle.Set();
        }

        /// <summary>
        /// Queue handler thread method for dealing with queued items
        /// </summary>
        private void Work()
        {
            while (true)
            {
                T item = null;
                lock (_lockerQueue)
                {
                    // Exit ?
                    if (_queuedItems == null)
                    {
                        return;
                    }

                    // Is there anything waiting ?

                    if (_queuedItems.Count > 0)
                    {
                        // Peek at the first item
                        item = _queuedItems[0];

                        // Are we able to handle this item yet ?
                        if (CanHandleItemNow(item))
                        {
                            // Dequeue
                            _queuedItems.RemoveAt(0);
                        }
                        else
                        {
                            // Don't handle it
                            item = null;
                        }
                    }
                }

                // Have we got an item to handle ?
                if (item != null)
                {
                    try
                    {
                        StartExecuting(item);

                        HandleItem(item);
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine("Exception handled by the Queue: {0}", Describe(ex));
                    }
                    finally
                    {
                        StopExecuting(item);
                    }
                }
                else
                {
                    // No more items - wait for a signal
                    if (IsTimed)
                    {
                        _waitHandle.WaitOne(Timeout);
                    }
                    else
                    {
                        _waitHandle.WaitOne();
                    }
                }
            }
        }

        /// <summary>
        /// Adds the item to the executing items list.
        /// </summary>
        /// <param name="item">The item to add.</param>
        private void StartExecuting(T item)
        {
            lock (_lockerExecuting)
            {
                _executingItems.Add(item);
            }
        }

        /// <summary>
        /// Removes the item from the executing items list.
        /// </summary>
        /// <remarks>
        /// Also performs cleanup of the item, if necessary
        /// </remarks>
        /// <param name="item">The item to remove.</param>
        private void StopExecuting(T item)
        {
            lock (_lockerExecuting)
            {
                _executingItems.Remove(item);
            }

            // Clean up items ?
            if (AutoCleanupItems)
            {
                // See if we can Dispose of it
                var itemDisposable = item as IDisposable;
                if (itemDisposable != null)
                {
                    itemDisposable.Dispose();
                }
            }
        }

        #endregion

        #region Overridable Methods

        /// <summary>
        /// Waits for consumers to complete.
        /// </summary>
        protected virtual void WaitForConsumersToComplete()
        {
            if (_workerThread != null)
            {
                _workerThread.Join();             // Wait for the consumer's thread to finish.
            }
        }

        /// <summary>
        /// Hook to determine if we can handle the item yet.
        /// </summary>
        /// <param name="item">The item about to be handled</param>
        /// <returns>
        /// true/false - depending on whether we can handle the item yet or not
        /// </returns>
        /// <remarks>
        /// Allows implementor to create custom lists (not just queues) based around the Producer/Consumer pattern
        /// </remarks>
        protected virtual bool CanHandleItemNow(T item)
        {
            return true;
        }

        /// <summary>
        /// Queue processor to handle an item when it gets to the front of the queue.
        /// </summary>
        /// <param name="item">The item to be handled</param>
        /// <remarks>
        /// Performs any processing required prior to calling specific implementor of ProcessItem
        /// </remarks>
        protected virtual void HandleItem(T item)
        {
            // Process it
            try
            {
                Trace.WriteLine("Processing Queue item: {0}", item == null ? "NULL" : item.GetType().Name);

                // Simply hand-off to ProcessItem as we're operating in single-thread mode
                ProcessItem(item);
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Exception from ProcessItem for Queue item: {0}", Describe(ex));
            }

            // Run any completion steps
            try
            {
                Trace.WriteLine("Completing Queue item: {0}", item == null ? "NULL" : item.GetType().Name);

                ItemComplete(item);
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Exception from ItemComplete for Queue item: {0}", Describe(ex));
            }
        }

        /// <summary>
        /// Hook called when an item has been added to the queue.
        /// </summary>
        /// <param name="item">The item just added.</param>
        protected virtual void ItemAdded(T item)
        {
        }

        /// <summary>
        /// Hook called when an item has been processed
        /// </summary>
        /// <param name="item">The item just successfully processed</param>
        protected virtual void ItemComplete(T item)
        {
        }

        /// <summary>
        /// Abstract method for processing a queued item after being picked up by the Queue handler
        /// </summary>
        /// <param name="item">The item to be processed</param>
        protected abstract void ProcessItem(T item);

        #endregion

        #region IProducerConsumerQueue<T> Members

        /// <summary>
        /// The Comparer to use when ordering Queued items
        /// </summary>
        /// <value>The comparer.</value>
        /// <remarks>
        /// Specify NULL for a regular FIFO queue
        /// </remarks>
        public IComparer<T> Comparer
        {
            get;
            private set;
        }

        /// <summary>
        /// Remove all items from the Queue
        /// </summary>
        public void Clear()
        {
            lock (_lockerQueue)
            {
                _queuedItems.Clear();
            }
        }

        /// <summary>
        /// Queue an item to be processed
        /// </summary>
        /// <param name="item">The item to be added.</param>
        /// <remarks>
        /// Public interface. Validates item to be a valid instance.
        /// </remarks>
        public void AddItem(T item)
        {
            if (item == null)
            {
                throw new NullReferenceException("Must add a valid item");
            }

            EnqueueItem(item);
        }

        /// <summary>
        /// Adds a batch of items to the Queue to be processed
        /// </summary>
        /// <param name="items">The items.</param>
        public void AddItems(T[] items)
        {
            var validated = new List<T>();

            // Remove any NULL instances
            if (items != null)
            {
                foreach (var item in items)
                {
                    if (item != null)
                    {
                        validated.Add(item);
                    }
                }
            }

            // Is there something to queue?
            if (validated.Count > 0)
            {
                EnqueueItems(validated.ToArray());
            }
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            EnqueueItem(null);             // Signal the consumer to exit.
            WaitForConsumersToComplete();  // Wait for the consumer's thread to finish.
            _waitHandle.Close();            // Release any OS resources.
        }

        #endregion
    }
}
