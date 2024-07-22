# Expectable
Define an expected exception with optional expectations.

## Where do I get it

Expectable can be installed using the Nuget package manager 

```
PM> Install-Package Expectable
```

or the dotnet CLI.

```
dotnet add package Expectable
```

## How to get started
1. Define an ExpectedException with an *exceptionType* and optional list of *expectations*.  

   ```csharp
   ExpectedException expectedException = Expect<ArgumentException>.Where
       .MessageStartWith("value")
       .MessageContains("cannot be", StringComparison.OrdinalIgnoreCase)
       .MessageEndsWith("null");
   ```

2. Catch exception

   ```csharp
   var exception = Assert.Throws(expectedException.Type, () => throw new ArgumentException("value CANNOT be null");
   ```

3. Compare exception 

   ```csharp
   Assert.Equal(expectedException, exception);
   ```

   when not equal

   ```
   Message:
     Assert.Equal() Failure: Values differ
     Expected: System.ArgumentException where
                 [+] Message starts with "value"
                 [-] Message contains "cannot be" (ComparisonType: OrdinalIgnoreCase)
                 [+] Message ends with "null"
     Actual:   System.ArgumentException: value was not null
                  at Expectable.Tests.ReadmeExamples.ReadmeExamples.DoSomething(String value)
                  at Xunit.Assert.RecordException(Action testCode)
   ```

## Expectations

Expectations allow you to confirm an optional list of expected conditions are fulfilled by the exception.

### MessageContains
Checks that the exception message contains a specific string value.
* **value** : The string to seek.
* **comparisonType** : One of the enumeration values that determines how the exception message and value are compared. (Default is StringComparison.Ordinal)

### MessageContainsCount
Checks that the exception message contains a specific string value a specific number of times.
* **expectedCount** : The expected number of instances of value within the exception message.
* **value** : The string to seek.
* **comparisonType** : One of the enumeration values that determines how the exception message and value are compared. (Default is StringComparison.Ordinal)

### MessageEndsWith
Checks that the exception message ends with a specific string value.
* **value** : The string to compare to the substring at the end of the exception message.
* **comparisonType** : One of the enumeration values that determines how the exception message and value are compared. (Default is StringComparison.Ordinal)

### MessageEquals
Checks that the exception message equals a specific string value.
* **value** : The string to compare to the exception message..
* **comparisonType** : One of the enumeration values that determines how the exception message and value are compared. (Default is StringComparison.Ordinal)

### MessageMatches
Checks that the exception message matches a specific regular expression pattern.
* **pattern** : The regular expression pattern to match.
* **options** : A bitwise combination of the enumeration values that provide options for matching. (Default is RegexOptions.None)

### MessageStartsWith
Checks that the exception message starts with a specific string value.
* **value** : The string to compare to the substring at the start of the exception message.
* **comparisonType** : One of the enumeration values that determines how the exception message and value are compared. (Default is StringComparison.Ordinal)

## `ToString()`
The value returned is different before and after comparing to a *thrown* exception.  A

### Before expectedException.Equals(thrownException)

```
System.ArgumentException where
      Message starts with "value"
      Message contains "cannot be" (ComparisonType: OrdinalIgnoreCase)
      Message ends with "null"
```

### After expectedException.Equals(thrownException)

```
System.ArgumentException where
  [+] Message starts with "value"
  [-] Message contains "cannot be" (ComparisonType: OrdinalIgnoreCase)
  [+] Message ends with "null"
```

*[+] expectation matched*

*[-] expectation not matched*

## `ResetResults()`
Removes any previously cached results.  The value returned by ToString() is reset to its initial value.

```csharp
expectedException.ResetResults();
```

## Initialization Alternatives

While using `Expect<TException>.Where ...` is the most succinct and versatile way to initialize an ExpectedException with expectations, the following alternatives are also available.

### Constructor `ExpectedException(Type exceptionType, params Expectation[] expectations)`

```csharp
ExpectedException expectedException = new ExpectedException(typeof(ArgumentException),
    new MessageStartsWith("value"),
    new MessageContains("cannot be", StringComparison.OrdinalIgnoreCase),
    new MessageEndsWith("null"));
```

*This is the verbose implementation of Expect&lt;TException&gt;.*


### Constructor `ExpectedException(Exception exception)`

```csharp
ExpectedException expectedException = new ExpectedException(new ArgumentException("value cannot be null"));
// expectedException.Type: typeof(ArgumentException)
// expectedException.Expectations: MessageEquals("value cannot be null")
```

*If the source exception provided was previously thrown, then the value returned by expectedException.ToString will be sourceException.ToString()*


### Implicit Conversion from an exception instance

```csharp
ExpectedException expectedException = new ArgumentException("value cannot be null");
// expectedException.Type: typeof(ArgumentException)
// expectedException.Expectations: MessageEquals("value cannot be null")
```

*If the source exception provided was previously thrown, then the value returned by expectedException.ToString will be sourceException.ToString()*

### Implicit Conversion from exception type

```csharp
ExpectedException expectedException = typeof(ArgumentException);
// expectedException.Type: typeof(ArgumentException)
// expectedException.Expectations: empty
``` 
