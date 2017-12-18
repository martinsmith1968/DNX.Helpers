using System;

namespace DNX.Helpers.Providers
{
    /// <summary>
    /// Class FormatProviderFunc.
    /// </summary>
    /// <seealso cref="System.IFormatProvider" />
    public class FormatProviderFunc : IFormatProvider
    {
        private readonly Func<Type, object> _func;

        private FormatProviderFunc(Func<Type, object> func)
        {
            _func = func;
        }

        /// <summary>
        /// Returns an object that provides formatting services for the specified type.
        /// </summary>
        /// <param name="formatType">An object that specifies the type of format object to return.</param>
        /// <returns>An instance of the object specified by <paramref name="formatType" />, if the <see cref="T:System.IFormatProvider" /> implementation can supply that type of object; otherwise, null.</returns>
        public object GetFormat(Type formatType)
        {
            return _func(formatType);
        }

        /// <summary>
        /// Creates the specified function.
        /// </summary>
        /// <param name="func">The function.</param>
        /// <returns>FormatProviderFunc.</returns>
        public static FormatProviderFunc Create(Func<Type, object> func)
        {
            return new FormatProviderFunc(func);
        }
    }
}
