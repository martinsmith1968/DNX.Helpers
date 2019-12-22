namespace DNX.Helpers.Strings.Interpolation.Interfaces
{
    /// <summary>
    /// Interface INamedInstance
    /// </summary>
    public interface INamedInstance
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        string Name { get; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>System.Object.</returns>
        object GetValue(string propertyName);
    }
}
