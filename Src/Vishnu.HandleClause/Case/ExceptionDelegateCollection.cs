using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Vishnu.HandleClause
{
    /// <summary>
    /// Class responsible for holding the list of <see cref="Exception"/> for a specific call.
    /// </summary>
    public class ExceptionDelegateCollection
    {
        /// <summary>
        /// Collection of <see cref="ExceptionDelegage"/>
        /// </summary>
        private List<ExceptionDelegate> _exceptionDelegages = null;

        /// <summary>
        /// Add specific <see cref="ExceptionDelegage"/> to collection
        /// </summary>
        /// <param name="exceptionDelegage"><see cref="ExceptionDelegage"/></param>
        internal void Add(ExceptionDelegate exceptionDelegage)
        {
            _exceptionDelegages = _exceptionDelegages ?? new List<ExceptionDelegate>();
            _exceptionDelegages.Add(exceptionDelegage);
        }

        /// <summary>
        /// Returns first or default exception from the colleciton of <see cref="ExceptionDelegage"/>
        /// </summary>
        /// <param name="ex">type of <see cref="Exception"/></param>
        /// <returns><see cref="Exception"/></returns>
        public Exception FirstOrDefault(Exception ex)
        {
            return _exceptionDelegages.Select(e => e(ex)).FirstOrDefault(e => e != null);
        }

        /// <summary>
        /// Empty delegate
        /// </summary>
        public static readonly ExceptionDelegateCollection None = new ExceptionDelegateCollection();
    }
}
