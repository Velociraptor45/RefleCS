using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RefleCS.Nodes;

namespace RefleCS.Converters;

internal class ParameterConverter
{
    private readonly ModifierConverter _modifierConverter = new();

    public Parameter ToParameter(ParameterSyntax parameter)
    {
        var modifiers = _modifierConverter.ToParameterModifier(parameter.Modifiers);

        if (parameter.Type is null)
            throw new InvalidOperationException($"Parameter has no type: {parameter}");

        return new Parameter(modifiers, parameter.Type.ToString(), parameter.Identifier.ToString());
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
        var modifiers = _modifierConverter.ToNode(parameter.Modifiers);

        return SyntaxFactory.Parameter(SyntaxFactory.Identifier(parameter.Name))
            .WithModifiers(modifiers)
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