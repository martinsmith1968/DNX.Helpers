using System.Collections.Generic;

namespace DNX.Helpers.Threading.Mutexes
{
    /// <summary>
    /// Class MutexManager.
    /// </summary>
    public static class MutexManager
    {
        /// <summary>
        /// The locker
        /// </summary>
        private static readonly object MutexManagerLocker = new object();

        /// <summary>
        /// Gets the mutexes.
        /// </summary>
        /// <value>The mutexes.</value>
        public static IDictionary<string, Mutex> Mutexes { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MutexManager"/> class.
        /// </summary>
        static MutexManager()
        {
            lock (MutexManagerLocker)
            {
                if (Mutexes == null)
                {
                    Mutexes = new Dictionary<string, Mutex>();
                }
            }
        }

        /// <summary>
        /// Acquires a named Mutex waiting for it to become available
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Mutex.</returns>
        public static Mutex Acquire(string name)
        {
            lock (MutexManagerLocker)
            {
                var mutex = new Mutex(name);

                return mutex;
            }
        }

        /// <summary>
        /// Acquires a named Mutex or returns null immediately if unable
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>DNX.Helpers.Threading.Mutexes.Mutex.</returns>
        public static Mutex AcquireNoWait(string name)
        {
            lock (MutexManagerLocker)
            {
                if (Mutexes.ContainsKey(name))
                {
                    return null;
                }
            }

            return Acquire(name);
        }

        /// <summary>
        /// Determines whether the named Mutex could be acquired
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns><c>true</c> if this instance can acquire the specified name; otherwise, <c>false</c>.</returns>
        public static bool CanAcquire(string name)
        {
            lock (MutexManagerLocker)
            {
                return !Mutexes.ContainsKey(name);
            }
        }

        internal static void Register(Mutex mutex)
        {
            lock (MutexManagerLocker)
            {
                Mutexes.Add(mutex.Name, mutex);
            }
        }

        internal static void Release(Mutex mutex)
        {
            lock (MutexManagerLocker)
            {
                Mutexes.Remove(mutex.Name);
            }
        }
    }
}
