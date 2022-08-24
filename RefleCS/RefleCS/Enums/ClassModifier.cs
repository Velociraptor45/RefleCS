using Microsoft.CodeAnalysis.CSharp;
using RefleCS.Attributes;

namespace RefleCS.Enums;

public enum ClassModifier
{
    [SyntaxKind(SyntaxKind.PublicKeyword)]
    Public,

    [SyntaxKind(SyntaxKind.PrivateKeyword)]
    Private,

    [SyntaxKind(SyntaxKind.ProtectedKeyword)]
    Protected,

    [SyntaxKind(SyntaxKind.InternalKeyword)]
    Internal,

    [SyntaxKind(SyntaxKind.AbstractKeyword)]
    Abstract,

    [SyntaxKind(SyntaxKind.SealedKeyword)]
    Sealed,

    [SyntaxKind(SyntaxKind.StaticKeyword)]
    Static
}