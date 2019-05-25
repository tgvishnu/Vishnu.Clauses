using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Vishnu.HandleClause
{
    /// <summary>
    /// Class responsible for invoking the specific actions and handles the exceptions 
    /// declared in Handle attribute <see cref="HandleAttribute"/> and also exceptions in Inline.
    /// </summary>
    public static partial class Handle
    {
        /// <summary>
        /// Invokes the action <paramref name="action"/> and also raises action <paramref name="exceptionHandledAction"/> if the exception is handled.
        /// </summary>
        /// <param name="action">action</param>
        /// <param name="exceptionHandledAction">action</param>
        public static void Method(Action action, Action<Exception> exceptionHandledAction = null)
        {
            new HandleAttributeHelper().Call(action, exceptionHandledAction);
        }

        /// <summary>
        /// Invokes the action <paramref name="action"/> and also raises action <paramref name="exceptionHandledAction"/> if the exception is handled.
        /// </summary>
        /// <typeparam name="TInput">type of input</typeparam>
        /// <param name="action">action</param>
        /// <param name="input"><typeparamref name="TInput"/></param>
        /// <param name="exceptionHandledAction">action</param>
        public static void Method<TInput>(Action<TInput> action, TInput input, Action<Exception> exceptionHandledAction = null)
        {
            new HandleAttributeHelper().Call<TInput>(action, input, exceptionHandledAction);
        }

        /// <summary>
        /// Invokes the action <paramref name="action"/> and also raises action <paramref name="exceptionHandledAction"/> if the exception is handled.
        /// </summary>
        /// <typeparam name="TResult">type of result</typeparam>
        /// <param name="action">action</param>
        /// <param name="exceptionHandledAction">action</param>
        /// <returns><typeparamref name="TResult"/></returns>
        public static TResult Method<TResult>(Func<TResult> action, Action<Exception> exceptionHandledAction = null)
        {
            return new HandleAttributeHelper().Call<TResult>(action, exceptionHandledAction);
        }

        /// <summary>
        /// Invokes the action <paramref name="action"/> and also raises action <paramref name="exceptionHandledAction"/> if the exception is handled.
        /// </summary>
        /// <typeparam name="TInput">type of input</typeparam>
        /// <typeparam name="TResult">type of result</typeparam>
        /// <param name="action">action</param>
        /// <param name="input"><typeparamref name="TInput"/></param>
        /// <param name="exceptionHandledAction">action</param>
        /// <returns><typeparamref name="TResult"/></returns>
        public static TResult Method<TInput, TResult>(Func<TInput, TResult> action, TInput input, Action<Exception> exceptionHandledAction = null)
        {
            return new HandleAttributeHelper().Call<TInput, TResult>(action, input, exceptionHandledAction);
        }

        /// <summary>
        /// Invokes the action <paramref name="action"/> and also raises action <paramref name="exceptionHandledAction"/> if the exception is handled.
        /// </summary>
        /// <typeparam name="TInput1">type of input1</typeparam>
        /// <typeparam name="TInput2">type of input2</typeparam>
        /// <typeparam name="TResult">type of result</typeparam>
        /// <param name="action">action</param>
        /// <param name="input1"><typeparamref name="TInput1"/></param>
        /// <param name="input2"><typeparamref name="TInput2"/></param>
        /// <param name="exceptionHandledAction">action</param>
        /// <returns><typeparamref name="TResult"/></returns>
        public static TResult Method<TInput1, TInput2, TResult>(Func<TInput1, TInput2, TResult> action, TInput1 input1, TInput2 input2, Action<Exception> exceptionHandledAction = null)
        {
            return new HandleAttributeHelper().Call<TInput1, TInput2, TResult>(action, input1, input2, exceptionHandledAction);
        }

        /// <summary>
        /// Invokes the action <paramref name="action"/> and also raises action <paramref name="exceptionHandledAction"/> if the exception is handled.
        /// </summary>
        /// <typeparam name="TInput1">type of input1</typeparam>
        /// <typeparam name="TInput2">type of input2</typeparam>
        /// <typeparam name="TInput3">type of input3</typeparam>
        /// <typeparam name="TResult">type of result</typeparam>
        /// <param name="action">action</param>
        /// <param name="input1"><typeparamref name="TInput1"/></param>
        /// <param name="input2"><typeparamref name="TInput2"/></param>
        /// <param name="input3"><typeparamref name="TInput3"/></param>
        /// <param name="exceptionHandledAction">action</param>
        /// <returns><typeparamref name="TResult"/></returns>
        public static TResult Method<TInput1, TInput2, TInput3, TResult>(Func<TInput1, TInput2, TInput3, TResult> action, TInput1 input1, TInput2 input2, TInput3 input3, Action<Exception> exceptionHandledAction = null)
        {
            return new HandleAttributeHelper().Call<TInput1, TInput2, TInput3, TResult>(action, input1, input2, input3, exceptionHandledAction);
        }
    }
}
