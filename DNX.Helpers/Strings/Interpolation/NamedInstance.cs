namespace DNX.Helpers.Strings.Interpolation
{
    /// <summary>
    /// Class NamedInstance.
    /// </summary>
    public class NamedInstance
    {
        public object Instance { get; set; }

        public string Name { get; set; }

        public NamedInstance(object instance, string name = null)
        {
            Instance = instance;
            Name     = name;
        }
    }
}
