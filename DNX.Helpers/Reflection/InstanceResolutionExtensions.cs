using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DNX.Helpers.Reflection
{
    /// <summary>
    /// Instance Resolution Extensions.
    /// </summary>
    public class InstanceResolutionExtensions
    {
        /// <summary>
        /// Finds the types that implement interface.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assembly">The assembly.</param>
        /// <returns>IList&lt;Type&gt;.</returns>
        public static IList<Type> GetTypesThatImplementInterface<T>(Assembly assembly)
        {
            var types = assembly.GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(T)))
                .ToList();

            return types;
        }

        /// <summary>
        /// Find all concrete classes in an assembly that implement a given interface
        /// </summary>
        /// <typeparam name="T">The type to find classes that implement</typeparam>
        /// <param name="assembly">The assembly to search</param>
        /// <returns>List of <see cref="Type"/></returns>
        public static IList<Type> GetConcreteTypesThatImplementInterface<T>(Assembly assembly)
        {
            var concreteClassTypes = GetTypesThatImplementInterface<T>(assembly)
                .Where((t => t.IsClass && !t.IsAbstract))
                .ToList();

            return concreteClassTypes;
        }

        /// <summary>
        /// Find instances of classes in an assembly that implement a given interface
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assembly">The assembly to search</param>
        /// <returns>List of instances of T></returns>
        public static IList<T> GetInstancesOfClassesThatImplementInterface<T>(Assembly assembly)
        {
            var types = GetConcreteTypesThatImplementInterface<T>(assembly);

            var instances = types
                .Select(t => Activator.CreateInstance(t))
                .Cast<T>()
                .ToList();

            return instances;
        }

        /// <summary>
        /// Find instances of classes in an assembly that implement a given interface and are decorated with an attribute that passes the given func test
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TA"></typeparam>
        /// <param name="assembly">The assembly to search</param>
        /// <param name="func">The func to run against the decoartion attribute</param>
        /// <returns>List of instances of T</returns>
        public static T ResolveImplementationOfInterfaceWithAttribute<T, TA>(Assembly assembly, Func<TA, bool> func)
        {
            var instances = GetInstancesOfClassesThatImplementInterface<T>(assembly);

            var candidate = GetInstanceOfClassesThatImplementInterfaceWithAttribute(instances, func);

            return candidate;
        }

        /// <summary>
        /// Find instances of classes in an assembly that implement a given interface and are decorated with an attribute that passes the given func test
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TA">The type of the ta.</typeparam>
        /// <param name="instances">The instances.</param>
        /// <param name="func">The func to run against the decoration attribute</param>
        /// <returns>Instance of T or null</returns>
        public static T GetInstanceOfClassesThatImplementInterfaceWithAttribute<T, TA>(IList<T> instances, Func<TA, bool> func)
        {
            var candidates = new List<T>();

            foreach (var instance in instances)
            {
                var attributes = instance.GetTypeAttributesFromInstance<TA>(true);

                var attributeMatches = attributes
                    .Where(i => func(i))
                    .ToList();

                if (attributeMatches.Any())
                {
                    candidates.Add(instance);
                }
            }

            var candidate = candidates.SingleOrDefault();

            return candidate;
        }
    }
}
