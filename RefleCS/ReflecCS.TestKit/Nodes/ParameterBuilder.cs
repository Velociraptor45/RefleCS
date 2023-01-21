using RefleCS.Enums;
using RefleCS.Nodes;
using ReflecCS.TestKit;
using System;
using System.Collections.Generic;

namespace RefleCS.TestKit.Nodes;
public class ParameterBuilder : TestBuilderBase<Parameter>
{
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