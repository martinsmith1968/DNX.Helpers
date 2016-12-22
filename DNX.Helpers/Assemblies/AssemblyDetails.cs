using System;
using System.IO;
using System.Reflection;
using DNX.Helpers.Validation;

namespace DNX.Helpers.Assemblies
{

    /// <summary>
    /// Implementation for obtaining Assembly Attributes
    /// </summary>
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
        /// Initializes a new instance of the <see cref="AssemblyDetails"/> class.
        /// </summary>
        public AssemblyDetails()
            : this(Assembly.GetCallingAssembly())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyDetails"/> class.
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
        /// <returns>
        /// The result of the specified Func, executed on the found attribute, if any.
        /// <c>null</c> if not matching attribute can be found
        /// </returns>
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
        public AssemblyName AssemblyName
        {
            get { return _assembly.GetName(); }
        }

        /// <summary>
        /// Gets the name of the assembly.
        /// </summary>
        public string Name
        {
            get { return AssemblyName.Name; }
        }

        /// <summary>
        /// Gets the location of the assembly.
        /// </summary>
        public string Location
        {
            get { return _assembly.Location; }
        }

        /// <summary>
        /// Gets the file name of the assembly.
        /// </summary>
        public string FileName
        {
            get { return Path.GetFileName(_assembly.Location); }
        }

        /// <summary>
        /// Gets the title attribute value.
        /// </summary>
        public string Title
        {
            get { return GetValue<AssemblyTitleAttribute>(a => a.Title); }
        }

        /// <summary>
        /// Gets the product attribute value.
        /// </summary>
        public string Product
        {
            get { return GetValue<AssemblyProductAttribute>(a => a.Product); }
        }

        /// <summary>
        /// Gets the copyright attribute value.
        /// </summary>
        public string Copyright
        {
            get { return GetValue<AssemblyCopyrightAttribute>(a => a.Copyright); }
        }

        /// <summary>
        /// Gets the company attribute value.
        /// </summary>
        public string Company
        {
            get { return GetValue<AssemblyCompanyAttribute>(a => a.Company); }
        }

        /// <summary>
        /// Gets the description attribute value.
        /// </summary>
        public string Description
        {
            get { return GetValue<AssemblyDescriptionAttribute>(a => a.Description); }
        }

        /// <summary>
        /// Gets the trademark attribute value.
        /// </summary>
        public string Trademark
        {
            get { return GetValue<AssemblyTrademarkAttribute>(a => a.Trademark); }
        }

        /// <summary>
        /// Gets the configuration attribute value.
        /// </summary>
        public string Configuration
        {
            get { return GetValue<AssemblyConfigurationAttribute>(a => a.Configuration); }
        }

        /// <summary>
        /// Gets the assembly version.
        /// </summary>
        public Version Version
        {
            get { return AssemblyName.Version; }
        }

        /// <summary>
        /// Gets the file version attribute value.
        /// </summary>
        public string FileVersion
        {
            get { return GetValue<AssemblyFileVersionAttribute>(a => a.Version); }
        }

        /// <summary>
        /// Gets the informational version attribute value.
        /// </summary>
        public string InformationalVersion
        {
            get { return GetValue<AssemblyInformationalVersionAttribute>(a => a.InformationalVersion); }
        }

        #endregion
    }
}
