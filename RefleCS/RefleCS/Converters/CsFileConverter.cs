using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RefleCS.Nodes;

namespace RefleCS.Converters;

internal class CsFileConverter
{
    private readonly NamespaceConverter _namespaceConverter = new();
    private readonly UsingConverter _usingConverter = new();

    public CsFile? ToCsFileFromPath(string filePath)
    {
        var content = File.ReadAllText(filePath);
        return ToCsFileFromContent(content);
    }

    public CsFile? ToCsFileFromContent(string fileContent)
    {
        var tree = CSharpSyntaxTree.ParseText(fileContent);
        if (tree.GetDiagnostics().Any())
            return null;

        var root = tree.GetRoot();

        try
        {
            var usingDeclarations = root.DescendantNodes().OfType<UsingDirectiveSyntax>();
            var usings = _usingConverter.ToUsing(usingDeclarations);

            var nmspDeclaration = root.DescendantNodes().OfType<FileScopedNamespaceDeclarationSyntax>().First();
            var nmsp = _namespaceConverter.ToNamespace(nmspDeclaration);

            return new CsFile(usings, nmsp);
        }
        catch (Exception)
        {
            return null;
        }
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