using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DNX.Helpers.Linq;
using DNX.Helpers.Reflection;

// ReSharper disable InconsistentNaming

namespace DNX.Helpers.Strings.Interpolation
{
    /// <summary>
    /// Class NamedInstance.
    /// </summary>
    public class NamedInstance
    {
        private const BindingFlags InstanceBindingFlags = Defaults.PropertyInfoReaderBindingFlags | BindingFlags.GetField;
        private const BindingFlags StaticBindingFlags = (Defaults.PropertyInfoReaderBindingFlags ^ BindingFlags.Instance) | BindingFlags.GetField | BindingFlags.Static;

        /// <summary>
        /// Gets or sets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public object Instance { get; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NamedInstance"/> class.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="name">The name.</param>
        public NamedInstance(object instance, string name = null)
        {
            Instance = instance;
            Name     = name;
        }

        /// <summary>
        /// Returns the named instance as a Dictionary
        /// </summary>
        /// <returns>IDictionary&lt;System.String, System.Object&gt;.</returns>
        public IDictionary<string, object> ToDictionary()
        {
            if (Instance == null)
                return null;

            var dict = Instance.AsDictionary(InstanceBindingFlags)
                .MergeWith(Instance.AsDictionary(StaticBindingFlags), MergeTechnique.TakeFirst);

            if (!string.IsNullOrWhiteSpace(Name))
            {
                dict = dict.ToDictionary(
                    x => $"{Name}.{x.Key}",
                    y => y.Value
                    );
            }

            return dict;
        }
    }
}
