using System.Linq;
using System.Reflection;

namespace DNX.Helpers.Strings.Interpolation
{
    /// <summary>
    /// An InterpolatableProperty
    /// </summary>
    public class InterpolatableProperty
    {
        public PropertyInfo PropertyInfo { get; private set; }
        public string Name { get; set; }
        public bool IsStatic { get; set; }

        internal InterpolatableProperty(PropertyInfo propertyInfo)
        {
            PropertyInfo = propertyInfo;
            Name         = propertyInfo.Name;
            IsStatic     = propertyInfo.GetAccessors().First().IsStatic;
        }

        /// <summary>
        /// Gets the name of the variable for substitution
        /// </summary>
        /// <param name="namePrefix">The name prefix.</param>
        /// <returns>System.String.</returns>
        public string GetVariableName(string namePrefix = null)
        {
            var variableName = string.Format("{0}{1}{2}",
                namePrefix,
                string.IsNullOrWhiteSpace(namePrefix) ? null : IsStatic ? ":" : ".",
                Name
            );

            return variableName;
        }
    }
}
