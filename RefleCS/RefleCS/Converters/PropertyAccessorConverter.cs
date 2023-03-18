using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RefleCS.Nodes;

namespace RefleCS.Converters;

public class PropertyAccessorConverter
{
    private readonly AccessorConverter _accessorConverter = new();
    private readonly ModifierConverter _modifierConverter = new();

    public PropertyAccessor ToPropertyAccessor(AccessorDeclarationSyntax accessor)
    {
        return new PropertyAccessor(
            _accessorConverter.ToAccessor(accessor.Kind()),
            _modifierConverter.ToAccessorModifier(accessor.Modifiers));
    }

    public AccessorListSyntax ToNode(IEnumerable<PropertyAccessor> accessors)
    {
        var accessorList = SyntaxFactory.List<AccessorDeclarationSyntax>();
        foreach (var accessor in accessors)
        {
            var accessorDecl = _accessorConverter.ToNode(accessor.Accessor);
            var modifiers = _modifierConverter.ToNode(accessor.Modifiers);
            var accs = SyntaxFactory
                .AccessorDeclaration(accessorDecl)
                .WithModifiers(modifiers)
                .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));
            accessorList = accessorList.Add(accs);
        }

        return SyntaxFactory.AccessorList(accessorList);
    }
}