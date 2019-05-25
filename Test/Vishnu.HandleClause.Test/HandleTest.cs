using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Vishnu.HandleClause;

namespace Vishnu.HandleClause.Test
{
    [TestFixture]
    public class HandleTest
    {
        [Test]
        public void Handle_Simple_Action()
        {
            Temp t = new Temp();
            Assert.DoesNotThrow(() =>  Handle.Method(t.MyMethod));
            Assert.Throws<IndexOutOfRangeException>(() => Handle.Method(t.MyMethodNotHandleException));
            Assert.DoesNotThrow(() => Handle.Method(t.MyMethodHandlesMultipleExceptions));
            Assert.DoesNotThrow(() => Handle.Method(t.MyMethodDoesnotThrowAnyException));
        }

        [Test]
        public void Handle_Simple_Action_withCallback()
        {
            Temp t = new Temp();
            Assert.DoesNotThrow(() => Handle.Method(t.MyMethod, this.ExceptionHandleCallback));
            Assert.Throws<IndexOutOfRangeException>(() => Handle.Method(t.MyMethodNotHandleException,this.ExceptionHandleCallback));
            Assert.DoesNotThrow(() => Handle.Method(t.MyMethodHandlesMultipleExceptions, this.ExceptionHandleCallback));
            Assert.DoesNotThrow(() => Handle.Method(t.MyMethodDoesnotThrowAnyException, this.ExceptionHandleCallback));
        }

        [Test]
        public void Handle_Derived_Simple_Action()
        {
            Derived d = new Derived();
            Assert.DoesNotThrow(() => Handle.Method(d.MyMethodHandlesMultipleExceptions));
        }

        [Test]
        public void Handle_Derived_Simple_Action_WithCallback()
        {
            Derived d = new Derived();
            Assert.DoesNotThrow(() => Handle.Method(d.MyMethodHandlesMultipleExceptions, this.ExceptionHandleCallback));
        }

        [Test]
        public void Handle_Action_WithOneParam()
        {
            Temp t = new Temp();
            Assert.Throws<ArgumentNullException>(() => Handle.Method<int>(t.MyMethodWithoutHanldes, 1));
            Assert.DoesNotThrow(() => Handle.Method<int>(t.MyMethodHandlesException, 1));
            Assert.DoesNotThrow(() => Handle.Method<int>(t.MyMethodHandlesException, 2));
            Assert.Throws<TimeoutException>(() => Handle.Method<int>(t.MyMethodHandlesException, 3));
            Assert.DoesNotThrow(() => Handle.Method<int>(t.MyMethodHandlesException, 4));
        }

        [Test]
        public void Handle_Action_WithOneParam_withCallback()
        {
            Temp t = new Temp();
            Assert.Throws<ArgumentNullException>(() => Handle.Method<int>(t.MyMethodWithoutHanldes, 1, this.ExceptionHandleCallback));
            Assert.DoesNotThrow(() => Handle.Method<int>(t.MyMethodHandlesException, 1, this.ExceptionHandleCallback));
            Assert.DoesNotThrow(() => Handle.Method<int>(t.MyMethodHandlesException, 2, this.ExceptionHandleCallback));
            Assert.Throws<TimeoutException>(() => Handle.Method<int>(t.MyMethodHandlesException, 3, this.ExceptionHandleCallback));
            Assert.DoesNotThrow(() => Handle.Method<int>(t.MyMethodHandlesException, 4, this.ExceptionHandleCallback));
        }

        [Test]
        public void Handle_Derived_Action_WithOneParam()
        {
            Derived d = new Derived();
            Assert.DoesNotThrow(() => Handle.Method<int>(d.MyMethodHandlesException, 3));
        }

        [Test]
        public void Handle_Derived_Action_WithOneParam_withcallback()
        {
            Derived d = new Derived();
            Assert.DoesNotThrow(() => Handle.Method<int>(d.MyMethodHandlesException, 3,this.ExceptionHandleCallback));
        }

        [Test]
        public void Handle_Func_no_param_only_return()
        {
            Temp t = new Temp();
            Assert.DoesNotThrow(() => Handle.Method<int>(t.MyFunc));
            Assert.Throws<ArgumentNullException>(() => Handle.Method<int>(t.MyFuncNoHandle));
            Assert.DoesNotThrow(() => Handle.Method<int>(t.MyFuncWithHandle));
        }

        [Test]
        public void Handle_Func_no_param_only_return_with_callback()
        {
            Temp t = new Temp();
            Assert.DoesNotThrow(() => Handle.Method<int>(t.MyFunc, this.ExceptionHandleCallback));
            Assert.Throws<ArgumentNullException>(() => Handle.Method<int>(t.MyFuncNoHandle, this.ExceptionHandleCallback));
            Assert.DoesNotThrow(() => Handle.Method<int>(t.MyFuncWithHandle, this.ExceptionHandleCallback));
        }

        [Test]
        public void Handle_Func_one_param_only_return()
        {
            Temp t = new Temp();
            Assert.DoesNotThrow(() => Handle.Method<int,int>(t.MyFunc, 3));
            Assert.Throws<ArgumentException>(() => Handle.Method<int, int>(t.MyFunc, 2));
            Assert.DoesNotThrow(() => Handle.Method<int, int>(t.MyFuncCanHandle, 1));
        }

        [Test]
        public void Handle_Func_one_param_only_return_with_callback()
        {
            Temp t = new Temp();
            Assert.DoesNotThrow(() => Handle.Method<int, int>(t.MyFunc, 3, this.ExceptionHandleCallback));
            Assert.Throws<ArgumentException>(() => Handle.Method<int, int>(t.MyFunc, 2, this.ExceptionHandleCallback));
            Assert.DoesNotThrow(() => Handle.Method<int, int>(t.MyFuncCanHandle, 1, this.ExceptionHandleCallback));
        }

        [Test]
        public void Handle_Func_two_param_only_return()
        {
            Temp t = new Temp();
            Assert.DoesNotThrow(() => Handle.Method<int, int, int>(t.MyFunc, 3, 1));
            Assert.Throws<ArgumentException>(() => Handle.Method<int, int, int>(t.MyFunc, 2, 1));
            Assert.DoesNotThrow(() => Handle.Method<int, int, int>(t.MyFuncCanHandle, 1, 1));
        }

        [Test]
        public void Handle_Func_two_param_only_return_with_callback()
        {
            Temp t = new Temp();
            Assert.DoesNotThrow(() => Handle.Method<int, int, int>(t.MyFunc, 3, 1,this.ExceptionHandleCallback));
            Assert.Throws<ArgumentException>(() => Handle.Method<int, int, int>(t.MyFunc, 2, 1, this.ExceptionHandleCallback));
            Assert.DoesNotThrow(() => Handle.Method<int, int, int>(t.MyFuncCanHandle, 1, 1,this.ExceptionHandleCallback));
        }

        [Test]
        public void Handle_Func_three_param_only_return()
        {
            Temp t = new Temp();
            Assert.DoesNotThrow(() => Handle.Method<int, int, int, int>(t.MyFunc, 3, 1,1));
            Assert.Throws<ArgumentException>(() => Handle.Method<int, int,int, int>(t.MyFunc, 2,1, 1));
            Assert.DoesNotThrow(() => Handle.Method<int, int,int, int>(t.MyFuncCanHandle, 1,1, 1));
        }

        [Test]
        public void Handle_Func_three_param_only_return_with_callback()
        {
            Temp t = new Temp();
            Assert.DoesNotThrow(() => Handle.Method<int, int,int, int>(t.MyFunc, 3, 1, 1,this.ExceptionHandleCallback));
            Assert.Throws<ArgumentException>(() => Handle.Method<int, int, int, int>(t.MyFunc, 2,1, 1, this.ExceptionHandleCallback));
            Assert.DoesNotThrow(() => Handle.Method<int, int, int, int>(t.MyFuncCanHandle, 1, 1,1, this.ExceptionHandleCallback));
        }

        private void ExceptionHandleCallback(Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.ToString());
        }
    }

    public class TempBase
    {
        protected void RaiseArgumentNullException()
        {
            throw new ArgumentNullException();
        }


        protected void IndexOutRaise()
        {
            throw new IndexOutOfRangeException();
        }
        protected void RaiseArgumentException()
        {
            throw new ArgumentException();
        }
        public virtual void MyMethod()
        {
        }

        protected void RaiseCutomException()
        {
            throw new CustomException();
        }


        protected void RaiseTimeOut()
        {
            throw new TimeoutException();
        }

        protected void BaseMethod()
        {

        }
    }

    public class CustomException : Exception
    {
    }

    public class Temp : TempBase
    {
        [Handle(typeof(Temp))]
        public void InvalidExceptionType()
        {

        }

        public void MethodRaiseArgumentNullException()
        {
            base.RaiseArgumentNullException();
        }

        [Handle(typeof(IndexOutOfRangeException))]
        public override void MyMethod()
        {
            base.IndexOutRaise();
        }

        public void MyMethodNotHandleException()
        {
            base.IndexOutRaise();
        }

        [Handle(new Type[] { typeof(ArgumentNullException), typeof(ArgumentException)})]
        public virtual void MyMethodHandlesMultipleExceptions()
        {
            base.RaiseArgumentNullException();
        }

        [Handle(new Type[] { typeof(ArgumentNullException), typeof(ArgumentException) })]

        public void MyMethodDoesnotThrowAnyException()
        {
            
        }

        public void MyMethodWithoutHanldes(int value)
        {
            base.RaiseArgumentNullException();
        }

        [Handle(new Type[] { typeof(ArgumentNullException), typeof(CustomException)})]
        public virtual void MyMethodHandlesException(int value)
        {
            if(value == 1)
            {
                base.RaiseArgumentNullException();
            }
            if(value == 2)
            {
                base.RaiseCutomException();
            }
            if(value == 3)
            {
                base.RaiseTimeOut();
            }
        }

        public int MyFunc()
        {
            return 1;
        }

        public int MyFuncNoHandle()
        {
            base.RaiseArgumentNullException();
            return 1;
        }

        [Handle(new Type[] { typeof(ArgumentNullException) })]
        public int MyFuncWithHandle()
        {
            base.RaiseArgumentNullException();
            return 1;
        }

        [Handle(new Type[] { typeof(ArgumentNullException) })]
        public int MyFunc(int input1)
        {
            if(input1 == 1)
            {
                base.RaiseArgumentNullException();
            }
            else if(input1 == 2)
            {
                base.RaiseArgumentException();
                
            }

            return input1;
        }

        [Handle(new Type[] { typeof(ArgumentNullException) })]
        public int MyFuncCanHandle(int input1)
        {
                base.RaiseArgumentNullException();
            return input1;
        }

        [Handle(new Type[] { typeof(ArgumentNullException) })]
        public int MyFunc(int input1, int input2)
        {
            if (input1 == 1)
            {
                base.RaiseArgumentNullException();
            }
            else if (input1 == 2)
            {
                base.RaiseArgumentException();

            }

            return input1;
        }

        [Handle(new Type[] { typeof(ArgumentNullException) })]
        public int MyFuncCanHandle(int input1, int input2)
        {
            base.RaiseArgumentNullException();
            return input1;
        }

        [Handle(new Type[] { typeof(ArgumentNullException) })]
        public int MyFunc(int input1, int input2, int input3)
        {
            if (input1 == 1)
            {
                base.RaiseArgumentNullException();
            }
            else if (input1 == 2)
            {
                base.RaiseArgumentException();

            }

            return input1;
        }

        [Handle(new Type[] { typeof(ArgumentNullException) })]
        public int MyFuncCanHandle(int input1, int input2, int input3)
        {
            base.RaiseArgumentNullException();
            return input1;
        }

    }

    public class Derived: Temp
    {
        [Handle(typeof(TimeoutException))]
        public override void MyMethodHandlesException(int value)
        {
            base.MyMethodHandlesException(value);
        }

        [Handle(typeof(TimeoutException))]
        public override void MyMethodHandlesMultipleExceptions()
        {
            base.RaiseTimeOut();
        }
    }
}
