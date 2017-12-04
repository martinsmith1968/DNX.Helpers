using DNX.Helpers.Strings;

namespace DNX.Helpers.Objects
{
    /// <summary>
    /// Class ObjectExtensions.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Gets the unique instance identifier.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>System.String.</returns>
        public static string GetUniqueInstanceId(this object obj)
        {
            return obj.GetUniqueInstanceId(null);
        }

        /// <summary>
        /// Gets the unique instance identifier.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="instanceIdOverride">The instance identifier override.</param>
        /// <returns>System.String.</returns>
        public static string GetUniqueInstanceId(this object obj, string instanceIdOverride)
        {
            return string.Format("{0}:{1}",
                obj.GetType().FullName,
                StringExtensions.CoalesceNullOrEmpty(instanceIdOverride, obj.GetHashCode().ToString())
            );
        }
    }
}
