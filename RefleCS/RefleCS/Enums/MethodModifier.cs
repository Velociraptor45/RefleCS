using Microsoft.CodeAnalysis.CSharp;
using RefleCS.Attributes;

namespace RefleCS.Enums;

/// <summary>
/// Represents a method modifier.
/// </summary>
public enum MethodModifier
{
    /// <summary>
    /// Public method modifier.
    /// </summary>
    [SyntaxKind(SyntaxKind.PublicKeyword)]
    Public,

    /// <summary>
    /// Private method modifier.
    /// </summary>
    [SyntaxKind(SyntaxKind.PrivateKeyword)]
    Private,

    /// <summary>
    /// Protected method modifier.
    /// </summary>
    [SyntaxKind(SyntaxKind.ProtectedKeyword)]
    Protected,

    /// <summary>
    /// Internal method modifier.
    /// </summary>
    [SyntaxKind(SyntaxKind.InternalKeyword)]
    Internal,

    /// <summary>
    /// Async method modifier.
    /// </summary>
    [SyntaxKind(SyntaxKind.AsyncKeyword)]
    Async,

    /// <summary>
    /// Override method modifier.
    /// </summary>
    [SyntaxKind(SyntaxKind.OverrideKeyword)]
    Override
}