# Vishnu.Clause

This package contains

- ShieldClause (NuGet: [Vishnu.ShieldClause](https://www.nuget.org/packages/Vishnu.ShieldClause))
   > A simple package with extensible shield clauses
- HandleClause (NuGet :)
   > A package for handling exceptions based on Attributes and Inline

## Give a Star! :star:
If you like or are using this project please give it a star. Thanks!

# 1. Vishnu.ShieldClause [ NuGet: [Vishnu.ShieldClause](https://www.nuget.org/packages/Vishnu.ShieldClause) ]
A simple package with extensible shield clauses. 

>## Usage

```c#
    public void ValidateContent(User user, string input)
    {
       
        Shield.Against.Null(User, nameof(user));
       
        Shield.Throws.ArugmentNullException<string>((input) => { return input == null ? true : false; }, null, "param1"));
       
        Shield.Throws.ArugmentNullException(Validate(""), null, "param1"));      
       
        Shield.Throws.ArgumentException((true || true), "param1"));
    }
    
    public bool Validate(string input)
    {
        if(string.IsNullOrEmpty(input))
        {
            return true;
        }
    }
```
>## Supported classes
- ** Shield.Against.NullOrEmpty**
- ** Shield.Against.NullOrWhiteSpace**
- ** Shield.Against.OutOfRange**
- ** Shield.Against.LesserThan<T>**
- ** Shield.Against.GreaterThan<T>**
- ** Shield.Against.IsTypeOf<T>**
- ** Shield.Against.NullOrEmpty<T>**
- ** Shield.Throws.ArgumentException**
- ** Shield.Throws.ArgumentNullException**
- ** Shield.Throws.TimeoutException**
- ** Shield.Throws.NotSupportedException**

>## Extending with your own Guard Clauses

```c#

    // use extension methods on IShieldClause for adding more functionality in "Against"
    namespace Vishnu.ShieldClause
    {
        public static class ShieldClauseExtension
        {
             public static void Tst(this IShieldClause shieldClause, int input, string parameterName)
            {
            }
         }
     }
     
    // use extension methods on ExceptionContainer for adding more functionality in "Throw"
    namespace Vishnu.ShieldClause
    {
        public static class ShieldClauseExtension
        {
            public static void FileNotFoundException(this ExceptionContainer container, bool when, int input, string parameterName)
            {
            }
        }
     }
    
```
# 2. Vishnu.HandleClause [ NuGet: [Vishnu.HandleClause]]
   A package for handling exception and invokes specific action based on the exception
   - Handle Attribute
   - Inline
## a. Handle Attribute
> ## Description
     Handle attribute, supresses or handles the exceptions raised by any method.  Optionally allows to invoke other action if any exception is handled or supressed.  Handle attribute allows inheritance.  

> ## Usage

1. Import namespace

```c#

using Vishnu.HandleClause;

```

2. Decorate the method with Handle attribute and specify the type of exceptions to be handled.

```c#
   public class Foo
   {
        // Handles supress only one exception
        [Handle(typeof(ArgumentNullException))]
        public void Update(string value)
        {
            var result = Check(value);
        }
        
        //  Handle multiple exceptions. Any custom exceptions can also be specifieed
        [Handle(new Type[] { typeof(ArgumentNullException), typeof(ArgumentException), typeof(CustomException) })]
        public int Sycnchorize()
        {
            return 0;
        }
   }
```
3. Pass the method in Handle.Method

```c#
        public void Test()
        {
            Foo foo = new Foo();
            // call the specific method to be invoked.
            Handle.Method<string>(foo.Update, "value");
            Handle.Method(foo.Sycnchorize);
            // pass the action to be excecuted if the exception is handled.
            Handle.Method(foo.Sycnchorize, ExceptionHandledCallback);
        }
        
        // Action invoked if the exception is handled.
        private void ExceptionHandledCallback(Exception ex)
        {
            //
        }
```

> ## Supported Actions

```c#

- Handle.Method(Action action, Action<Exception> exceptionHandledAction = null)
- Handle.Method<TInput>(Action<TInput> action, TInput input, Action<Exception> exceptionHandledAction = null)
- TResult result = Handle.Method<TResult>(Func<TResult> action, Action<Exception> exceptionHandledAction = null)
- TResult result = Handle.Method<TInput, TResult>(Func<TInput, TResult> action, TInput input, Action<Exception> exceptionHandledAction = null)
- TResult result = Handle.Method<TInput1, TInput2, TResult>(Func<TInput1, TInput2, TResult> action, TInput1 input1, TInput2 input2, Action<Exception> exceptionHandledAction = null)
- TResult result = Handle.Method<TInput1, TInput2, TInput3, TResult>(Func<TInput1, TInput2, TInput3, TResult> action, TInput1 input1, TInput2 input2, TInput3 input3, Action<Exception> exceptionHandledAction = null)

```

## b. Inline

> ## Description
   Inline exception handling allows to handle or supress only one exception.  Optionally, it allows to invoke an action if the exception is handled.  

> ## Usage
1. Declare namespace

```c#

using Vishnu.HandleClause;

```
2. Use Handle.Inline static method and pass the action to be invoked as parameter.  Optionally exception handled call back can also be passed.

```c#
    public class Boo
    {
        public void Update()
        {
            .....
        }

        public int Update(string value)
        {
            ....
            return 0;
        }
    }
    
    public void Test()
   {
       Boo boo = new Boo();
       // handles ArgumentException
       Handle.Inline<ArgumentException>(boo.Update);
       Handle.Inline<ArgumentException, string, int>(boo.Update, "hello");
       
       // Handles ArgumentException and also invokes ExceptionHandledCallback if exception is handled.
       Handle.Inline<ArgumentException, string, int>(boo.Update, "hello", this.ExceptionHandledCallback);
   }
    
```
> ## Supported Actions

```c#

- Handle.Inline<TException>(Action action, Action<Exception> exceptionHanldedAction = null) where TException : Exception
- Handle.Inline<TException, TInput>(Action<TInput> action, TInput input, Action<Exception> exceptionHanldedAction = null) where TException : Exception
- TResult result = Handle.Inline<TException, TResult>(Func<TResult> action, Action<Exception> exceptionHanldedAction = null) where TException : Exception
- TResult result = Handle.Inline<TException, TInput, TResult>(Func<TInput, TResult> action, TInput input, Action<Exception> exceptionHanldedAction = null) where TException : Exception
- TResult result = Handle.Inline<TException, TInput1, TInput2, TResult>(Func<TInput1, TInput2, TResult> action, TInput1 input1, TInput2 input2, Action<Exception> exceptionHanldedAction = null) where TException : Exception
- TResult result = Handle.Inline<TException, TInput1, TInput2, TInput3, TResult>(Func<TInput1, TInput2, TInput3, TResult> action, TInput1 input1, TInput2 input2, TInput3 input3, Action<Exception> exceptionHanldedAction = null) where TException : Exception

```

## References

    
