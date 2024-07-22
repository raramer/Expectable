using Expectable.Expectations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Expectable;

public sealed class ExpectedException
{
    private IEnumerable<(Expectation Expectation, bool IsMatch)> _expectationResults;
    private readonly bool _isThrownException;
    private readonly Exception _sourceException;

    /// <summary>
    /// The expectations that the exception is expected to fulfill.
    /// </summary>
    public IEnumerable<Expectation> Expectations { get; }

    /// <summary>
    /// The type of exception expected.
    /// </summary>
    public Type Type { get; }

    /// <summary>
    /// Defines an ExpectedException based on an existing exception.
    /// </summary>
    /// <param name="exception"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public ExpectedException(Exception exception)
    {
        if (exception is null)
            throw new ArgumentNullException(nameof(exception), $"{nameof(exception)} cannot be null.");

        _sourceException = exception;
        _isThrownException = exception.StackTrace != null;
        Type = exception.GetType();
        Expectations = new[] { new MessageEquals(exception.Message) };
    }

    /// <summary>
    /// Defines an ExpectedException.
    /// </summary>
    /// <param name="exceptionType">The type of exception expected.</param>
    /// <param name="expectations">An optional list of expectations that the exception is expected to fulfill.</param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public ExpectedException(Type exceptionType, params Expectation[] expectations)
    {
        if (exceptionType is null)
            throw new ArgumentNullException(nameof(exceptionType), $"{nameof(exceptionType)} cannot be null.");

        if (!typeof(Exception).IsAssignableFrom(exceptionType))
            throw new ArgumentException($"{nameof(exceptionType)} must derive from System.Exception.", nameof(exceptionType));

        Type = exceptionType;
        Expectations = expectations?.Where(_ => _ != null).Distinct().ToArray() ?? Array.Empty<Expectation>();
    }

    /// <summary>
    /// Implicitly converts an existing Expection to an ExpectedException.
    /// </summary>
    /// <param name="exception">An existing exception.</param>
    public static implicit operator ExpectedException(Exception exception) => new ExpectedException(exception);

    /// <summary>
    /// Implicitly converts an exception type to an ExpectedException.
    /// </summary>
    /// <param name="exceptionType"></param>
    public static implicit operator ExpectedException(Type exceptionType) => new ExpectedException(exceptionType);

    /// <summary>
    /// Resets the results of the ExpectedException.
    /// </summary>
    public void ResetResults() => _expectationResults = null;

    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
    public override bool Equals(object obj) => Equals(obj as ExpectedException);

    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
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

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object</returns>
    public override int GetHashCode()
    {
        var hashCode = base.GetHashCode();
        hashCode = hashCode * -1521134295 + EqualityComparer<Type>.Default.GetHashCode(Type);
        foreach (var expectation in  Expectations)
            hashCode = hashCode * -1521134295 + EqualityComparer<Expectation>.Default.GetHashCode(expectation);
        return hashCode;
    }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
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