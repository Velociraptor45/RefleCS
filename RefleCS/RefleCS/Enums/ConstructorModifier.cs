using Microsoft.CodeAnalysis.CSharp;
using RefleCS.Attributes;

namespace RefleCS.Enums;

/// <summary>
/// Represents a constructor modifier.
/// </summary>
public enum ConstructorModifier
{
    /// <summary>
    /// Public constructor modifier.
    /// </summary>
    [SyntaxKind(SyntaxKind.PublicKeyword)]
    Public,

    /// <summary>
    /// Private constructor modifier.
    /// </summary>
    [SyntaxKind(SyntaxKind.PrivateKeyword)]
    Private,

    /// <summary>
    /// Protected constructor modifier.
    /// </summary>
    [SyntaxKind(SyntaxKind.ProtectedKeyword)]
    Protected,

    /// <summary>
    /// Internal constructor modifier.
    /// </summary>
    [SyntaxKind(SyntaxKind.InternalKeyword)]
    Internal
}