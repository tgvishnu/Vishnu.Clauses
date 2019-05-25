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
        /// Invokes the action <paramref name="action"/> and handles the exception
        /// <typeparamref name="TException"/>.  Action <paramref name="exceptionHanldedAction"/> 
        /// will be invoked if the exception is handled.
        /// </summary>
        /// <typeparam name="TException"><see cref="Exception"/></typeparam>
        /// <param name="action">action</param>
        /// <param name="exceptionHanldedAction">action</param>
        public static void Inline<TException>(Action action, Action<Exception> exceptionHanldedAction = null) where TException : Exception
        {
            HandleExceptionHolder holder = new HandleExceptionHolder((exception) => exception is TException ? exception : null);
            try
            {
                action.Invoke();
            }
            catch(Exception ex)
            {
                if(holder.FirstOrDefault(ex) == null)
                {
                    throw;
                }
                else
                {
                    if(exceptionHanldedAction != null)
                    {
                        exceptionHanldedAction.Invoke(ex);
                    }
                }
            }
        }

        /// <summary>
        /// Invokes the action <paramref name="action"/> and handles the exception
        /// <typeparamref name="TException"/>.  Action <paramref name="exceptionHanldedAction"/> 
        /// will be invoked if the exception is handled.
        /// </summary>
        /// <typeparam name="TException"><see cref="Exception"/></typeparam>
        /// <typeparam name="TInput">type of input</typeparam>
        /// <param name="action">action</param>
        /// <param name="input"><typeparamref name="TInput"/></param>
        /// <param name="exceptionHanldedAction">action</param>
        public static void Inline<TException, TInput>(Action<TInput> action, TInput input, Action<Exception> exceptionHanldedAction = null) where TException : Exception
        {
            HandleExceptionHolder holder = new HandleExceptionHolder((exception) => exception is TException ? exception : null);
            try
            {
                action.Invoke(input);
            }
            catch (Exception ex)
            {
                if (holder.FirstOrDefault(ex) == null)
                {
                    throw;
                }
                else
                {
                    if (exceptionHanldedAction != null)
                    {
                        exceptionHanldedAction.Invoke(ex);
                    }
                }
            }
        }

        /// <summary>
        /// Invokes the action <paramref name="action"/> and handles the exception
        /// <typeparamref name="TException"/>.  Action <paramref name="exceptionHanldedAction"/> 
        /// will be invoked if the exception is handled.
        /// </summary>
        /// <typeparam name="TException"><see cref="Exception"/></typeparam>
        /// <typeparam name="TResult">type of result</typeparam>
        /// <param name="action">action</param>
        /// <param name="exceptionHanldedAction">action</param>
        /// <returns></returns>
        public static TResult Inline<TException, TResult>(Func<TResult> action, Action<Exception> exceptionHanldedAction = null) where TException : Exception
        {
            HandleExceptionHolder holder = new HandleExceptionHolder((exception) => exception is TException ? exception : null);
            try
            {
                return action.Invoke();
            }
            catch (Exception ex)
            {
                if (holder.FirstOrDefault(ex) == null)
                {
                    throw;
                }
                else
                {
                    if (exceptionHanldedAction != null)
                    {
                        exceptionHanldedAction.Invoke(ex);
                    }
                }
            }

            return default(TResult);
        }

        /// <summary>
        /// Invokes the action <paramref name="action"/> and handles the exception
        /// <typeparamref name="TException"/>.  Action <paramref name="exceptionHanldedAction"/> 
        /// will be invoked if the exception is handled.
        /// </summary>
        /// <typeparam name="TException"><see cref="Exception"/></typeparam>
        /// <typeparam name="TInput">type of input</typeparam>
        /// <typeparam name="TResult">type of result</typeparam>
        /// <param name="action">action</param>
        /// <param name="input"><typeparamref name="TInput"/></param>
        /// <param name="exceptionHanldedAction">action</param>
        /// <returns><typeparamref name="TResult"/></returns>
        public static TResult Inline<TException, TInput, TResult>(Func<TInput, TResult> action, TInput input, Action<Exception> exceptionHanldedAction = null) where TException : Exception
        {
            HandleExceptionHolder holder = new HandleExceptionHolder((exception) => exception is TException ? exception : null);
            try
            {
                return action.Invoke(input);
            }
            catch (Exception ex)
            {
                if (holder.FirstOrDefault(ex) == null)
                {
                    throw;
                }
                else
                {
                    if (exceptionHanldedAction != null)
                    {
                        exceptionHanldedAction.Invoke(ex);
                    }
                }
            }

            return default(TResult);
        }

        /// <summary>
        /// Invokes the action <paramref name="action"/> and handles the exception
        /// <typeparamref name="TException"/>.  Action <paramref name="exceptionHanldedAction"/> 
        /// will be invoked if the exception is handled.
        /// </summary>
        /// <typeparam name="TException"><see cref="Exception"/></typeparam>
        /// <typeparam name="TInput1">type of input1</typeparam>
        /// <typeparam name="TInput2">type of input2</typeparam>
        /// <typeparam name="TResult">type of result</typeparam>
        /// <param name="action">action</param>
        /// <param name="input1"><typeparamref name="TInput1"/></param>
        /// <param name="input2"><typeparamref name="TInput2"/></param>
        /// <param name="exceptionHanldedAction">action</param>
        /// <returns><typeparamref name="TResult"/></returns>
        public static TResult Inline<TException, TInput1, TInput2, TResult>(Func<TInput1, TInput2, TResult> action, TInput1 input1, TInput2 input2, Action<Exception> exceptionHanldedAction = null) where TException : Exception
        {
            HandleExceptionHolder holder = new HandleExceptionHolder((exception) => exception is TException ? exception : null);
            try
            {
                return action.Invoke(input1, input2);
            }
            catch (Exception ex)
            {
                if (holder.FirstOrDefault(ex) == null)
                {
                    throw;
                }
                else
                {
                    if (exceptionHanldedAction != null)
                    {
                        exceptionHanldedAction.Invoke(ex);
                    }
                }
            }

            return default(TResult);
        }

        /// <summary>
        /// Invokes the action <paramref name="action"/> and handles the exception
        /// <typeparamref name="TException"/>.  Action <paramref name="exceptionHanldedAction"/> 
        /// will be invoked if the exception is handled.
        /// </summary>
        /// <typeparam name="TException"><see cref="Exception"/></typeparam>
        /// <typeparam name="TInput1">type of input1</typeparam>
        /// <typeparam name="TInput2">type of input2</typeparam>
        /// <typeparam name="TInput3">type of input3</typeparam>
        /// <typeparam name="TResult">type of result</typeparam>
        /// <param name="action">action</param>
        /// <param name="input1"><typeparamref name="TInput1"/></param>
        /// <param name="input2"><typeparamref name="TInput2"/></param>
        /// <param name="input3"><typeparamref name="TInput3"/></param>
        /// <param name="exceptionHanldedAction">action</param>
        /// <returns><typeparamref name="TResult"/></returns>
        public static TResult Inline<TException, TInput1, TInput2, TInput3, TResult>(Func<TInput1, TInput2, TInput3, TResult> action, TInput1 input1, TInput2 input2, TInput3 input3, Action<Exception> exceptionHanldedAction = null) where TException : Exception
        {
            HandleExceptionHolder holder = new HandleExceptionHolder((exception) => exception is TException ? exception : null);
            try
            {
                return action.Invoke(input1, input2, input3);
            }
            catch (Exception ex)
            {
                if (holder.FirstOrDefault(ex) == null)
                {
                    throw;
                }
                else
                {
                    if (exceptionHanldedAction != null)
                    {
                        exceptionHanldedAction.Invoke(ex);
                    }
                }
            }

            return default(TResult);
        }
    }
}
