using AutoFixture.Kernel;
using RefleCS.Enums;
using RefleCS.Nodes;
using RefleCS.TestKit.Common.Selectors;

namespace RefleCS.TestKit.Nodes;

public class ClassBuilder : TestBuilderBase<Class>
{
    public ClassBuilder()
    {
        Customize<Class>(c =>
            c.FromFactory(new MethodInvoker(new CtorSelectionQuery(typeof(IEnumerable<ClassModifier>)))));
    }

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
        return WithModifiers([]);
    }

    public ClassBuilder WithConstructors(IEnumerable<Constructor> constructors)
    {
        FillConstructorWith(nameof(constructors), constructors);
        return this;
    }

    public ClassBuilder WithEmptyConstructors()
    {
        return WithConstructors([]);
    }

    public ClassBuilder WithFields(IEnumerable<Field> fields)
    {
        FillConstructorWith(nameof(fields), fields);
        return this;
    }

    public ClassBuilder WithEmptyFields()
    {
        return WithFields([]);
    }

    public ClassBuilder WithProperties(IEnumerable<Property> properties)
    {
        FillConstructorWith(nameof(properties), properties);
        return this;
    }

    public ClassBuilder WithEmptyProperties()
    {
        return WithProperties([]);
    }

    public ClassBuilder WithMethods(IEnumerable<Method> methods)
    {
        FillConstructorWith(nameof(methods), methods);
        return this;
    }

    public ClassBuilder WithEmptyMethods()
    {
        return WithMethods([]);
    }

    public ClassBuilder WithBaseTypes(IEnumerable<BaseType> baseTypes)
    {
        FillConstructorWith(nameof(baseTypes), baseTypes);
        return this;
    }

    public ClassBuilder WithEmptyBaseTypes()
    {
        return WithBaseTypes([]);
    }
}