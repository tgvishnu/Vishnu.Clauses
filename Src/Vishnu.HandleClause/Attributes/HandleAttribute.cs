using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.HandleClause
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class HandleAttribute : Attribute
    {
        public HandleAttribute(Type exception)
        {
            if(exception != null)
            {
                Exceptions = new Type[] { exception };
            }
        }

        public HandleAttribute(Type[] exceptions)
        {
            Exceptions = exceptions;
        }

        public Type[] Exceptions { get; }
    }
}
