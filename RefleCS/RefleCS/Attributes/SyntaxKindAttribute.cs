using Microsoft.CodeAnalysis.CSharp;

namespace RefleCS.Attributes;

internal class SyntaxKindAttribute : Attribute
{
    public SyntaxKindAttribute(SyntaxKind syntaxKind)
    {
        SyntaxKind = syntaxKind;
    }

    public SyntaxKind SyntaxKind { get; }
}