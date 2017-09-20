using System;
using System.Linq.Expressions;
using DNX.Helpers.Reflection;

// ReSharper disable InvertIf
namespace DNX.Helpers.Validation
{
    /// <summary>
    /// Guard Extensions.
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// Determines whether the specified exp is true.
        /// </summary>
        /// <param name="exp">The exp.</param>
        /// <param name="messageText">The message text.</param>
        public static void IsTrue(Expression<Func<bool>> exp, string messageText)
        {
            IsTrue(exp, exp.Compile().Invoke(), messageText);
        }

        /// <summary>
        /// Determines whether the specified exp is true.
        /// </summary>
        /// <param name="exp">The exp.</param>
        /// <param name="val">The value.</param>
        /// <param name="messageText">The message text.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public static void IsTrue(Expression<Func<bool>> exp, bool val, string messageText)
        {
            if (val)
            {
                return;
            }

            var memberName = ReflectionExtensions.GetMemberName(exp);

            throw new ArgumentOutOfRangeException(
                memberName,
                val,
                string.Format(messageText, memberName)
            );
        }

        /// <summary>
        /// Determines whether the specified exp is false.
        /// </summary>
        /// <param name="exp">The exp.</param>
        /// <param name="messageText">The message text.</param>
        public static void IsFalse(Expression<Func<bool>> exp, string messageText)
        {
            IsFalse(exp, exp.Compile().Invoke(), messageText);
        }

        /// <summary>
        /// Determines whether the specified exp is false.
        /// </summary>
        /// <param name="exp">The exp.</param>
        /// <param name="val">The value.</param>
        /// <param name="messageText">The message text.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public static void IsFalse(Expression<Func<bool>> exp, bool val, string messageText)
        {
            if (!val)
            {
                return;
            }

            var memberName = ReflectionExtensions.GetMemberName(exp);

            throw new ArgumentOutOfRangeException(
                memberName,
                val,
                string.Format(messageText, memberName)
            );
        }

        /// <summary>
        /// Throw an ArgumentNullException when checking the result of exp.
        /// </summary>
        /// <typeparam name="T">Any reference type</typeparam>
        /// <param name="exp">The linq expression of the argument to check</param>
        public static void IsNotNull<T>(Expression<Func<T>> exp)
            where T : class
        {
            var val = exp.Compile().Invoke();

            IsNotNull(exp, val);
        }

        /// <summary>
        /// Throw an ArgumentNullException when checking the result of exp.
        /// </summary>
        /// <typeparam name="T">Any reference type</typeparam>
        /// <param name="exp">The linq expression of the argument to check</param>
        /// <param name="val">value of argument in exp</param>
        /// <remarks>Use this if you are not happy that the expression exp will be invoked more than once by your method.</remarks>
        public static void IsNotNull<T>(Expression<Func<T>> exp, T val)
            where T : class
        {
            if (val == null)
            {
                var memberName = ReflectionExtensions.GetMemberName(exp);

                throw new ArgumentNullException(
                    memberName,
                    string.Format("{0} may not be null", memberName)
                    );
            }
        }

        /// <summary>
        /// Throw an ArgumentException if the string resulting from exp is null or empty.
        /// </summary>
        /// <param name="exp">The linq expression of the argument to check</param>
        public static void IsNotNullOrEmpty(Expression<Func<string>> exp)
        {
            IsNotNullOrEmpty(exp, exp.Compile().Invoke());
        }

        /// <summary>
        ///Throw an ArgumentException if the string resulting from exp is null or empty.
        /// </summary>
        /// <param name="exp">The linq expression of the argument to check</param>
        /// <param name="val">value of argument in exp</param>
        /// <remarks>Use this if you are not happy that the expression exp will be invoked more than once by your method.</remarks>
        public static void IsNotNullOrEmpty(Expression<Func<string>> exp, string val)
        {
            if (string.IsNullOrEmpty(val))
            {
                var memberName = ReflectionExtensions.GetMemberName(exp);

                throw new ArgumentException(
                    string.Format("{0} may not be null or empty", memberName), memberName
                    );
            }
        }

        /// <summary>
        /// Throw an ArgumentException if the string resulting from exp is null or empty.
        /// </summary>
        /// <param name="exp">The linq expression of the argument to check</param>
        public static void IsNotNullOrWhitespace(Expression<Func<string>> exp)
        {
            IsNotNullOrWhitespace(exp, exp.Compile().Invoke());
        }

        /// <summary>
        ///Throw an ArgumentException if the string resulting from exp is null or empty.
        /// </summary>
        /// <param name="exp">The linq expression of the argument to check</param>
        /// <param name="val">value of argument in exp</param>
        /// <remarks>Use this if you are not happy that the expression exp will be invoked more than once by your method.</remarks>
        public static void IsNotNullOrWhitespace(Expression<Func<string>> exp, string val)
        {
            if (string.IsNullOrWhiteSpace(val))
            {
                var memberName = ReflectionExtensions.GetMemberName(exp);

                throw new ArgumentException(
                    string.Format("{0} may not be null or whitespace", memberName), memberName
                    );
            }
        }
    }
}
