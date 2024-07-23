using Expectable.Expectations;

namespace Expectable.Tests.Expectations;

public sealed class MessageStartsWithTests : ExpectationTestBase
{
    [Fact]
    public void ComparisonType_Does_Not_Exist()
        => Expect<ArgumentException>(Data.Apple, Data.InvalidStringComparison, ExpectedMessages.ComparisonTypeMustBeAValidStringComparison);

    [Theory]
    [InlineData(Data.Apple, StringComparison.Ordinal, Data.Apple, null, true)]
    [InlineData(Data.Apple, StringComparison.Ordinal, Data.Apple, StringComparison.CurrentCulture, false)]
    [InlineData(Data.Apple, StringComparison.Ordinal, Data.Apple, StringComparison.CurrentCultureIgnoreCase, false)]
    [InlineData(Data.Apple, StringComparison.Ordinal, Data.Apple, StringComparison.InvariantCulture, false)]
    [InlineData(Data.Apple, StringComparison.Ordinal, Data.Apple, StringComparison.InvariantCultureIgnoreCase, false)]
    [InlineData(Data.Apple, StringComparison.Ordinal, Data.Apple, StringComparison.Ordinal, true)]
    [InlineData(Data.Apple, StringComparison.Ordinal, Data.Apple, StringComparison.OrdinalIgnoreCase, false)]
    [InlineData(Data.Apple, StringComparison.Ordinal, Data.apple, null, false)]
    [InlineData(Data.Apple, StringComparison.Ordinal, Data.apple, StringComparison.CurrentCulture, false)]
    [InlineData(Data.Apple, StringComparison.Ordinal, Data.apple, StringComparison.CurrentCultureIgnoreCase, false)]
    [InlineData(Data.Apple, StringComparison.Ordinal, Data.apple, StringComparison.InvariantCulture, false)]
    [InlineData(Data.Apple, StringComparison.Ordinal, Data.apple, StringComparison.InvariantCultureIgnoreCase, false)]
    [InlineData(Data.Apple, StringComparison.Ordinal, Data.apple, StringComparison.Ordinal, false)]
    [InlineData(Data.Apple, StringComparison.Ordinal, Data.apple, StringComparison.OrdinalIgnoreCase, false)]
    [InlineData(Data.Apple, StringComparison.Ordinal, Data.Orange, null, false)]
    [InlineData(Data.Apple, StringComparison.Ordinal, Data.Orange, StringComparison.CurrentCulture, false)]
    [InlineData(Data.Apple, StringComparison.Ordinal, Data.Orange, StringComparison.CurrentCultureIgnoreCase, false)]
    [InlineData(Data.Apple, StringComparison.Ordinal, Data.Orange, StringComparison.InvariantCulture, false)]
    [InlineData(Data.Apple, StringComparison.Ordinal, Data.Orange, StringComparison.InvariantCultureIgnoreCase, false)]
    [InlineData(Data.Apple, StringComparison.Ordinal, Data.Orange, StringComparison.Ordinal, false)]
    [InlineData(Data.Apple, StringComparison.Ordinal, Data.Orange, StringComparison.OrdinalIgnoreCase, false)]
    public void Equality(string value, StringComparison? comparisonType, string otherValue, StringComparison? otherComparisonType, bool expectEqual)
        => AssertEqualityWhen(
           left: comparisonType.HasValue ? new MessageStartsWith(value, comparisonType.Value) : new MessageStartsWith(value),
           right: otherComparisonType.HasValue ? new MessageStartsWith(otherValue, otherComparisonType.Value) : new MessageStartsWith(otherValue),
           expectEqual: expectEqual);

    [Theory]
    [InlineData(null, Data.Null, false)]
    [InlineData(null, Data.Empty, false)]
    [InlineData(null, Data.Whitespace, false)]
    [InlineData(null, Data.Apple, true)]
    [InlineData(null, Data.apple, false)]
    [InlineData(null, Data.Orange, false)]
    [InlineData(null, Data.AppleOrangePear, true)]
    [InlineData(null, Data.OrangeApplePear, false)]
    [InlineData(null, Data.OrangePearApple, false)]
    [InlineData(null, Data._AppleOrangePear, false)]
    [InlineData(null, Data.Apple_OrangePear, true)]
    [InlineData(null, Data.AppleOrangePear_, true)]
    [InlineData(null, Data.Apple_apple_Apple, true)]
    [InlineData(StringComparison.Ordinal, Data.Null, false)]
    [InlineData(StringComparison.Ordinal, Data.Empty, false)]
    [InlineData(StringComparison.Ordinal, Data.Whitespace, false)]
    [InlineData(StringComparison.Ordinal, Data.Apple, true)]
    [InlineData(StringComparison.Ordinal, Data.apple, false)]
    [InlineData(StringComparison.Ordinal, Data.Orange, false)]
    [InlineData(StringComparison.Ordinal, Data.AppleOrangePear, true)]
    [InlineData(StringComparison.Ordinal, Data.OrangeApplePear, false)]
    [InlineData(StringComparison.Ordinal, Data.OrangePearApple, false)]
    [InlineData(StringComparison.Ordinal, Data._AppleOrangePear, false)]
    [InlineData(StringComparison.Ordinal, Data.Apple_OrangePear, true)]
    [InlineData(StringComparison.Ordinal, Data.AppleOrangePear_, true)]
    [InlineData(StringComparison.Ordinal, Data.Apple_apple_Apple, true)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Null, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Empty, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Whitespace, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Apple, true)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.apple, true)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Orange, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.AppleOrangePear, true)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.OrangeApplePear, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.OrangePearApple, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data._AppleOrangePear, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Apple_OrangePear, true)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.AppleOrangePear_, true)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Apple_apple_Apple, true)]
    public void Value_Is_Apple(StringComparison? comparisonType, string actualMessage, bool expectedIsMatch)
        => When(Data.Apple, comparisonType, actualMessage, expectedIsMatch);

    [Fact]
    public void Value_Is_Empty()
        => Expect<ArgumentException>(Data.Empty, null, ExpectedMessages.ValueMustBeNonEmpty);

    [Fact]
    public void Value_Is_Null()
        => Expect<ArgumentException>(Data.Null, null, ExpectedMessages.ValueMustBeNonEmpty);

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
    [InlineData(null, Data.Apple_OrangePear, false)]
    [InlineData(null, Data.AppleOrangePear_, false)]
    [InlineData(null, Data.Apple_apple_Apple, false)]
    [InlineData(StringComparison.Ordinal, Data.Null, false)]
    [InlineData(StringComparison.Ordinal, Data.Empty, false)]
    [InlineData(StringComparison.Ordinal, Data.Whitespace, true)]
    [InlineData(StringComparison.Ordinal, Data.Apple, false)]
    [InlineData(StringComparison.Ordinal, Data.apple, false)]
    [InlineData(StringComparison.Ordinal, Data.Orange, false)]
    [InlineData(StringComparison.Ordinal, Data.AppleOrangePear, false)]
    [InlineData(StringComparison.Ordinal, Data.OrangeApplePear, false)]
    [InlineData(StringComparison.Ordinal, Data.OrangePearApple, false)]
    [InlineData(StringComparison.Ordinal, Data._AppleOrangePear, true)]
    [InlineData(StringComparison.Ordinal, Data.Apple_OrangePear, false)]
    [InlineData(StringComparison.Ordinal, Data.AppleOrangePear_, false)]
    [InlineData(StringComparison.Ordinal, Data.Apple_apple_Apple, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Null, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Empty, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Whitespace, true)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Apple, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.apple, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Orange, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.AppleOrangePear, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.OrangeApplePear, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.OrangePearApple, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data._AppleOrangePear, true)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Apple_OrangePear, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.AppleOrangePear_, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Apple_apple_Apple, false)]
    public void Value_Is_WhiteSpace(StringComparison? comparisonType, string actualMessage, bool expectedIsMatch)
        => When(Data.Whitespace, comparisonType, actualMessage, expectedIsMatch);

    private void Expect<TException>(string? value, StringComparison? comparisonType, string expectedMessage)
        where TException : Exception
    {
        // arrange
        var exception = Assert.Throws<TException>(() => comparisonType.HasValue ? new MessageStartsWith(value, comparisonType.Value) : new MessageStartsWith(value));

        // assert
        Assert.Equal(expectedMessage, exception.Message);
    }

    private void When(string value, StringComparison? comparisonType, string actualMessage, bool expectedIsMatch)
    {
        // arrange
        var messageStartsWith = comparisonType.HasValue ? new MessageStartsWith(value, comparisonType.Value) : new MessageStartsWith(value);

        // assert properties
        Assert.Equal(comparisonType ?? StringComparison.Ordinal, messageStartsWith.ComparisonType);
        Assert.Equal(value, messageStartsWith.Value);

        // assert ToString()
        var expectedToString = $@"Message starts with ""{value}""";
        if (comparisonType != null)
            expectedToString += $" (ComparisonType: {comparisonType})";
        Assert.Equal(expectedToString, messageStartsWith.ToString());

        // assert IsMatch
        Assert.Equal(expectedIsMatch, messageStartsWith.IsMatch(actualMessage));
    }
}