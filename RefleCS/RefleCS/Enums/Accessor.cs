using Microsoft.CodeAnalysis.CSharp;
using RefleCS.Attributes;

namespace RefleCS.Enums;

/// <summary>
/// Represents an accessor.
/// </summary>
public enum Accessor
{
    /// <summary>
    /// Get accessor.
    /// </summary>
    [SyntaxKind(SyntaxKind.GetAccessorDeclaration)]
    Get,

    /// <summary>
    /// Set accessor.
    /// </summary>
    [SyntaxKind(SyntaxKind.SetAccessorDeclaration)]
    Set
}