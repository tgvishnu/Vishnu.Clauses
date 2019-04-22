using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.ShieldClause.Test
{
    [TestFixture]
    public class ShieldClauseRangeExtensionsTest
    {
        [TestCase]
        public void OutOfRange_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => Shield.Against.OutOfRange(1, "param1", 10, 2));
            Assert.Throws<ArgumentException>(() => Shield.Against.OutOfRange(DateTime.Now, "param1", DateTime.Now.AddDays(2), DateTime.Now));
            Assert.Throws<ArgumentOutOfRangeException>(() => Shield.Against.OutOfRange(9, "param1", 10, 20));
            Assert.Throws<ArgumentOutOfRangeException>(() => Shield.Against.OutOfRange(29, "param1", 10, 20));
            Assert.Throws<ArgumentOutOfRangeException>(() => Shield.Against.OutOfRange(DateTime.Now, "param1", DateTime.Now.AddDays(2) , DateTime.Now.AddDays(4)));
            Assert.Throws<ArgumentOutOfRangeException>(() => Shield.Against.OutOfRange(DateTime.Now.AddDays(10), "param1", DateTime.Now.AddDays(2), DateTime.Now.AddDays(4)));
        }

        [TestCase]
        public void OutOfRange_DoesNotThrowsException()
        {
            Assert.DoesNotThrow(() => Shield.Against.OutOfRange(15, "param1", 10, 20));
            Assert.DoesNotThrow(() => Shield.Against.OutOfRange(DateTime.Now.AddDays(1), "param1", DateTime.Now, DateTime.Now.AddDays(4)));
        }
    }
}
