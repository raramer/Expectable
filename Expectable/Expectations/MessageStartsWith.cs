using System;
using System.Collections.Generic;

namespace Expectable.Expectations;

public sealed record MessageStartsWith : Expectation
{
    private readonly StringComparison? OriginalComparisonType;

    public StringComparison ComparisonType { get; }
    public string Value { get; }

    public MessageStartsWith(string value, StringComparison? comparisonType = null)
    {
        Value = Guard.AgainstNullOrEmpty(value, nameof(value));
        ComparisonType = Guard.AgainstInvalidStringComparison(comparisonType, nameof(comparisonType)) ?? DefaultStringComparison;
        OriginalComparisonType = comparisonType;
    }

    public bool Equals(MessageStartsWith other)
    {
        if ((object)this == other)
            return true;

        return base.Equals(other)
            && EqualityComparer<StringComparison>.Default.Equals(ComparisonType, other.ComparisonType)
            && EqualityComparer<string>.Default.Equals(Value, other.Value);
    }

    public override int GetHashCode()
    {
        var hashCode = base.GetHashCode();
        hashCode = hashCode * -1521134295 + EqualityComparer<StringComparison>.Default.GetHashCode(ComparisonType);
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Value);
        return hashCode;
    }

    public override bool IsMatch(Exception exception)
        => IsMatch(exception?.Message);

    public bool IsMatch(string actualMessage)
        => actualMessage != null && actualMessage.StartsWith(Value, ComparisonType);

    public override string ToString()
        => ToString("Message", "starts with", Value, nameof(ComparisonType), OriginalComparisonType);
}