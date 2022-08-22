using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace RefleCS;

public class CsFile
{
    public CsFile(Namespace nmsp)
    {
        Nmsp = nmsp;
    }

    public Namespace Nmsp { get; }

    public CompilationUnitSyntax ToNode()
    {
        return SyntaxFactory.CompilationUnit().AddMembers(Nmsp.ToNode());
    }
}