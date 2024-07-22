using System.Text;
using System.Text.RegularExpressions;
using Expectable.Expectations;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Xunit.Abstractions;

namespace Expectable.Tests.ExpectedExceptions;

public class ExpectedExceptionTests
{
    private ITestOutputHelper _testOutput;

    public ExpectedExceptionTests(ITestOutputHelper testOutput)
    {
        _testOutput = testOutput;
    }

    [Theory]
    [InlineData(Data.Null, false)]
    [InlineData(Data.Empty, false)]
    [InlineData(Data.Whitespace, false)]
    [InlineData(Data.Apple, false)]
    [InlineData(Data.apple, false)]
    [InlineData(Data.Orange, false)]
    [InlineData(Data.AppleOrangePear, true)]
    [InlineData(Data.OrangeApplePear, false)]
    [InlineData(Data.OrangePearApple, false)]
    [InlineData(Data._AppleOrangePear, false)]
    [InlineData(Data.Apple_OrangePear, false)]
    [InlineData(Data.AppleOrangePear_, false)]
    [InlineData(Data.Apple_apple_Apple, false)]
    public void Exception_Is_Not_Null(string message, bool expectedEquals)
        => When(
            expectedException: new ExpectedException(new ArgumentException(Data.AppleOrangePear)),
            expectedType: typeof(ArgumentException),
            expectedExpectationsCount: 1,
            expectedExpectations: [new MessageEquals(Data.AppleOrangePear)],
            testSameExceptionType: (new ArgumentException(message), expectedEquals),
            testDifferentExceptionType: new Exception(Data.AppleOrangePear));

    [Theory]
    [InlineData(Data.Null, false)]
    [InlineData(Data.Empty, false)]
    [InlineData(Data.Whitespace, false)]
    [InlineData(Data.Apple, true)]
    [InlineData(Data.apple, false)]
    [InlineData(Data.Orange, false)]
    [InlineData(Data.AppleOrangePear, true)]
    [InlineData(Data.OrangeApplePear, true)]
    [InlineData(Data.OrangePearApple, true)]
    [InlineData(Data._AppleOrangePear, true)]
    [InlineData(Data.Apple_OrangePear, true)]
    [InlineData(Data.AppleOrangePear_, true)]
    [InlineData(Data.Apple_apple_Apple, true)]
    public void Expectations_Contains_Duplicate_Expectations(string message, bool expectedEquals)
        => When(
            exceptionType: typeof(ArgumentException),
            expectations: [
                new MessageMatches(Data.Apple),
                new MessageMatches(Data.Apple),
                new MessageMatches(Data.Apple, RegexOptions.None)
            ],
            expectedExpectationsCount: 1,
            testSameExceptionType: (new ArgumentException(message), expectedEquals),
            testDifferentExceptionType: new Exception(message));

    [Theory]
    [InlineData(Data.Null, false)]
    [InlineData(Data.Empty, false)]
    [InlineData(Data.Whitespace, false)]
    [InlineData(Data.Apple, true)]
    [InlineData(Data.apple, false)]
    [InlineData(Data.Orange, false)]
    [InlineData(Data.AppleOrangePear, true)]
    [InlineData(Data.OrangeApplePear, false)]
    [InlineData(Data.OrangePearApple, false)]
    [InlineData(Data._AppleOrangePear, false)]
    [InlineData(Data.Apple_OrangePear, false)]
    [InlineData(Data.AppleOrangePear_, false)]
    [InlineData(Data.Apple_apple_Apple, false)]
    public void Expectations_Contains_Null_Expectations(string message, bool expectedEquals)
        => When(
            exceptionType: typeof(ArgumentException),
            expectations: [
                new MessageStartsWith(Data.Apple),
                null!,
                new MessageContainsCount(0, Data.Whitespace)
            ],
            expectedExpectationsCount: 2,
            testSameExceptionType: (new ArgumentException(message), expectedEquals),
            testDifferentExceptionType: new Exception(message));

    [Theory]
    [InlineData(Data.Null, false)]
    [InlineData(Data.Empty, false)]
    [InlineData(Data.Whitespace, false)]
    [InlineData(Data.Apple, true)]
    [InlineData(Data.apple, true)]
    [InlineData(Data.Orange, false)]
    [InlineData(Data.AppleOrangePear, false)]
    [InlineData(Data.OrangeApplePear, false)]
    [InlineData(Data.OrangePearApple, false)]
    [InlineData(Data._AppleOrangePear, false)]
    [InlineData(Data.Apple_OrangePear, false)]
    [InlineData(Data.AppleOrangePear_, false)]
    [InlineData(Data.Apple_apple_Apple, false)]
    public void Expectations_Contains_Single_Expectation(string message, bool expectedEquals)
        => When(exceptionType: typeof(ArgumentException),
            expectations: [
                new MessageEquals(Data.Apple, StringComparison.OrdinalIgnoreCase)
            ],
            expectedExpectationsCount: 1,
            testSameExceptionType: (new ArgumentException(message), expectedEquals),
            testDifferentExceptionType: new Exception(message));

    [Theory]
    [InlineData(Data.Null, false)]
    [InlineData(Data.Empty, false)]
    [InlineData(Data.Whitespace, false)]
    [InlineData(Data.Apple, false)]
    [InlineData(Data.apple, false)]
    [InlineData(Data.Orange, false)]
    [InlineData(Data.AppleOrangePear, true)]
    [InlineData(Data.OrangeApplePear, true)]
    [InlineData(Data.OrangePearApple, true)]
    [InlineData(Data._AppleOrangePear, true)]
    [InlineData(Data.Apple_OrangePear, true)]
    [InlineData(Data.AppleOrangePear_, true)]
    [InlineData(Data.Apple_apple_Apple, false)]
    public void Expectations_Contains_Unique_Expectations(string message, bool expectedEquals)
        => When(exceptionType: typeof(ArgumentException),
            expectations: [
                new MessageContains(Data.Apple),
                new MessageContains(Data.Orange),
                new MessageContains(Data.Pear),
            ],
            expectedExpectationsCount: 3,
            testSameExceptionType: (new ArgumentException(message), expectedEquals),
            testDifferentExceptionType: new Exception(message));

    [Theory]
    [InlineData(Data.Null, true)]
    [InlineData(Data.Empty, true)]
    [InlineData(Data.Whitespace, true)]
    [InlineData(Data.Apple, true)]
    [InlineData(Data.apple, true)]
    [InlineData(Data.Orange, true)]
    [InlineData(Data.AppleOrangePear, true)]
    [InlineData(Data.OrangeApplePear, true)]
    [InlineData(Data.OrangePearApple, true)]
    [InlineData(Data._AppleOrangePear, true)]
    [InlineData(Data.Apple_OrangePear, true)]
    [InlineData(Data.AppleOrangePear_, true)]
    [InlineData(Data.Apple_apple_Apple, true)]
    public void Expectations_Is_Empty(string message, bool expectedEquals)
        => When(exceptionType: typeof(ArgumentException),
            expectations: Array.Empty<Expectation>(),
            expectedExpectationsCount: 0,
            testSameExceptionType: (new ArgumentException(message), expectedEquals),
            testDifferentExceptionType: new Exception(message));

    [Theory]
    [InlineData(Data.Null, true)]
    [InlineData(Data.Empty, true)]
    [InlineData(Data.Whitespace, true)]
    [InlineData(Data.Apple, true)]
    [InlineData(Data.apple, true)]
    [InlineData(Data.Orange, true)]
    [InlineData(Data.AppleOrangePear, true)]
    [InlineData(Data.OrangeApplePear, true)]
    [InlineData(Data.OrangePearApple, true)]
    [InlineData(Data._AppleOrangePear, true)]
    [InlineData(Data.Apple_OrangePear, true)]
    [InlineData(Data.AppleOrangePear_, true)]
    [InlineData(Data.Apple_apple_Apple, true)]
    public void Expectations_Is_Null(string message, bool expectedEquals)
        => When(exceptionType: typeof(ArgumentException),
            expectations: null,
            expectedExpectationsCount: 0,
            testSameExceptionType: (new ArgumentException(message), expectedEquals),
            testDifferentExceptionType: new Exception(message));

    [Theory]
    [InlineData(Data.Null, false)]
    [InlineData(Data.Empty, false)]
    [InlineData(Data.Whitespace, false)]
    [InlineData(Data.Apple, false)]
    [InlineData(Data.apple, false)]
    [InlineData(Data.Orange, false)]
    [InlineData(Data.AppleOrangePear, true)]
    [InlineData(Data.OrangeApplePear, false)]
    [InlineData(Data.OrangePearApple, false)]
    [InlineData(Data._AppleOrangePear, false)]
    [InlineData(Data.Apple_OrangePear, false)]
    [InlineData(Data.AppleOrangePear_, false)]
    [InlineData(Data.Apple_apple_Apple, false)]
    public void Implicit_Conversion_Exception_Is_Not_Null(string message, bool expectedEquals)
        => When(
            expectedException: new ArgumentException(Data.AppleOrangePear),
            expectedType: typeof(ArgumentException),
            expectedExpectationsCount: 1,
            expectedExpectations: [new MessageEquals(Data.AppleOrangePear)],
            testSameExceptionType: (new ArgumentException(message), expectedEquals),
            testDifferentExceptionType: new Exception(Data.AppleOrangePear));

    [Fact]
    public void Implicit_Conversion_Exception_Is_Null()
        => Expect<ArgumentNullException>(() => { ExpectedException expectedException = default(Exception); }, 
            ExpectedMessages.ExceptionCannotBeNull);

    [Fact]
    public void Implicit_Conversion_Type_Is_Not_An_Exception()
        => this.Expect<ArgumentException>(() => { ExpectedException expectedException = typeof(string); }, 
            ExpectedMessages.ExceptionTypeMustDeriveFromSystemException);

    [Theory]
    [InlineData(Data.Null, true)]
    [InlineData(Data.Empty, true)]
    [InlineData(Data.Whitespace, true)]
    [InlineData(Data.Apple, true)]
    [InlineData(Data.apple, true)]
    [InlineData(Data.Orange, true)]
    [InlineData(Data.AppleOrangePear, true)]
    [InlineData(Data.OrangeApplePear, true)]
    [InlineData(Data.OrangePearApple, true)]
    [InlineData(Data._AppleOrangePear, true)]
    [InlineData(Data.Apple_OrangePear, true)]
    [InlineData(Data.AppleOrangePear_, true)]
    [InlineData(Data.Apple_apple_Apple, true)]
    public void Implicit_Conversion_Type_Is_Not_Null(string message, bool expectedEquals)
        => When(
            expectedException: typeof(ArgumentException),
            expectedType: typeof(ArgumentException),
            expectedExpectationsCount: 0,
            expectedExpectations: [],
            testSameExceptionType: (new ArgumentException(message), expectedEquals),
            testDifferentExceptionType: new Exception(Data.AppleOrangePear));

    [Fact]
    public void Implicit_Conversion_Type_Is_Null()
        => Expect<ArgumentNullException>(() => { ExpectedException expectedException = default(Type); }, 
            ExpectedMessages.ExceptionTypeCannotBeNull);

    [Fact]
    public void Type_Is_Not_An_Exception()
        => Expect<ArgumentException>(exceptionType: typeof(string), expectations: null,
            ExpectedMessages.ExceptionTypeMustDeriveFromSystemException);

    [Fact]
    public void Type_Is_Null()
        => Expect<ArgumentNullException>(exceptionType: null, expectations: null,
            ExpectedMessages.ExceptionTypeCannotBeNull);

    private void Expect<TException>(Type? exceptionType, Expectation[]? expectations, string expectedMessage) where TException : Exception
        => Expect<TException>(() => new ExpectedException(exceptionType, expectations), expectedMessage);

    private void Expect<TException>(Action action, string expectedMessage) where TException : Exception
    {
        var exception = Assert.Throws<TException>(action);
        Assert.Equal(expectedMessage, exception.Message);
    }

    private string GetExpectedToString(ExpectedException expectedException, string when, Exception? exception = null)
    {
        var expectedToString = new StringBuilder(expectedException.Type.FullName);
        if (expectedException.Expectations.Any())
        {
            expectedToString.Append(" where");
            foreach (var expectation in expectedException.Expectations)
            {
                expectedToString.Append($"{Environment.NewLine}  ");
                expectedToString.Append(exception is null
                    ? "    "
                    : $"[{(expectation.IsMatch(exception) ? '+' : '-')}] ");
                expectedToString.Append(expectation);
            }
        }
        _testOutput.WriteLine($"Expected ToString {when}: {Environment.NewLine}{expectedException}{Environment.NewLine}");
        return expectedToString.ToString();
    }

    private void When(Type exceptionType, Expectation[]? expectations, int expectedExpectationsCount, (Exception Exception, bool ExpectedEquals) testSameExceptionType, Exception testDifferentExceptionType)
        => When(
            expectedException: new ExpectedException(exceptionType, expectations),
            expectedType: exceptionType,
            expectedExpectationsCount: expectedExpectationsCount,
            expectedExpectations: expectations?.Distinct().Where(_ => _ is not null) ?? Enumerable.Empty<Expectation>(),
            testSameExceptionType: testSameExceptionType,
            testDifferentExceptionType: testDifferentExceptionType);

    private void When(
        ExpectedException expectedException, 
        Type expectedType, 
        int expectedExpectationsCount,
        IEnumerable<Expectation> expectedExpectations,
        (Exception Exception, bool ExpectedEquals) testSameExceptionType, 
        Exception testDifferentExceptionType)
    {
        // get *thrown* versions of test exceptions
        var testSameExceptionTypeThrown = ThrowException(testSameExceptionType.Exception);
        var testDifferentExceptionTypeThrown = ThrowException(testDifferentExceptionType);

        // assert Expectations
        Assert.NotNull(expectedException.Expectations);
        Assert.Equal(expectedExpectationsCount, expectedException.Expectations.Count());
        Assert.True(expectedException.Expectations.SequenceEqual(expectedExpectations));

        // assert Type
        Assert.Equal(expectedType, expectedException.Type);

        // assert ToString before Equals
        var expectedToString = GetExpectedToString(expectedException, "before Equals");
        Assert.Equal(expectedToString, expectedException.ToString());

        // assert Equals (same exception type) and ToString after Equals
        Assert.Equal(testSameExceptionType.ExpectedEquals, expectedException.Equals(testSameExceptionTypeThrown));
        expectedToString = GetExpectedToString(expectedException, "after Equals (same exception Type)", testSameExceptionTypeThrown);
        Assert.Equal(expectedToString, expectedException.ToString());
        if (testSameExceptionType.ExpectedEquals)
        {
            Assert.Equal(expectedException, testSameExceptionTypeThrown);
            Assert.Equal(testSameExceptionTypeThrown, expectedException);
        }
        else
        {
            Assert.NotEqual(expectedException, testSameExceptionTypeThrown);
            Assert.NotEqual(testSameExceptionTypeThrown, expectedException);
        }

        // assert Equals (different exception type) and ToString after Equals
        Assert.False(expectedException.Equals(testDifferentExceptionTypeThrown));
        expectedToString = GetExpectedToString(expectedException, "after Equals (different exception Type)", testDifferentExceptionTypeThrown);
        Assert.Equal(expectedToString, expectedException.ToString());
        Assert.NotEqual(expectedException, testDifferentExceptionTypeThrown);
        Assert.NotEqual(testDifferentExceptionTypeThrown, expectedException);

        // assert ToString after ResetResults
        expectedException.ResetResults();
        expectedToString = GetExpectedToString(expectedException, "after ResetResults");
        Assert.Equal(expectedToString, expectedException.ToString());
    }

    private Exception ThrowException(Exception ex)
    {
        try { throw ex; }
        catch (Exception thrownException) { return thrownException; }
    }
}
