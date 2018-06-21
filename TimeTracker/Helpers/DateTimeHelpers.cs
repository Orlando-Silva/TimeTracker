#region --Using--
using System;
#endregion

namespace Helpers
{
    public class DateTimeHelpers
    {

        public static bool IsDataMaiorQueAtual(DateTime data) => data > DateTime.UtcNow;

    }
}
