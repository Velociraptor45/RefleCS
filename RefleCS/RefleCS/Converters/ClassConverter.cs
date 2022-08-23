using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RefleCS.Nodes;

namespace RefleCS.Converters;

internal class ClassConverter
{
    private readonly PropertyConverter _propertyConverter = new();
    private readonly ConstructorConverter _constructorConverter = new();
    private readonly ModifierConverter _modifierConverter = new();
    private readonly MethodConverter _methodConverter = new();

    public Class ToClass(ClassDeclarationSyntax classDeclaration)
    {
        var propertyDeclarations = classDeclaration.DescendantNodes().OfType<PropertyDeclarationSyntax>();
        var properties = _propertyConverter.ToProperty(propertyDeclarations);

        var ctorDeclarations = classDeclaration.DescendantNodes().OfType<ConstructorDeclarationSyntax>();
        var ctors = _constructorConverter.ToConstructor(ctorDeclarations).ToList();

        var modifiers = _modifierConverter.ToModifier(classDeclaration.Modifiers);

        var methodDeclarations = classDeclaration.DescendantNodes().OfType<MethodDeclarationSyntax>();
        var methods = _methodConverter.ToMethod(methodDeclarations);

        return new Class(modifiers, classDeclaration.Identifier.ToString(), ctors, properties, methods);
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
        var ctors = _constructorConverter.ToNode(cls.Constructors);
        var properties = _propertyConverter.ToNode(cls.Properties);
        var modifieres = _modifierConverter.ToNode(cls.Modifiers);
        var methods = _methodConverter.ToNode(cls.Methods);

        return SyntaxFactory.ClassDeclaration(cls.Name)
            .AddModifiers(modifieres.ToArray())
            .AddMembers(ctors.ToArray())
            .AddMembers(properties.ToArray())
            .AddMembers(methods.ToArray());
    }

    public IEnumerable<ClassDeclarationSyntax> ToNode(IEnumerable<Class> classes)
    {
        foreach (var cls in classes)
        {
            yield return ToNode(cls);
        }
    }
}