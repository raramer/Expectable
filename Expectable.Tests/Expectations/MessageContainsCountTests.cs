﻿using Expectable.Expectations;

namespace Expectable.Tests.Expectations;

public sealed class MessageContainsCountTests : ExpectationTestBase
{

    [Fact]
    public void ComparisonType_Does_Not_Exist()
        => Expect<ArgumentException>(2, Data.Apple, Data.InvalidStringComparison, ExpectedMessages.ComparisonTypeMustBeAValidStringComparison);

    [Theory]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 0, Data.Apple, null, true)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 0, Data.Apple, StringComparison.CurrentCulture, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 0, Data.Apple, StringComparison.CurrentCultureIgnoreCase, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 0, Data.Apple, StringComparison.InvariantCulture, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 0, Data.Apple, StringComparison.InvariantCultureIgnoreCase, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 0, Data.Apple, StringComparison.Ordinal, true)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 0, Data.Apple, StringComparison.OrdinalIgnoreCase, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 0, Data.apple, null, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 0, Data.apple, StringComparison.CurrentCulture, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 0, Data.apple, StringComparison.CurrentCultureIgnoreCase, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 0, Data.apple, StringComparison.InvariantCulture, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 0, Data.apple, StringComparison.InvariantCultureIgnoreCase, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 0, Data.apple, StringComparison.Ordinal, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 0, Data.apple, StringComparison.OrdinalIgnoreCase, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 0, Data.Orange, null, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 0, Data.Orange, StringComparison.CurrentCulture, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 0, Data.Orange, StringComparison.CurrentCultureIgnoreCase, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 0, Data.Orange, StringComparison.InvariantCulture, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 0, Data.Orange, StringComparison.InvariantCultureIgnoreCase, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 0, Data.Orange, StringComparison.Ordinal, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 0, Data.Orange, StringComparison.OrdinalIgnoreCase, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 1, Data.Apple, null, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 1, Data.Apple, StringComparison.CurrentCulture, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 1, Data.Apple, StringComparison.CurrentCultureIgnoreCase, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 1, Data.Apple, StringComparison.InvariantCulture, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 1, Data.Apple, StringComparison.InvariantCultureIgnoreCase, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 1, Data.Apple, StringComparison.Ordinal, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 1, Data.Apple, StringComparison.OrdinalIgnoreCase, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 1, Data.apple, null, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 1, Data.apple, StringComparison.CurrentCulture, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 1, Data.apple, StringComparison.CurrentCultureIgnoreCase, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 1, Data.apple, StringComparison.InvariantCulture, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 1, Data.apple, StringComparison.InvariantCultureIgnoreCase, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 1, Data.apple, StringComparison.Ordinal, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 1, Data.apple, StringComparison.OrdinalIgnoreCase, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 1, Data.Orange, null, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 1, Data.Orange, StringComparison.CurrentCulture, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 1, Data.Orange, StringComparison.CurrentCultureIgnoreCase, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 1, Data.Orange, StringComparison.InvariantCulture, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 1, Data.Orange, StringComparison.InvariantCultureIgnoreCase, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 1, Data.Orange, StringComparison.Ordinal, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 1, Data.Orange, StringComparison.OrdinalIgnoreCase, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 2, Data.Apple, null, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 2, Data.Apple, StringComparison.CurrentCulture, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 2, Data.Apple, StringComparison.CurrentCultureIgnoreCase, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 2, Data.Apple, StringComparison.InvariantCulture, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 2, Data.Apple, StringComparison.InvariantCultureIgnoreCase, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 2, Data.Apple, StringComparison.Ordinal, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 2, Data.Apple, StringComparison.OrdinalIgnoreCase, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 2, Data.apple, null, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 2, Data.apple, StringComparison.CurrentCulture, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 2, Data.apple, StringComparison.CurrentCultureIgnoreCase, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 2, Data.apple, StringComparison.InvariantCulture, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 2, Data.apple, StringComparison.InvariantCultureIgnoreCase, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 2, Data.apple, StringComparison.Ordinal, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 2, Data.apple, StringComparison.OrdinalIgnoreCase, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 2, Data.Orange, null, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 2, Data.Orange, StringComparison.CurrentCulture, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 2, Data.Orange, StringComparison.CurrentCultureIgnoreCase, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 2, Data.Orange, StringComparison.InvariantCulture, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 2, Data.Orange, StringComparison.InvariantCultureIgnoreCase, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 2, Data.Orange, StringComparison.Ordinal, false)]
    [InlineData(0, Data.Apple, StringComparison.Ordinal, 2, Data.Orange, StringComparison.OrdinalIgnoreCase, false)]
    public void Equality(int expectedCount, string value, StringComparison? comparisonType, int otherExpectedCount, string otherValue, StringComparison? otherComparisonType, bool expectEqual)
        => AssertEqualityWhen(
           left: new MessageContainsCount(expectedCount, value, comparisonType),
           right: new MessageContainsCount(otherExpectedCount, otherValue, otherComparisonType),
           expectEqual: expectEqual);

    [Fact]
    public void ExpectedCount_Is_Negative()
        => Expect<ArgumentException>(-1, Data.Apple, null, ExpectedMessages.ExpectedCountMustBeGreaterThanOrEqualToZero);

    [Theory]
    [InlineData(null, Data.Null, true)]
    [InlineData(null, Data.Empty, true)]
    [InlineData(null, Data.Whitespace, true)]
    [InlineData(null, Data.Apple, false)]
    [InlineData(null, Data.apple, true)]
    [InlineData(null, Data.Orange, true)]
    [InlineData(null, Data._AppleOrangePear, false)]
    [InlineData(null, Data.Apple_OrangePear, false)]
    [InlineData(null, Data.AppleOrangePear_, false)]
    [InlineData(null, Data.AppleOrangePear, false)]
    [InlineData(null, Data.OrangeApplePear, false)]
    [InlineData(null, Data.OrangePearApple, false)]
    [InlineData(null, Data.Apple_apple_Apple, false)]
    [InlineData(StringComparison.Ordinal, Data.Null, true)]
    [InlineData(StringComparison.Ordinal, Data.Empty, true)]
    [InlineData(StringComparison.Ordinal, Data.Whitespace, true)]
    [InlineData(StringComparison.Ordinal, Data.Apple, false)]
    [InlineData(StringComparison.Ordinal, Data.apple, true)]
    [InlineData(StringComparison.Ordinal, Data.Orange, true)]
    [InlineData(StringComparison.Ordinal, Data._AppleOrangePear, false)]
    [InlineData(StringComparison.Ordinal, Data.Apple_OrangePear, false)]
    [InlineData(StringComparison.Ordinal, Data.AppleOrangePear_, false)]
    [InlineData(StringComparison.Ordinal, Data.AppleOrangePear, false)]
    [InlineData(StringComparison.Ordinal, Data.OrangeApplePear, false)]
    [InlineData(StringComparison.Ordinal, Data.OrangePearApple, false)]
    [InlineData(StringComparison.Ordinal, Data.Apple_apple_Apple, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Null, true)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Empty, true)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Whitespace, true)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Apple, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.apple, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Orange, true)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data._AppleOrangePear, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Apple_OrangePear, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.AppleOrangePear_, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.AppleOrangePear, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.OrangeApplePear, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.OrangePearApple, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Apple_apple_Apple, false)]
    public void Value_Is_Apple_ExpectedCount_Is_0(StringComparison? comparisonType, string actualMessage, bool expectedIsMatch)
        => When(0, Data.Apple, comparisonType, actualMessage, expectedIsMatch);

    [Theory]
    [InlineData(null, Data.Null, false)]
    [InlineData(null, Data.Empty, false)]
    [InlineData(null, Data.Whitespace, false)]
    [InlineData(null, Data.Apple, true)]
    [InlineData(null, Data.apple, false)]
    [InlineData(null, Data.Orange, false)]
    [InlineData(null, Data._AppleOrangePear, true)]
    [InlineData(null, Data.Apple_OrangePear, true)]
    [InlineData(null, Data.AppleOrangePear_, true)]
    [InlineData(null, Data.AppleOrangePear, true)]
    [InlineData(null, Data.OrangeApplePear, true)]
    [InlineData(null, Data.OrangePearApple, true)]
    [InlineData(null, Data.Apple_apple_Apple, false)]
    [InlineData(StringComparison.Ordinal, Data.Null, false)]
    [InlineData(StringComparison.Ordinal, Data.Empty, false)]
    [InlineData(StringComparison.Ordinal, Data.Whitespace, false)]
    [InlineData(StringComparison.Ordinal, Data.Apple, true)]
    [InlineData(StringComparison.Ordinal, Data.apple, false)]
    [InlineData(StringComparison.Ordinal, Data.Orange, false)]
    [InlineData(StringComparison.Ordinal, Data._AppleOrangePear, true)]
    [InlineData(StringComparison.Ordinal, Data.Apple_OrangePear, true)]
    [InlineData(StringComparison.Ordinal, Data.AppleOrangePear_, true)]
    [InlineData(StringComparison.Ordinal, Data.AppleOrangePear, true)]
    [InlineData(StringComparison.Ordinal, Data.OrangeApplePear, true)]
    [InlineData(StringComparison.Ordinal, Data.OrangePearApple, true)]
    [InlineData(StringComparison.Ordinal, Data.Apple_apple_Apple, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Null, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Empty, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Whitespace, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Apple, true)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.apple, true)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Orange, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data._AppleOrangePear, true)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Apple_OrangePear, true)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.AppleOrangePear_, true)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.AppleOrangePear, true)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.OrangeApplePear, true)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.OrangePearApple, true)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Apple_apple_Apple, false)]
    public void Value_Is_Apple_ExpectedCount_Is_1(StringComparison? comparisonType, string actualMessage, bool expectedIsMatch)
        => When(1, Data.Apple, comparisonType, actualMessage, expectedIsMatch);

    [Theory]
    [InlineData(null, Data.Null, false)]
    [InlineData(null, Data.Empty, false)]
    [InlineData(null, Data.Whitespace, false)]
    [InlineData(null, Data.Apple, false)]
    [InlineData(null, Data.apple, false)]
    [InlineData(null, Data.Orange, false)]
    [InlineData(null, Data._AppleOrangePear, false)]
    [InlineData(null, Data.Apple_OrangePear, false)]
    [InlineData(null, Data.AppleOrangePear_, false)]
    [InlineData(null, Data.AppleOrangePear, false)]
    [InlineData(null, Data.OrangeApplePear, false)]
    [InlineData(null, Data.OrangePearApple, false)]
    [InlineData(null, Data.Apple_apple_Apple, true)]
    [InlineData(StringComparison.Ordinal, Data.Null, false)]
    [InlineData(StringComparison.Ordinal, Data.Empty, false)]
    [InlineData(StringComparison.Ordinal, Data.Whitespace, false)]
    [InlineData(StringComparison.Ordinal, Data.Apple, false)]
    [InlineData(StringComparison.Ordinal, Data.apple, false)]
    [InlineData(StringComparison.Ordinal, Data.Orange, false)]
    [InlineData(StringComparison.Ordinal, Data._AppleOrangePear, false)]
    [InlineData(StringComparison.Ordinal, Data.Apple_OrangePear, false)]
    [InlineData(StringComparison.Ordinal, Data.AppleOrangePear_, false)]
    [InlineData(StringComparison.Ordinal, Data.AppleOrangePear, false)]
    [InlineData(StringComparison.Ordinal, Data.OrangeApplePear, false)]
    [InlineData(StringComparison.Ordinal, Data.OrangePearApple, false)]
    [InlineData(StringComparison.Ordinal, Data.Apple_apple_Apple, true)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Null, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Empty, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Whitespace, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Apple, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.apple, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Orange, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data._AppleOrangePear, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Apple_OrangePear, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.AppleOrangePear_, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.AppleOrangePear, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.OrangeApplePear, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.OrangePearApple, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Apple_apple_Apple, false)]
    public void Value_Is_Apple_ExpectedCount_Is_2(StringComparison? comparisonType, string actualMessage, bool expectedIsMatch)
        => When(2, Data.Apple, comparisonType, actualMessage, expectedIsMatch);

    [Fact]
    public void Value_Is_Empty()
        => Expect<ArgumentException>(2, Data.Empty, null, ExpectedMessages.ValueMustBeNonEmpty);

    [Fact]
    public void Value_Is_Null()
        => Expect<ArgumentException>(2, Data.Null, null, ExpectedMessages.ValueMustBeNonEmpty);

    [Theory]
    [InlineData(null, Data.Null, true)]
    [InlineData(null, Data.Empty, true)]
    [InlineData(null, Data.Whitespace, false)]
    [InlineData(null, Data.Apple, true)]
    [InlineData(null, Data.apple, true)]
    [InlineData(null, Data.Orange, true)]
    [InlineData(null, Data._AppleOrangePear, false)]
    [InlineData(null, Data.Apple_OrangePear, false)]
    [InlineData(null, Data.AppleOrangePear_, false)]
    [InlineData(null, Data.AppleOrangePear, true)]
    [InlineData(null, Data.OrangeApplePear, true)]
    [InlineData(null, Data.OrangePearApple, true)]
    [InlineData(null, Data.Apple_apple_Apple, false)]
    [InlineData(StringComparison.Ordinal, Data.Null, true)]
    [InlineData(StringComparison.Ordinal, Data.Empty, true)]
    [InlineData(StringComparison.Ordinal, Data.Whitespace, false)]
    [InlineData(StringComparison.Ordinal, Data.Apple, true)]
    [InlineData(StringComparison.Ordinal, Data.apple, true)]
    [InlineData(StringComparison.Ordinal, Data.Orange, true)]
    [InlineData(StringComparison.Ordinal, Data._AppleOrangePear, false)]
    [InlineData(StringComparison.Ordinal, Data.Apple_OrangePear, false)]
    [InlineData(StringComparison.Ordinal, Data.AppleOrangePear_, false)]
    [InlineData(StringComparison.Ordinal, Data.AppleOrangePear, true)]
    [InlineData(StringComparison.Ordinal, Data.OrangeApplePear, true)]
    [InlineData(StringComparison.Ordinal, Data.OrangePearApple, true)]
    [InlineData(StringComparison.Ordinal, Data.Apple_apple_Apple, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Null, true)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Empty, true)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Whitespace, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Apple, true)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.apple, true)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Orange, true)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data._AppleOrangePear, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Apple_OrangePear, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.AppleOrangePear_, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.AppleOrangePear, true)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.OrangeApplePear, true)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.OrangePearApple, true)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Apple_apple_Apple, false)]
    public void Value_Is_Whitespace_ExpectedCount_Is_0(StringComparison? comparisonType, string actualMessage, bool expectedIsMatch)
        => When(0, Data.Whitespace, comparisonType, actualMessage, expectedIsMatch);

    [Theory]
    [InlineData(null, Data.Null, false)]
    [InlineData(null, Data.Empty, false)]
    [InlineData(null, Data.Whitespace, true)]
    [InlineData(null, Data.Apple, false)]
    [InlineData(null, Data.apple, false)]
    [InlineData(null, Data.Orange, false)]
    [InlineData(null, Data._AppleOrangePear, true)]
    [InlineData(null, Data.Apple_OrangePear, true)]
    [InlineData(null, Data.AppleOrangePear_, true)]
    [InlineData(null, Data.AppleOrangePear, false)]
    [InlineData(null, Data.OrangeApplePear, false)]
    [InlineData(null, Data.OrangePearApple, false)]
    [InlineData(null, Data.Apple_apple_Apple, false)]
    [InlineData(StringComparison.Ordinal, Data.Null, false)]
    [InlineData(StringComparison.Ordinal, Data.Empty, false)]
    [InlineData(StringComparison.Ordinal, Data.Whitespace, true)]
    [InlineData(StringComparison.Ordinal, Data.Apple, false)]
    [InlineData(StringComparison.Ordinal, Data.apple, false)]
    [InlineData(StringComparison.Ordinal, Data.Orange, false)]
    [InlineData(StringComparison.Ordinal, Data._AppleOrangePear, true)]
    [InlineData(StringComparison.Ordinal, Data.Apple_OrangePear, true)]
    [InlineData(StringComparison.Ordinal, Data.AppleOrangePear_, true)]
    [InlineData(StringComparison.Ordinal, Data.AppleOrangePear, false)]
    [InlineData(StringComparison.Ordinal, Data.OrangeApplePear, false)]
    [InlineData(StringComparison.Ordinal, Data.OrangePearApple, false)]
    [InlineData(StringComparison.Ordinal, Data.Apple_apple_Apple, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Null, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Empty, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Whitespace, true)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Apple, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.apple, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Orange, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data._AppleOrangePear, true)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Apple_OrangePear, true)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.AppleOrangePear_, true)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.AppleOrangePear, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.OrangeApplePear, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.OrangePearApple, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Apple_apple_Apple, false)]
    public void Value_Is_Whitespace_ExpectedCount_Is_1(StringComparison? comparisonType, string actualMessage, bool expectedIsMatch)
        => When(1, Data.Whitespace, comparisonType, actualMessage, expectedIsMatch);

    [Theory]
    [InlineData(null, Data.Null, false)]
    [InlineData(null, Data.Empty, false)]
    [InlineData(null, Data.Whitespace, false)]
    [InlineData(null, Data.Apple, false)]
    [InlineData(null, Data.apple, false)]
    [InlineData(null, Data.Orange, false)]
    [InlineData(null, Data._AppleOrangePear, false)]
    [InlineData(null, Data.Apple_OrangePear, false)]
    [InlineData(null, Data.AppleOrangePear_, false)]
    [InlineData(null, Data.AppleOrangePear, false)]
    [InlineData(null, Data.OrangeApplePear, false)]
    [InlineData(null, Data.OrangePearApple, false)]
    [InlineData(null, Data.Apple_apple_Apple, true)]
    [InlineData(StringComparison.Ordinal, Data.Null, false)]
    [InlineData(StringComparison.Ordinal, Data.Empty, false)]
    [InlineData(StringComparison.Ordinal, Data.Whitespace, false)]
    [InlineData(StringComparison.Ordinal, Data.Apple, false)]
    [InlineData(StringComparison.Ordinal, Data.apple, false)]
    [InlineData(StringComparison.Ordinal, Data.Orange, false)]
    [InlineData(StringComparison.Ordinal, Data._AppleOrangePear, false)]
    [InlineData(StringComparison.Ordinal, Data.Apple_OrangePear, false)]
    [InlineData(StringComparison.Ordinal, Data.AppleOrangePear_, false)]
    [InlineData(StringComparison.Ordinal, Data.AppleOrangePear, false)]
    [InlineData(StringComparison.Ordinal, Data.OrangeApplePear, false)]
    [InlineData(StringComparison.Ordinal, Data.OrangePearApple, false)]
    [InlineData(StringComparison.Ordinal, Data.Apple_apple_Apple, true)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Null, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Empty, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Whitespace, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Apple, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.apple, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Orange, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data._AppleOrangePear, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Apple_OrangePear, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.AppleOrangePear_, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.AppleOrangePear, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.OrangeApplePear, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.OrangePearApple, false)]
    [InlineData(StringComparison.OrdinalIgnoreCase, Data.Apple_apple_Apple, true)]
    public void Value_Is_Whitespace_ExpectedCount_Is_2(StringComparison? comparisonType, string actualMessage, bool expectedIsMatch)
        => When(2, Data.Whitespace, comparisonType, actualMessage, expectedIsMatch);

    private void Expect<TException>(int expectedCount, string? value, StringComparison? comparisonType, string expectedMessage)
        where TException : Exception
    {
        // arrange
        var exception = Assert.Throws<TException>(() => new MessageContainsCount(expectedCount, value, comparisonType));

        // assert
        Assert.Equal(expectedMessage, exception.Message);
    }

    private void When(int expectedCount, string value, StringComparison? comparisonType, string actualMessage, bool expectedIsMatch)
    {
        // arrange
        var messageContainsCount = new MessageContainsCount(expectedCount, value, comparisonType);

        // assert properties
        Assert.Equal(comparisonType ?? StringComparison.Ordinal, messageContainsCount.ComparisonType);
        Assert.Equal(value, messageContainsCount.Value);

        // assert ToString()
        var expectedToString = $@"Message contains {expectedCount} ""{value}""";
        if (comparisonType != null)
            expectedToString += $" (ComparisonType: {comparisonType})";
        Assert.Equal(expectedToString, messageContainsCount.ToString());

        // assert IsMatch
        Assert.Equal(expectedIsMatch, messageContainsCount.IsMatch(actualMessage));
    }
}