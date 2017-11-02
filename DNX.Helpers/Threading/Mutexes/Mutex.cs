using System;
using System.Collections.Concurrent;
using System.Threading;

namespace DNX.Helpers.Threading.Mutexes
{
    /// <inheritdoc />
    /// <summary>
    /// Class Mutex.
    /// </summary>
    /// <seealso cref="T:System.IDisposable" />
    public class Mutex : IDisposable
    {
        private static readonly object MutexLocker = new object();

        private static readonly ConcurrentDictionary<string, object> LockObjects;


        /// <summary>
        /// Gets or sets the lock object.
        /// </summary>
        /// <value>The lock object.</value>
        public object LockObject { get; private set; }

        /// <summary>
        /// Gets the state.
        /// </summary>
        /// <value>The state.</value>
        public MutexState State { get; private set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the timestamp.
        /// </summary>
        /// <value>The timestamp.</value>
        public DateTime Timestamp { get; private set; }

        /// <summary>
        /// Gets the thread identifier.
        /// </summary>
        /// <value>The thread identifier.</value>
        public int ThreadId { get; private set; }

        static Mutex()
        {
            lock (MutexLocker)
            {
                if (LockObjects == null)
                {
                    LockObjects = new ConcurrentDictionary<string, object>();
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Mutex" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="lockObject">The lock object.</param>
        internal Mutex(string name, object lockObject)
        {
            State      = MutexState.Waiting;
            LockObject = lockObject;
            Name       = name;
            Timestamp  = DateTime.UtcNow;
            ThreadId   = Thread.CurrentThread.ManagedThreadId;

            AcquireLock();
            MutexManager.Register(this);
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DNX.Helpers.Threading.Mutexes.Mutex" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public Mutex(string name)
            : this(name, GetLockObject(name))
        {
        }

        private static object GetLockObject(string name)
        {
            return LockObjects.GetOrAdd(name, new object());
        }

        /// <inheritdoc />
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            MutexManager.Release(this);
            ReleaseLock();
        }

        internal void AcquireLock()
        {
            Monitor.Enter(LockObject);
            State = MutexState.Acquired;
        }

        internal void ReleaseLock()
        {
            Monitor.Exit(LockObject);
            State = MutexState.Released;
        }
    }
}
