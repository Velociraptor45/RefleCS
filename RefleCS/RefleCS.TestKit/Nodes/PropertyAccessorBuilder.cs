using RefleCS.Enums;
using RefleCS.Nodes;

namespace RefleCS.TestKit.Nodes;
public class PropertyAccessorBuilder : TestBuilderBase<PropertyAccessor>
{
    public PropertyAccessorBuilder WithAccessor(Accessor accessor)
    {
        FillConstructorWith(nameof(accessor), accessor);
        return this;
    }

    public PropertyAccessorBuilder WithModifiers(IEnumerable<AccessorModifier> modifiers)
    {
        FillConstructorWith(nameof(modifiers), modifiers);
        return this;
    }

    public PropertyAccessorBuilder WithEmptyModifiers()
    {
        return WithModifiers(Enumerable.Empty<AccessorModifier>());
    }
}