namespace DNX.Helpers.Interfaces
{
    /// <summary>
    /// Extractable Interface for populating another instance from this one
    /// </summary>
    /// <typeparam name="T1">The type of the t1.</typeparam>
    public interface IExtractable<in T1>
    {
        /// <summary>
        /// Extracts this object into another
        /// </summary>
        /// <param name="target">The target.</param>
        void ExtractInto(T1 target);
    }
}
