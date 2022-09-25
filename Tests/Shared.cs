using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Ichosys.DataModel.Tests
{
    class Shared
    {
        /// <summary>
        /// The <see cref="ILogger"/> instance for this project.
        /// </summary>
        internal static readonly ILogger Logger = LoggerFactory
            .Create(builder => builder.AddConsole().AddDebug())
            .CreateLogger<Shared>();

        public static void WriteAreEqualDebug(object expected, object actual)
        {
            Debug.WriteLine($"[Expected]< {expected} > | [Observed]< {actual} >");
        }
    }
}
