using System;
using System.Collections.Generic;
using System.Linq;

namespace DNX.Helpers.Reflection
{
    /// <summary>
    /// Instance Resolution Extensions.
    /// </summary>
    public static class InstanceResolutionExtensions
    {
        /// <summary>
        /// Find the instances of a Type that are decorated with an attribute that satisfies the given func condition
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TA">The type of the ta.</typeparam>
        /// <param name="instances">The instances.</param>
        /// <param name="func">The func to run against the decoration attribute</param>
        /// <param name="inherit">if set to <c>true</c> include inherited attributes.</param>
        /// <returns>List of T</returns>
        public static IList<T> ResolveInstancesOfTypeWithAttributeAndCondition<T, TA>(this IList<T> instances, Func<TA, bool> func, bool inherit = true)
        {
            var candidates = new List<T>();

            foreach (var instance in instances)
            {
                var attributes = instance.GetTypeAttributesFromInstance<TA>(inherit);

                var attributeMatches = attributes
                    .Where(i => func(i))
                    .ToList();

                if (attributeMatches.Any())
                {
                    candidates.Add(instance);
                }
            }

            return candidates;
        }
    }
}
