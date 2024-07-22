using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Expectable.Expectations;

namespace Expectable;

public sealed class Expect<TException> where TException : Exception
{
    public static Expect<TException> Where
        => new Expect<TException>();

    public static implicit operator ExpectedException(Expect<TException> expectedException)
        => new ExpectedException(typeof(TException), expectedException._expectations.ToArray());

    private Expect() { }

    private List<Expectation> _expectations = new List<Expectation>();

    /// <summary>
    /// Checks that the exception message contains a specific string value.
    /// </summary>
    /// <param name="value">The string to seek.</param>
    /// <param name="comparisonType">One of the enumeration values that determines how the exception message and value are compared. (Default is StringComparison.Ordinal)</param>
    /// <returns>Expect<typeparamref name="TException"/></returns>
    public Expect<TException> MessageContains(string value, StringComparison? comparisonType = null)
        => AddExpectation(new MessageContains(value, comparisonType));

    /// <summary>
    /// Checks that the exception message contains a specific string value a specific number of times.
    /// </summary>
    /// <param name="expectedCount">The expected number of instances of value within the exception message.</param>
    /// <param name="value">The string to seek.</param>
    /// <param name="comparisonType">One of the enumeration values that determines how the exception message and value are compared. (Default is StringComparison.Ordinal)</param>
    /// <returns>Expe</returns>
    public Expect<TException> MessageContainsCount(int expectedCount, string value, StringComparison? comparisonType = null)
        => AddExpectation(new MessageContainsCount(expectedCount, value, comparisonType));

    /// <summary>
    /// Checks that the exception message ends with a specific string value.
    /// </summary>
    /// <param name="value">The string to compare to the substring at the end of the exception message.</param>
    /// <param name="comparisonType">One of the enumeration values that determines how the exception message and value are compared. (Default is StringComparison.Ordinal)</param>
    /// <returns>Expect<typeparamref name="TException"/></returns>
    public Expect<TException> MessageEndsWith(string value, StringComparison? comparisonType = null)
        => AddExpectation(new MessageEndsWith(value, comparisonType));

    /// <summary>
    /// Checks that the exception message equals a specific string value.
    /// </summary>
    /// <param name="value">The string to compare to the exception message.</param>
    /// <param name="comparisonType">One of the enumeration values that determines how the exception message and value are compared. (Default is StringComparison.Ordinal)</param>
    /// <returns>Expect<typeparamref name="TException"/></returns>
    public Expect<TException> MessageEquals(string value, StringComparison? comparisonType = null)
        => AddExpectation(new MessageEquals(value, comparisonType));

    /// <summary>
    /// Checks that the exception message matches a specific regular expression pattern.
    /// </summary>
    /// <param name="pattern">The regular expression pattern to match.</param>
    /// <param name="options">A bitwise combination of the enumeration values that provide options for matching. (Default is RegexOptions.None)</param>
    /// <returns></returns>
    public Expect<TException> MessageMatches(string pattern, RegexOptions? options = null)
        => AddExpectation(new MessageMatches(pattern, options));

    /// <summary>
    /// Checks that the exception message starts with a specific string value.
    /// </summary>
    /// <param name="value">The string to compare to the substring at the start of the exception message.</param>
    /// <param name="comparisonType">One of the enumeration values that determines how the exception message and value are compared. (Default is StringComparison.Ordinal)</param>
    /// <returns>Expect<typeparamref name="TException"/></returns>
    public Expect<TException> MessageStartsWith(string value, StringComparison? comparisonType = null)
        => AddExpectation(new MessageStartsWith(value, comparisonType));

    private Expect<TException> AddExpectation(Expectation expectation)
    {
        _expectations.Add(expectation);
        return this;
    }
}
