using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.ShieldClause
{
    internal class StringUtils
    {
        internal static string FormatParameter(string parameter)
        {
            return parameter == null ? string.Empty : parameter;
        }

        internal static string FormatMessage(string message)
        {
            return message == null ? "" : " " + message;
        }
    }
}
