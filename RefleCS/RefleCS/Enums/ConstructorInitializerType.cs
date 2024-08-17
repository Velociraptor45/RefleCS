using Microsoft.CodeAnalysis.CSharp;
using RefleCS.Attributes;

namespace RefleCS.Enums;

/// <summary>
/// Represents a constructor initializer type.
/// </summary>
public enum ConstructorInitializerType
{
    /// <summary>
    /// Base constructor initializer.
    /// </summary>
    [SyntaxKind(SyntaxKind.BaseConstructorInitializer)]
    Base,

    /// <summary>
    /// This constructor initializer.
    /// </summary>
    [SyntaxKind(SyntaxKind.ThisConstructorInitializer)]
    This
}