using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.ShieldClause
{
    public class Shield : IShieldClause
    {
        /// <summary>
        /// Gets new instance of the Shield Clause
        /// </summary>
        public static IShieldClause Against { get => new Shield(); }

        /// <summary>
        /// Gets new instance of <see cref="ExceptionContainer"/>
        /// </summary>
        public static ExceptionContainer Throws { get => new ExceptionContainer(); }

        /// <summary>
        /// Prevents creation of new instance of the  <see cref="Shield"/> class.
        /// </summary>
        private Shield()
        {
        }
    }
}
