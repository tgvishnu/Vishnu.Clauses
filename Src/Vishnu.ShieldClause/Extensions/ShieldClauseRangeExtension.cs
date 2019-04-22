using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.ShieldClause
{
    public static class ShieldClauseRangeExtension
    {
        /// <summary>
        /// Throws <see cref="ArgumentOutOfRangeException"/> when the value is less than limit
        /// </summary>
        /// <typeparam name="T">input type</typeparam>
        /// <param name="shieldClause">shield clause</param>
        /// <param name="input">input</param>
        /// <param name="limit">limit</param>
        /// <param name="parameterName">parameter range</param>
        public static void LesserThan<T>(this IShieldClause shieldClause, T input, T limit, string parameterName) where T : IComparable<T>
        {
            if (input.CompareTo(limit) >= 0)
            {
                throw new ArgumentOutOfRangeException(StringUtils.FormatParameter(parameterName));
            }
        }

        /// <summary>
        /// Throws <see cref="ArgumentOutOfRangeException"/> when the value is less than limit
        /// </summary>
        /// <typeparam name="T">input type</typeparam>
        /// <param name="shieldClause">shield clause</param>
        /// <param name="input">input</param>
        /// <param name="limit">limit</param>
        /// <param name="parameterName">parameter range</param>
        /// <param name="message">custom message</param>
        public static void LesserThan<T>(this IShieldClause shieldClause, T input, T limit, string parameterName, string message) where T : IComparable<T>
        {
            if (input.CompareTo(limit) >= 0)
            {
                throw new ArgumentOutOfRangeException(StringUtils.FormatParameter(parameterName), StringUtils.FormatMessage(message));
            }
        }

        /// <summary>
        /// Throws <see cref="ArgumentOutOfRangeException"/> when the value is greater than limit
        /// </summary>
        /// <typeparam name="T">input type</typeparam>
        /// <param name="shieldClause">shield clause</param>
        /// <param name="input">input</param>
        /// <param name="limit">limit</param>
        /// <param name="parameterName">parameter range</param>
        public static void GreaterThan<T>(this IShieldClause shieldClause, T input, T limit, string parameterName) where T : IComparable<T>
        {
            if(input.CompareTo(limit) <= 0)
            {
                throw new ArgumentOutOfRangeException(StringUtils.FormatParameter(parameterName));
            }
        }

        /// <summary>
        /// Throws <see cref="ArgumentOutOfRangeException"/> when the value is greater than limit
        /// </summary>
        /// <typeparam name="T">input type</typeparam>
        /// <param name="shieldClause">shield clause</param>
        /// <param name="input">input</param>
        /// <param name="limit">limit</param>
        /// <param name="parameterName">parameter range</param>
        /// <param name="message">custom message</param>
        public static void GreaterThan<T>(this IShieldClause shieldClause, T input, T limit, string parameterName, string message) where T : IComparable<T>
        {
            if (input.CompareTo(limit) <= 0)
            {
                throw new ArgumentOutOfRangeException(StringUtils.FormatParameter(parameterName), StringUtils.FormatMessage(message));
            }
        }

        /// <summary>
        /// Throws <see cref="ArgumentException"/> if <see cref="from"/> is greater than <see cref="to"/>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if <see cref="input"/> value is not with in the specified range
        /// </summary>
        /// <param name="shieldClause">shield clause</param>
        /// <param name="input">input</param>
        /// <param name="parameterName">parameter name</param>
        /// <param name="from">range from</param>
        /// <param name="to">range to</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void OutOfRange(this IShieldClause shieldClause, int input, string parameterName, int from, int to)
        {
            OutOfRange<int>(shieldClause, input, parameterName, from, to);
        }

        /// <summary>
        /// Throws <see cref="ArgumentException"/> if <see cref="from"/> is greater than <see cref="to"/>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if <see cref="input"/> datetime is not with in the specified range
        /// </summary>
        /// <param name="shieldClause">shield clause</param>
        /// <param name="input">input</param>
        /// <param name="parameterName">parameter name</param>
        /// <param name="from">range from</param>
        /// <param name="to">range to</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void OutOfRange(this IShieldClause shieldClause, DateTime input, string parameterName, DateTime from, DateTime to)
        {
            OutOfRange<DateTime>(shieldClause, input, parameterName, from, to);
        }

        /// <summary>
        /// Throws <see cref="ArgumentException"/> if <see cref="from"/> is greater than <see cref="to"/>
        /// Throws <see cref="ArgumentOutOfRangeException"/> if <see cref="input"/> is not with in the specified range
        /// </summary>
        /// <typeparam name="T">type of param</typeparam>
        /// <param name="shieldClause">shield clause</param>
        /// <param name="input">input</param>
        /// <param name="parameterName">parameter name</param>
        /// <param name="from">range from</param>
        /// <param name="to">range to</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private static void OutOfRange<T>(this IShieldClause shieldClause, T input, string parameterName, T from, T to)
        {
            Comparer<T> comparer = Comparer<T>.Default;
            if (comparer.Compare(from, to) > 0)
            {
                throw new ArgumentException($"{nameof(from)} should be less or equal to  {nameof(to)}");
            }

            if (comparer.Compare(input, from) < 0 || comparer.Compare(input, to) > 0)
            {
                throw new ArgumentOutOfRangeException($"Input {StringUtils.FormatParameter(parameterName)} was out of range.");
            }
        }
    }
}
