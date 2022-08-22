using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RefleCS;

public class Namespace
{
    public Namespace(string name, IEnumerable<Class> classes)
    {
        Name = name;
        Classes = classes;
    }

    public string Name { get; }
    public IEnumerable<Class> Classes { get; }

    public NamespaceDeclarationSyntax ToNode()
    {
        return SyntaxFactory.NamespaceDeclaration(SyntaxFactory.IdentifierName(Name))
            .AddMembers(Classes.Select(c => c.ToNode()).ToArray());
    }
}