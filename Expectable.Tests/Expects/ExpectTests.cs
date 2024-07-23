using Expectable.Expectations;
using System.Text.RegularExpressions;

namespace Expectable.Tests.Expects;

public class ExpectTests
{
    [Fact]
    public void Where()
        => When(Expectable.Expect<ArgumentException>.Where);

    [Fact]
    public void MessageContains_Value_Is_Apple()
        => When(
            expect: Expectable.Expect<ArgumentException>.Where
                .MessageContains(Data.Apple)
                .MessageContains(Data.Apple, StringComparison.Ordinal)
                .MessageContains(Data.Apple, StringComparison.OrdinalIgnoreCase),
            expectedExpectations: [
                new MessageContains(Data.Apple),
                new MessageContains(Data.Apple, StringComparison.OrdinalIgnoreCase),
            ]);

    [Fact]
    public void MessageContains_Value_Is_Empty()
        => Expect<ArgumentException>(
            action: () => Expectable.Expect<ArgumentException>.Where
                .MessageContains(Data.Empty),
            expectedMessage: ExpectedMessages.ValueMustBeNonEmpty);

    [Fact]
    public void MessageContains_Value_Is_Null()
        => Expect<ArgumentException>(
            action: () => Expectable.Expect<ArgumentException>.Where
                .MessageContains(Data.Null),
            expectedMessage: ExpectedMessages.ValueMustBeNonEmpty);

    [Fact]
    public void MessageContainsCount_Value_Is_Apple()
        => When(
            expect: Expectable.Expect<ArgumentException>.Where
                .MessageContainsCount(1, Data.Apple)
                .MessageContainsCount(1, Data.Apple, StringComparison.Ordinal)
                .MessageContainsCount(2, Data.Apple, StringComparison.OrdinalIgnoreCase)
                .MessageContainsCount(3, Data.Apple, StringComparison.OrdinalIgnoreCase),
            expectedExpectations: [
                new MessageContainsCount(1, Data.Apple),
                new MessageContainsCount(2, Data.Apple, StringComparison.OrdinalIgnoreCase),
                new MessageContainsCount(3, Data.Apple, StringComparison.OrdinalIgnoreCase),
            ]);

    [Fact]
    public void MessageContainsCount_Value_Is_Empty()
        => Expect<ArgumentException>(
            action: () => Expectable.Expect<ArgumentException>.Where
                .MessageContainsCount(2, Data.Empty),
            expectedMessage: ExpectedMessages.ValueMustBeNonEmpty);

    [Fact]
    public void MessageContainsCount_Value_Is_Null()
        => Expect<ArgumentException>(
            action: () => Expectable.Expect<ArgumentException>.Where
                .MessageContainsCount(2, Data.Null),
            expectedMessage: ExpectedMessages.ValueMustBeNonEmpty);

    [Fact]
    public void MessageEndsWith_Value_Is_Apple()
        => When(
            expect: Expectable.Expect<ArgumentException>.Where
                .MessageEndsWith(Data.Apple)
                .MessageEndsWith(Data.Apple, StringComparison.Ordinal)
                .MessageEndsWith(Data.Apple, StringComparison.OrdinalIgnoreCase),
            expectedExpectations: [
                new MessageEndsWith(Data.Apple),
                new MessageEndsWith(Data.Apple, StringComparison.OrdinalIgnoreCase),
            ]);

    [Fact]
    public void MessageEndsWith_Value_Is_Empty()
        => Expect<ArgumentException>(
            action: () => Expectable.Expect<ArgumentException>.Where
                .MessageEndsWith(Data.Empty),
            expectedMessage: ExpectedMessages.ValueMustBeNonEmpty);

    [Fact]
    public void MessageEndsWith_Value_Is_Null()
        => Expect<ArgumentException>(
            action: () => Expectable.Expect<ArgumentException>.Where
                .MessageEndsWith(Data.Null),
            expectedMessage: ExpectedMessages.ValueMustBeNonEmpty);

    [Fact]
    public void MessageEquals_Value_Is_Apple()
        => When(
            expect: Expectable.Expect<ArgumentException>.Where
                .MessageEquals(Data.Apple)
                .MessageEquals(Data.Apple, StringComparison.Ordinal)
                .MessageEquals(Data.Apple, StringComparison.OrdinalIgnoreCase),
            expectedExpectations: [
                new MessageEquals(Data.Apple),
                new MessageEquals(Data.Apple, StringComparison.OrdinalIgnoreCase),
            ]);

    [Fact]
    public void MessageEquals_Value_Is_Empty()
        => When(
            expect: Expectable.Expect<ArgumentException>.Where
                .MessageEquals(Data.Empty)
                .MessageEquals(Data.Empty, StringComparison.Ordinal)
                .MessageEquals(Data.Empty, StringComparison.OrdinalIgnoreCase),
            expectedExpectations: [
                new MessageEquals(Data.Empty),
                new MessageEquals(Data.Empty, StringComparison.OrdinalIgnoreCase),
            ]);

    [Fact]
    public void MessageEquals_Value_Is_Null()
        => When(
            expect: Expectable.Expect<ArgumentException>.Where
                .MessageEquals(Data.Null)
                .MessageEquals(Data.Null, StringComparison.Ordinal)
                .MessageEquals(Data.Null, StringComparison.OrdinalIgnoreCase),
            expectedExpectations: [
                new MessageEquals(Data.Null),
                new MessageEquals(Data.Null, StringComparison.OrdinalIgnoreCase),
            ]);

    [Fact]
    public void MessageMatches_Pattern_Is_Apple()
        => When(
            expect: Expectable.Expect<ArgumentException>.Where
                .MessageMatches(Data.Apple)
                .MessageMatches(Data.Apple, RegexOptions.None)
                .MessageMatches(Data.Apple, RegexOptions.IgnoreCase),
            expectedExpectations: [
                new MessageMatches(Data.Apple),
                new MessageMatches(Data.Apple, RegexOptions.IgnoreCase),
            ]);

    [Fact]
    public void MessageMatches_Pattern_Is_Empty()
        => Expect<ArgumentException>(
            action: () => Expectable.Expect<ArgumentException>.Where
                .MessageMatches(Data.Empty),
            expectedMessage: ExpectedMessages.PatternMustBeNonEmpty);

    [Fact]
    public void MessageMatches_Pattern_Is_Null()
        => Expect<ArgumentException>(
            action: () => Expectable.Expect<ArgumentException>.Where
                .MessageMatches(Data.Null),
            expectedMessage: ExpectedMessages.PatternMustBeNonEmpty);

    [Fact]
    public void MessageStartsWith_Value_Is_Apple()
        => When(
            expect: Expectable.Expect<ArgumentException>.Where
                .MessageStartsWith(Data.Apple)
                .MessageStartsWith(Data.Apple, StringComparison.Ordinal)
                .MessageStartsWith(Data.Apple, StringComparison.OrdinalIgnoreCase),
            expectedExpectations: [
                new MessageStartsWith(Data.Apple),
                new MessageStartsWith(Data.Apple, StringComparison.OrdinalIgnoreCase),
            ]);

    [Fact]
    public void MessageStartsWith_Value_Is_Empty()
        => Expect<ArgumentException>(
            action: () => Expectable.Expect<ArgumentException>.Where
                .MessageStartsWith(Data.Empty),
            expectedMessage: ExpectedMessages.ValueMustBeNonEmpty);

    [Fact]
    public void MessageStartsWith_Value_Is_Null()
        => Expect<ArgumentException>(
            action: () => Expectable.Expect<ArgumentException>.Where
                .MessageStartsWith(Data.Null),
            expectedMessage: ExpectedMessages.ValueMustBeNonEmpty);



    private void Expect<TException>(Action action, string expectedMessage) where TException : Exception
    {
        var exception = Assert.Throws<TException>(action);
        Assert.Equal(expectedMessage, exception.Message);
    }

    private void When<TException>(Expectable.Expect<TException> expect, params Expectation[] expectedExpectations) where TException : Exception
    {
        Assert.NotNull(expect);

        ExpectedException expectedException = expect;
        Assert.NotNull(expectedException);
        Assert.Equal(typeof(ArgumentException), expectedException.Type);

        if (expectedExpectations?.Any() == true)
        {
            Assert.NotEmpty(expectedException.Expectations);
            Assert.Equal(expectedExpectations.Length, expectedException.Expectations.Count());
            Assert.True(expectedExpectations.SequenceEqual(expectedException.Expectations));
        }
        else
        {
            Assert.Empty(expectedException.Expectations);
        }
    }
}
