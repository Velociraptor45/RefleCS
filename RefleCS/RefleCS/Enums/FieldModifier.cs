using Microsoft.CodeAnalysis.CSharp;
using RefleCS.Attributes;

namespace RefleCS.Enums;

/// <summary>
/// Represents a field modifier.
/// </summary>
public enum FieldModifier
{
    /// <summary>
    /// Public field modifier.
    /// </summary>
    [SyntaxKind(SyntaxKind.PublicKeyword)]
    Public,

    /// <summary>
    /// Private field modifier.
    /// </summary>
    [SyntaxKind(SyntaxKind.PrivateKeyword)]
    Private,

    /// <summary>
    /// Protected field modifier.
    /// </summary>
    [SyntaxKind(SyntaxKind.ProtectedKeyword)]
    Protected,

    /// <summary>
    /// Internal field modifier.
    /// </summary>
    [SyntaxKind(SyntaxKind.InternalKeyword)]
    Internal
}