using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Expectable.Expectations;

/// <summary>
/// Checks that the exception message matches a specific regular expression pattern.
/// </summary>
public sealed record MessageMatches : Expectation
{
    private readonly RegexOptions? OriginalOptions;

    /// <summary>
    /// A bitwise combination of the enumeration values that provide options for matching.
    /// </summary>
    public RegexOptions Options { get; }

    /// <summary>
    /// The regular expression pattern to match.
    /// </summary>
    public string Pattern { get; }

    /// <summary>
    /// Defines a new MessageMatches expectation.
    /// </summary>
    /// <param name="pattern">The regular expression pattern to match.</param>
    /// <param name="options">A bitwise combination of the enumeration values that provide options for matching. (Default is RegexOptions.None)</param>
    public MessageMatches(string pattern, RegexOptions? options = null)
    {
        Pattern = Guard.AgainstInvalidRegexPattern(pattern, nameof(pattern));
        Options = Guard.AgainstInvalidRegexOptions(options, nameof(options)) ?? DefaultRegexOptions;
        OriginalOptions = options;
    }

    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
    public bool Equals(MessageMatches other)
    {
        if ((object)this == other)
            return true;

        return base.Equals(other)
            && EqualityComparer<RegexOptions>.Default.Equals(Options, other.Options)
            && EqualityComparer<string>.Default.Equals(Pattern, other.Pattern);
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object</returns>
    public override int GetHashCode()
    {
        var hashCode = base.GetHashCode();
        hashCode = hashCode * -1521134295 + EqualityComparer<RegexOptions>.Default.GetHashCode(Options);
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Pattern);
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
        => actualMessage != null && Regex.IsMatch(actualMessage, Pattern, Options);

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString()
        => ToString("Message", "matches", Pattern, nameof(Options), OriginalOptions);
}