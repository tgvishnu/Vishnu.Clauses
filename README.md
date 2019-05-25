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
   - Attribute
   - Inline
## a. Attribute based : Handle
> ## Description
> ## Usage
> ## Supported Actions

## b. Inline
> ## Description
> ## Usage
> ## Supported Actions
## References

    
