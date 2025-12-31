using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RefleCS.Nodes;

namespace RefleCS.Converters;

internal class ClassConverter
{
    private readonly FieldConverter _fieldConverter = new();
    private readonly PropertyConverter _propertyConverter = new();
    private readonly ConstructorConverter _constructorConverter = new();
    private readonly ModifierConverter _modifierConverter = new();
    private readonly MethodConverter _methodConverter = new();
    private readonly BaseTypeConverter _baseTypeConverter = new();

    public Class ToClass(ClassDeclarationSyntax classDeclaration)
    {
        var fieldDeclarations = classDeclaration.DescendantNodes().OfType<FieldDeclarationSyntax>();
        var fields = _fieldConverter.ToField(fieldDeclarations);

        var propertyDeclarations = classDeclaration.DescendantNodes().OfType<PropertyDeclarationSyntax>();
        var properties = _propertyConverter.ToProperty(propertyDeclarations);

        var ctorDeclarations = classDeclaration.DescendantNodes().OfType<ConstructorDeclarationSyntax>();
        var ctors = _constructorConverter.ToConstructor(ctorDeclarations).ToList();

        var modifiers = _modifierConverter.ToClassModifier(classDeclaration.Modifiers);

        var methodDeclarations = classDeclaration.DescendantNodes().OfType<MethodDeclarationSyntax>();
        var methods = _methodConverter.ToMethod(methodDeclarations);

        var baseTypes = classDeclaration.BaseList is null
            ? []
            : _baseTypeConverter.ToBaseType(classDeclaration.BaseList);

        return new Class(modifiers, classDeclaration.Identifier.ToString(), ctors, fields, properties, methods, baseTypes);
    }

    public IEnumerable<Class> ToClass(IEnumerable<ClassDeclarationSyntax> classDeclarations)
    {
        foreach (var classDeclaration in classDeclarations)
        {
            yield return ToClass(classDeclaration);
        }
    }

    public ClassDeclarationSyntax ToNode(Class cls)
    {
        var ctors = _constructorConverter.ToNode(cls.Constructors).ToArray<MemberDeclarationSyntax>();
        var fields = _fieldConverter.ToNode(cls.Fields).ToArray<MemberDeclarationSyntax>();
        var properties = _propertyConverter.ToNode(cls.Properties).ToArray<MemberDeclarationSyntax>();
        var modifiers = _modifierConverter.ToNode(cls.Modifiers);
        var methods = _methodConverter.ToNode(cls.Methods).ToArray<MemberDeclarationSyntax>();
        var baseTypes = _baseTypeConverter.ToNode(cls.BaseTypes).ToArray();

        var classDeclaration = SyntaxFactory.ClassDeclaration(cls.Name)
            .AddModifiers(modifiers.ToArray())
            .AddMembers(fields)
            .AddMembers(ctors)
            .AddMembers(properties)
            .AddMembers(methods);

        if (baseTypes.Any())
            classDeclaration = classDeclaration.AddBaseListTypes(baseTypes);

        return classDeclaration;
    }

    public IEnumerable<ClassDeclarationSyntax> ToNode(IEnumerable<Class> classes)
    {
        foreach (var cls in classes)
        {
            yield return ToNode(cls);
        }
    }
}