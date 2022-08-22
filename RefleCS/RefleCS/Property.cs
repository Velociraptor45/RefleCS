using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RefleCS;

public class Property
{
    public Property(string type, string name, IEnumerable<Accessor> accessors)
    {
        TypeName = type;
        Name = name;
        Accessors = accessors.ToList();
    }

    public string TypeName { get; }
    public string Name { get; }
    public IReadOnlyCollection<Accessor> Accessors { get; }

    public PropertyDeclarationSyntax ToNode()
    {
        var attr = SyntaxFactory.List<AttributeListSyntax>();
        var tokens = SyntaxFactory.TokenList()
            .Add(SyntaxFactory.Token(true ? SyntaxKind.PublicKeyword : SyntaxKind.PrivateKeyword));
        //var getAccessor = SyntaxFactory.AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
        //    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
        //var setAccessor = SyntaxFactory.AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
        //    .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
        var accessorList = SyntaxFactory.List<AccessorDeclarationSyntax>();
        //.Add(getAccessor)
        //.Add(setAccessor);
        foreach (var accessor in Accessors)
        {
            var isGet = accessor == Accessor.Get;
            var accs = SyntaxFactory.AccessorDeclaration(isGet ? SyntaxKind.GetAccessorDeclaration : SyntaxKind.SetAccessorDeclaration)
                .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
            accessorList = accessorList.Add(accs);
        }

        var result = SyntaxFactory.PropertyDeclaration(SyntaxFactory.ParseTypeName(TypeName), Name)
            .WithModifiers(tokens)
            .WithAccessorList(SyntaxFactory.AccessorList(accessorList));

        return result;
    }
}