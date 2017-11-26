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
    }
}
