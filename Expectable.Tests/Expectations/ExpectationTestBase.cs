using Expectable.Expectations;

namespace Expectable.Tests.Expectations;

public abstract class ExpectationTestBase
{
    protected void AssertEqualityWhen<TExpectation>(TExpectation left, TExpectation right, bool expectEqual)
        where TExpectation : Expectation
    {
        // ==
        Assert.False(left == default(TExpectation));
        Assert.False(default(TExpectation) == left);
        Assert.False(right == default(TExpectation));
        Assert.False(default(TExpectation) == right);
        Assert.Equal(expectEqual, left == right);
        Assert.Equal(expectEqual, right == left);

        // !=
        Assert.True(left != default(TExpectation));
        Assert.True(default(TExpectation) != left);
        Assert.True(right != default(TExpectation));
        Assert.True(default(TExpectation) != right);
        Assert.Equal(!expectEqual, left != right);
        Assert.Equal(!expectEqual, right != left);

        // equals
        Assert.False(left.Equals(default(TExpectation)));
        Assert.False(right.Equals(default(TExpectation)));
        Assert.Equal(expectEqual, left.Equals(right));
        Assert.Equal(expectEqual, right.Equals(left));

        // hash code
        var hashCode1 = left.GetHashCode();
        var hashCode2 = right.GetHashCode();
        var details = $@"{left}\r\n{hashCode1}\r\n\r\n{right}\r\n{hashCode2}";

        Assert.Equal(expectEqual, hashCode1 == hashCode2);
    }
}