using Microsoft.CodeAnalysis.CSharp;
using RefleCS.Enums;
using RefleCS.Extensions;

namespace RefleCS.Converters;

internal class AccessorConverter
{
    public Accessor ToAccessor(SyntaxKind syntaxKind)
    {
        return syntaxKind switch
        {
            SyntaxKind.GetAccessorDeclaration => Accessor.Get,
            SyntaxKind.SetAccessorDeclaration => Accessor.Set,
            _ => throw new InvalidOperationException($"Syntax kind {syntaxKind} is no accessor")
        };
    }

    public SyntaxKind ToNode(Accessor accessor)
    {
        return accessor.GetSyntaxKind();
    }
}