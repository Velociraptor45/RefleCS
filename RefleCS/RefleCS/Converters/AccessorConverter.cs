using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RefleCS.Enums;

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

    public AccessorListSyntax ToNode(IEnumerable<Accessor> accessors)
    {
        var accessorList = SyntaxFactory.List<AccessorDeclarationSyntax>();
        foreach (var accessor in accessors)
        {
            var isGet = accessor == Accessor.Get;
            var accs = SyntaxFactory.AccessorDeclaration(isGet ? SyntaxKind.GetAccessorDeclaration : SyntaxKind.SetAccessorDeclaration)
                .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
            accessorList = accessorList.Add(accs);
        }

        return SyntaxFactory.AccessorList(accessorList);
    }
}