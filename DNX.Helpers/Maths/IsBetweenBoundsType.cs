namespace DNX.Helpers.Maths
{
    /// <summary>
    /// Enum IsBetweenBoundsType
    /// </summary>
    public enum IsBetweenBoundsType
    {
        /// <summary>
        /// Include Lower and Upper bounds when determining IsBetween
        /// </summary>
        IncludeLowerAndUpper = 1,
        /// <summary>
        /// Include Lower and Upper bounds when determining IsBetween
        /// </summary>
        Inclusive = IncludeLowerAndUpper,

        /// <summary>
        /// Exclude Lower and Upper bounds when determining IsBetween
        /// </summary>
        ExcludeLowerAndUpper = 2,
        /// <summary>
        /// Exclude Lower and Upper bounds when determining IsBetween
        /// </summary>
        Exclusive = ExcludeLowerAndUpper,

        /// <summary>
        /// Include Lower but Exclude Upper bounds when determining IsBetween
        /// </summary>
        IncludeLowerExcludeUpper = 3,
        /// <summary>
        /// Include Lower but Exclude Upper bounds when determining IsBetween
        /// </summary>
        GreaterThanOrEqualToLowerLessThanUpper = IncludeLowerExcludeUpper,

        /// <summary>
        /// Exclude Lower but Include Upper bounds when determining IsBetween
        /// </summary>
        ExcludeLowerIncludeUpper = 4,
        /// <summary>
        /// Exclude Lower but Include Upper bounds when determining IsBetween
        /// </summary>
        GreaterThanLowerLessThanOrEqualToUpper = ExcludeLowerIncludeUpper
    }

    /// <summary>
    /// Class IsBetweenTypeExtensions.
    /// </summary>
    public static class IsBetweenTypeExtensions
    {
        /// <summary>
        /// Gets the limit description format.
        /// </summary>
        /// <param name="boundsType">Type of the bounds.</param>
        /// <returns>System.String.</returns>
        public static string GetLimitDescriptionFormat(this IsBetweenBoundsType boundsType)
        {
            switch (boundsType)
            {
                case IsBetweenBoundsType.IncludeLowerAndUpper:
                    return "between {0} and {1}";

                case IsBetweenBoundsType.ExcludeLowerAndUpper:
                    return "between but not including {0} and {1}";

                case IsBetweenBoundsType.IncludeLowerExcludeUpper:
                    return "greater than or equal to {0} but less than {1}";

                case IsBetweenBoundsType.ExcludeLowerIncludeUpper:
                    return "greater than {0} but less than or equal to {1}";

                default:
                    return null;
            }
        }
    }
}
