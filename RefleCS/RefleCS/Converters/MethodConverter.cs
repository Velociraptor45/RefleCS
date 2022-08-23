using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RefleCS.Nodes;

namespace RefleCS.Converters;

internal class MethodConverter
{
    private readonly ParameterConverter _parameterConverter = new();
    private readonly ModifierConverter _modifierConverter = new();
    private readonly StatementConverter _statementConverter = new();

    public Method ToMethod(MethodDeclarationSyntax method)
    {
        var modifiers = _modifierConverter.ToMethodModifier(method.Modifiers);
        var parameters = _parameterConverter.ToParameter(method.ParameterList.Parameters);
        var statements = _statementConverter.ToStatement(method.Body.Statements);

        return new Method(modifiers, method.ReturnType.ToString(), method.Identifier.ValueText, parameters, statements);
    }

    public IEnumerable<Method> ToMethod(IEnumerable<MethodDeclarationSyntax> methods)
    {
        foreach (var method in methods)
        {
            yield return ToMethod(method);
        }
    }

    public MethodDeclarationSyntax ToNode(Method method)
    {
        var modifiers = _modifierConverter.ToNode(method.Modifiers);
        var parameters = _parameterConverter.ToNode(method.Parameters);
        var statements = _statementConverter.ToNode(method.Statements);

        return SyntaxFactory.MethodDeclaration(SyntaxFactory.ParseTypeName(method.ReturnTypeName), method.Identifier)
            .AddModifiers(modifiers.ToArray())
            .AddParameterListParameters(parameters.ToArray())
            .AddBodyStatements(statements.ToArray());
    }

    public IEnumerable<MethodDeclarationSyntax> ToNode(IEnumerable<Method> methods)
    {
        foreach (var method in methods)
        {
            yield return ToNode(method);
        }
    }
}