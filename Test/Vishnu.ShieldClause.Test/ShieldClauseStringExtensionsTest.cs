using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit;

namespace Vishnu.ShieldClause.Test
{
    [TestFixture]
    public class ShieldClauseStringExtensionsTest
    {
        [Test]
        public static void NullOrEmpty_ThrowsExcpetion()
        {
            Assert.Throws<ArgumentNullException>(() => Shield.Against.NullOrEmpty(null, "param1"));
            Assert.Throws<ArgumentException>(() => Shield.Against.NullOrEmpty(string.Empty, "param1"));
        }

        [Test]
        public static void NullOrEmpty_DonotThrowException()
        {
            Assert.DoesNotThrow(() => Shield.Against.NullOrEmpty("test", "param1"));
        }

        [Test]
        public static void NullOrWhiteSpace_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => Shield.Against.NullOrWhiteSpace(null, "param1"));
            Assert.Throws<ArgumentException>(() => Shield.Against.NullOrWhiteSpace(string.Empty, "param1"));
            Assert.Throws<ArgumentException>(() => Shield.Against.NullOrWhiteSpace(" ", "param1"));
            Assert.Throws<ArgumentException>(() => Shield.Against.NullOrWhiteSpace("    ", "param1"));
        }

        [Test]
        public static void NullOrWhiteSpac_DonotThrowException()
        {
            Assert.DoesNotThrow(() => Shield.Against.NullOrWhiteSpace("test", "param1"));
        }
    }
}
