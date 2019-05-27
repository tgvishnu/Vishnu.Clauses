using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.HandleClause
{
    /// <summary>
    /// Synchronous methods calls.
    /// </summary>
    public class SyncCall
    {
        /// <summary>
        /// Exception delegate collections.
        /// </summary>
        private ExceptionDelegateCollection holder;

        /// <summary>
        /// Creates new instance of <see cref="SyncCall"/> class.
        /// </summary>
        /// <param name="exceptionDelegateCollection"><see cref="ExceptionDelegateCollection"/></param>
        public SyncCall(ExceptionDelegateCollection exceptionDelegateCollection)
        {
            holder = exceptionDelegateCollection;
        }

        /// <summary>
        /// Excecutes an action
        /// </summary>
        /// <param name="action">action</param>
        /// <param name="exceptionHanldedAction">action</param>
        public void Execute(Action action, Action<Exception> exceptionHanldedAction = null)
        {
            try
            {
                action.Invoke();
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
        /// Executes an action with one input <typeparamref name="TInput"/>
        /// </summary>
        /// <typeparam name="TInput">type of input</typeparam>
        /// <param name="action">action</param>
        /// <param name="input"><typeparamref name="TInput"/></param>
        /// <param name="exceptionHanldedAction">action</param>
        public void Execute<TInput>(Action<TInput> action, TInput input, Action<Exception> exceptionHanldedAction = null)
        {
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
        /// Executes an action with no input params and returns result <typeparamref name="TResult"/>.
        /// </summary>
        /// <typeparam name="TException"><see cref="Exception"/></typeparam>
        /// <typeparam name="TInput">type of input</typeparam>
        /// <param name="action">action</param>
        /// <param name="input"><typeparamref name="TInput"/></param>
        /// <param name="exceptionHanldedAction">action</param>
        public TResult Execute<TResult>(Func<TResult> action, Action<Exception> exceptionHanldedAction = null)
        {
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
        /// Executes an action with one input TInput <typeparamref name="TInput"/> and returns <typeparamref name="TResult"/>
        /// </summary>
        /// <typeparam name="TInput">type of input</typeparam>
        /// <typeparam name="TResult">type of result</typeparam>
        /// <param name="action">action</param>
        /// <param name="input"><typeparamref name="TInput"/></param>
        /// <param name="exceptionHanldedAction">action</param>
        /// <returns><typeparamref name="TResult"/></returns>
        public TResult Execute<TInput, TResult>(Func<TInput, TResult> action, TInput input, Action<Exception> exceptionHanldedAction = null)
        {
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
        /// Executes an action with two inputs TInput1 <typeparamref name="TInput1"/>, TInput2 <typeparamref name="TInput2"/> and returns result <typeparamref name="TResult"/>
        /// </summary>
        /// <typeparam name="TInput1">type of input1</typeparam>
        /// <typeparam name="TInput2">type of input2</typeparam>
        /// <typeparam name="TResult">type of result</typeparam>
        /// <param name="action">action</param>
        /// <param name="input1"><typeparamref name="TInput1"/></param>
        /// <param name="input2"><typeparamref name="TInput2"/></param>
        /// <param name="exceptionHanldedAction">action</param>
        /// <returns><typeparamref name="TResult"/></returns>
        public TResult Execute<TInput1, TInput2, TResult>(Func<TInput1, TInput2, TResult> action, TInput1 input1, TInput2 input2, Action<Exception> exceptionHanldedAction = null)
        {
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
        /// Executes an action with three inputs TInput1 <typeparamref name="TInput1"/>, TInput2 <typeparamref name="TInput2"/> and TInput3 <typeparamref name="TInput3"/> and returns result <typeparamref name="TResult"/>
        /// </summary>
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
        public TResult Execute<TInput1, TInput2, TInput3, TResult>(Func<TInput1, TInput2, TInput3, TResult> action, TInput1 input1, TInput2 input2, TInput3 input3, Action<Exception> exceptionHanldedAction = null)
        {
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
