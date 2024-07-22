using Expectable.Expectations;
using Xunit.Abstractions;

namespace Expectable.Tests.ReadmeExamples;

public class ReadmeExamples
{
    private ITestOutputHelper _output;
    public ReadmeExamples(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void GettingStarted()
    {
        ExpectedException expectedException = Expect<ArgumentException>.Where
            .MessageStartsWith("value")
            .MessageContains("cannot be", StringComparison.OrdinalIgnoreCase)
            .MessageEndsWith("null");

        var value = default(string);
        var exception = Assert.Throws(expectedException.Type, () => DoSomething(value));

        var outerException = Assert.Throws<Xunit.Sdk.EqualException>(() =>
        {
            Assert.Equal(expectedException, exception);
        });

        _output.WriteLine(outerException.ToString());
    }

    [Fact]
    public void InitializationAlternatives()
    {
        // verbose constructor
        {
            ExpectedException expectedException = new ExpectedException(typeof(ArgumentException),
                new MessageStartsWith("value"),
                new MessageContains("cannot be", StringComparison.OrdinalIgnoreCase),
                new MessageEndsWith("null"));
        }
        // Exception constructor
        {
            ExpectedException expectedException = new ExpectedException(new ArgumentException("value cannot be null"));
        }
        // implicit conversion from Exception
        {
            ExpectedException expectedException = new ArgumentException("value cannot be null");
        }
        // implicit conversion from Type
        {
            ExpectedException expectedException = typeof(ArgumentException);
        }
    }

    private void DoSomething(string? value) => throw new ArgumentException("value was null");

    [Fact]
    public void ToStringReset()
    {
        ExpectedException expectedException1 = Expect<ArgumentException>.Where
            .MessageStartsWith("value")
            .MessageContains("cannot be", StringComparison.OrdinalIgnoreCase)
            .MessageEndsWith("null");

        ExpectedException expectedException2 = Expect<ArgumentException>.Where
            .MessageStartsWith("value")
            .MessageContains("cannot be", StringComparison.OrdinalIgnoreCase)
            .MessageEndsWith("null");

        ExpectedException expectedException3 = typeof(ArgumentException);

        Exception exception = new ArgumentException("value was null");

        Exception thrownException = new ArgumentException("value was null");
        try { throw thrownException; } catch { }

        _output.WriteLine("[before]");
        _output.WriteLine(expectedException1.ToString());
        _output.WriteLine("");

        _output.WriteLine("[after Equals / == with another expected exception]");
        _ = expectedException1.Equals(expectedException2);
        _ = expectedException1 == expectedException2;
        _ = expectedException2.Equals(expectedException1);
        _ = expectedException2 == expectedException1;
        _output.WriteLine(expectedException1.ToString());
        expectedException1.ResetResults();
        _output.WriteLine("");

        _output.WriteLine("[after Equals / == with another expected exception (with source exception)]");
        _ = expectedException1.Equals(expectedException3);
        _ = expectedException1 == expectedException3;
        _ = expectedException3.Equals(expectedException1);
        _ = expectedException3 == expectedException1;
        _output.WriteLine(expectedException1.ToString());
        expectedException1.ResetResults();
        _output.WriteLine("");

        _output.WriteLine("[after Equals / == with an unthrown exception]");
        _ = expectedException1.Equals(exception);
        _ = (object)expectedException1 == exception;
        _ = exception.Equals(expectedException1);
        _ = (object)exception == expectedException1;
        _output.WriteLine(expectedException1.ToString());
        expectedException1.ResetResults();
        _output.WriteLine("");

        _output.WriteLine("[after Equals with an thrown exception 1]");
        _ = expectedException1.Equals(thrownException);
        _output.WriteLine(expectedException1.ToString());
        expectedException1.ResetResults();
        _output.WriteLine(expectedException1.ToString());
        _output.WriteLine("");

        _output.WriteLine("[after Equals with an thrown exception 2]");
        _ = thrownException.Equals(expectedException1);
        _output.WriteLine(expectedException1.ToString());
        expectedException1.ResetResults();
        _output.WriteLine(expectedException1.ToString());
        _output.WriteLine("");

        _output.WriteLine("[after == with an thrown exception 1]");
        _ = (object)expectedException1 == thrownException;
        _output.WriteLine(expectedException1.ToString());
        expectedException1.ResetResults();
        _output.WriteLine(expectedException1.ToString());
        _output.WriteLine("");

        _output.WriteLine("[after == with an thrown exception 2]");
        _ = (object)thrownException == expectedException1;
        _output.WriteLine(expectedException1.ToString());
        expectedException1.ResetResults();
        _output.WriteLine(expectedException1.ToString());
        _output.WriteLine("");

        _output.WriteLine("[after Assert.Equal with an unthrown exception]");
        try { Assert.Equal(expectedException1, exception); } catch { }
        try { Assert.Equal(exception, expectedException1); } catch { }
        _output.WriteLine(expectedException1.ToString());
        _output.WriteLine("");
        expectedException1.ResetResults();

        _output.WriteLine("[after Assert.Equal with an thrown exception 1]");
        try { Assert.Equal(expectedException1, thrownException); } catch { }
        _output.WriteLine(expectedException1.ToString());
        _output.WriteLine("");
        expectedException1.ResetResults();

        _output.WriteLine("[after Assert.Equal with an thrown exception 2]");
        try { Assert.Equal(thrownException, expectedException1); } catch { }
        _output.WriteLine(expectedException1.ToString());
        _output.WriteLine("");
        expectedException1.ResetResults();
    }
}
