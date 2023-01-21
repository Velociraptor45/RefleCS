using RefleCS.Enums;
using RefleCS.Nodes;
using ReflecCS.TestKit;

namespace RefleCS.TestKit.Nodes;
public class RecordBuilder : TestBuilderBase<Record>
{
    public RecordBuilder WithName(string name)
    {
        FillConstructorWith(nameof(name), name);
        return this;
    }

    public RecordBuilder WithModifiers(IEnumerable<ClassModifier> modifiers)
    {
        FillConstructorWith(nameof(modifiers), modifiers);
        return this;
    }

    public RecordBuilder WithEmptyModifiers()
    {
        return WithModifiers(Enumerable.Empty<ClassModifier>());
    }

    public RecordBuilder WithParameters(IEnumerable<Parameter> parameters)
    {
        FillConstructorWith(nameof(parameters), parameters);
        return this;
    }

    public RecordBuilder WithEmptyParameters()
    {
        return WithParameters(Enumerable.Empty<Parameter>());
    }

    public RecordBuilder WithConstructors(IEnumerable<Constructor> constructors)
    {
        FillConstructorWith(nameof(constructors), constructors);
        return this;
    }

    public RecordBuilder WithEmptyConstructors()
    {
        return WithConstructors(Enumerable.Empty<Constructor>());
    }

    public RecordBuilder WithProperties(IEnumerable<Property> properties)
    {
        FillConstructorWith(nameof(properties), properties);
        return this;
    }

    public RecordBuilder WithEmptyProperties()
    {
        return WithProperties(Enumerable.Empty<Property>());
    }

    public RecordBuilder WithMethods(IEnumerable<Method> methods)
    {
        FillConstructorWith(nameof(methods), methods);
        return this;
    }

    public RecordBuilder WithEmptyMethods()
    {
        return WithMethods(Enumerable.Empty<Method>());
    }

    public RecordBuilder WithBaseTypes(IEnumerable<BaseType> baseTypes)
    {
        FillConstructorWith(nameof(baseTypes), baseTypes);
        return this;
    }

    public RecordBuilder WithEmptyBaseTypes()
    {
        return WithBaseTypes(Enumerable.Empty<BaseType>());
    }
}