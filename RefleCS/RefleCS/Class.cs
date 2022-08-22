using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RefleCS;

public class Class
{
    public Class(string name, IEnumerable<Property> properties)
    {
        Name = name;
        Properties = properties;
    }

    public string Name { get; }
    public IEnumerable<Property> Properties { get; }

    public ClassDeclarationSyntax ToNode()
    {
        return SyntaxFactory.ClassDeclaration(Name).AddMembers(Properties.Select(p => p.ToNode()).ToArray());
    }
}