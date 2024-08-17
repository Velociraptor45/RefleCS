using AutoFixture.Kernel;
using RefleCS.Enums;
using RefleCS.Nodes;
using RefleCS.TestKit.Common.Selectors;

namespace RefleCS.TestKit.Nodes;

public class ParameterBuilder : TestBuilderBase<Parameter>
{
    public ParameterBuilder()
    {
        Customize<Parameter>(c =>
            c.FromFactory(new MethodInvoker(new CtorSelectionQuery(typeof(IEnumerable<ParameterModifier>)))));
    }

    public ParameterBuilder WithTypeName(string typeName)
    {
        FillConstructorWith(nameof(typeName), typeName);
        return this;
    }

    public ParameterBuilder WithName(string name)
    {
        FillConstructorWith(nameof(name), name);
        return this;
    }

    public ParameterBuilder WithModifiers(IEnumerable<ParameterModifier> modifiers)
    {
        FillConstructorWith(nameof(modifiers), modifiers);
        return this;
    }

    public ParameterBuilder WithEmptyModifiers()
    {
        return WithModifiers(Enumerable.Empty<ParameterModifier>());
    }
}