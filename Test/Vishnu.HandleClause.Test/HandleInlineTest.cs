using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Vishnu.HandleClause;

namespace Vishnu.HandleClause.Test
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


        [Test]
        public void HandleInline_Action_one_input()
        {
            Assert.DoesNotThrow(() => Handle.Inline<ArgumentNullException, int>(new Temp().MyMethodHandlesException, 4));
            Assert.Throws<ArgumentNullException>(() => Handle.Inline<IndexOutOfRangeException, int>(new Temp().MyMethodHandlesException, 1));
        }

        [Test]
        public void HandleInline_Action_one_input_RaiseAction()
        {
            Assert.DoesNotThrow(() => Handle.Inline<ArgumentNullException, int>(new Temp().MyMethodHandlesException, 4, this.ExceptionHandled));
            Assert.Throws<ArgumentNullException>(() => Handle.Inline<IndexOutOfRangeException, int>(new Temp().MyMethodHandlesException, 1, this.ExceptionHandled));
        }

        [Test]
        public void HandleInline_Func_return_one()
        {
            Assert.DoesNotThrow(() => Handle.Inline<ArgumentNullException, int>(new Temp().MyFuncNoHandle));
            Assert.Throws<ArgumentNullException>(() => Handle.Inline<IndexOutOfRangeException, int>(new Temp().MyFuncNoHandle));
        }

        [Test]
        public void HandleInline_Func_return_one_RaiseAction()
        {
            Assert.DoesNotThrow(() => Handle.Inline<ArgumentNullException, int>(new Temp().MyFuncNoHandle, this.ExceptionHandled));
            Assert.Throws<ArgumentNullException>(() => Handle.Inline<IndexOutOfRangeException, int>(new Temp().MyFuncNoHandle, this.ExceptionHandled));
        }

        [Test]
        public void HandleInline_Func_inputone_return_one()
        {
            Assert.DoesNotThrow(() => Handle.Inline<ArgumentNullException, int, int>(new Temp().MyFunc, 1));
            Assert.Throws<ArgumentNullException>(() => Handle.Inline<IndexOutOfRangeException, int, int>(new Temp().MyFunc,1));
        }

        [Test]
        public void HandleInline_Func_inputone_return_one_RaiseAction()
        {
            Assert.DoesNotThrow(() => Handle.Inline<ArgumentNullException, int, int>(new Temp().MyFunc, 1,this.ExceptionHandled));
            Assert.Throws<ArgumentNullException>(() => Handle.Inline<IndexOutOfRangeException, int, int>(new Temp().MyFunc, 1, this.ExceptionHandled));
        }



        private void ExceptionHandled(Exception ex)
        {
            System.Diagnostics.Debug.Write(ex.ToString());
        }

    }
}
