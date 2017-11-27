// Code generated by a Template
using System;
using System.Linq.Expressions;
using DNX.Helpers.Maths;
using DNX.Helpers.Maths.BuiltInTypes;
using DNX.Helpers.Reflection;

namespace DNX.Helpers.Validation
{
    /// <summary>
    /// Guard Extensions.
    /// </summary>
    public static partial class Guard
    {
        /// <summary>
        /// Ensures the expression evaluates to greater than the specified minimum
        /// </summary>
        /// <param name="exp">The exp.</param>
        /// <param name="min">The minimum.</param>
        public static void IsGreaterThan(Expression<Func<float>> exp, float min)
        {
            IsGreaterThan(exp, exp.Compile().Invoke(), min);
        }

        /// <summary>
        /// Ensures the expression and corresponding value evaluates to greater than the specified minimum
        /// </summary>
        /// <param name="exp">The exp.</param>
        /// <param name="val">The value.</param>
        /// <param name="min">The minimum.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public static void IsGreaterThan(Expression<Func<float>> exp, float val, float min)
        {
            if (val > min)
            {
                return;
            }

            var memberName = ReflectionExtensions.GetMemberName(exp);

            throw new ArgumentOutOfRangeException(
                memberName,
                val,
                string.Format("{0} must be greater than {1}",
                    memberName,
                    min
                )
            );
        }

        /// <summary>
        /// Ensures the expression evaluates to greater than or equal to the specified minimum
        /// </summary>
        /// <param name="exp">The exp.</param>
        /// <param name="min">The minimum.</param>
        public static void IsGreaterThanOrEqualTo(Expression<Func<float>> exp, float min)
        {
            IsGreaterThanOrEqualTo(exp, exp.Compile().Invoke(), min);
        }

        /// <summary>
        /// Ensures the expression and corresponding value evaluates to greater than or equal to the specified minimum
		/// </summary>
        /// <param name="exp">The exp.</param>
        /// <param name="val">The value.</param>
        /// <param name="min">The minimum.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public static void IsGreaterThanOrEqualTo(Expression<Func<float>> exp, float val, float min)
        {
            if (val >= min)
            {
                return;
            }

            var memberName = ReflectionExtensions.GetMemberName(exp);

            throw new ArgumentOutOfRangeException(
                memberName,
                val,
                string.Format("{0} must be greater than or equal to {1}",
                    memberName,
                    min
                )
            );
        }

        /// <summary>
        /// Ensures the expression evaluates to less than the specified minimum
        /// </summary>
        /// <param name="exp">The exp.</param>
        /// <param name="max">The maximum.</param>
        public static void IsLessThan(Expression<Func<float>> exp, float max)
        {
            IsLessThan(exp, exp.Compile().Invoke(), max);
        }

        /// <summary>
        /// Ensures the expression and corresponding value evaluates to less than the specified minimum
        /// </summary>
        /// <param name="exp">The exp.</param>
        /// <param name="val">The value.</param>
        /// <param name="max">The minimum.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public static void IsLessThan(Expression<Func<float>> exp, float val, float max)
        {
            if (val < max)
            {
                return;
            }

            var memberName = ReflectionExtensions.GetMemberName(exp);

            throw new ArgumentOutOfRangeException(
                memberName,
                val,
                string.Format("{0} must be less than {1}",
                    memberName,
                    max
                )
            );
        }

        /// <summary>
        /// Ensures the expression evaluates to less than or equal to the specified minimum
        /// </summary>
        /// <param name="exp">The exp.</param>
        /// <param name="max">The maximum.</param>
        public static void IsLessThanOrEqualTo(Expression<Func<float>> exp, float max)
        {
            IsLessThanOrEqualTo(exp, exp.Compile().Invoke(), max);
        }

        /// <summary>
        /// Ensures the expression and corresponding value evaluates to less than or equal to the specified minimum
        /// </summary>
        /// <param name="exp">The exp.</param>
        /// <param name="val">The value.</param>
        /// <param name="max">The maximum.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public static void IsLessThanOrEqualTo(Expression<Func<float>> exp, float val, float max)
        {
            if (val <= max)
            {
                return;
            }

            var memberName = ReflectionExtensions.GetMemberName(exp);

            throw new ArgumentOutOfRangeException(
                memberName,
                val,
                string.Format("{0} must be less than or equal to {1}",
                    memberName,
                    max
                )
            );
        }

        /// <summary>
        /// Ensures the expression evaluates to between the specified values
        /// </summary>
        /// <param name="exp">The linq expression of the argument to check</param>
        /// <param name="min">minimum allowed value</param>
        /// <param name="max">maximum allowed value</param>
        public static void IsBetween(Expression<Func<float>> exp, float min, float max)
        {
            IsBetween(exp, min, max, IsBetweenBoundsType.Inclusive);
        }

        /// <summary>
        /// Ensures the expression and corresponding value evaluates to between the specified values
        /// </summary>
        /// <param name="exp">The exp.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <param name="boundsType">Type of the bounds.</param>
        public static void IsBetween(Expression<Func<float>> exp, float min, float max, IsBetweenBoundsType boundsType)
        {
            IsBetween(exp, min, max, false, boundsType);
        }

        /// <summary>
        /// Ensures the expression evaluates to between the specified values
        /// </summary>
        /// <param name="exp">The exp.</param>
        /// <param name="bound1">The bound1.</param>
        /// <param name="bound2">The bound2.</param>
        /// <param name="allowEitherOrder">if set to <c>true</c> [allow either order].</param>
        /// <param name="boundsType">Type of the bounds.</param>
        public static void IsBetween(Expression<Func<float>> exp, float bound1, float bound2, bool allowEitherOrder, IsBetweenBoundsType boundsType)
        {
            IsBetween(exp, exp.Compile().Invoke(), bound1, bound2, allowEitherOrder, boundsType);
        }

        /// <summary>
        /// Ensures the expression and corresponding value evaluates to between the specified values
        /// </summary>
        /// <param name="exp">The exp.</param>
        /// <param name="val">The value.</param>
        /// <param name="bound1">The bound1.</param>
        /// <param name="bound2">The bound2.</param>
        /// <param name="allowEitherOrder">if set to <c>true</c> [allow either order].</param>
        /// <param name="boundsType">Type of the bounds.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public static void IsBetween(Expression<Func<float>> exp, float val, float bound1, float bound2, bool allowEitherOrder, IsBetweenBoundsType boundsType)
        {
            if (val.IsBetween(bound1, bound2, allowEitherOrder, boundsType))
            {
                return;
            }

            var memberName = ReflectionExtensions.GetMemberName(exp);

            throw new ArgumentOutOfRangeException(
                memberName,
                val,
                string.Format("{0} must be {1}",
                    memberName,
                    string.Format(boundsType.GetLimitDescriptionFormat(),
                        MathsFloatExtensions.GetLowerBound(bound1, bound2, allowEitherOrder),
                        MathsFloatExtensions.GetUpperBound(bound1, bound2, allowEitherOrder)
                        )
                    )
                );
        }
    }
}
