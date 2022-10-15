using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RefleCS.Nodes;

namespace RefleCS.Converters;

internal class NamespaceConverter
{
    private readonly ClassConverter _classConverter = new();

    public Namespace ToNamespace(FileScopedNamespaceDeclarationSyntax nmsp)
    {
        var classDeclarations = nmsp.DescendantNodes().OfType<ClassDeclarationSyntax>();

        var classes = _classConverter.ToClass(classDeclarations);

        return new Namespace(nmsp.Name.ToString(), classes);
    }

    public FileScopedNamespaceDeclarationSyntax ToNode(Namespace nmsp)
    {
        var classes = _classConverter.ToNode(nmsp.Classes);

        return SyntaxFactory.FileScopedNamespaceDeclaration(SyntaxFactory.IdentifierName(nmsp.Name))
            .AddMembers(classes.ToArray());
    }
}