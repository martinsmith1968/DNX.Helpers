using System;
using System.Collections.Generic;
using System.Linq;

namespace DNX.Helpers.Linq
{
    /// <summary>
    /// Class ItemComparisonList.
    /// </summary>
    public class ItemComparisonList
    {
        /// <summary>
        /// Creates the specified source list.
        /// </summary>
        /// <typeparam name="T1">The type of the t1.</typeparam>
        /// <typeparam name="T2">The type of the t2.</typeparam>
        /// <param name="sourceList">The source list.</param>
        /// <param name="targetList">The target list.</param>
        /// <param name="matchFunc">The match function.</param>
        /// <returns>IList&lt;ItemComparison&lt;T1, T2&gt;&gt;.</returns>
        public static IList<ItemComparison<T1, T2>> Create<T1, T2>(IList<T1> sourceList, IList<T2> targetList, Func<T1, T2, bool> matchFunc)
        {
            var matchList = sourceList
                .Select(source => ItemComparison<T1, T2>.Create(source, targetList.SingleOrDefault(target => matchFunc(source, target))))
                .Union(
                    targetList
                        .Select(target => ItemComparison<T1, T2>.Create(sourceList.SingleOrDefault(source => matchFunc(source, target)), target))
                        .Where(targetMatch => targetMatch.TargetOnly)
                )
                .ToList();

            return matchList;
        }

        /// <summary>
        /// Creates the specified source list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sourceList">The source list.</param>
        /// <param name="targetList">The target list.</param>
        /// <param name="matchFunc">The match function.</param>
        /// <returns>IList&lt;ItemComparison&lt;T, T&gt;&gt;.</returns>
        public static IList<ItemComparison<T, T>> Create<T>(IList<T> sourceList, IList<T> targetList, Func<T, T, bool> matchFunc)
        {
            return Create<T, T>(sourceList, targetList, matchFunc);
        }
    }
}
