using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Vishnu.HandleClause
{
    public static partial class Handle
    {
        public static void Inline<TException>(ActionDelegate actionDelegate, ActionDelegate<Exception> exceptionHanldedAction = null) where TException : Exception
        {
            HandleExceptionHolder holder = new HandleExceptionHolder((exception) => exception is TException ? exception : null);
            try
            {
                actionDelegate.Invoke();
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

        public static void Inline<TException, TInput>(ActionDelegate<TInput> actionDelegate, TInput input, ActionDelegate<Exception> exceptionHanldedAction = null) where TException : Exception
        {
            HandleExceptionHolder holder = new HandleExceptionHolder((exception) => exception is TException ? exception : null);
            try
            {
                actionDelegate.Invoke(input);
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


        public static TResult Inline<TException, TResult>(FuncDelegate<TResult> funcDelegate, ActionDelegate<Exception> exceptionHanldedAction = null) where TException : Exception
        {
            HandleExceptionHolder holder = new HandleExceptionHolder((exception) => exception is TException ? exception : null);
            try
            {
                return funcDelegate.Invoke();
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

        public static TResult Inline<TException, TInput, TResult>(FuncDelegate<TInput, TResult> funcDelegate, TInput input, ActionDelegate<Exception> exceptionHanldedAction = null) where TException : Exception
        {
            HandleExceptionHolder holder = new HandleExceptionHolder((exception) => exception is TException ? exception : null);
            try
            {
                return funcDelegate.Invoke(input);
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

        public static TResult Inline<TException, TInput1, TInput2, TResult>(FuncDelegate<TInput1, TInput2, TResult> funcDelegate, TInput1 input1, TInput2 input2, ActionDelegate<Exception> exceptionHanldedAction = null) where TException : Exception
        {
            HandleExceptionHolder holder = new HandleExceptionHolder((exception) => exception is TException ? exception : null);
            try
            {
                return funcDelegate.Invoke(input1, input2);
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

        public static TResult Inline<TException, TInput1, TInput2, TInput3, TResult>(FuncDelegate<TInput1, TInput2, TInput3, TResult> funcDelegate, TInput1 input1, TInput2 input2, TInput3 input3, ActionDelegate<Exception> exceptionHanldedAction = null) where TException : Exception
        {
            HandleExceptionHolder holder = new HandleExceptionHolder((exception) => exception is TException ? exception : null);
            try
            {
                return funcDelegate.Invoke(input1, input2, input3);
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
