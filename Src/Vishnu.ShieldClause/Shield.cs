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
        public static IShieldClause Against
        {
            get
            {
                return new Shield();
            }
        }

        /// <summary>
        /// Prevents creation of new instance of the  <see cref="Shield"/> class.
        /// </summary>
        private Shield()
        {
        }
    }
}
