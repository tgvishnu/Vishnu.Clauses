using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.ShieldClause
{
    public static class ShieldClauseDefaultExtension
    {
        /// <summary>
        /// Throws <see cref="ArgumentException"/> if the input is equals to Zero
        /// </summary>
        /// <param name="shieldClause">shield clause</param>
        /// <param name="input">input</param>
        /// <param name="parameterName">parameter name</param>
        /// <exception cref="ArgumentException"></exception>
        public static void Zero(this IShieldClause shieldClause, int input, string parameterName)
        {
            Zero<int>(shieldClause, input, parameterName);
        }

        /// <summary>
        /// Throws <see cref="ArgumentException"/> if the input is equals to Zero
        /// </summary>
        /// <param name="shieldClause">shield clause</param>
        /// <param name="input">input</param>
        /// <param name="parameterName">parameter name</param>
        /// <exception cref="ArgumentException"></exception>
        public static void Zero(this IShieldClause shieldClause, long input, string parameterName)
        {
            Zero<long>(shieldClause, input, parameterName);
        }

        /// <summary>
        /// Throws <see cref="ArgumentException"/> if the input is equals to Zero
        /// </summary>
        /// <param name="shieldClause">shield clause</param>
        /// <param name="input">input</param>
        /// <param name="parameterName">parameter name</param>
        /// <exception cref="ArgumentException"></exception>
        public static void Zero(this IShieldClause shieldClause, decimal input, string parameterName)
        {
            Zero<decimal>(shieldClause, input, parameterName);
        }

        /// <summary>
        /// Throws <see cref="ArgumentException"/> if the input is equals to default value
        /// </summary>
        /// <typeparam name="T">type of input</typeparam>
        /// <param name="shieldClause">shield clause</param>
        /// <param name="input">input</param>
        /// <param name="parameterName">parameter name</param>
        /// <exception cref="ArgumentException"></exception>
        public static void Default<T>(this IShieldClause shieldClause, T input, string parameterName)
        {
            if(EqualityComparer<T>.Default.Equals(input, default(T)))
            {
                throw new ArgumentException($"Parameter {parameterName} is default value for type {typeof(T).Name}");
            }
        }

        /// <summary>
        /// Throws <see cref="ArgumentException"/> if the input is equals to default value
        /// </summary>
        /// <typeparam name="T">type of input</typeparam>
        /// <param name="shieldClause">shield clause</param>
        /// <param name="input">input</param>
        /// <param name="parameterName">parameter name</param>
        /// <exception cref="ArgumentException"></exception>
        private static void Zero<T>(this IShieldClause shieldClause, T input, string parameterName)
        {
            if (EqualityComparer<T>.Default.Equals(input, default(T)))
            {
                throw new ArgumentException($"Required input {StringUtils.FormatParameter(parameterName)} cannot be zero");
            }
        }
    }
}
