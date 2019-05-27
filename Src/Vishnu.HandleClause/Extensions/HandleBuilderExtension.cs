using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.HandleClause
{
    /// <summary>
    /// Extension methods for HandleBuilder
    /// </summary>
    public static class HandleBuilderExtension
    {
        /// <summary>
        /// Handles Synchronous calls
        /// </summary>
        /// <param name="handleBuilder"><see cref="HandleBuilder"/></param>
        /// <returns><see cref="SyncCall"/></returns>
        public static SyncCall UseSync(this HandleBuilder handleBuilder)
        {
            return new SyncCall(handleBuilder.ExceptionDelegateCollection);
        }
    }
}
