using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Expectable.Expectations;

internal static class Guard
{
    public static int AgainstNegative(int value, string parameterName)
    {
        if (value < 0)
            throw new ArgumentException($"{parameterName} must be greater than or equal to 0.", parameterName);
        return value;
    }

    public static string AgainstInvalidRegexPattern(string pattern, string parameterName)
    {
        AgainstNullOrEmpty(pattern, parameterName);

        try
        {
            Regex.Match(string.Empty, pattern);
            return pattern;
        }
        catch
        {
            throw new ArgumentException($"{parameterName} must be a valid regex pattern.", parameterName);
        }
    }

    public static string AgainstNullOrEmpty(string value, string parameterName)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentException($"{parameterName} must be non-empty.", parameterName);
        return value;
    }

    public static StringComparison? AgainstInvalidStringComparison(StringComparison? value, string parameterName)
    {
        if (value.HasValue && !Enum.IsDefined(typeof(StringComparison), value.Value))
            throw new ArgumentException($@"{parameterName} must be a valid System.StringComparison value.", parameterName);
        return value;
    }

    private static readonly char[] DigitsAndMinus = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-'];

    public static RegexOptions? AgainstInvalidRegexOptions(RegexOptions? value, string parameterName)
    {
        if (value.HasValue && DigitsAndMinus.Contains(value.Value.ToString()[0]))
            throw new ArgumentException($"{parameterName} must be a valid System.Text.RegularExpressions.RegexOptions value.", parameterName);
        return value;
    }
}