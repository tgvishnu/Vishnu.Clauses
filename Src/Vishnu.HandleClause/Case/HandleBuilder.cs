using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.HandleClause
{
    /// <summary>
    /// Class responsible for chaining the exceptions that need to be handled.
    /// </summary>
    public class HandleBuilder
    {
        /// <summary>
        /// <see cref="ExceptionDelegateCollection"/>
        /// </summary>
        internal ExceptionDelegateCollection ExceptionDelegateCollection { get; }

        /// <summary>
        /// Creates new instance of the <see cref="HandleBuilder"/> class.
        /// </summary>
        /// <param name="exceptionDelegate"><see cref="ExceptionDelegate"/></param>
        public HandleBuilder(ExceptionDelegate exceptionDelegate)
        {
            this.ExceptionDelegateCollection = new ExceptionDelegateCollection();
            this.ExceptionDelegateCollection.Add(exceptionDelegate);
        }

        /// <summary>
        /// Append the exceptions
        /// </summary>
        /// <typeparam name="TException"><see cref="Exception"/></typeparam>
        /// <returns><see cref="HandleBuilder"/></returns>
        public HandleBuilder Or<TException>() where TException : Exception
        {
            this.ExceptionDelegateCollection.Add((exception) => exception is TException ? exception : null);
            return this;
        }
    }
}
