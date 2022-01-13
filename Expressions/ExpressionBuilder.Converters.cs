using System;
using System.Globalization;

namespace Ichosoft.Expressions
{
    #region Type-string converters
    public partial class ExpressionBuilder
    {
        /// <summary>
        /// Parses the given string into a <see cref="DateTime?"/> value, using culture-specific
        /// date formats./>.
        /// </summary>
        /// <param name="s"></param>
        /// <returns>A <see cref="DateTime"/> value if parsed successfully, else null.</returns>
        private static DateTime? TryParseDateTime(string s)
        {
            // Specify the list of culture and misc. supported formats.
            var dateFormats =
                new string[]
                {
                    CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern,
                    "MM/dd/yyyy",
                    "MMddyyyy",
                    "yyyyMMdd"
                };

            // Check each format and break the loop when the first result is found.
            foreach (var format in dateFormats)
            {
                if (DateTime.TryParseExact(
                    s: s,
                    format: format,
                    provider: CultureInfo.CurrentUICulture,
                    style: DateTimeStyles.None,
                    out DateTime result))

                    return result;
            }

            return null;
        }
    }
    #endregion
}
