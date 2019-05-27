using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Vishnu.HandleClause
{
    /// <summary>
    /// Class responsible for invoking the specific actions and handles the exceptions 
    /// declared in Handle attribute <see cref="HandleAttribute"/> and also exceptions in Inline or 
    /// using handle builder.
    /// </summary>
    public static partial class Handle
    {
        /// <summary>
        /// Handles specific exception <typeparamref name="TException"/>
        /// </summary>
        /// <typeparam name="TException">type of <see cref="Exception"/></typeparam>
        /// <returns><see cref="HandleBuilder"/></returns>
        public static HandleBuilder Case<TException>() where TException : Exception
        {
            return new HandleBuilder((exception) => exception is TException ? exception : null);
        }
    }
}