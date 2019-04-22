using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.ShieldClause.Test
{
    [TestFixture]
    public class ExceptionContainerTest
    {
        [Test]
        public void ThrowException()
        {
            string value = "";
            Assert.Throws<ArgumentException>(() =>  Shield.Throws.ArgumentException(true, "param1"));
            Assert.Throws<ArgumentException>(() => Shield.Throws.ArgumentException((true || true), "param1"));
            Assert.Throws<ArgumentException>(() => Shield.Throws.ArgumentException<string>((input) => { return true; }, "",  "param1"));
            Assert.Throws<ArgumentNullException>(() => Shield.Throws.ArgumentNullException((value == string.Empty || value == null), "param1"));
            Assert.Throws<ArgumentNullException>(() => Shield.Throws.ArugmentNullException<string>((input) => { return input == null ? true : false; }, null, "param1"));
            Assert.Throws<TimeoutException>(() => Shield.Throws.TimeoutException(true, "exception occured"));
            Assert.Throws<NotSupportedException>(() => Shield.Throws.NotSupportedException(true, "not supported"));
        }
    }
}
