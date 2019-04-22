using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.ShieldClause
{
    public static class ShieldClauseStringExtensions
    {
        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the <see cref="input"/> is null.
        /// Throws <see cref="ArgumentException"/> if the  <see cref="input"/> is an empty string
        /// </summary>
        /// <param name="shieldClause">shieldClause</param>
        /// <param name="input">input</param>
        /// <param name="parameterName">parameter name</param>
        /// <param name="customExceptionMessage">custom message</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static void NullOrEmpty(this IShieldClause shieldClause, string input, string parameterName, string customExceptionMessage = null)
        {
            Shield.Against.Null(input, parameterName, customExceptionMessage);
            if (input == string.Empty)
            {
                throw new ArgumentException($"Required input {StringUtils.FormatParameter(parameterName)} was empty. {StringUtils.FormatMessage(customExceptionMessage)}");
            }
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the <see cref="input"/> is null.
        /// Throws <see cref="ArgumentException"/> if the  <see cref="input"/> is an empty string or white space string
        /// </summary>
        /// <param name="shieldClause">shieldClause</param>
        /// <param name="input">input</param>
        /// <param name="parameterName">parameter name</param>
        /// <param name="customExceptionMessage">custom message</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static void NullOrWhiteSpace(this IShieldClause shieldClause, string input, string parameterName, string customExceptionMessage = null)
        {
            Shield.Against.Null(input, parameterName, customExceptionMessage);
            if(String.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException($"Required input {StringUtils.FormatParameter(parameterName)} was empty. {StringUtils.FormatMessage(customExceptionMessage)}");
            }
        }
    }
}
