using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RefleCS.Nodes;

namespace RefleCS.Converters;

internal class RecordConverter
{
    private readonly PropertyConverter _propertyConverter = new();
    private readonly ConstructorConverter _constructorConverter = new();
    private readonly ModifierConverter _modifierConverter = new();
    private readonly MethodConverter _methodConverter = new();
    private readonly BaseTypeConverter _baseTypeConverter = new();
    private readonly ParameterConverter _parameterConverter = new();

    public Record ToRecord(RecordDeclarationSyntax recordDeclaration)
    {
        var propertyDeclarations = recordDeclaration.DescendantNodes().OfType<PropertyDeclarationSyntax>();
        var properties = _propertyConverter.ToProperty(propertyDeclarations);

        var ctorDeclarations = recordDeclaration.DescendantNodes().OfType<ConstructorDeclarationSyntax>();
        var ctors = _constructorConverter.ToConstructor(ctorDeclarations).ToList();

        var modifiers = _modifierConverter.ToClassModifier(recordDeclaration.Modifiers);

        var methodDeclarations = recordDeclaration.DescendantNodes().OfType<MethodDeclarationSyntax>();
        var methods = _methodConverter.ToMethod(methodDeclarations);

        var parameterDeclarations = recordDeclaration.ParameterList?.Parameters.AsEnumerable()
                                    ?? Enumerable.Empty<ParameterSyntax>();
        var parameters = _parameterConverter.ToParameter(parameterDeclarations);

        var baseTypes = recordDeclaration.BaseList is null
            ? Enumerable.Empty<BaseType>()
            : _baseTypeConverter.ToBaseType(recordDeclaration.BaseList);

        var record = new Record(modifiers, recordDeclaration.Identifier.ToString(), parameters, ctors, properties, methods, baseTypes);
        return record;
    }

    public IEnumerable<Record> ToRecord(IEnumerable<RecordDeclarationSyntax> classDeclarations)
    {
        foreach (var classDeclaration in classDeclarations)
        {
            yield return ToRecord(classDeclaration);
        }
    }

    public RecordDeclarationSyntax ToNode(Record recrd)
    {
        var ctors = _constructorConverter.ToNode(recrd.Constructors).ToArray<MemberDeclarationSyntax>();
        var properties = _propertyConverter.ToNode(recrd.Properties).ToArray<MemberDeclarationSyntax>();
        var modifiers = _modifierConverter.ToNode(recrd.Modifiers);
        var methods = _methodConverter.ToNode(recrd.Methods).ToArray<MemberDeclarationSyntax>();
        var baseTypes = _baseTypeConverter.ToNode(recrd.BaseTypes).ToArray();
        var parameters = _parameterConverter.ToNode(recrd.Parameters);

        var recordToken = SyntaxFactory.Token(SyntaxKind.RecordKeyword);
        var openBraceToken = SyntaxFactory.Token(SyntaxKind.OpenBraceToken);
        var closeBraceToken = SyntaxFactory.Token(SyntaxKind.CloseBraceToken);

        var node = SyntaxFactory.RecordDeclaration(recordToken, recrd.Name)
            .WithOpenBraceToken(openBraceToken)
            .WithCloseBraceToken(closeBraceToken)
            .AddModifiers(modifiers.ToArray())
            .AddParameterListParameters(parameters.ToArray())
            .AddMembers(ctors)
            .AddMembers(properties)
            .AddMembers(methods);

        if (baseTypes.Any())
            node = node.AddBaseListTypes(baseTypes.ToArray());

        return node;
    }

    public IEnumerable<RecordDeclarationSyntax> ToNode(IEnumerable<Record> records)
    {
        foreach (var recrd in records)
        {
            yield return ToNode(recrd);
        }
    }
}