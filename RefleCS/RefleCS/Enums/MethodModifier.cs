using Microsoft.CodeAnalysis.CSharp;
using RefleCS.Attributes;

namespace RefleCS.Enums;

public enum MethodModifier
{
    [SyntaxKind(SyntaxKind.PublicKeyword)]
    Public,

    [SyntaxKind(SyntaxKind.PrivateKeyword)]
    Private,

    [SyntaxKind(SyntaxKind.ProtectedKeyword)]
    Protected,

    [SyntaxKind(SyntaxKind.InternalKeyword)]
    Internal,

    [SyntaxKind(SyntaxKind.AsyncKeyword)]
    Async
}