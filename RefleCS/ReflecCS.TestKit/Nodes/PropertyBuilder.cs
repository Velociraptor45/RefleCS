using RefleCS.Enums;
using RefleCS.Nodes;
using ReflecCS.TestKit;
using System;
using System.Collections.Generic;

namespace RefleCS.TestKit.Nodes;
public class PropertyBuilder : TestBuilderBase<Property>
{
    public PropertyBuilder WithModifiers(IEnumerable<PropertyModifier> modifiers)
    {
        FillConstructorWith(nameof(modifiers), modifiers);
        return this;
    }

    public PropertyBuilder WithEmptyModifiers()
    {
        return WithModifiers(Enumerable.Empty<PropertyModifier>());
    }

    public PropertyBuilder WithType(string type)
    {
        FillConstructorWith(nameof(type), type);
        return this;
    }

    public PropertyBuilder WithName(string name)
    {
        FillConstructorWith(nameof(name), name);
        return this;
    }

    public PropertyBuilder WithAccessors(IEnumerable<Accessor> accessors)
    {
        FillConstructorWith(nameof(accessors), accessors);
        return this;
    }

    public PropertyBuilder WithEmptyAccessors()
    {
        return WithAccessors(Enumerable.Empty<Accessor>());
    }
}