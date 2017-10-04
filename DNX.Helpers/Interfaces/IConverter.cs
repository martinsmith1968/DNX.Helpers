namespace DNX.Helpers.Interfaces
{
    /// <summary>
    /// Converter Interface for transposing objects between 2 types
    /// </summary>
    /// <typeparam name="T1">The type of the t1.</typeparam>
    /// <typeparam name="T2">The type of the t2.</typeparam>
    public interface IConverter<in T1, out T2>
    {
        /// <summary>
        /// Converts the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>T2.</returns>
        T2 Convert(T1 source);
    }
}
