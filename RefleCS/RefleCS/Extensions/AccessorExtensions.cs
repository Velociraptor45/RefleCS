using Microsoft.CodeAnalysis.CSharp;
using RefleCS.Attributes;
using RefleCS.Enums;

namespace RefleCS.Extensions;

internal static class AccessorExtensions
{
    public static SyntaxKind GetSyntaxKind(this Accessor accessor)
    {
        return accessor.GetAttribute<SyntaxKindAttribute>().SyntaxKind;
    }
}