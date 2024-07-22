using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Expectable.Expectations;

public abstract record Expectation
{
    protected const StringComparison DefaultStringComparison = StringComparison.Ordinal;
    protected const RegexOptions DefaultRegexOptions = RegexOptions.None;

    public abstract bool IsMatch(Exception exception);

    protected string ToString<TOption>(string subject, string action, string value, string optionName, TOption option)
    {
        var toString = new StringBuilder($"{subject} {action} ");
        toString.Append(value == null ? "null" : $@"""{value}""");
        if (option != null)
            toString.Append($" ({optionName}: {option})");
        return toString.ToString();
    }
}
