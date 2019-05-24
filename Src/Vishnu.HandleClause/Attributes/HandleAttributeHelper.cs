using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;

namespace Vishnu.HandleClause
{
    internal class HandleAttributeHelper
    {
        internal void Call(ActionDelegate action, Action<Exception> exceptionHandledAction = null)
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

        internal void Call<TInput>(ActionDelegate<TInput> action, TInput input, Action<Exception> exceptionHandledAction = null)
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

        internal TResult Call<TResult>(FuncDelegate<TResult> action, Action<Exception> exceptionHandledAction = null)
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

        internal TResult Call<TInput, TResult>(FuncDelegate<TInput, TResult> action, TInput input, Action<Exception> exceptionHandledAction = null)
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

        internal TResult Call<TInput1, TInput2, TResult>(FuncDelegate<TInput1, TInput2, TResult> action, TInput1 input1, TInput2 input2, Action<Exception> exceptionHandledAction = null)
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

        internal TResult Call<TInput1, TInput2, TInput3, TResult>(FuncDelegate<TInput1, TInput2, TInput3, TResult> action, TInput1 input1, TInput2 input2, TInput3 input3, Action<Exception> exceptionHandledAction = null)
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
