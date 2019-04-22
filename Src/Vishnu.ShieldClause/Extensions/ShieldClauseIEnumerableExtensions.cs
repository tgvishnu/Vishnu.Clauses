using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Vishnu.ShieldClause
{
    public static class ShieldClauseIEnumerableExtensions
    {
        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the <see cref="input"/> is null.
        /// Throws <see cref="ArgumentException"/> if the  <see cref="input"/> is IEnumerable<T> is empty
        /// </summary>
        /// <param name="shieldClause">shieldClause</param>
        /// <param name="input">input</param>
        /// <param name="parameterName">parameter name</param>
        /// <param name="customExceptionMessage">custom message</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static void NullOrEmpty<T>(this IShieldClause shieldClause, IEnumerable<T> input, string parameterName, string customExceptionMessage = null)
        {
            Shield.Against.Null(input, parameterName, customExceptionMessage);
            if(!input.Any())
            {
                throw new ArgumentException($"Required input {StringUtils.FormatParameter(parameterName)} was empty. {StringUtils.FormatMessage(customExceptionMessage)}");
            }
        }
    }
}
