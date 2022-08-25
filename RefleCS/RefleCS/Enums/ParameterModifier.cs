using Microsoft.CodeAnalysis.CSharp;
using RefleCS.Attributes;

namespace RefleCS.Enums;

public enum ParameterModifier
{
    [SyntaxKind(SyntaxKind.InKeyword)]
    In,

    [SyntaxKind(SyntaxKind.OutKeyword)]
    Out,

    [SyntaxKind(SyntaxKind.RefKeyword)]
    Ref,
}