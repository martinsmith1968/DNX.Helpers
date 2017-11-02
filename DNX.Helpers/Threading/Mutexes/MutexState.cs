namespace DNX.Helpers.Threading.Mutexes
{
    /// <summary>
    /// The waiting
    /// </summary>
    public enum MutexState
    {
        /// <summary>
        /// Waiting to acquire a lock
        /// </summary>
        Waiting = 0,

        /// <summary>
        /// Lock acquired
        /// </summary>
        Acquired = 1,

        /// <summary>
        /// Lock released
        /// </summary>
        Released = 2
    }
}
