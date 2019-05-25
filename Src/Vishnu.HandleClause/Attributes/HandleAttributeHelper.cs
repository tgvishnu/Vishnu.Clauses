using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;

namespace Vishnu.HandleClause
{
    /// <summary>
    /// Class for processing <see cref="HandleAttribute"/> Handle attribute
    /// </summary>
    internal class HandleAttributeHelper
    {
        /// <summary>
        /// Invokes specific action <paramref name="action"/> and also invokes action <paramref name="exceptionHandledAction"/> if exception is handled.
        /// </summary>
        /// <param name="action">action</param>
        /// <param name="exceptionHandledAction">action</param>
        internal void Call(Action action, Action<Exception> exceptionHandledAction = null)
        {
            var exceptions = this.GetExceptionsFromAction(action.Method.DeclaringType, action.Method);
            try
            {
                action.Invoke();
            }
            catch(Exception ex)
            {
                if(!Contains(exceptions, ex.GetType()))
                {
                    throw;
                }
                else
                {
                    if(exceptionHandledAction != null)
                    {
                        exceptionHandledAction(ex);
                    }
                }
            }
        }

        /// <summary>
        /// Invokes specific action <paramref name="action"/> and also invokes action <paramref name="exceptionHandledAction"/> if exception is handled.
        /// </summary>
        /// <typeparam name="TInput">type of input</typeparam>
        /// <param name="action">action</param>
        /// <param name="input">input</param>
        /// <param name="exceptionHandledAction">action</param>
        internal void Call<TInput>(Action<TInput> action, TInput input, Action<Exception> exceptionHandledAction = null)
        {
            var exceptions = this.GetExceptionsFromAction(action.Method.DeclaringType, action.Method);
            try
            {
                action.Invoke(input);
            }
            catch (Exception ex)
            {
                if (!Contains(exceptions, ex.GetType()))
                {
                    throw;
                }
                else
                {
                    if (exceptionHandledAction != null)
                    {
                        exceptionHandledAction(ex);
                    }
                }
            }
        }

        /// <summary>
        /// Invokes specific action <paramref name="action"/> and also invokes action <paramref name="exceptionHandledAction"/> if exception is handled.
        /// </summary>
        /// <typeparam name="TResult">Result type</typeparam>
        /// <param name="action">action</param>
        /// <param name="exceptionHandledAction">action</param>
        /// <returns><typeparamref name="TResult"/></returns>
        internal TResult Call<TResult>(Func<TResult> action, Action<Exception> exceptionHandledAction = null)
        {
            var exceptions = this.GetExceptionsFromAction(action.Method.DeclaringType, action.Method);
            try
            {
                return action.Invoke();
            }
            catch (Exception ex)
            {
                if (!Contains(exceptions, ex.GetType()))
                {
                    throw;
                }
                else
                {
                    if (exceptionHandledAction != null)
                    {
                        exceptionHandledAction(ex);
                    }

                    return default(TResult);
                }
            }
        }

        /// <summary>
        /// Invokes specific action <paramref name="action"/> and also invokes action <paramref name="exceptionHandledAction"/> if exception is handled.
        /// </summary>
        /// <typeparam name="TInput">type of input</typeparam>
        /// <typeparam name="TResult">type of result</typeparam>
        /// <param name="action">action</param>
        /// <param name="input"><typeparamref name="TInput"/></param>
        /// <param name="exceptionHandledAction">action</param>
        /// <returns><typeparamref name="TResult"/></returns>
        internal TResult Call<TInput, TResult>(Func<TInput, TResult> action, TInput input, Action<Exception> exceptionHandledAction = null)
        {
            var exceptions = this.GetExceptionsFromAction(action.Method.DeclaringType, action.Method);
            try
            {
                return action.Invoke(input);
            }
            catch (Exception ex)
            {
                if (!Contains(exceptions, ex.GetType()))
                {
                    throw;
                }
                else
                {
                    if (exceptionHandledAction != null)
                    {
                        exceptionHandledAction(ex);
                    }

                    return default(TResult);
                }
            }
        }

        /// <summary>
        /// Invokes specific action <paramref name="action"/> and also invokes action <paramref name="exceptionHandledAction"/> if exception is handled.
        /// </summary>
        /// <typeparam name="TInput1">type of input1</typeparam>
        /// <typeparam name="TInput2">type of input2</typeparam>
        /// <typeparam name="TResult">return type</typeparam>
        /// <param name="action">action</param>
        /// <param name="input1"><typeparamref name="TInput1"/></param>
        /// <param name="input2"><typeparamref name="TInput2"/></param>
        /// <param name="exceptionHandledAction">action</param>
        /// <returns><typeparamref name="TResult"/></returns>
        internal TResult Call<TInput1, TInput2, TResult>(Func<TInput1, TInput2, TResult> action, TInput1 input1, TInput2 input2, Action<Exception> exceptionHandledAction = null)
        {
            var exceptions = this.GetExceptionsFromAction(action.Method.DeclaringType, action.Method);
            try
            {
                return action.Invoke(input1, input2);
            }
            catch (Exception ex)
            {
                if (!Contains(exceptions, ex.GetType()))
                {
                    throw;
                }
                else
                {
                    if (exceptionHandledAction != null)
                    {
                        exceptionHandledAction(ex);
                    }

                    return default(TResult);
                }
            }
        }

        /// <summary>
        /// Invokes specific action <paramref name="action"/> and also invokes action <paramref name="exceptionHandledAction"/> if exception is handled.
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
        internal TResult Call<TInput1, TInput2, TInput3, TResult>(Func<TInput1, TInput2, TInput3, TResult> action, TInput1 input1, TInput2 input2, TInput3 input3, Action<Exception> exceptionHandledAction = null)
        {
            var exceptions = this.GetExceptionsFromAction(action.Method.DeclaringType, action.Method);
            try
            {
                return action.Invoke(input1, input2,  input3);
            }
            catch (Exception ex)
            {
                if (!Contains(exceptions, ex.GetType()))
                {
                    throw;
                }
                else
                {
                    if (exceptionHandledAction != null)
                    {
                        exceptionHandledAction(ex);
                    }

                    return default(TResult);
                }
            }
        }

        private IList<Type> GetExceptionsFromAction(Type declaredType, MethodInfo actionMethodInfo)
        {
            List<Type> exceptions = new List<Type>();
            var methodInfos = declaredType.GetMethods().Where(e => e.Name == actionMethodInfo.Name);
            MemberInfo memberInfo = null;
            foreach(var mi in methodInfos)
            {
                var miParams = mi.GetParameters();
                var actionParams = actionMethodInfo.GetParameters();
                bool isValid = true;
                if(miParams != null & actionParams != null)
                {
                    if(miParams.Length == actionParams.Length)
                    {
                        for (int ii = 0; ii < actionParams.Length; ii++)
                        {
                            if(miParams[ii].GetType() != actionParams[ii].GetType())
                            {
                                isValid = false;
                                break;
                            }
                        }
                    }
                }

                if(isValid)
                {
                    memberInfo = mi;
                    break;
                }
            }

            if (memberInfo != null)
            {
                var attributes = System.Attribute.GetCustomAttributes(memberInfo);
                if (attributes != null && attributes.Length > 0)
                {
                    foreach (var attribute in attributes)
                    {
                        if (attribute is HandleAttribute)
                        {
                            var ex = ((HandleAttribute)attribute).Exceptions;
                            if (ex != null && ex.Length > 0)
                            {
                                exceptions.AddRange(ex);
                            }
                        }
                    }
                }
            }

            return exceptions;
        }

        private bool Contains(IList<Type> types, Type type)
        {
            return types.FirstOrDefault(e => e == type) != null ? true : false; 
        }
    }
}
