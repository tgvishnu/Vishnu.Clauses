using System;
using System.Collections.Generic;
using System.Text;

namespace Vishnu.HandleClause
{
    /// <summary>
    /// Encapsulates a method that has one parameter of type Exception <see cref="Exception"/> and 
    /// returns Exception <see cref="Exception"/>
    /// </summary>
    /// <param name="ex"><see cref="Exception"/></param>
    /// <returns><see cref="Exception"/> or null</returns>
    public delegate Exception ExceptionDelegate(Exception ex);
}
