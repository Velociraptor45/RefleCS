using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RefleCS.Nodes;

namespace RefleCS.Converters;

internal class ConstructorConverter
{
    private readonly ParameterConverter _parameterConverter = new();
    private readonly ModifierConverter _modifierConverter = new();
    private readonly StatementConverter _statementConverter = new();
    private readonly ConstructorInitializerConverter _constructorInitializerConverter = new();

    public Constructor ToConstructor(ConstructorDeclarationSyntax ctorDeclaration)
    {
        var statements = ctorDeclaration.Body is null
            ? Enumerable.Empty<Statement>()
            : _statementConverter.ToStatement(ctorDeclaration.Body.Statements);
        var parameters = _parameterConverter.ToParameter(ctorDeclaration.ParameterList.Parameters);
        var modifiers = _modifierConverter.ToConstructorModifier(ctorDeclaration.Modifiers);

        ConstructorInitializer? initializer = null;
        if (ctorDeclaration.Initializer is not null)
        {
            initializer = _constructorInitializerConverter.ToConstructorInitializer(ctorDeclaration.Initializer);
        }

        return new Constructor(modifiers, ctorDeclaration.Identifier.ValueText, parameters, initializer, statements);
    }

    public IEnumerable<Constructor> ToConstructor(IEnumerable<ConstructorDeclarationSyntax> ctorDeclarations)
    {
        foreach (var ctorDeclaration in ctorDeclarations)
        {
            yield return ToConstructor(ctorDeclaration);
        }
    }

    public ConstructorDeclarationSyntax ToNode(Constructor constructor)
    {
        var modifiers = _modifierConverter.ToNode(constructor.Modifiers);
        var parameters = _parameterConverter.ToNode(constructor.Parameters);
        var statements = _statementConverter.ToNode(constructor.Statements);

        var ctor = SyntaxFactory.ConstructorDeclaration(constructor.ClassName)
            .AddModifiers(modifiers.ToArray())
            .AddParameterListParameters(parameters.ToArray())
            .AddBodyStatements(statements.ToArray());

        if (constructor.Initializer is not null)
        {
            var initializer = _constructorInitializerConverter.ToNode(constructor.Initializer);
            ctor = ctor.WithInitializer(initializer);
        }

        return ctor;
    }

    public IEnumerable<ConstructorDeclarationSyntax> ToNode(IEnumerable<Constructor> constructors)
    {
        foreach (var constructor in constructors)
        {
            yield return ToNode(constructor);
        }
    }
}