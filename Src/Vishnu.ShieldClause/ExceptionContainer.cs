using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.ShieldClause
{
    public class ExceptionContainer
    {
        /// <summary>
        /// Raise <see cref="ArgumentNullException"/> null exception when condition fails
        /// </summary>
        /// <typeparam name="T">param type</typeparam>
        /// <param name="when">predicate function</param>
        /// <param name="input">input</param>
        /// <param name="parameterName">parameter name</param>
        /// <param name="message">custom message</param>
        public void ArugmentNullException<T>(Func<T, bool> when, T input, string parameterName, string message = null)
        {
            if(when(input))
            {
                throw new ArgumentNullException(StringUtils.FormatParameter(parameterName), StringUtils.FormatMessage(message));
            }
        }

        /// <summary>
        /// Raise <see cref="ArgumentNullException"/> null exception when condition fails
        /// </summary>
        /// <typeparam name="T">param type</typeparam>
        /// <param name="when">predicate function</param>
        /// <param name="input">input</param>
        /// <param name="parameterName">parameter name</param>
        /// <param name="message">custom message</param>
        public void ArgumentNullException(bool when, string parameterName, string message = null)
        {
            if (when)
            {
                throw new ArgumentNullException(StringUtils.FormatParameter(parameterName), StringUtils.FormatMessage(message));
            }
        }

        /// <summary>
        /// Raise <see cref="ArgumentException"/> null exception when condition fails
        /// </summary>
        /// <typeparam name="T">param type</typeparam>
        /// <param name="when">predicate function</param>
        /// <param name="input">input</param>
        /// <param name="parameterName">parameter name</param>
        /// <param name="message">custom message</param>
        public void ArgumentException<T>(Func<T, bool> when, T input, string parameterName, string message = null)
        {
            if(when(input))
            {
                throw new ArgumentException(StringUtils.FormatParameter(parameterName), StringUtils.FormatMessage(message));
            }
        }

        /// <summary>
        /// Raise <see cref="ArgumentException"/> null exception when condition fails
        /// </summary>
        /// <typeparam name="T">param type</typeparam>
        /// <param name="when">predicate function</param>
        /// <param name="input">input</param>
        /// <param name="parameterName">parameter name</param>
        /// <param name="message">custom message</param>
        public void ArgumentException(bool when, string parameterName, string message = null)
        {
            if (when)
            {
                throw new ArgumentException(StringUtils.FormatParameter(parameterName), StringUtils.FormatMessage(message));
            }
        }

        /// <summary>
        /// Raise <see cref="ArgumentOutOfRangeException"/> null exception when condition fails
        /// </summary>
        /// <typeparam name="T">param type</typeparam>
        /// <param name="when">predicate function</param>
        /// <param name="input">input</param>
        /// <param name="parameterName">parameter name</param>
        /// <param name="message">custom message</param>
        public void ArgumentOutOfRangeException<T>(Func<T, bool> when, T input, string parameterName, string message = null)
        {
            if(when(input))
            {
                throw new ArgumentOutOfRangeException(StringUtils.FormatParameter(parameterName), StringUtils.FormatMessage(message));
            }
        }

        /// <summary>
        /// Raise <see cref="ArgumentOutOfRangeException"/> null exception when condition fails
        /// </summary>
        /// <typeparam name="T">param type</typeparam>
        /// <param name="when">predicate function</param>
        /// <param name="input">input</param>
        /// <param name="parameterName">parameter name</param>
        /// <param name="message">custom message</param>
        public void ArgumentOutOfRangeException(bool when, string parameterName, string message = null)
        {
            if (when)
            {
                throw new ArgumentOutOfRangeException(StringUtils.FormatParameter(parameterName), StringUtils.FormatMessage(message));
            }
        }

        /// <summary>
        /// Raise <see cref="NotSupportedException"/> null exception when condition fails
        /// </summary>
        /// <typeparam name="T">param type</typeparam>
        /// <param name="when">predicate function</param>
        /// <param name="input">input</param>
        /// <param name="parameterName">parameter name</param>
        /// <param name="message">custom message</param>
        public void NotSupportedException(bool when, string message = null)
        {
            if (when)
            {
                throw new NotSupportedException(StringUtils.FormatMessage(message));
            }
        }

        /// <summary>
        /// Raise <see cref="TimeoutException"/> null exception when condition fails
        /// </summary>
        /// <typeparam name="T">param type</typeparam>
        /// <param name="when">predicate function</param>
        /// <param name="input">input</param>
        /// <param name="parameterName">parameter name</param>
        /// <param name="message">custom message</param>
        public void TimeoutException(bool when, string message = null)
        {
            if (when)
            {
                throw new TimeoutException(StringUtils.FormatMessage(message));
            }
        }
    }
}
