using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RefleCS.Nodes;

namespace RefleCS.Converters;

internal class CsFileConverter
{
    private readonly NamespaceConverter _namespaceConverter = new();

    public CsFile ToCsFile(SyntaxTree tree)
    {
        var root = tree.GetRoot();

        var nmspDeclaration = root.DescendantNodes().OfType<FileScopedNamespaceDeclarationSyntax>().First();
        var nmsp = _namespaceConverter.ToNamespace(nmspDeclaration);

        return new CsFile(nmsp);
    }

    public CompilationUnitSyntax ToNode(CsFile file)
    {
        var nmsp = _namespaceConverter.ToNode(file.Nmsp);

        return SyntaxFactory.CompilationUnit()
            .AddMembers(nmsp);
    }
}