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
        /// <value>The name of the assembly.</value>
        AssemblyName AssemblyName { get; }

        /// <summary>
        /// Gets the name of the assembly.
        /// </summary>
        /// <value>The name.</value>
        string Name { get; }

        /// <summary>
        /// Gets the location of the assembly.
        /// </summary>
        /// <value>The location.</value>
        string Location { get; }

        /// <summary>
        /// Gets the file name of the assembly.
        /// </summary>
        /// <value>The name of the file.</value>
        string FileName { get; }

        /// <summary>
        /// Gets the title attribute value.
        /// </summary>
        /// <value>The title.</value>
        string Title { get; }

        /// <summary>
        /// Gets the product attribute value.
        /// </summary>
        /// <value>The product.</value>
        string Product { get; }

        /// <summary>
        /// Gets the copyright attribute value.
        /// </summary>
        /// <value>The copyright.</value>
        string Copyright { get; }

        /// <summary>
        /// Gets the company attribute value.
        /// </summary>
        /// <value>The company.</value>
        string Company { get; }

        /// <summary>
        /// Gets the description attribute value.
        /// </summary>
        /// <value>The description.</value>
        string Description { get; }

        /// <summary>
        /// Gets the trademark attribute value.
        /// </summary>
        /// <value>The trademark.</value>
        string Trademark { get; }

        /// <summary>
        /// Gets the configuration attribute value.
        /// </summary>
        /// <value>The configuration.</value>
        string Configuration { get; }

        /// <summary>
        /// Gets the assembly version.
        /// </summary>
        /// <value>The version.</value>
        Version Version { get; }

        /// <summary>
        /// Gets the file version attribute value.
        /// </summary>
        /// <value>The file version.</value>
        string FileVersion { get; }

        /// <summary>
        /// Gets the informational version attribute value.
        /// </summary>
        /// <value>The informational version.</value>
        string InformationalVersion { get; }
    }
}
