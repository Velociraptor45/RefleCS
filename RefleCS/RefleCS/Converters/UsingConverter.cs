using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RefleCS.Nodes;

namespace RefleCS.Converters;

public class UsingConverter
{
    public Using ToUsing(UsingDirectiveSyntax usng)
    {
        return new Using(usng.Name.ToString());
    }

    public IEnumerable<Using> ToUsing(IEnumerable<UsingDirectiveSyntax> usings)
    {
        foreach (var usng in usings)
        {
            yield return ToUsing(usng);
        }
    }

    public UsingDirectiveSyntax ToNode(Using usng)
    {
        return SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(usng.Value));
    }

    public IEnumerable<UsingDirectiveSyntax> ToNode(IEnumerable<Using> usings)
    {
        foreach (var usng in usings)
        {
            yield return ToNode(usng);
        }
    }
}