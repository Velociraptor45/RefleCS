using RefleCS.Enums;
using RefleCS.Nodes;
using ReflecCS.TestKit;

namespace RefleCS.TestKit.Nodes;
public class ClassBuilder : TestBuilderBase<Class>
{
    public ClassBuilder WithName(string name)
    {
        FillConstructorWith(nameof(name), name);
        return this;
    }

    public ClassBuilder WithModifiers(IEnumerable<ClassModifier> modifiers)
    {
        FillConstructorWith(nameof(modifiers), modifiers);
        return this;
    }

    public ClassBuilder WithEmptyModifiers()
    {
        return WithModifiers(Enumerable.Empty<ClassModifier>());
    }

    public ClassBuilder WithConstructors(IEnumerable<Constructor> constructors)
    {
        FillConstructorWith(nameof(constructors), constructors);
        return this;
    }

    public ClassBuilder WithEmptyConstructors()
    {
        return WithConstructors(Enumerable.Empty<Constructor>());
    }

    public ClassBuilder WithProperties(IEnumerable<Property> properties)
    {
        FillConstructorWith(nameof(properties), properties);
        return this;
    }

    public ClassBuilder WithEmptyProperties()
    {
        return WithProperties(Enumerable.Empty<Property>());
    }

    public ClassBuilder WithMethods(IEnumerable<Method> methods)
    {
        FillConstructorWith(nameof(methods), methods);
        return this;
    }

    public ClassBuilder WithEmptyMethods()
    {
        return WithMethods(Enumerable.Empty<Method>());
    }

    public ClassBuilder WithBaseTypes(IEnumerable<BaseType> baseTypes)
    {
        FillConstructorWith(nameof(baseTypes), baseTypes);
        return this;
    }

    public ClassBuilder WithEmptyBaseTypes()
    {
        return WithBaseTypes(Enumerable.Empty<BaseType>());
    }
}