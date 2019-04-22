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
            Assert.Throws<ArgumentException>(() =>  Shield.Throw.ArgumentException(true, "param1"));
            Assert.Throws<ArgumentException>(() => Shield.Throw.ArgumentException((true || true), "param1"));
            Assert.Throws<ArgumentException>(() => Shield.Throw.ArgumentException<string>((input) => { return true; }, "",  "param1"));
            Assert.Throws<ArgumentNullException>(() => Shield.Throw.ArgumentNullException((value == string.Empty || value == null), "param1"));
            Assert.Throws<ArgumentNullException>(() => Shield.Throw.ArugmentNullException<string>((input) => { return input == null ? true : false; }, null, "param1"));
        }
    }
}
