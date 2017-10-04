namespace DNX.Helpers.Interfaces
{
    /// <summary>
    /// Populatable Interface for populating this object from another
    /// </summary>
    /// <typeparam name="T1">The type of the t1.</typeparam>
    public interface IPopulatable<in T1>
    {
        /// <summary>
        /// Populates from an instance of T1
        /// </summary>
        /// <param name="source">The source.</param>
        void PopulateFrom(T1 source);
    }
}
