﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.ShieldClause.Test
{
    [TestFixture]
    public class ShieldClauseObjectExtensionsTest
    {

        [TestCase(null, "param1")]
        public void Null_ThrowsException(object value, string parameter)
        {
            TestClass ts = null;
            Assert.Throws<ArgumentNullException>(() =>  Shield.Against.Null(value, parameter));
            Assert.Throws<ArgumentNullException>(() => Shield.Against.Null<TestClass>(ts, parameter));
        }

        [TestCase("hello", "param1")]
        public void Null_DoesnotThrowException(object value, string parameter)
        {
            Assert.DoesNotThrow(() => Shield.Against.Null(value, parameter));
        }
    }

    public class TestClass
    {

    }
}
