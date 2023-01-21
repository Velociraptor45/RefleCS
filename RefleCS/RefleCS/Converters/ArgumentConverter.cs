using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RefleCS.Nodes;

namespace RefleCS.Converters;

internal class ArgumentConverter
{
    public Argument ToArgument(ArgumentSyntax argument)
    {
        return new Argument(argument.ToString());
    }

    public IEnumerable<Argument> ToArgument(IEnumerable<ArgumentSyntax> arguments)
    {
        foreach (var argument in arguments)
        {
            yield return ToArgument(argument);
        }
    }

    public ArgumentSyntax ToNode(Argument argument)
    {
        var expr = SyntaxFactory.ParseExpression(argument.Name);
        return SyntaxFactory.Argument(expr);
    }

    public IEnumerable<ArgumentSyntax> ToNode(IEnumerable<Argument> arguments)
    {
        foreach (var argument in arguments)
        {
            yield return ToNode(argument);
        }
    }
}