using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RefleCS.Nodes;

namespace RefleCS.Converters;

internal class CsFileConverter
{
    private readonly NamespaceConverter _namespaceConverter = new();
    private readonly UsingConverter _usingConverter = new();

    public CsFile ToCsFile(SyntaxTree tree)
    {
        var root = tree.GetRoot();

        var usingDeclarations = root.DescendantNodes().OfType<UsingDirectiveSyntax>();
        var usings = _usingConverter.ToUsing(usingDeclarations);

        var nmspDeclaration = root.DescendantNodes().OfType<FileScopedNamespaceDeclarationSyntax>().First();
        var nmsp = _namespaceConverter.ToNamespace(nmspDeclaration);

        return new CsFile(usings, nmsp);
    }

    public CompilationUnitSyntax ToNode(CsFile file)
    {
        var nmsp = _namespaceConverter.ToNode(file.Nmsp);
        var usings = _usingConverter.ToNode(file.Usings);

        return SyntaxFactory.CompilationUnit()
            .AddUsings(usings.ToArray())
            .AddMembers(nmsp);
    }
}