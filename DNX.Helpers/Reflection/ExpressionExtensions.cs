using System;
using System.Linq.Expressions;

namespace DNX.Helpers.Reflection
{
    /// <summary>
    /// Class ExpressionExtensions.
    /// </summary>
    public static class ExpressionExtensions
    {
        /// <summary>
        /// Determines whether the expression is a member expression
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exp">The exp.</param>
        /// <returns></returns>
        public static bool IsMemberExpression<T>(Expression<Func<T>> exp)
        {
            var memberExpression = exp.Body as MemberExpression;

            return memberExpression != null;
        }

        /// <summary>
        /// Determines whether Determines whether the expression is a lambda expression
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exp">The exp.</param>
        /// <returns></returns>
        public static bool IsLambdaExpression<T>(Expression<Func<T>> exp)
        {
            var lambdaExpression = exp.Body as LambdaExpression;

            return lambdaExpression != null;
        }

        /// <summary>
        /// Determines whether Determines whether the expression is a unary expression
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exp">The exp.</param>
        /// <returns></returns>
        public static bool IsUnaryExpression<T>(Expression<Func<T>> exp)
        {
            var unaryExpression = exp.Body as UnaryExpression;

            return unaryExpression != null;
        }

        /// <summary>
        /// Gets the name of the member expression.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exp">The exp.</param>
        /// <returns></returns>
        public static string GetMemberName<T>(Expression<Func<T>> exp)
        {
            var memberExpression = exp.Body as MemberExpression;

            return memberExpression == null
                ? null
                : memberExpression.Member.Name;
        }

        /// <summary>
        /// Gets the name of the lambda expression.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exp">The exp.</param>
        /// <returns></returns>
        public static string GetLambdaName<T>(Expression<Func<T>> exp)
        {
            var lambdaExpression = exp.Body as LambdaExpression;

            return lambdaExpression == null
                ? null
                : lambdaExpression.Name;
        }

        /// <summary>
        /// Gets the name of the unary expression.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exp">The exp.</param>
        /// <returns></returns>
        public static string GetUnaryName<T>(Expression<Func<T>> exp)
        {
            var unaryExpression = exp.Body as UnaryExpression; //((UnaryExpression)exp.Body).Operand;

            var operand = unaryExpression == null
                ? null
                : unaryExpression.Operand as MemberExpression;

            return operand == null
                ? null
                : operand.Member.Name;
        }

        /// <summary>
        /// Gets the name of the expression.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exp">The exp.</param>
        /// <returns></returns>
        public static string GetExpressionName<T>(Expression<Func<T>> exp)
        {
            if (IsMemberExpression(exp))
            {
                return GetMemberName(exp);
            }

            if (IsLambdaExpression(exp))
            {
                return GetLambdaName(exp);
            }

            if (IsUnaryExpression(exp))
            {
                return GetUnaryName(exp);
            }

            return null;
        }
    }
}
