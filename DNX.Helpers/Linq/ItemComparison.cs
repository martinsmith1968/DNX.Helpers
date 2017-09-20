namespace DNX.Helpers.Linq
{
    /// <summary>
    /// ItemComparison result for logical comparison of 2 objects.
    /// </summary>
    /// <typeparam name="T1">The type of the t1.</typeparam>
    /// <typeparam name="T2">The type of the t2.</typeparam>
    public class ItemComparison<T1, T2>
    {
        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <value>The source.</value>
        public T1 Source { get; private set; }

        /// <summary>
        /// Gets the target.
        /// </summary>
        /// <value>The target.</value>
        public T2 Target { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="ItemComparison{T1, T2}"/> is matched.
        /// </summary>
        /// <value><c>true</c> if matched; otherwise, <c>false</c>.</value>
        public bool Matched { get { return Source != null && Target != null; } }

        /// <summary>
        /// Gets a value indicating whether [source only].
        /// </summary>
        /// <value><c>true</c> if [source only]; otherwise, <c>false</c>.</value>
        public bool SourceOnly { get { return Source != null && Target == null; } }

        /// <summary>
        /// Gets a value indicating whether [target only].
        /// </summary>
        /// <value><c>true</c> if [target only]; otherwise, <c>false</c>.</value>
        public bool TargetOnly { get { return Source == null && Target != null; } }

        private ItemComparison(T1 source, T2 target)
        {
            Source = source;
            Target = target;
        }

        /// <summary>
        /// Creates an ItemComparison
        /// </summary>
        /// <param name="item1">The item1.</param>
        /// <param name="item2">The item2.</param>
        /// <returns>ItemComparison&lt;T1, T2&gt;.</returns>
        public static ItemComparison<T1, T2> Create(T1 item1, T2 item2)
        {
            return new ItemComparison<T1, T2>(item1, item2);
        }
    }
}
