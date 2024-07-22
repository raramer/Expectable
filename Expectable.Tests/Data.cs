using System.Text.RegularExpressions;

namespace Expectable.Tests;

public static class Data
{
    // invalid values
    public const string InvalidRegexPattern = "[";
    public static readonly RegexOptions InvalidRegexOptions = (RegexOptions)int.MinValue;
    public static readonly StringComparison InvalidStringComparison = (StringComparison)int.MinValue;

    // null, empty, whitespace
    public const string Null = null;
    public const string Empty = "";
    public const string Whitespace = "   ";

    // single words case sensitive
    public const string Apple = nameof(Apple);
    public const string apple = nameof(apple);
    public const string Orange = nameof(Orange);
    public const string Pear = nameof(Pear);

    // word in different positions
    public const string AppleOrangePear = Apple + Orange + Pear;
    public const string OrangeApplePear = Orange + Apple + Pear;
    public const string OrangePearApple = Orange + Pear + Apple;

    // whitespace in different positions
    public const string _AppleOrangePear = Whitespace + Apple + Orange + Pear;
    public const string Apple_OrangePear = Apple + Whitespace + Orange + Pear;
    public const string AppleOrangePear_ = Apple + Orange + Pear + Whitespace;

    // repeated word, repeated whitespace
    public const string Apple_apple_Apple = Apple + Whitespace + apple + Whitespace + Apple;
}