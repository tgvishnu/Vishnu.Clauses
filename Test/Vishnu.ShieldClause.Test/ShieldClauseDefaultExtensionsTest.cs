using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.ShieldClause.Test
{
    [TestFixture]
    public class ShieldClauseDefaultExtensionsTest
    {
        [Test]
        public void Default_ThrowsException()
        {
            int intValue = default(int);
            long longValue = default(long);
            decimal decimalValue = default(decimal);
            Guid guidValue = default(Guid);
            Assert.Throws<ArgumentException>(() => Shield.Against.Zero(intValue, "param1"));
            Assert.Throws<ArgumentException>(() => Shield.Against.Zero(longValue, "param1"));
            Assert.Throws<ArgumentException>(() => Shield.Against.Zero(decimalValue, "param1"));
            Assert.Throws<ArgumentNullException>(() => Shield.Against.Default<Guid>(guidValue, "param1"));
        }

        [Test]
        public void Default_DoesNotThrowException()
        {
            Assert.DoesNotThrow(() => Shield.Against.Zero((int)1, "param1"));
            Assert.DoesNotThrow(() => Shield.Against.Zero((long)1, "param1"));
            Assert.DoesNotThrow(() => Shield.Against.Zero((decimal)1, "param1"));
            Assert.DoesNotThrow(() => Shield.Against.Default<Guid>(Guid.NewGuid(), "param1"));
        }
    }
}
