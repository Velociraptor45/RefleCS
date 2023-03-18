using Microsoft.CodeAnalysis.CSharp;
using RefleCS.Attributes;

namespace RefleCS.Enums;

public enum AccessorModifier
{
    [SyntaxKind(SyntaxKind.PrivateKeyword)]
    Private,

    [SyntaxKind(SyntaxKind.ProtectedKeyword)]
    Protected,

    [SyntaxKind(SyntaxKind.InternalKeyword)]
    Internal,
}