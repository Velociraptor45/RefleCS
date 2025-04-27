using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RefleCS.Nodes;

namespace RefleCS.Converters;

internal class FieldConverter
{
    private readonly ModifierConverter _modifierConverter = new();

    public Field ToField(FieldDeclarationSyntax field)
    {
        var typeName = field.Declaration.Type.ToString();
        var name = field.Declaration.Variables.First().Identifier.ToString();
        var modifiers = _modifierConverter.ToFieldModifier(field.Modifiers);
        var initializerString = field.Declaration.Variables.First().Initializer?.Value.ToString();
        FieldInitializer? initializer = initializerString is null
            ? null
            : new FieldInitializer(initializerString);

        return new Field(modifiers, typeName, name, initializer);
    }

    public IEnumerable<Field> ToField(IEnumerable<FieldDeclarationSyntax> fields)
    {
        foreach (var field in fields)
        {
            yield return ToField(field);
        }
    }

    public FieldDeclarationSyntax ToNode(Field field)
    {
        var modifiers = _modifierConverter.ToNode(field.Modifiers);

        var initializer = field.Initializer is null
            ? null
            : SyntaxFactory.EqualsValueClause(
                //SyntaxFactory.Token(SyntaxKind.EqualsValueClause),
                SyntaxFactory.ParseExpression(field.Initializer.Value));

        var variable = SyntaxFactory.VariableDeclarator(field.TypeName)
            .WithIdentifier(SyntaxFactory.ParseToken(field.Name))
            .WithInitializer(initializer);

        var variables = SyntaxFactory.VariableDeclaration(SyntaxFactory.ParseTypeName(field.TypeName))
            .WithVariables([variable]);

        var result = SyntaxFactory
            .FieldDeclaration(variables)
            .WithModifiers(modifiers);

        return result;
    }

    public IEnumerable<FieldDeclarationSyntax> ToNode(IEnumerable<Field> fields)
    {
        foreach (var field in fields)
        {
            yield return ToNode(field);
        }
    }
}
