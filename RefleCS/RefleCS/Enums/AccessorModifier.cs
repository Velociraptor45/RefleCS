using Microsoft.CodeAnalysis.CSharp;
using RefleCS.Attributes;

namespace RefleCS.Enums;

/// <summary>
/// Represents an accessor modifier. No access modifier is equivalent to public.
/// </summary>
public enum AccessorModifier
{
    /// <summary>
    /// Private accessor modifier.
    /// </summary>
    [SyntaxKind(SyntaxKind.PrivateKeyword)]
    Private,

    /// <summary>
    /// Protected accessor modifier.
    /// </summary>
    [SyntaxKind(SyntaxKind.ProtectedKeyword)]
    Protected,

    /// <summary>
    /// Internal accessor modifier.
    /// </summary>
    [SyntaxKind(SyntaxKind.InternalKeyword)]
    Internal
}