using System.Threading;
using DNX.Helpers.Validation;

namespace DNX.Helpers.Threading
{
    /// <summary>
    /// Generic parameterized delegate.
    /// </summary>
    /// <typeparam name="T">Type of method parameter.</typeparam>
    /// <param name="value">The strongly typed value to pass to the method.</param>
    public delegate void ParameterizedThreadStart<in T>(T value);

    /// <summary>
    /// Helper class for Thread operations
    /// </summary>
    /// <example>
    /// // Start new thread with type safe parameter.
    /// RunThread.Start(new ParameterizedThreadStart&lt;int&gt;(RunThis), 8);
    ///
    /// // Start new thread pool thread with type safe parameter.
    /// RunThread.StartOnThreadPool(new ParameterizedThreadStart&lt;int&gt;(RunThis), 9);
    ///
    /// // Start anonymous method on the thread pool.
    /// RunThread.StartOnThreadPool(delegate(int i)
    /// {
    ///    Console.WriteLine("Anonymous method run on thread pool and passed: " + i);
    /// }, 10);
    ///
    /// // Method with parm to run on a new thread.
    /// private void RunThis(int value)
    /// {
    ///    Console.WriteLine("Value: " + value + " ThreadPool: " +
    /// Thread.CurrentThread.IsThreadPoolThread +
    /// " ID: " + Thread.CurrentThread.ManagedThreadId);
    /// }
    /// </example>
    public static class ThreadHelper
    {
        /// <summary>
        /// Creates and starts a new Thread which runs the parameterized delegate.
        /// </summary>
        /// <typeparam name="T">The type of parameter the delegate accepts.</typeparam>
        /// <param name="start">The generic delegate.</param>
        /// <param name="value">The type to pass to delegate.</param>
        /// <returns>The Thread instance.</returns>
        public static Thread Start<T>(ParameterizedThreadStart<T> start, T value)
        {
            Guard.IsNotNull(() => start);

            var t = new Thread(
                delegate()
                {
                    start(value);
                }
                );

            t.Start();

            return t;
        }

        /// <summary>
        /// Creates and starts a new Thread.
        /// </summary>
        /// <param name="start">ThreadStart delegate.</param>
        /// <returns>The Thread instance.</returns>
        public static Thread Start(ThreadStart start)
        {
            Guard.IsNotNull(() => start);

            var t = new Thread(start);

            t.Start();

            return t;
        }

        /// <summary>
        /// Queues a delegate to run on a thread pool thread.
        /// </summary>
        /// <typeparam name="T">The type of parameter the delegate accepts.</typeparam>
        /// <param name="start">The generic delegate.</param>
        /// <param name="value">The type to pass to delegate.</param>
        /// <returns>
        ///   <c>True</c> if the delegate is queued successfully; <c>False</c> otherwise
        /// </returns>
        public static bool StartOnThreadPool<T>(ParameterizedThreadStart<T> start, T value)
        {
            Guard.IsNotNull(() => start);

            // We use this method instead of BeginInvoke so we get fire and forget semantics.
            return ThreadPool.QueueUserWorkItem(
                delegate
                {
                    start(value);
                }
                );
        }

        /// <summary>
        /// Queues a delegate to run on a thread pool thread.
        /// </summary>
        /// <param name="start">ThreadStart delegate.</param>
        /// <returns>
        ///   <c>True</c> if the delegate is queued successfully; <c>False</c> otherwise
        /// </returns>
        public static bool StartOnThreadPool(ThreadStart start)
        {
            Guard.IsNotNull(() => start);

            // We use this method instead of BeginInvoke so we get fire and forget semantics.
            return ThreadPool.QueueUserWorkItem(
                delegate
                {
                    start();
                }
                );
        }
    }
}
