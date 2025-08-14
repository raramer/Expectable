using Expectable.Expectations;
using System.Text.RegularExpressions;

namespace Expectable.Tests.Expectations;

public sealed class MessageMatchesTests : ExpectationTestBase
{
    [Theory]
    [InlineData(Data.Apple, RegexOptions.None, Data.Apple, null, true)]
    [InlineData(Data.Apple, RegexOptions.None, Data.Apple, RegexOptions.None, true)]
    [InlineData(Data.Apple, RegexOptions.None, Data.Apple, RegexOptions.IgnoreCase, false)]
    [InlineData(Data.Apple, RegexOptions.None, Data.Apple, RegexOptions.Multiline, false)]
    [InlineData(Data.Apple, RegexOptions.None, Data.Apple, RegexOptions.ExplicitCapture, false)]
    [InlineData(Data.Apple, RegexOptions.None, Data.Apple, RegexOptions.Compiled, false)]
    [InlineData(Data.Apple, RegexOptions.None, Data.Apple, RegexOptions.Singleline, false)]
    [InlineData(Data.Apple, RegexOptions.None, Data.Apple, RegexOptions.IgnorePatternWhitespace, false)]
    [InlineData(Data.Apple, RegexOptions.None, Data.Apple, RegexOptions.RightToLeft, false)]
    [InlineData(Data.Apple, RegexOptions.None, Data.Apple, RegexOptions.ECMAScript, false)]
    [InlineData(Data.Apple, RegexOptions.None, Data.Apple, RegexOptions.CultureInvariant, false)]
    [InlineData(Data.Apple, RegexOptions.None, Data.Apple, RegexOptions.NonBacktracking, false)]
    [InlineData(Data.Apple, RegexOptions.None, Data.apple, null, false)]
    [InlineData(Data.Apple, RegexOptions.None, Data.apple, RegexOptions.None, false)]
    [InlineData(Data.Apple, RegexOptions.None, Data.apple, RegexOptions.IgnoreCase, false)]
    [InlineData(Data.Apple, RegexOptions.None, Data.apple, RegexOptions.Multiline, false)]
    [InlineData(Data.Apple, RegexOptions.None, Data.apple, RegexOptions.ExplicitCapture, false)]
    [InlineData(Data.Apple, RegexOptions.None, Data.apple, RegexOptions.Compiled, false)]
    [InlineData(Data.Apple, RegexOptions.None, Data.apple, RegexOptions.Singleline, false)]
    [InlineData(Data.Apple, RegexOptions.None, Data.apple, RegexOptions.IgnorePatternWhitespace, false)]
    [InlineData(Data.Apple, RegexOptions.None, Data.apple, RegexOptions.RightToLeft, false)]
    [InlineData(Data.Apple, RegexOptions.None, Data.apple, RegexOptions.ECMAScript, false)]
    [InlineData(Data.Apple, RegexOptions.None, Data.apple, RegexOptions.CultureInvariant, false)]
    [InlineData(Data.Apple, RegexOptions.None, Data.apple, RegexOptions.NonBacktracking, false)]
    [InlineData(Data.Apple, RegexOptions.None, Data.Orange, null, false)]
    [InlineData(Data.Apple, RegexOptions.None, Data.Orange, RegexOptions.None, false)]
    [InlineData(Data.Apple, RegexOptions.None, Data.Orange, RegexOptions.IgnoreCase, false)]
    [InlineData(Data.Apple, RegexOptions.None, Data.Orange, RegexOptions.Multiline, false)]
    [InlineData(Data.Apple, RegexOptions.None, Data.Orange, RegexOptions.ExplicitCapture, false)]
    [InlineData(Data.Apple, RegexOptions.None, Data.Orange, RegexOptions.Compiled, false)]
    [InlineData(Data.Apple, RegexOptions.None, Data.Orange, RegexOptions.Singleline, false)]
    [InlineData(Data.Apple, RegexOptions.None, Data.Orange, RegexOptions.IgnorePatternWhitespace, false)]
    [InlineData(Data.Apple, RegexOptions.None, Data.Orange, RegexOptions.RightToLeft, false)]
    [InlineData(Data.Apple, RegexOptions.None, Data.Orange, RegexOptions.ECMAScript, false)]
    [InlineData(Data.Apple, RegexOptions.None, Data.Orange, RegexOptions.CultureInvariant, false)]
    [InlineData(Data.Apple, RegexOptions.None, Data.Orange, RegexOptions.NonBacktracking, false)]
    public void Equality(string value, RegexOptions? options, string otherValue, RegexOptions? otherOptions, bool expectEqual)
        => AssertEqualityWhen(
           left: options.HasValue ? new MessageMatches(value, options.Value) : new MessageMatches(value),
           right: otherOptions.HasValue ? new MessageMatches(otherValue, otherOptions.Value) : new MessageMatches(otherValue),
           expectEqual: expectEqual);

    [Fact]
    public void Options_Does_Not_Exist()
        => Expect<ArgumentException>(Data.Apple, Data.InvalidRegexOptions, ExpectedMessages.OptionsMustBeAValidRegexOptions);

    [Fact]
    public void Value_Is_An_Invalid_Regex()
        => Expect<ArgumentException>(Data.InvalidRegexPattern, null, ExpectedMessages.PatternMustBeAValidRegexPattern);

    [Theory]
    [InlineData(null, Data.Null, false)]
    [InlineData(null, Data.Empty, false)]
    [InlineData(null, Data.Whitespace, false)]
    [InlineData(null, Data.Apple, true)]
    [InlineData(null, Data.apple, false)]
    [InlineData(null, Data.Orange, false)]
    [InlineData(null, Data.AppleOrangePear, true)]
    [InlineData(null, Data.OrangeApplePear, true)]
    [InlineData(null, Data.OrangePearApple, true)]
    [InlineData(null, Data._AppleOrangePear, true)]
    [InlineData(null, Data.Apple_OrangePear, true)]
    [InlineData(null, Data.AppleOrangePear_, true)]
    [InlineData(null, Data.Apple_apple_Apple, true)]
    [InlineData(RegexOptions.None, Data.Null, false)]
    [InlineData(RegexOptions.None, Data.Empty, false)]
    [InlineData(RegexOptions.None, Data.Whitespace, false)]
    [InlineData(RegexOptions.None, Data.Apple, true)]
    [InlineData(RegexOptions.None, Data.apple, false)]
    [InlineData(RegexOptions.None, Data.Orange, false)]
    [InlineData(RegexOptions.None, Data.AppleOrangePear, true)]
    [InlineData(RegexOptions.None, Data.OrangeApplePear, true)]
    [InlineData(RegexOptions.None, Data.OrangePearApple, true)]
    [InlineData(RegexOptions.None, Data._AppleOrangePear, true)]
    [InlineData(RegexOptions.None, Data.Apple_OrangePear, true)]
    [InlineData(RegexOptions.None, Data.AppleOrangePear_, true)]
    [InlineData(RegexOptions.None, Data.Apple_apple_Apple, true)]
    [InlineData(RegexOptions.IgnoreCase, Data.Null, false)]
    [InlineData(RegexOptions.IgnoreCase, Data.Empty, false)]
    [InlineData(RegexOptions.IgnoreCase, Data.Whitespace, false)]
    [InlineData(RegexOptions.IgnoreCase, Data.Apple, true)]
    [InlineData(RegexOptions.IgnoreCase, Data.apple, true)]
    [InlineData(RegexOptions.IgnoreCase, Data.Orange, false)]
    [InlineData(RegexOptions.IgnoreCase, Data.AppleOrangePear, true)]
    [InlineData(RegexOptions.IgnoreCase, Data.OrangeApplePear, true)]
    [InlineData(RegexOptions.IgnoreCase, Data.OrangePearApple, true)]
    [InlineData(RegexOptions.IgnoreCase, Data._AppleOrangePear, true)]
    [InlineData(RegexOptions.IgnoreCase, Data.Apple_OrangePear, true)]
    [InlineData(RegexOptions.IgnoreCase, Data.AppleOrangePear_, true)]
    [InlineData(RegexOptions.IgnoreCase, Data.Apple_apple_Apple, true)]
    public void Value_Is_Apple(RegexOptions? options, string? actualMessage, bool expectedIsMatch)
        => When(Data.Apple, options, actualMessage, expectedIsMatch);

    [Fact]
    public void Value_Is_Empty()
        => Expect<ArgumentException>(Data.Empty, null, ExpectedMessages.PatternMustBeNonEmpty);

    [Fact]
    public void Value_Is_Null()
        => Expect<ArgumentException>(Data.Null, null, ExpectedMessages.PatternMustBeNonEmpty);

    [Theory]
    [InlineData(null, Data.Null, false)]
    [InlineData(null, Data.Empty, false)]
    [InlineData(null, Data.Whitespace, true)]
    [InlineData(null, Data.Apple, false)]
    [InlineData(null, Data.apple, false)]
    [InlineData(null, Data.Orange, false)]
    [InlineData(null, Data.AppleOrangePear, false)]
    [InlineData(null, Data.OrangeApplePear, false)]
    [InlineData(null, Data.OrangePearApple, false)]
    [InlineData(null, Data._AppleOrangePear, true)]
    [InlineData(null, Data.Apple_OrangePear, true)]
    [InlineData(null, Data.AppleOrangePear_, true)]
    [InlineData(null, Data.Apple_apple_Apple, true)]
    [InlineData(RegexOptions.None, Data.Null, false)]
    [InlineData(RegexOptions.None, Data.Empty, false)]
    [InlineData(RegexOptions.None, Data.Whitespace, true)]
    [InlineData(RegexOptions.None, Data.Apple, false)]
    [InlineData(RegexOptions.None, Data.apple, false)]
    [InlineData(RegexOptions.None, Data.Orange, false)]
    [InlineData(RegexOptions.None, Data.AppleOrangePear, false)]
    [InlineData(RegexOptions.None, Data.OrangeApplePear, false)]
    [InlineData(RegexOptions.None, Data.OrangePearApple, false)]
    [InlineData(RegexOptions.None, Data._AppleOrangePear, true)]
    [InlineData(RegexOptions.None, Data.Apple_OrangePear, true)]
    [InlineData(RegexOptions.None, Data.AppleOrangePear_, true)]
    [InlineData(RegexOptions.None, Data.Apple_apple_Apple, true)]
    [InlineData(RegexOptions.IgnoreCase, Data.Null, false)]
    [InlineData(RegexOptions.IgnoreCase, Data.Empty, false)]
    [InlineData(RegexOptions.IgnoreCase, Data.Whitespace, true)]
    [InlineData(RegexOptions.IgnoreCase, Data.Apple, false)]
    [InlineData(RegexOptions.IgnoreCase, Data.apple, false)]
    [InlineData(RegexOptions.IgnoreCase, Data.Orange, false)]
    [InlineData(RegexOptions.IgnoreCase, Data.AppleOrangePear, false)]
    [InlineData(RegexOptions.IgnoreCase, Data.OrangeApplePear, false)]
    [InlineData(RegexOptions.IgnoreCase, Data.OrangePearApple, false)]
    [InlineData(RegexOptions.IgnoreCase, Data._AppleOrangePear, true)]
    [InlineData(RegexOptions.IgnoreCase, Data.Apple_OrangePear, true)]
    [InlineData(RegexOptions.IgnoreCase, Data.AppleOrangePear_, true)]
    [InlineData(RegexOptions.IgnoreCase, Data.Apple_apple_Apple, true)]
    public void Value_Is_WhiteSpace(RegexOptions? options, string? actualMessage, bool expectedIsMatch)
        => When(Data.Whitespace, options, actualMessage, expectedIsMatch);

    private void Expect<TException>(string? pattern, RegexOptions? options, string expectedMessage)
        where TException : Exception
    {
        // arrange
        var exception = Assert.Throws<TException>(() => options.HasValue ? new MessageMatches(pattern, options.Value) : new MessageMatches(pattern));

        // assert
        Assert.Equal(expectedMessage, exception.Message);
    }

    private void When(string pattern, RegexOptions? options, string? actualMessage, bool expectedIsMatch)
    {
        // arrange
        var messageMatches = options.HasValue ? new MessageMatches(pattern, options.Value) : new MessageMatches(pattern);

        // assert properties
        Assert.Equal(options ?? RegexOptions.None, messageMatches.Options);
        Assert.Equal(pattern, messageMatches.Pattern);

        // assert ToString()
        var expectedToString = $@"Message matches ""{pattern}""";
        if (options != null)
            expectedToString += $" (Options: {options})";
        Assert.Equal(expectedToString, messageMatches.ToString());

        // assert IsMatch
        Assert.Equal(expectedIsMatch, messageMatches.IsMatch(actualMessage));
    }
}