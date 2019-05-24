using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Vishnu.HandleClause;

namespace Vishnu.ShieldClause.Test
{
    [TestFixture]
    public class HandleInlineTest
    {

        [Test]
        public void HandleInline_SimpleAction()
        {
            Assert.DoesNotThrow(() => Handle.Inline<ArgumentNullException>(new Temp().MethodRaiseArgumentNullException));
            Assert.Throws<ArgumentNullException>(() => Handle.Inline<IndexOutOfRangeException>(new Temp().MethodRaiseArgumentNullException));
        }

        [Test]
        public void HandleInline_SimpleAction_RaiseAction()
        {
            Assert.DoesNotThrow(() => Handle.Inline<ArgumentNullException>(new Temp().MethodRaiseArgumentNullException, this.ExceptionHandled));
            Assert.Throws<ArgumentNullException>(() => Handle.Inline<IndexOutOfRangeException>(new Temp().MethodRaiseArgumentNullException, this.ExceptionHandled));
        }

        private void ExceptionHandled(Exception ex)
        {
            System.Diagnostics.Debug.Write(ex.ToString());
        }

    }
}
