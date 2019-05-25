using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.HandleClause
{
    /// <summary>
    /// Attribute class to handle exceptions.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class HandleAttribute : Attribute
    {
        /// <summary>
        /// Creates new instance of <see cref="HandleAttribute"/> class
        /// </summary>
        /// <param name="exception">typeof exception</param>
        public HandleAttribute(Type exception)
        {
            if(exception != null)
            {
                Exceptions = new Type[] { exception };
            }
        }

        /// <summary>
        /// Creates new instance of <see cref="HandleAttribute"/> class
        /// </summary>
        /// <param name="exceptions">typeof exceptions</param>
        public HandleAttribute(Type[] exceptions)
        {
            Exceptions = exceptions;
        }

        /// <summary>
        /// Get exceptions
        /// </summary>
        public Type[] Exceptions { get; }
    }
}
