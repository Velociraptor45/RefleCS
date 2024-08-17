using Microsoft.CodeAnalysis.CSharp;
using RefleCS.Attributes;

namespace RefleCS.Enums;

/// <summary>
/// Represents a class modifier.
/// </summary>
public enum ClassModifier
{
    /// <summary>
    /// Public class modifier.
    /// </summary>
    [SyntaxKind(SyntaxKind.PublicKeyword)]
    Public,

    /// <summary>
    /// Private class modifier.
    /// </summary>
    [SyntaxKind(SyntaxKind.PrivateKeyword)]
    Private,

    /// <summary>
    /// Protected class modifier.
    /// </summary>
    [SyntaxKind(SyntaxKind.ProtectedKeyword)]
    Protected,

    /// <summary>
    /// Internal class modifier.
    /// </summary>
    [SyntaxKind(SyntaxKind.InternalKeyword)]
    Internal,

    /// <summary>
    /// Abstract class modifier.
    /// </summary>
    [SyntaxKind(SyntaxKind.AbstractKeyword)]
    Abstract,

    /// <summary>
    /// Sealed class modifier.
    /// </summary>
    [SyntaxKind(SyntaxKind.SealedKeyword)]
    Sealed,

    /// <summary>
    /// Static class modifier.
    /// </summary>
    [SyntaxKind(SyntaxKind.StaticKeyword)]
    Static
}