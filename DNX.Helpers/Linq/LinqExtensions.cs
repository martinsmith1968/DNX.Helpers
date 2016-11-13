using System;
using System.Collections.Generic;
using System.Linq;

namespace DNX.Helpers.Linq
{
    public static class LinqExtensions
    {
        public static T GetAt<T>(this IList<T> enumerable , int index)
        {
            if (enumerable != null)
            {
                if (index < 0)
                {
                    index = enumerable.Count - Math.Abs(index % enumerable.Count);
                }

                if (index < enumerable.Count)
                {
                    return enumerable[index];
                }
            }

            return default(T);
        }

        public static bool HasAny<T>(this IEnumerable<T> enumerable)
        {
            return enumerable != null && enumerable.Any();
        }

        public static bool HasAny<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
        {
            return enumerable != null && enumerable.Any(predicate);
        }
    }
}
