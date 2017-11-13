using System;
using System.IO;
using System.Reflection;
using DNX.Helpers.Validation;

namespace DNX.Helpers.Assemblies
{

    /// <summary>
    /// Implementation for obtaining Assembly Attributes
    /// </summary>
    /// <seealso cref="DNX.Helpers.Assemblies.IAssemblyDetails" />
    public class AssemblyDetails : IAssemblyDetails
    {
        #region Fields

        /// <summary>
        /// Internal _assembly field
        /// </summary>
        private readonly Assembly _assembly;

        #endregion

        #region Constructor(s)

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyDetails" /> class.
        /// </summary>
        public AssemblyDetails()
            : this(Assembly.GetCallingAssembly())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyDetails" /> class.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        public AssemblyDetails(Assembly assembly)
        {
            Guard.IsNotNull(() => assembly);

            _assembly = assembly;
        }

        #endregion

        #region Internal Methods

        /// <summary>
        /// Returns the value of attribute T or String.Empty if no value is available.
        /// </summary>
        /// <typeparam name="T">The type of attribute to interrogate</typeparam>
        /// <param name="getValue">The get value.</param>
        /// <returns>The result of the specified Func, executed on the found attribute, if any.
        /// <c>null</c> if not matching attribute can be found</returns>
        protected string GetValue<T>(Func<T, string> getValue) where T : Attribute
        {
            var a = (T)Attribute.GetCustomAttribute(_assembly, typeof(T));

            return a == null
                ? null
                : getValue(a);
        }

        #endregion

        #region IAssemblyDetails Members

        /// <summary>
        /// Gets the AssemblyName
        /// </summary>
        /// <value>The name of the assembly.</value>
        public AssemblyName AssemblyName
        {
            get { return _assembly.GetName(); }
        }

        /// <summary>
        /// Gets the name of the assembly.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get { return AssemblyName.Name; }
        }

        /// <summary>
        /// Gets the location of the assembly.
        /// </summary>
        /// <value>The location.</value>
        public string Location
        {
            get { return _assembly.Location; }
        }

        /// <summary>
        /// Gets the file name of the assembly.
        /// </summary>
        /// <value>The name of the file.</value>
        public string FileName
        {
            get { return Path.GetFileName(_assembly.Location); }
        }

        /// <summary>
        /// Gets the title attribute value.
        /// </summary>
        /// <value>The title.</value>
        public string Title
        {
            get { return GetValue<AssemblyTitleAttribute>(a => a.Title); }
        }

        /// <summary>
        /// Gets the product attribute value.
        /// </summary>
        /// <value>The product.</value>
        public string Product
        {
            get { return GetValue<AssemblyProductAttribute>(a => a.Product); }
        }

        /// <summary>
        /// Gets the copyright attribute value.
        /// </summary>
        /// <value>The copyright.</value>
        public string Copyright
        {
            get { return GetValue<AssemblyCopyrightAttribute>(a => a.Copyright); }
        }

        /// <summary>
        /// Gets the company attribute value.
        /// </summary>
        /// <value>The company.</value>
        public string Company
        {
            get { return GetValue<AssemblyCompanyAttribute>(a => a.Company); }
        }

        /// <summary>
        /// Gets the description attribute value.
        /// </summary>
        /// <value>The description.</value>
        public string Description
        {
            get { return GetValue<AssemblyDescriptionAttribute>(a => a.Description); }
        }

        /// <summary>
        /// Gets the trademark attribute value.
        /// </summary>
        /// <value>The trademark.</value>
        public string Trademark
        {
            get { return GetValue<AssemblyTrademarkAttribute>(a => a.Trademark); }
        }

        /// <summary>
        /// Gets the configuration attribute value.
        /// </summary>
        /// <value>The configuration.</value>
        public string Configuration
        {
            get { return GetValue<AssemblyConfigurationAttribute>(a => a.Configuration); }
        }

        /// <summary>
        /// Gets the assembly version.
        /// </summary>
        /// <value>The version.</value>
        public Version Version
        {
            get { return AssemblyName.Version; }
        }

        /// <summary>
        /// Gets or sets the simplified version.
        /// </summary>
        /// <value>The simplified version.</value>
        public string SimplifiedVersion
        {
            get { return Version.Simplify(); }
        }

        /// <summary>
        /// Gets the file version attribute value.
        /// </summary>
        /// <value>The file version.</value>
        public string FileVersion
        {
            get { return GetValue<AssemblyFileVersionAttribute>(a => a.Version); }
        }

        /// <summary>
        /// Gets the informational version attribute value.
        /// </summary>
        /// <value>The informational version.</value>
        public string InformationalVersion
        {
            get { return GetValue<AssemblyInformationalVersionAttribute>(a => a.InformationalVersion); }
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Froms the assembly.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>IAssemblyDetails.</returns>
        public static IAssemblyDetails ForAssembly(Assembly assembly)
        {
            return new AssemblyDetails(assembly);
        }

        /// <summary>
        /// For the calling assembly
        /// </summary>
        /// <returns>IAssemblyDetails.</returns>
        public static IAssemblyDetails ForMe()
        {
            return ForAssembly(Assembly.GetCallingAssembly());
        }

        /// <summary>
        /// Fors the entry point.
        /// </summary>
        /// <returns>IAssemblyDetails.</returns>
        public static IAssemblyDetails ForEntryPoint()
        {
            return ForAssembly(Assembly.GetEntryAssembly());
        }

        /// <summary>
        /// Fors the assembly containing.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>IAssemblyDetails.</returns>
        public static IAssemblyDetails ForAssemblyContaining(Type type)
        {
            return ForAssembly(type.Assembly);
        }

        /// <summary>
        /// Fors the assembly containing.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>IAssemblyDetails.</returns>
        public static IAssemblyDetails ForAssemblyContaining<T>()
        {
            return ForAssembly(typeof(T).Assembly);
        }

        #endregion
    }
}
