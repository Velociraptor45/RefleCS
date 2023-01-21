using Microsoft.CodeAnalysis.CSharp;
using RefleCS.Attributes;

namespace RefleCS.Enums;

public enum ConstructorInitializerType
{
    [SyntaxKind(SyntaxKind.BaseConstructorInitializer)]
    Base,

    [SyntaxKind(SyntaxKind.ThisConstructorInitializer)]
    This
}