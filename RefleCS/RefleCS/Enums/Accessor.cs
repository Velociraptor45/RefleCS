using Microsoft.CodeAnalysis.CSharp;
using RefleCS.Attributes;

namespace RefleCS.Enums;

public enum Accessor
{
    [SyntaxKind(SyntaxKind.GetAccessorDeclaration)]
    Get,

    [SyntaxKind(SyntaxKind.SetAccessorDeclaration)]
    Set
}