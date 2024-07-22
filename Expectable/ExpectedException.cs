using System;
using System.Collections.Generic;
using System.Linq;
using Expectable.Expectations;

namespace Expectable;

public sealed class ExpectedException
{
    private IEnumerable<(Expectation Expectation, bool IsMatch)> _expectationResults;
    private readonly bool _isThrownException;
    private readonly Exception _sourceException;

    public IEnumerable<Expectation> Expectations { get; }
    public Type Type { get; }

    public ExpectedException(Exception exception)
    {
        if (exception is null)
            throw new ArgumentNullException(nameof(exception), $"{nameof(exception)} cannot be null.");

        _sourceException = exception;
        _isThrownException = exception.StackTrace != null;
        Type = exception.GetType();
        Expectations = new[] { new MessageEquals(exception.Message) };
    }

    public ExpectedException(Type exceptionType, params Expectation[] expectations)
    {
        if (exceptionType is null)
            throw new ArgumentNullException(nameof(exceptionType), $"{nameof(exceptionType)} cannot be null.");

        if (!typeof(Exception).IsAssignableFrom(exceptionType))
            throw new ArgumentException($"{nameof(exceptionType)} must derive from System.Exception.", nameof(exceptionType));

        Type = exceptionType;
        Expectations = expectations?.Where(_ => _ != null).Distinct().ToArray() ?? Array.Empty<Expectation>();
    }

    public static implicit operator ExpectedException(Exception exception) => new ExpectedException(exception);

    public static implicit operator ExpectedException(Type exceptionType) => new ExpectedException(exceptionType);

    public void ResetResults() => _expectationResults = null;

    public override bool Equals(object obj) => Equals(obj as ExpectedException);

    public bool Equals(ExpectedException other)
    {
        if (other == null)
            return false;

        // check if same object
        if (this == other)
            return true;

        // if only *this* is a *thrown* exception, then reverse the comparision
        if (_isThrownException && !other._isThrownException)
            return other.Equals(this);

        // if defined, compare SourceException
        if (other._isThrownException)
        {
            // compare exception with Expectations and store results
            _expectationResults = Expectations.Select(_ => (_, _.IsMatch(other._sourceException))).ToArray();

            // return result
            return this.Type == other.Type && _expectationResults.All(_ => _.IsMatch);
        }

        // compare Type
        if (this.Type != other.Type)
            return false;

        // compare Expectations
        return this.Expectations.SequenceEqual(other.Expectations);
    }

    public override int GetHashCode()
    {
        // TODO
        return base.GetHashCode();
    }

    public override string ToString()
    {
        if (_isThrownException)
            return _sourceException.ToString();

        var expectedType = $"{Type.FullName}";

        if (!Expectations.Any())
            return expectedType;

        var expectations = _expectationResults is null
            ? string.Concat(Expectations.Select(_ => Environment.NewLine + "      " + _))
            : string.Concat(_expectationResults.Select(_ => Environment.NewLine + $"  [{(_.IsMatch ? '+' : '-')}] " + _.Expectation));

        return expectedType + $" where{expectations}";
    }
}