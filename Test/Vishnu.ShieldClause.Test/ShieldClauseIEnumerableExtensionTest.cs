using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.ShieldClause.Test
{
    [TestFixture]
    public class ShieldClauseIEnumerableExtensionTest
    {
        [TestCase]
        public void NullOrEmpty_Enumerable_ThrowsException()
        {
            List<string> listCollection = null;
            Dictionary<string, string> keyValuePairs = null;
            Assert.Throws<ArgumentNullException>(() => Shield.Against.NullOrEmpty<string>(listCollection, "listCollection"));
            Assert.Throws<ArgumentNullException>(() => Shield.Against.NullOrEmpty<KeyValuePair<string, string>>(keyValuePairs, "keyValuePairs"));
            listCollection = new List<string>();
            keyValuePairs = new Dictionary<string, string>();
            Assert.Throws <ArgumentException>(() => Shield.Against.NullOrEmpty<string>(listCollection, "listCollection"));
            Assert.Throws<ArgumentException>(() => Shield.Against.NullOrEmpty<KeyValuePair<string, string>>(keyValuePairs, "keyValuePairs"));
        }

        [Test]
        public void NullOrEmpty_Enumerable_DoNotThrowException()
        {
            List<string> listCollection = new List<string>()
            {
                "Hello"
            };
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>()
            {
                {"key1", "value1" }
            };

            Assert.DoesNotThrow(() => Shield.Against.NullOrEmpty<string>(listCollection, "listCollection"));
            Assert.DoesNotThrow(() => Shield.Against.NullOrEmpty<KeyValuePair<string, string>>(keyValuePairs, "keyValuePairs"));
        }
    }
}
