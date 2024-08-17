using Microsoft.CodeAnalysis.CSharp;
using RefleCS.Attributes;

namespace RefleCS.Enums;

/// <summary>
/// Represents a property modifier.
/// </summary>
public enum PropertyModifier
{
    /// <summary>
    /// Public property modifier.
    /// </summary>
    [SyntaxKind(SyntaxKind.PublicKeyword)]
    Public,

    /// <summary>
    /// Private property modifier.
    /// </summary>
    [SyntaxKind(SyntaxKind.PrivateKeyword)]
    Private,

    /// <summary>
    /// Protected property modifier.
    /// </summary>
    [SyntaxKind(SyntaxKind.ProtectedKeyword)]
    Protected,

    /// <summary>
    /// Internal property modifier.
    /// </summary>
    [SyntaxKind(SyntaxKind.InternalKeyword)]
    Internal
}