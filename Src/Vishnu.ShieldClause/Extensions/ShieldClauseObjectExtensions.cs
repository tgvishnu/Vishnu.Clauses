using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.ShieldClause
{
    public static class ShieldClauseObjectExtensions
    {
        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the <see cref="input"/> is null;
        /// </summary>
        /// <param name="shieldClause">Shield clause</param>
        /// <param name="input">input</param>
        /// <param name="parameterName">name of the parameter</param>
        /// <param name="customExceptionMessage">custom message</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void Null(this IShieldClause shieldClause, object input, string parameterName, string customExceptionMessage = null)
        {
            if(input == null)
            {
                throw new ArgumentNullException(StringUtils.FormatParameter(parameterName) + StringUtils.FormatMessage(customExceptionMessage));
            }
        }
    }
}
