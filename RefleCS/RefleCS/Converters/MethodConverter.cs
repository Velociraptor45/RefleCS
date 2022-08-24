using Microsoft.CodeAnalysis;
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

        var comments = method.GetLeadingTrivia()
            .Where(t => !string.IsNullOrWhiteSpace(t.ToString()))
            .Select(t => new Comment(t.ToString()));

        return new Method(
            comments,
            modifiers,
            method.ReturnType.ToString(),
            method.Identifier.ValueText,
            parameters,
            statements);
    }

    public IEnumerable<Method> ToMethod(IEnumerable<MethodDeclarationSyntax> methods)
    {
        return methods.Select(ToMethod);
    }

    public MethodDeclarationSyntax ToNode(Method method)
    {
        var modifiers = _modifierConverter.ToNode(method.Modifiers);
        var parameters = _parameterConverter.ToNode(method.Parameters);
        var statements = _statementConverter.ToNode(method.Statements);

        var returnTypeToken = SyntaxFactory.ParseTypeName(method.ReturnTypeName);

        var comments = SyntaxFactory.TriviaList(method.LeadingComments.Select(c => SyntaxFactory.Comment(c.Value)));

        if (modifiers.Any())
        {
            var newFirst = modifiers.First().WithLeadingTrivia(comments);
            modifiers = modifiers.Replace(modifiers.First(), newFirst);
        }
        else
        {
            returnTypeToken = returnTypeToken.WithLeadingTrivia(comments);
        }

        return SyntaxFactory.MethodDeclaration(returnTypeToken, method.Identifier)
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