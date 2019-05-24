using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.HandleClause
{
    public delegate void ActionDelegate();
    public delegate void ActionDelegate<in TInput>(TInput input);
    public delegate TResult FuncDelegate<out TResult>();
    public delegate TResult FuncDelegate<in TInput, out TResult>(TInput input);
    public delegate TResult FuncDelegate<in TInput1, in TInput2 , out TResult>(TInput1 input1, TInput2 input2);
    public delegate TResult FuncDelegate<in TInput1, in TInput2, in TInput3, out TResult>(TInput1 input1, TInput2 input2, TInput3 input3);
    internal delegate Exception ExceptionDelegage(Exception ex);
}
