using Microsoft.CodeAnalysis.CSharp;
using RefleCS.Attributes;
using System.Reflection;

namespace RefleCS.Extensions;

internal static class EnumExtensions
{
    public static TAttribute GetAttribute<TAttribute>(this Enum value)
        where TAttribute : Attribute
    {
        var type = value.GetType();
        var name = Enum.GetName(type, value)!;
        var attribute = type.GetField(name)!
            .GetCustomAttribute<TAttribute>();
        if (attribute is null)
            throw new InvalidOperationException($"Attribute {name} on enum {value} of {type} not found.");

        return attribute;
    }

    public static SyntaxKind GetSyntaxKind<T>(this T modifier) where T : Enum
    {
        return modifier.GetAttribute<SyntaxKindAttribute>().SyntaxKind;
    }
}