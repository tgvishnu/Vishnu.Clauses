using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Vishnu.HandleClause
{
    public static partial class Handle
    {
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
