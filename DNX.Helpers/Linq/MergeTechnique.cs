namespace DNX.Helpers.Linq
{
    /// <summary>
    /// MergeTechnique
    /// </summary>
    /// <remarks>The technique to use when merging dictionaries</remarks>
    public enum MergeTechnique
    {
        /// <summary>
        /// All keys must be unique
        /// </summary>
        Unique = 1,

        /// <summary>
        /// When keys clash, take the first found key value
        /// </summary>
        TakeFirst = 2,

        /// <summary>
        /// When keys clash, take the last found key value
        /// </summary>
        TakeLast = 3
    }
}
