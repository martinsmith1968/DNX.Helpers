using System;
using System.Reflection;

namespace DNX.Helpers.Assemblies
{
    /// <summary>
    /// Interface IAssemblyDetail
    /// </summary>
    public interface IAssemblyDetails
    {
        /// <summary>
        /// Gets the AssemblyName
        /// </summary>
        AssemblyName AssemblyName { get; }

        /// <summary>
        /// Gets the name of the assembly.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the location of the assembly.
        /// </summary>
        string Location { get; }

        /// <summary>
        /// Gets the file name of the assembly.
        /// </summary>
        string FileName { get; }

        /// <summary>
        /// Gets the title attribute value.
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Gets the product attribute value.
        /// </summary>
        string Product { get; }

        /// <summary>
        /// Gets the copyright attribute value.
        /// </summary>
        string Copyright { get; }

        /// <summary>
        /// Gets the company attribute value.
        /// </summary>
        string Company { get; }

        /// <summary>
        /// Gets the description attribute value.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets the trademark attribute value.
        /// </summary>
        string Trademark { get; }

        /// <summary>
        /// Gets the configuration attribute value.
        /// </summary>
        string Configuration { get; }

        /// <summary>
        /// Gets the assembly version.
        /// </summary>
        Version Version { get; }

        /// <summary>
        /// Gets the file version attribute value.
        /// </summary>
        string FileVersion { get; }

        /// <summary>
        /// Gets the informational version attribute value.
        /// </summary>
        string InformationalVersion { get; }
    }
}
