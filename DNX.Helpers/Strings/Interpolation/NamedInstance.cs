namespace DNX.Helpers.Strings.Interpolation
{
    /// <summary>
    /// Class NamedInstance.
    /// </summary>
    public class NamedInstance
    {
        public object Instance { get; set; }

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
