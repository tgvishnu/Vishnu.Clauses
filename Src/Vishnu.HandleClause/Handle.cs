﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Vishnu.HandleClause
{
    public static partial class Handle
    {
        public static void Method(ActionDelegate action, Action<Exception> exceptionHandledAction = null)
        {
            new HandleAttributeHelper().Call(action, exceptionHandledAction);
        }

        public static void Method<TInput>(ActionDelegate<TInput> action, TInput input, Action<Exception> exceptionHandledAction = null)
        {
            new HandleAttributeHelper().Call<TInput>(action, input, exceptionHandledAction);
        }


        public static TResult Method<TResult>(FuncDelegate<TResult> action, Action<Exception> exceptionHandledAction = null)
        {
            return new HandleAttributeHelper().Call<TResult>(action, exceptionHandledAction);
        }

        public static TResult Method<TInput, TResult>(FuncDelegate<TInput, TResult> action, TInput input, Action<Exception> exceptionHandledAction = null)
        {
            return new HandleAttributeHelper().Call<TInput, TResult>(action, input, exceptionHandledAction);
        }

        public static TResult Method<TInput1, TInput2, TResult>(FuncDelegate<TInput1, TInput2, TResult> action, TInput1 input1, TInput2 input2, Action<Exception> exceptionHandledAction = null)
        {
            return new HandleAttributeHelper().Call<TInput1, TInput2, TResult>(action, input1, input2, exceptionHandledAction);
        }

        public static TResult Method<TInput1, TInput2, TInput3, TResult>(FuncDelegate<TInput1, TInput2, TInput3, TResult> action, TInput1 input1, TInput2 input2, TInput3 input3, Action<Exception> exceptionHandledAction = null)
        {
            return new HandleAttributeHelper().Call<TInput1, TInput2, TInput3, TResult>(action, input1, input2, input3, exceptionHandledAction);
        }
    }
}