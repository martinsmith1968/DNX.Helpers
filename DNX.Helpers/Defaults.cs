using System.Reflection;

namespace DNX.Helpers
{
    /// <summary>
    /// Default values
    /// </summary>
    public class Defaults
    {
        /// <summary>
        /// The default property information binding flags for reading via reflection
        /// </summary>
        public const BindingFlags PropertyInfoReaderBindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty;

        /// <summary>
        /// The default property information binding flags for writing via reflection
        /// </summary>
        public const BindingFlags PropertyInfoWriterBindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty;

        /// <summary>
        /// The default field information binding flags for reading via reflection
        /// </summary>
        public const BindingFlags FieldInfoReaderBindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetField;

        /// <summary>
        /// The default field information binding flags for writing via reflection
        /// </summary>
        public const BindingFlags FieldInfoWriterBindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetField;
    }
}
