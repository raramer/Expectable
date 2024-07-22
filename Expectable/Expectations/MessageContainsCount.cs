using System;
using System.Collections.Generic;

namespace Expectable.Expectations;

public sealed record MessageContainsCount : Expectation
{
    private readonly StringComparison? OriginalComparisonType;

    public StringComparison ComparisonType { get; }
    public int ExpectedCount { get; }
    public string Value { get; }

    public MessageContainsCount(int expectedCount, string value, StringComparison? comparisonType = null)
    {
        ExpectedCount = Guard.AgainstNegative(expectedCount, nameof(expectedCount));
        Value = Guard.AgainstNullOrEmpty(value, nameof(value));
        ComparisonType = Guard.AgainstInvalidStringComparison(comparisonType, nameof(comparisonType)) ?? DefaultStringComparison;
        OriginalComparisonType = comparisonType;
    }

    public bool Equals(MessageContainsCount other)
    {
        if ((object)this == other)
            return true;

        return base.Equals(other)
            && EqualityComparer<StringComparison>.Default.Equals(ComparisonType, other.ComparisonType)
            && EqualityComparer<int>.Default.Equals(ExpectedCount, other.ExpectedCount)
            && EqualityComparer<string>.Default.Equals(Value, other.Value);
    }

    public override int GetHashCode()
    {
        var hashCode = base.GetHashCode();
        hashCode = hashCode * -1521134295 + EqualityComparer<StringComparison>.Default.GetHashCode(ComparisonType);
        hashCode = hashCode * -1521134295 + EqualityComparer<int>.Default.GetHashCode(ExpectedCount);
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Value);
        return hashCode;
    }

    public override bool IsMatch(Exception exception)
        => IsMatch(exception?.Message);

    public bool IsMatch(string actualMessage)
    {
        var count = 0;
        if (!string.IsNullOrEmpty(actualMessage))
        {
            var nextStartIndex = 0;
            while (true)
            {
                var index = actualMessage.IndexOf(Value, nextStartIndex, ComparisonType);
                if (index < 0)
                    break;
                count++;
                nextStartIndex = index + Value.Length;
            }
        }
        return count == ExpectedCount;
    }

    public override string ToString()
        => ToString("Message", "contains " + ExpectedCount, Value, nameof(ComparisonType), OriginalComparisonType);
}