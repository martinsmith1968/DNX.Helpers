using System;
using System.Collections.Generic;
using System.Linq;
using DNX.Helpers.Maths;
using DNX.Helpers.Validation.BuiltInTypes;

namespace DNX.Helpers.Assemblies
{
    /// <summary>
    /// Class VersionExtensions.
    /// </summary>
    public static class VersionExtensions
    {
        /// <summary>
        /// Simplifies the Version to the specified minimum positions
        /// </summary>
        /// <param name="version">The version.</param>
        /// <param name="minimumPositions">The minimum positions.</param>
        /// <returns>System.String.</returns>
        public static string Simplify(this Version version, int minimumPositions = 1)
        {
            Guard.IsBetween(() => minimumPositions, 1, 4, IsBetweenBoundsType.IncludeLowerAndUpper);

            if (version == null)
            {
                return null;
            }

            var parts = new List<string>( version.ToString().Split('.'));

            while (parts.Any() && parts.Last().Equals("0") && parts.Count > minimumPositions)
            {
                parts = parts.Take(parts.Count - 1).ToList();
            }

            var versionText = string.Join(".", parts);

            return versionText;
        }
    }
}
