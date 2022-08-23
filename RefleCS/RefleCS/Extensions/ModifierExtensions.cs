using Microsoft.CodeAnalysis.CSharp;
using RefleCS.Attributes;
using RefleCS.Enums;

namespace RefleCS.Extensions;

internal static class ModifierExtensions
{
    public static SyntaxKind GetSyntaxKind(this Modifier modifier)
    {
        return modifier.GetAttribute<SyntaxKindAttribute>().SyntaxKind;
    }
}