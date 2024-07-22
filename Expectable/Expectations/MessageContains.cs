using System;
using System.Collections.Generic;

namespace Expectable.Expectations;

/// <summary>
/// Checks that the exception message contains a specific string value.
/// </summary>
public sealed record MessageContains : Expectation
{
    private readonly StringComparison? OriginalComparisonType;

    /// <summary>
    /// One of the enumeration values that determines how the exception message and value are compared.
    /// </summary>
    public StringComparison ComparisonType { get; }

    /// <summary>
    /// The string to seek.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Defines a new MessageContains expectation.
    /// </summary>
    /// <param name="value">The string to seek.</param>
    /// <param name="comparisonType">One of the enumeration values that determines how the exception message and value are compared. (Default is StringComparison.Ordinal)</param>
    public MessageContains(string value, StringComparison? comparisonType = null)
    {
        Value = Guard.AgainstNullOrEmpty(value, nameof(value));
        ComparisonType = Guard.AgainstInvalidStringComparison(comparisonType, nameof(comparisonType)) ?? DefaultStringComparison;
        OriginalComparisonType = comparisonType;
    }

    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
    public bool Equals(MessageContains other)
    {
        if ((object)this == other)
            return true;

        return base.Equals(other)
            && EqualityComparer<StringComparison>.Default.Equals(ComparisonType, other.ComparisonType)
            && EqualityComparer<string>.Default.Equals(Value, other.Value);
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object</returns>
    public override int GetHashCode()
    {
        var hashCode = base.GetHashCode();
        hashCode = hashCode * -1521134295 + EqualityComparer<StringComparison>.Default.GetHashCode(ComparisonType);
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Value);
        return hashCode;
    }

    /// <summary>
    /// Indicates whether the exception message matches.
    /// </summary>
    /// <param name="exception">The exception to compare.</param>
    /// <returns>true if the exception message matches; otherwise, false.</returns>
    public override bool IsMatch(Exception exception)
        => IsMatch(exception?.Message);

    /// <summary>
    /// Indicates whether the exception message matches.
    /// </summary>
    /// <param name="actualMessage">The string to compare.</param>
    /// <returns>true if the exception message matches; otherwise, false.</returns>
    public bool IsMatch(string actualMessage)
        => actualMessage != null && actualMessage.IndexOf(Value, ComparisonType) >= 0;

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
        => ToString("Message", "contains", Value, nameof(ComparisonType), OriginalComparisonType);
}