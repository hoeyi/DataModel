using System.Diagnostics;

namespace Ichosys.DataModel.UnitTest
{
    class Shared
    {
        public static void WriteAreEqualDebug(object expected, object actual)
        {
            Debug.WriteLine($"[Expected]< {expected} > | [Observed]< {actual} >");
        }
    }
}
