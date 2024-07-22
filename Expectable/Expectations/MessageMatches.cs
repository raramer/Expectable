using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Expectable.Expectations;

public sealed record MessageMatches : Expectation
{
    private readonly RegexOptions? OriginalOptions;

    public RegexOptions Options { get; }
    public string Pattern { get; }

    public MessageMatches(string pattern, RegexOptions? options = null)
    {
        Pattern = Guard.AgainstInvalidRegexPattern(pattern, nameof(pattern));
        Options = Guard.AgainstInvalidRegexOptions(options, nameof(options)) ?? DefaultRegexOptions;
        OriginalOptions = options;
    }

    public bool Equals(MessageMatches other)
    {
        if ((object)this == other)
            return true;

        return base.Equals(other)
            && EqualityComparer<RegexOptions>.Default.Equals(Options, other.Options)
            && EqualityComparer<string>.Default.Equals(Pattern, other.Pattern);
    }

    public override int GetHashCode()
    {
        var hashCode = base.GetHashCode();
        hashCode = hashCode * -1521134295 + EqualityComparer<RegexOptions>.Default.GetHashCode(Options);
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Pattern);
        return hashCode;
    }

    public override bool IsMatch(Exception exception)
        => IsMatch(exception?.Message);

    public bool IsMatch(string actualMessage)
        => actualMessage != null && Regex.IsMatch(actualMessage, Pattern, Options);

    public override string ToString()
        => ToString("Message", "matches", Pattern, nameof(Options), OriginalOptions);
}