using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Vishnu.HandleClause;

namespace Vishnu.ShieldClause.Test
{
    [TestFixture]
    public class HandleTest
    {
        [Test]
        public void Handle_Simple_Action()
        {
            Temp t = new Temp();
            Assert.DoesNotThrow(() =>  Handle.Method(t.MyMethod));
            Assert.Throws<IndexOutOfRangeException>(() => t.MyMethodNotHandleException());
            Assert.Throws<ArgumentNullException>(() => t.MyMethodHandlesMultipleExceptions());
            Assert.DoesNotThrow(() => Handle.Method(t.MyMethodDoesnotThrowAnyException));
        }

        [Test]
        public void Handle_Derived_Simple_Action()
        {
            Derived d = new Derived();
            Assert.DoesNotThrow(() => Handle.Method(d.MyMethodHandlesMultipleExceptions));
        }

        [Test]
        public void Handle_Action_WithOneParam()
        {
            Temp t = new Temp();
            Assert.Throws<ArgumentNullException>(() => Handle.Method<int>(t.MyMethod, 1));
            Assert.DoesNotThrow(() => Handle.Method<int>(t.MyMethodHandlesException, 1));
            Assert.DoesNotThrow(() => Handle.Method<int>(t.MyMethodHandlesException, 2));
            Assert.Throws<TimeoutException>(() => Handle.Method<int>(t.MyMethodHandlesException, 3));
            Assert.DoesNotThrow(() => Handle.Method<int>(t.MyMethodHandlesException, 4));

            
        }

        [Test]
        public void Handle_Derived_Action_WithOneParam()
        {
            Derived d = new Derived();
            Assert.DoesNotThrow(() => Handle.Method<int>(d.MyMethodHandlesException, 3));
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

        public void MyMethod(int value)
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

        public int MyFunc(int input1)
        {
            return input1;
        }

        public int MyFunc(int input1, int input2)
        {
            return input1 / input2;
        }

        public int MyFunc(int input1, int input2, int input3)
        {
            return input1 + input2 + input3;
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
