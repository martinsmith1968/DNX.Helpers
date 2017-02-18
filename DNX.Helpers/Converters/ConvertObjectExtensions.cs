
namespace DNX.Helpers.Converters
{
    /// <summary>
    /// Conversion Extensions.
    /// </summary>
    public static class ConvertObjectExtensions
    {
        /// <summary>
        /// Returns the obj.ToString() or null if null
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>System.String.</returns>
        public static string ToStringOrNull(this object obj)
        {
            return obj == null
                ? null
                : obj.ToString();
        }

        /// <summary>
        /// Returns the obj.ToString() or Empty if null
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>System.String.</returns>
        public static string ToStringOrEmpty(this object obj)
        {
            return obj == null
                ? string.Empty
                : obj.ToString();
        }
    }
}
