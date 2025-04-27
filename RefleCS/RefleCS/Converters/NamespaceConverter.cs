using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RefleCS.Nodes;

namespace RefleCS.Converters;

internal class NamespaceConverter
{
    private readonly ClassConverter _classConverter = new();
    private readonly RecordConverter _recordConverter = new();

    public Namespace ToNamespace(FileScopedNamespaceDeclarationSyntax nmsp)
    {
        var classDeclarations = nmsp.DescendantNodes().OfType<ClassDeclarationSyntax>();
        var classes = _classConverter.ToClass(classDeclarations);
        var recordDeclarations = nmsp.DescendantNodes().OfType<RecordDeclarationSyntax>();
        var records = _recordConverter.ToRecord(recordDeclarations).ToList();

        return new Namespace(nmsp.Name.ToString(), classes, records);
    }

    public FileScopedNamespaceDeclarationSyntax ToNode(Namespace nmsp)
    {
        var classes = _classConverter.ToNode(nmsp.Classes).ToArray<MemberDeclarationSyntax>();
        var records = _recordConverter.ToNode(nmsp.Records).ToArray<MemberDeclarationSyntax>();

        return SyntaxFactory.FileScopedNamespaceDeclaration(SyntaxFactory.IdentifierName(nmsp.Name))
            .AddMembers(classes)
            .AddMembers(records);
    }
}