using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RefleCS.Nodes;

namespace RefleCS.Converters;

internal class ParameterConverter
{
    public Parameter ToParameter(ParameterSyntax parameter)
    {
        return new Parameter(parameter.Type.ToString(), parameter.Identifier.ToString());
    }

    public IEnumerable<Parameter> ToParameter(IEnumerable<ParameterSyntax> parameters)
    {
        foreach (var parameter in parameters)
        {
            yield return ToParameter(parameter);
        }
    }

    public ParameterSyntax ToNode(Parameter parameter)
    {
        return SyntaxFactory.Parameter(SyntaxFactory.Identifier(parameter.Identifier))
            .WithType(SyntaxFactory.ParseTypeName(parameter.TypeName));
    }

    public IEnumerable<ParameterSyntax> ToNode(IEnumerable<Parameter> parameters)
    {
        foreach (var parameter in parameters)
        {
            yield return ToNode(parameter);
        }
    }
}