using System;
using System.Linq.Expressions;
using DNX.Helpers.Maths.BuiltInTypes;
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
        /// Throw an ArgumentOutOfRangeException when checking the result of exp.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exp">The linq expression of the argument to check</param>
        /// <param name="val">value of argument in exp</param>
        /// <param name="min">minimum allowed integer value</param>
        /// <param name="max">maximum allowed integer value</param>
        /// <param name="inclusive">if set to <c>true</c> min and max are inclusive.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        /// <remarks>Use this if you are not happy that the expression exp will be invoked more than once by your method.</remarks>
        public static void IsBetween<T>(Expression<Func<T>> exp, int val, int min, int max, bool inclusive)
        {
            if (val.IsBetween(min, max, inclusive))
            {
                return;
            }

            var memberName = ReflectionExtensions.GetMemberName(exp);

            throw new ArgumentOutOfRangeException(memberName,
                val,
                string.Format("{0} must be between {1} and {2} ", memberName, min, max)
                );
        }

        /// <summary>
        /// Determines whether [is between either] [the specified exp].
        /// </summary>
        /// <param name="exp">The exp.</param>
        /// <param name="val">The value.</param>
        /// <param name="bound1">The bound1.</param>
        /// <param name="bound2">The bound2.</param>
        /// <param name="inclusive">if set to <c>true</c> bound1 and bound2 are inclusive.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public static void IsBetweenEither(Expression<Func<int>> exp, int val, int bound1, int bound2, bool inclusive)
        {
            if (val.IsBetweenEither(bound1, bound2, inclusive))
            {
                return;
            }

            var memberName = ReflectionExtensions.GetMemberName(exp);

            throw new ArgumentOutOfRangeException(memberName,
                val,
                string.Format("{0} must be between {1} and {2} ", memberName, bound1, bound2)
            );
        }

        /// <summary>
        /// Verifies an expression is between 2 values
        /// </summary>
        /// <param name="exp">The linq expression of the argument to check</param>
        /// <param name="min">minimum allowed value</param>
        /// <param name="max">maximum allowed value</param>
        public static void IsBetween(Expression<Func<int>> exp, int min, int max)
        {
            IsBetween(exp, min, max, true);
        }

        /// <summary>
        /// Verifies an expression is between 2 values
        /// </summary>
        /// <param name="exp">The linq expression of the argument to check</param>
        /// <param name="min">minimum allowed value</param>
        /// <param name="max">maximum allowed value</param>
        /// /// <param name="inclusive">if set to <c>true</c> min and max are inclusive.</param>
        public static void IsBetween(Expression<Func<int>> exp, int min, int max, bool inclusive)
        {
            IsBetween(exp, exp.Compile().Invoke(), min, max, inclusive);
        }

        /// <summary>
        /// Throw an ArgumentOutOfRangeException when checking the result of exp.
        /// </summary>
        /// <param name="exp">The linq expression of the argument to check</param>
        /// <param name="bound1">first boundary allowed integer value</param>
        /// <param name="bound2">second boundary allowed integer value</param>
        /// <remarks>Use this if you are not happy that the expression exp will be invoked more than once by your method.</remarks>
        public static void IsBetweenEither(Expression<Func<int>> exp, int bound1, int bound2)
        {
            IsBetweenEither(exp, bound1, bound2, true);
        }

        /// <summary>
        /// Throw an ArgumentOutOfRangeException when checking the result of exp.
        /// </summary>
        /// <param name="exp">The linq expression of the argument to check</param>
        /// <param name="bound1">first boundary allowed integer value</param>
        /// <param name="bound2">second boundary allowed integer value</param>
        /// /// <param name="inclusive">if set to <c>true</c> bound1 and bound2 are inclusive.</param>
        /// <remarks>Use this if you are not happy that the expression exp will be invoked more than once by your method.</remarks>
        public static void IsBetweenEither(Expression<Func<int>> exp, int bound1, int bound2, bool inclusive)
        {
            IsBetweenEither(exp, exp.Compile().Invoke(), bound1, bound2, inclusive);
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

            IsNotNull<T>(exp, val);
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
