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
1. Define an ExpectedException. 
 
   See **Initialization** and **Expectations** below for options.

   ```csharp
   // using Expectable;

   ExpectedException expectedException = Expect<ArgumentException>.Where
       .MessageStartWith("value")
       .MessageContains("cannot be", StringComparison.OrdinalIgnoreCase)
       .MessageEndsWith("null");
   ```

2. Catch the exception.

   XUnit / NUnit

   ```csharp
   // string value = null;

   var exception = Assert.Throws(expectedException.Type, () => DoSomething(value));

   // void DoSomething(string value)
   // {
   //      if (value == null) 
   //         throw new ArgumentException("value is null");
   //     ...
   // }
   ```

3. Compare the exception to the expected exception.

   XUnit

   ```csharp
   Assert.Equal(expectedException, exception);
   ```
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

   NUnit

   ```csharp
   Assert.That<ExpectedException>(exception, Is.EqualTo(expectedException));
   ```
   ```
   Assert.That(exception, Is.EqualTo(expectedException))
     Expected: <System.ArgumentException where
     [+] Message starts with "value"
     [-] Message contains "cannot be"
     [+] Message ends with "null">
     But was:  <System.ArgumentException: value was null
      at Expectable.Tests.ReadmeExamples.ReadmeExamples.DoSomething(String value)
      at NUnit.Framework.Assert.Throws(IResolveConstraint expression, TestDelegate code, String message, Object[] args)>
   ```

## Initialization

There are several ways to initialize an ExpectedException.  

See **Expectations** below for further options.

### Implicit Conversion from Expect&lt;TException&gt;

```csharp
ExpectedException expectedException = Expect<ArgumentException>.Where
    .MessageStartsWith("value")
    .MessageContains("cannot be", StringComparison.OrdinalIgnoreCase)
    .MessageEndsWith("null");
```
This is the most succinct and versatile way to initialize an ExpectedException that has expectations.

This example expects
* The exception to be an ArgumentException
* The exception message to 
   * start with "value"
   * contain "cannot be" (case-insensitive)
   * end with "null"

### Implicit Conversion from exception type

```csharp
ExpectedException expectedException = typeof(ArgumentException);
```
This is useful when only the exception type is required.

This example expects
* The exception to be an ArgumentException

### Implicit Conversion from an exception instance

```csharp
ExpectedException expectedException = new ArgumentException("value cannot be null");
```
If the source exception provided was previously thrown, then the value returned by expectedException.ToString() will be sourceException.ToString().

This example expects
* The exception to be an ArgumentException
* The exception message to
    * equal "value cannot be null"

### ExpectedException(Type exceptionType, params Expectation[] expectations) Constructor

```csharp
ExpectedException expectedException = new ExpectedException(typeof(ArgumentException),
    new MessageStartsWith("value"),
    new MessageContains("cannot be", StringComparison.OrdinalIgnoreCase),
    new MessageEndsWith("null"));
```
This is the verbose implementation of **Implicit Conversion from Expect&lt;TException&gt;**.

This example expects
* The exception to be an ArgumentException
* The exception message to 
   * start with "value"
   * contain "cannot be" (case-insensitive)
   * end with "null"

### ExpectedException(Exception exception) Constructor

```csharp
ExpectedException expectedException = new ExpectedException(new ArgumentException("value cannot be null"));
```
This is the verbose implementation of **Implicit Conversion from an exception instance**. If the source exception provided was previously thrown, then the value returned by expectedException.ToString() will be sourceException.ToString().

This example expects
* The exception to be an ArgumentException
* The exception message to
    * equal "value cannot be null"

## Expectations

Expectations allow you to confirm a list of expected conditions are fulfilled by the exception.

### MessageContains
Checks that the exception message contains a specific string value.

| Parameter | Type | Required | Description | Restrictions | Default |
| - |
| value | string | yes | The string to seek. | Cannot be null or empty. | N/A |
| comparisonType | System.StringComparison? | no | One of the enumeration values that determines how the exception message and value are compared. | null or a valid StringComparison | StringComparison.Ordinal |

### MessageContainsCount
Checks that the exception message contains a specific string value a specific number of times.

| Parameter | Type | Required | Description | Restrictions | Default |
| - |
| expectedCount | int | yes | The expected number of instances of value within the exception message. | Greater than or equal to 0 | N/A |
| value | string | yes | The string to seek. | Cannot be null or empty. | N/A |
| comparisonType | System.StringComparison? | no | One of the enumeration values that determines how the exception message and value are compared. | null or a valid StringComparison | StringComparison.Ordinal |

### MessageEndsWith
Checks that the exception message ends with a specific string value.

| Parameter | Type | Required | Description | Restrictions | Default |
| - |
| value | string | yes | The string to compare to the substring at the end of the exception message. | Cannot be null or empty. | N/A |
| comparisonType | System.StringComparison? | no | One of the enumeration values that determines how the exception message and value are compared. | null or a valid StringComparison | StringComparison.Ordinal |

### MessageEquals
Checks that the exception message equals a specific string value.

| Parameter | Type | Required | Description | Restrictions | Default |
| - |
| value | string | yes | The string to compare to the exception message. | None | N/A |
| comparisonType | System.StringComparison? | no | One of the enumeration values that determines how the exception message and value are compared. | null or a valid StringComparison | StringComparison.Ordinal |

### MessageMatches
Checks that the exception message matches a specific regular expression pattern.

| Parameter | Type | Required | Description | Restrictions | Default |
| - |
| pattern | string | yes | The regular expression pattern to match. | Cannot be null or empty. Must be a valid regular expression. | N/A |
| options | System.Text.RegularExpressions.RegexOptions? | no | A bitwise combination of the enumeration values that provide options for matching. | null or a valid RegexOptions | RegexOptions.None |

### MessageStartsWith
Checks that the exception message starts with a specific string value.

| Parameter | Type | Required | Description | Restrictions | Default |
| - |
| value | string | yes | The string to compare to the substring at the start of the exception message. | Cannot be null or empty. | N/A |
| comparisonType | System.StringComparison? | no | One of the enumeration values that determines how the exception message and value are compared. | null or a valid StringComparison | StringComparison.Ordinal |

## ToString()

The value returned is different before and after comparing to a *thrown* exception.

### Before expectedException.Equals(exception)

```
System.ArgumentException where
      Message starts with "value"
      Message contains "cannot be" (ComparisonType: OrdinalIgnoreCase)
      Message ends with "null"
```

### After expectedException.Equals(exception)

```
System.ArgumentException where
  [+] Message starts with "value"
  [-] Message contains "cannot be" (ComparisonType: OrdinalIgnoreCase)
  [+] Message ends with "null"
```
*[+] expectation matched*; 
*[-] expectation not matched*

## ResetResults()

Removes any previously cached results.  The value returned by ToString() is reset to its initial value.

```csharp
expectedException.ResetResults();
```

