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
        /// <exception cref="ArgumentNullException"></exception>
        public static void Null(this IShieldClause shieldClause, object input, string parameterName)
        {
            if(input == null)
            {
                throw new ArgumentNullException(StringUtils.FormatParameter(parameterName));
            }
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the <see cref="input"/> is null;
        /// </summary>
        /// <param name="shieldClause">Shield clause</param>
        /// <param name="input">input</param>
        /// <param name="parameterName">name of the parameter</param>
        /// <param name="message">custom message</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void Null(this IShieldClause shieldClause, object input, string parameterName, string message = null)
        {
            if (input == null)
            {
                throw new ArgumentNullException(StringUtils.FormatParameter(parameterName), StringUtils.FormatMessage(message));
            }
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the <see cref="input"/> is null;
        /// Throws <see cref="ArgumentException"/> if the input is not of specified type.
        /// </summary>
        /// <param name="shieldClause">Shield clause</param>
        /// <param name="input">input</param>
        /// <param name="parameterName">name of the parameter</param>
        /// <param name="customExceptionMessage">custom message</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static void IsTypeOf<T>(this IShieldClause shieldClause, object input, string parameterName)
        {
            Shield.Against.Null(input, parameterName);
            if(!(input is T))
            {
                throw new ArgumentException($"{input.GetType().Name} is not an instance of type {typeof(T).Name}");
            }
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the <see cref="input"/> is null;
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="shieldClause">Shield clause</param>
        /// <param name="input">input</param>
        /// <param name="parameterName">name of the parameter</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void Null<T>(this IShieldClause shieldClause, T input, string parameterName) where T : class
        {
            if (input == default(T))
            {
                throw new ArgumentNullException(StringUtils.FormatParameter(parameterName));
            }
        }

        /// <summary>
        /// Throws <see cref="ArgumentNullException"/> if the <see cref="input"/> is null;
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="shieldClause">Shield clause</param>
        /// <param name="input">input</param>
        /// <param name="parameterName">name of the parameter</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <param name="message">custom message</param>
        public static void Null<T>(this IShieldClause shieldClause, T input, string parameterName, string message) where T : class
        {
            if (input == default(T))
            {
                throw new ArgumentNullException(StringUtils.FormatParameter(parameterName), StringUtils.FormatMessage(message));
            }
        }
    }
}
