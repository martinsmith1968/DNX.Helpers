using System;
using System.Threading.Tasks;

namespace DNX.Helpers.Internal
{
    /// <summary>
    /// RunSafely - execute code with defaulted exception handling
    /// </summary>
    public class RunSafely
    {
        /// <summary>
        /// Executes the specified action.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="exceptionHandler">The exception handler.</param>
        public static void Execute(Action action, Action<Exception> exceptionHandler = null)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception ex)
            {
                Execute(() => exceptionHandler?.Invoke(ex));
            }
        }

        /// <summary>
        /// Executes the specified function.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func">The function.</param>
        /// <param name="exceptionHandler">The exception handler.</param>
        /// <returns>T.</returns>
        public static T Execute<T>(Func<T> func, Action<Exception> exceptionHandler = null)
        {
            return Execute(func, default, exceptionHandler);
        }

        /// <summary>
        /// Executes the specified function.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func">The function.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <param name="exceptionHandler">The exception handler.</param>
        /// <returns>T.</returns>
        public static T Execute<T>(Func<T> func, T defaultValue, Action<Exception> exceptionHandler = null)
        {
            try
            {
                return func.Invoke();
            }
            catch (Exception ex)
            {
                Execute(() => exceptionHandler?.Invoke(ex));

                return defaultValue;
            }
        }

        /// <summary>
        /// execute as an asynchronous operation.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <param name="exceptionHandler">The exception handler.</param>
        public static async Task ExecuteAsync(Task task, Action<Exception> exceptionHandler = null)
        {
            try
            {
                await task.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Execute(() => exceptionHandler?.Invoke(ex));
            }
        }

        /// <summary>
        /// execute as an asynchronous operation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="task">The task.</param>
        /// <param name="exceptionHandler">The exception handler.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public static async Task<T> ExecuteAsync<T>(Task<T> task, Action<Exception> exceptionHandler = null)
        {
            return await ExecuteAsync(task, default, exceptionHandler);
        }

        /// <summary>
        /// execute as an asynchronous operation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="task">The task.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <param name="exceptionHandler">The exception handler.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public static async Task<T> ExecuteAsync<T>(Task<T> task, T defaultValue, Action<Exception> exceptionHandler = null)
        {
            try
            {
                return await task.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Execute(() => exceptionHandler?.Invoke(ex));

                return defaultValue;
            }
        }
    }
}
