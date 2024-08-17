using Microsoft.CodeAnalysis.CSharp;
using RefleCS.Attributes;

namespace RefleCS.Enums;

/// <summary>
/// Represents a parameter modifier.
/// </summary>
public enum ParameterModifier
{
    /// <summary>
    /// In parameter modifier.
    /// </summary>
    [SyntaxKind(SyntaxKind.InKeyword)]
    In,

    /// <summary>
    /// Out parameter modifier.
    /// </summary>
    [SyntaxKind(SyntaxKind.OutKeyword)]
    Out,

    /// <summary>
    /// Ref parameter modifier.
    /// </summary>
    [SyntaxKind(SyntaxKind.RefKeyword)]
    Ref,
}