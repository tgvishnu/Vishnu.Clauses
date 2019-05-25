using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Vishnu.HandleClause
{
    /// <summary>
    /// Exception delegate holder
    /// </summary>
    internal class HandleExceptionHolder
    {
        /// <summary>
        /// Gets list of <see cref="ExceptionDelegate"/>
        /// </summary>
        public IList<ExceptionDelegate> Exceptions { get; }

        /// <summary>
        /// Creates new instance of <see cref="HandleExceptionHolder"/> class.
        /// </summary>
        /// <param name="exceptionDelegate"><see cref="ExceptionDelegate"/></param>
        internal HandleExceptionHolder(ExceptionDelegate exceptionDelegate)
        {
            this.Exceptions = new List<ExceptionDelegate>();
            this.Exceptions.Add(exceptionDelegate);
        }

        /// <summary>
        /// Creates new instance of <see cref="HandleExceptionHolder"/> class.
        /// </summary>
        /// <param name="exceptionDelegates">Collection of <see cref="ExceptionDelegate"/></param>
        internal HandleExceptionHolder(IList<ExceptionDelegate> exceptionDelegates)
        {
            this.Exceptions = new List<ExceptionDelegate>();
            this.Exceptions = exceptionDelegates;
        }

        /// <summary>
        /// Gets first or default exception.
        /// </summary>
        /// <param name="ex">typeof <see cref="Exception"/></param>
        /// <returns><see cref="Exception"/> or null</returns>
        internal Exception FirstOrDefault(Exception ex)
        {
           return this.Exceptions.Select(e => e(ex)).FirstOrDefault(e => e != null);
        }
    }
}
