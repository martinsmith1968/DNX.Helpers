using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DNX.Helpers.Exceptions;
using DNX.Helpers.Linq;
using DNX.Helpers.Reflection;

namespace DNX.Helpers.Enumerations
{
    /// <summary>
    /// Enum Extensions.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Translate a given string to an enumeration value.
        /// May throw a translation exception
        /// </summary>
        /// <typeparam name="T">The enum type to translate to</typeparam>
        /// <param name="item">The string representation of an enum value of T</param>
        /// <returns>
        /// The result
        /// </returns>
        public static T ParseEnum<T>(this string item)
            where T : struct
        {
            return ParseEnum<T>(item, false);
        }

        /// <summary>
        /// Translate a given string to an enumeration value.
        /// May throw a translation exception
        /// </summary>
        /// <typeparam name="T">The enum type to translate to</typeparam>
        /// <param name="item">The string representation of an enum value of T</param>
        /// <param name="ignoreCase">if set to <c>true</c> ignore the case of item.</param>
        /// <returns>
        /// The result
        /// </returns>
        public static T ParseEnum<T>(this string item, bool ignoreCase)
            where T : struct
        {
            if (typeof(T).IsEnum == false)
            {
                throw new EnumTypeException(typeof(T));
            }

            return (T)Enum.Parse(typeof(T), item, ignoreCase);
        }

        /// <summary>
        /// Attempt to safely translate a string to an enumeration value.
        /// If translation is not possible return a default value
        /// </summary>
        /// <typeparam name="T">The enum type to translate to</typeparam>
        /// <param name="item">The string representation of an enum value of T</param>
        /// <param name="defaultValue">The default value to return if translation cannot complete</param>
        /// <returns></returns>
        /// <exception cref="EnumTypeException"></exception>
        public static T ParseEnumOrDefault<T>(this string item, T defaultValue)
            where T : struct
        {
            return ParseEnumOrDefault(item, false, defaultValue);
        }

        /// <summary>
        /// Attempt to safely translate a string to an enumeration value.
        /// If translation is not possible return a default value
        /// </summary>
        /// <typeparam name="T">The enum type to translate to</typeparam>
        /// <param name="item">The string representation of an enum value of T</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        /// <param name="defaultValue">The default value to return if translation cannot complete</param>
        /// <returns></returns>
        /// <exception cref="EnumTypeException"></exception>
        public static T ParseEnumOrDefault<T>(this string item, bool ignoreCase, T defaultValue)
            where T : struct
        {
            if (typeof(T).IsEnum == false)
            {
                throw new EnumTypeException(typeof(T));
            }

            try
            {
                return (T)Enum.Parse(typeof(T), item, ignoreCase);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string GetDescription(this Enum value)
        {
            var type = value.GetType();

            var memInfo = type.GetMember(value.ToString())
                .SingleOrDefault();

            var description = memInfo == null
                ? null
                : memInfo.GetMemberAttributes<DescriptionAttribute>(true);

            return description.HasAny()
                ? description.First().Description
                : null;
        }

        /// <summary>
        /// Determines whether the specified enum value is a valid enum name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The enum value.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is valid; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidEnum<T>(this T value)
            where T : struct
        {
            return Convert.ToString(value).IsValidEnum<T>();
        }

        /// <summary>
        /// Determines whether the specified enum value is a valid enum name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The enum Name.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is valid; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidEnum<T>(this string value)
            where T : struct
        {
            return IsValidEnum(value, typeof(T), false);
        }

        /// <summary>
        /// Determines whether the specified enum value is a valid enum name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        /// <returns><c>true</c> if [is valid enum] [the specified ignore case]; otherwise, <c>false</c>.</returns>
        public static bool IsValidEnum<T>(this string value, bool ignoreCase)
            where T : struct
        {
            return IsValidEnum(value, typeof(T), ignoreCase);
        }

        /// <summary>
        /// Determines whether the text is a valid enum value of the specified enum type
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="type">The type.</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        /// <returns><c>true</c> if [is valid enum] [the specified type]; otherwise, <c>false</c>.</returns>
        /// <exception cref="System.ArgumentNullException">type</exception>
        /// <exception cref="EnumTypeException"></exception>
        public static bool IsValidEnum(this string value, Type type, bool ignoreCase)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            if (!type.IsEnum)
            {
                throw new EnumTypeException(type);
            }

            var comparison = ignoreCase
                ? StringComparison.CurrentCultureIgnoreCase
                : StringComparison.CurrentCulture;

            var names = Enum.GetNames(type)
                .ToList();

            return names.Any(n => n.Equals(value, comparison));
        }

        /// <summary>
        /// Gets the max enum value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetMaxValue<T>()
            where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new EnumTypeException(typeof(T));
            }

            return Enum.GetValues(typeof(T))
                .Cast<T>()
                .Max();
        }

        /// <summary>
        /// Gets the min enum value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetMinValue<T>()
            where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new EnumTypeException(typeof(T));
            }

            return Enum.GetValues(typeof(T))
                .Cast<T>()
                .Min();
        }

        /// <summary>
        /// Determines whether [is value one of] [the specified args].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="allowed">The allowed.</param>
        /// <returns>
        ///   <c>true</c> if [is value one of] [the specified args]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValueOneOf<T>(this T value, params T[] allowed)
            where T : struct
        {
            return value.IsValueOneOf(allowed.ToList());
        }

        /// <summary>
        /// Determines whether [is value one of] [the specified args].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="allowed">The allowed.</param>
        /// <returns>
        ///   <c>true</c> if [is value one of] [the specified args]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValueOneOf<T>(this T value, IList<T> allowed)
            where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new EnumTypeException(typeof(T));
            }

            return allowed.Contains(value);
        }

        /// <summary>
        /// Sets the flag.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="flag">The flag.</param>
        /// <param name="set">if set to <c>true</c> [set].</param>
        /// <returns></returns>
        public static T ManipulateFlag<T>(this Enum value, T flag, bool set)
        {
            var underlyingType = Enum.GetUnderlyingType(value.GetType());

            // note: AsInt mean: math integer vs enum (not the c# int type)
            dynamic valueAsInt = Convert.ChangeType(value, underlyingType);
            dynamic flagAsInt  = Convert.ChangeType(flag, underlyingType);

            if (set)
            {
                valueAsInt |= flagAsInt;
            }
            else
            {
                valueAsInt &= ~flagAsInt;
            }
            return (T)valueAsInt;
        }

        /// <summary>
        /// Sets the flag.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="flag">The flag.</param>
        /// <returns></returns>
        public static T SetFlag<T>(this Enum value, T flag)
        {
            return ManipulateFlag(value, flag, true);
        }

        /// <summary>
        /// Unsets the flag.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="flag">The flag.</param>
        /// <returns></returns>
        public static T UnsetFlag<T>(this Enum value, T flag)
        {
            return ManipulateFlag(value, flag, false);
        }

        /// <summary>
        /// Gets the set values list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumValue">The enum value.</param>
        /// <returns></returns>
        public static List<T> GetSetValuesList<T>(this Enum enumValue)
            where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new EnumTypeException(typeof(T));
            }

            var list = new List<T>();

            foreach (var name in Enum.GetNames(typeof(T)))
            {
                var nameValue = (Enum)Enum.Parse(typeof(T), name);

                if ((enumValue.HasFlag(nameValue)))
                {
                    var actualValue = (T)Enum.Parse(typeof(T), name);

                    list.Add(actualValue);
                }
            }

            return list;
        }

        /// <summary>
        /// Converts the entire enum to a dictionary with Name as the key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IDictionary<string, T> ToDictionaryByName<T>()
            where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new EnumTypeException(typeof(T));
            }

            var dictionary = Enum.GetValues(typeof(T))
                .Cast<T>()
                .ToDictionary(
                    t => t.ToString(),
                    t => t
                    );

            return dictionary;
        }

        /// <summary>
        /// Converts the entire enum to a dictionary with Value as the key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IDictionary<T, string> ToDictionaryByValue<T>()
            where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new EnumTypeException(typeof(T));
            }

            var dictionary = Enum.GetValues(typeof(T))
                .Cast<T>()
                .ToDictionary(
                    t => t,
                    t => t.ToString()
                    );

            return dictionary;
        }
    }
}
