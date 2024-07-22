namespace Expectable.Tests;

internal static class ExpectedMessages
{
    internal const string ComparisonTypeMustBeAValidStringComparison = "comparisonType must be a valid System.StringComparison value. (Parameter 'comparisonType')";

    internal const string ExceptionCannotBeNull = "exception cannot be null. (Parameter 'exception')";

    internal const string ExceptionTypeCannotBeNull = "exceptionType cannot be null. (Parameter 'exceptionType')";

    internal const string ExceptionTypeMustDeriveFromSystemException = "exceptionType must derive from System.Exception. (Parameter 'exceptionType')";

    internal const string ExpectedCountMustBeGreaterThanOrEqualToZero = "expectedCount must be greater than or equal to 0. (Parameter 'expectedCount')";

    internal const string OptionsMustBeAValidRegexOptions = "options must be a valid System.Text.RegularExpressions.RegexOptions value. (Parameter 'options')";

    internal const string PatternMustBeAValidRegexPattern = "pattern must be a valid regex pattern. (Parameter 'pattern')";

    internal const string PatternMustBeNonEmpty = "pattern must be non-empty. (Parameter 'pattern')";

    internal const string ValueMustBeNonEmpty = "value must be non-empty. (Parameter 'value')";
}