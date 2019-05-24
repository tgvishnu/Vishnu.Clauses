using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Vishnu.HandleClause
{
    internal class HandleExceptionHolder
    {
        public IList<ExceptionDelegage> Exceptions;

        internal HandleExceptionHolder(ExceptionDelegage exceptionDelegage)
        {
            this.Exceptions = new List<ExceptionDelegage>();
            this.Exceptions.Add(exceptionDelegage);
        }

        internal HandleExceptionHolder(IList<ExceptionDelegage> exceptionDelegages)
        {
            this.Exceptions = new List<ExceptionDelegage>();
            this.Exceptions = exceptionDelegages;
        }

        internal Exception FirstOrDefault(Exception ex)
        {
           return this.Exceptions.Select(e => e(ex)).FirstOrDefault(e => e != null);
        }
    }
}
