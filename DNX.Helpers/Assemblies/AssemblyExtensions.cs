using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DNX.Helpers.Assemblies
{
    /// <summary>
    /// Class AssemblyExtensions.
    /// </summary>
    public static class AssemblyExtensions
    {
        /// <summary>
        /// Gets the assembly details.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>IAssemblyDetails.</returns>
        public static IAssemblyDetails GetAssemblyDetails(this Assembly assembly)
        {
            return AssemblyDetails.ForAssembly(assembly);
        }

        /// <summary>
        /// Find the types in the Assembly that implement the specified Type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assembly">The assembly.</param>
        /// <returns>IList&lt;Type&gt;.</returns>
        public static IList<Type> FindTypesThatImplementType<T>(this Assembly assembly)
        {
            var types = assembly.GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(T)))
                .ToList();

            return types;
        }

        /// <summary>
        /// Find the concrete types in the Assembly that implement the specified Type
        /// </summary>
        /// <typeparam name="T">The type to find classes that implement</typeparam>
        /// <param name="assembly">The assembly to search</param>
        /// <returns>List of <see cref="Type"/></returns>
        public static IList<Type> FindConcreteTypesThatImplementType<T>(this Assembly assembly)
        {
            var concreteClassTypes = FindTypesThatImplementType<T>(assembly)
                .Where((t => t.IsClass && !t.IsAbstract))
                .ToList();

            return concreteClassTypes;
        }

        /// <summary>
        /// Create instances of concrete types in an assembly that implement the specified type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assembly">The assembly to search</param>
        /// <returns>List of instances of T></returns>
        public static IList<T> CreateInstancesOfConcreteTypesThatImplementType<T>(this Assembly assembly)
        {
            var types = assembly.FindConcreteTypesThatImplementType<T>();

            var instances = types
                .Select(t => Activator.CreateInstance(t))
                .Cast<T>()
                .ToList();

            return instances;
        }
    }
}
