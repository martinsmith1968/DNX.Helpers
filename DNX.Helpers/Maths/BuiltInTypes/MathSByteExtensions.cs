using System;

namespace DNX.Helpers.Maths.BuiltInTypes
{
    /// <summary>
    /// Class MathSByteExtensions.
    /// </summary>
    public static class MathSByteExtensions
    {
        /// <summary>
        /// Determines whether the specified value is inclusively between min and max.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns><c>true</c> if the specified minimum is between min and max; otherwise, <c>false</c>.</returns>
        public static bool IsBetween(this sbyte value, sbyte min, sbyte max)
        {
            return value.IsBetween(min, max, true);
        }

        /// <summary>
        /// Determines whether the specified value is inclusively between the smaller of min and max and the larger of min and max.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns><c>true</c> if the specified minimum is between min and max; otherwise, <c>false</c>.</returns>
        public static bool IsBetweenEither(this sbyte value, sbyte min, sbyte max)
        {
            return value.IsBetweenEither(min, max, true);
        }

        /// <summary>
        /// Determines whether the specified value is between the smaller of min and max and the larger of min and max, optionally inclusively.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
		/// <param name="inclusive">if set to <c>true</c> min and max are inclusive.</param>
        /// <returns><c>true</c> if the specified minimum is between min and max; otherwise, <c>false</c>.</returns>
        public static bool IsBetweenEither(this sbyte value, sbyte min, sbyte max, bool inclusive)
        {
            return value.IsBetween(min < max ? min : max, max > min ? max : min, inclusive);
        }

        /// <summary>
        /// Determines whether the specified value is between min and max, optionally inclusively.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
		/// <param name="inclusive">if set to <c>true</c> min and max are inclusive.</param>
        /// <returns><c>true</c> if the specified minimum is between min and max; otherwise, <c>false</c>.</returns>
        public static bool IsBetween(this sbyte value, sbyte min, sbyte max, bool inclusive)
        {
            return inclusive
                ? (value >= min) && (value <= max)
                : (value > min) && (value < max);
        }
    }
}
