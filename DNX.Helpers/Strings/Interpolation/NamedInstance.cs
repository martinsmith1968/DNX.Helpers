namespace DNX.Helpers.Strings.Interpolation
{
    /// <summary>
    /// Class NamedInstance.
    /// </summary>
    public class NamedInstance
    {
        /// <summary>
        /// Gets or sets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public object Instance { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

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
    }
}
