using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

// ReSharper disable once ConvertIfStatementToReturnStatement
namespace DNX.Helpers.Reflection
{
    /// <summary>
    /// Reflection Extensions.
    /// </summary>
    public static class ReflectionExtensions
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

        /// <summary>
        /// Gets the object properties as a dictionary.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>IDictionary&lt;System.String, System.Object&gt;.</returns>
        public static IDictionary<string, object> GetPropertiesDictionary(object obj)
        {
            var dictionary = GetPropertiesDictionary(obj,
                BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance
                );

            return dictionary;
        }

        /// <summary>
        /// Gets the object properties as a dictionary.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="bindingFlags">The binding flags.</param>
        /// <returns>IDictionary&lt;System.String, System.Object&gt;.</returns>
        public static IDictionary<string, object> GetPropertiesDictionary(object obj, BindingFlags bindingFlags)
        {
            if (obj == null)
            {
                return null;
            }

            var dictionary = GetPropertiesForType(obj.GetType(), bindingFlags)
                .ToDictionary(
                    pi => pi.Name,
                    pi => pi.GetValue(obj)
                );

            return dictionary;
        }

        /// <summary>
        /// Gets the properties for the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>IList&lt;PropertyInfo&gt;.</returns>
        public static IList<PropertyInfo> GetPropertiesForType(Type type)
        {
            var list = GetPropertiesForType(
                type,
                BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance
                );

            return list;
        }

        /// <summary>
        /// Gets the properties for the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="bindingFlags">The binding flags.</param>
        /// <returns>IList&lt;PropertyInfo&gt;.</returns>
        public static IList<PropertyInfo> GetPropertiesForType(Type type, BindingFlags bindingFlags)
        {
            var propertyInfos = type.GetProperties(bindingFlags);

            return propertyInfos;
        }

        /// <summary>
        /// Gets the properties for the specified types.
        /// </summary>
        /// <param name="types">The types.</param>
        /// <returns>IList&lt;PropertyInfo&gt;.</returns>
        public static IList<PropertyInfo> GetPropertiesForTypes(IEnumerable<Type> types)
        {
            var list = GetPropertiesForTypes(
                types,
                BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance
                );

            return list;
        }

        /// <summary>
        /// Gets the properties for the specified types.
        /// </summary>
        /// <param name="types">The types.</param>
        /// <param name="bindingFlags">The binding flags.</param>
        /// <returns>IList&lt;PropertyInfo&gt;.</returns>
        public static IList<PropertyInfo> GetPropertiesForTypes(IEnumerable<Type> types, BindingFlags bindingFlags)
        {
            var properties = types
                .SelectMany(t => GetPropertiesForType(t, bindingFlags))
                .ToList();

            return properties;
        }

        /// <summary>
        /// Gets an objects property info by name. Supports dot notation for child properties
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>PropertyInfo.</returns>
        public static PropertyInfo GetPropertyInfoByName(this object instance, string propertyName)
        {
            var propertyNames = propertyName.Split(".".ToCharArray());

            var instancePropertyName = propertyNames
                .FirstOrDefault();

            var childPropertyNames = propertyNames
                .Skip(1)
                .ToList();

            var childPropertyNamesText = childPropertyNames.Any()
                ? string.Join(".", childPropertyNames)
                : string.Empty;

            var propertyInfo = instance == null
                ? null
                : GetPropertiesForType(instance.GetType())
                    .FirstOrDefault(p => p.Name.Equals(instancePropertyName, StringComparison.CurrentCultureIgnoreCase));

            var instanceValue = propertyInfo == null
                ? null
                : propertyInfo.GetValue(instance, null);

            var returnValue = childPropertyNames.Any()
                ? GetPropertyInfoByName(instanceValue, childPropertyNamesText)
                : propertyInfo;

            return returnValue;
        }

        /// <summary>
        /// Determines whether the specified property name is valid for the specified object
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>System.Boolean.</returns>
        public static bool IsPropertyNameValid(this object instance, string propertyName)
        {
            var propertyInfo = GetPropertyInfoByName(instance, propertyName);

            var exists = propertyInfo != null;

            return exists;
        }

        /// <summary>
        /// Gets he value of an objects property by name
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>System.Object.</returns>
        public static object GetPropertyValueByName(this object instance, string propertyName)
        {
            var propertyNames = propertyName.Split(".".ToCharArray());

            var instancePropertyName = propertyNames
                .FirstOrDefault();

            var childPropertyNames = propertyNames
                .Skip(1)
                .ToList();
            var childPropertyNamesText = childPropertyNames.Any()
                ? string.Join(".", childPropertyNames)
                : string.Empty;

            var propertyInfo = GetPropertiesForType(instance.GetType())
                .FirstOrDefault(p => p.Name.Equals(instancePropertyName, StringComparison.CurrentCultureIgnoreCase));

            var instanceValue = propertyInfo == null
                ? null
                : propertyInfo.GetValue(instance, null);

            var returnValue = childPropertyNames.Any()
                ? GetPropertyValueByName(instanceValue, childPropertyNamesText)
                : instanceValue;

            return returnValue;
        }
    }
}
