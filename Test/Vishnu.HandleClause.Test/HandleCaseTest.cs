using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.HandleClause.Test
{
    [TestFixture]
    public class HandleCaseTest
    {
        [Test]
        public void HandleCase_SimpleAction()
        {

            Assert.DoesNotThrow(() => Handle
                                        .Case<ArgumentNullException>()
                                        .Or<ArgumentException>()
                                        .UseSync()
                                        .Execute(new Temp().MyMethodHandlesMultipleExceptions));

            Assert.DoesNotThrow(() => Handle
                                        .Case<ArgumentNullException>()
                                        .UseSync()
                                        .Execute(new Temp().MethodRaiseArgumentNullException));

            


            Assert.Throws<ArgumentNullException>(() => Handle
                                                            .Case<IndexOutOfRangeException>()
                                                            .UseSync()
                                                            .Execute(new Temp().MethodRaiseArgumentNullException));
        }

        [Test]
        public void HandleInline_SimpleAction_RaiseAction()
        {
            Assert.DoesNotThrow(() => Handle
                                        .Case<ArgumentNullException>()
                                        .UseSync()
                                        .Execute(new Temp().MethodRaiseArgumentNullException, this.ExceptionHandled));
            Assert.Throws<ArgumentNullException>(() => Handle
                                                    .Case<IndexOutOfRangeException>()
                                                    .UseSync()
                                                    .Execute(new Temp().MethodRaiseArgumentNullException, this.ExceptionHandled));

            Assert.DoesNotThrow(() => Handle
                                        .Case<ArgumentNullException>()
                                        .Or<ArgumentException>()
                                        .UseSync()
                                        .Execute(new Temp().MyMethodHandlesMultipleExceptions, this.ExceptionHandled));
        }

        [Test]
        public void HandleCase_Action_one_input_RaiseAction()
        {
            Assert.DoesNotThrow(() => Handle
                                        .Case<ArgumentNullException>()
                                        .Or<CustomException>()
                                        .Or<ArgumentException>()
                                        .UseSync()
                                        .Execute<int>(new Temp().MyMethodHandlesException, 4, this.ExceptionHandled));

            Assert.Throws<ArgumentNullException>(() => Handle
                                                        .Case<IndexOutOfRangeException>()
                                                        .UseSync()
                                                        .Execute<int>(new Temp().MyMethodHandlesException, 1, this.ExceptionHandled));
        }

        [Test]
        public void HandleCase_Func_return_one()
        {
            Assert.DoesNotThrow(() => Handle
                                        .Case<ArgumentNullException>()
                                        .UseSync()
                                        .Execute<int>(new Temp().MyFuncNoHandle));

            Assert.Throws<ArgumentNullException>(() => Handle
                                                        .Case<IndexOutOfRangeException>()
                                                        .UseSync()
                                                        .Execute<int>(new Temp().MyFuncNoHandle));
        }


        [Test]
        public void HandleCase_Func_return_one_RaiseAction()
        {
            Assert.DoesNotThrow(() => Handle
                                        .Case<ArgumentNullException>()
                                        .UseSync()
                                         .Execute<int>(new Temp().MyFuncNoHandle, this.ExceptionHandled));
            Assert.Throws<ArgumentNullException>(() => Handle
                                                        .Case<IndexOutOfRangeException>()
                                                        .UseSync()
                                                        .Execute<int>(new Temp().MyFuncNoHandle, this.ExceptionHandled));
        }

        [Test]
        public void HandleCase_Func_inputone_return_one()
        {
                        
            Assert.DoesNotThrow(() => Handle
                                        .Case<ArgumentNullException>()
                                        .UseSync()
                                        .Execute<int, int>(new Temp().MyFunc, 1));
            Assert.Throws<ArgumentNullException>(() => Handle
                                                        .Case<IndexOutOfRangeException>()
                                                        .UseSync()
                                                        .Execute<int, int>(new Temp().MyFunc, 1));
        }

        [Test]
        public void HandleCase_Func_inputone_return_one_RaiseAction()
        {
            Assert.DoesNotThrow(() => Handle
                                        .Case<ArgumentNullException>()
                                        .UseSync()
                                        .Execute<int, int>(new Temp().MyFunc, 1, this.ExceptionHandled));
            Assert.Throws<ArgumentNullException>(() => Handle
                                                        .Case<IndexOutOfRangeException>()
                                                        .UseSync()
                                                        .Execute<int, int>(new Temp().MyFunc, 1, this.ExceptionHandled));
        }



        private void ExceptionHandled(Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.ToString());
        }
    }
}
