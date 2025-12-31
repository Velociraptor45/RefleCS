using RefleCS.Enums;
using RefleCS.Nodes;

namespace RefleCS.TestKit.Nodes;
public class FieldBuilder : TestBuilderBase<Field>
{
    public FieldBuilder WithModifiers(IEnumerable<FieldModifier> modifiers)
    {
        FillConstructorWith(nameof(modifiers), modifiers);
        return this;
    }

    public FieldBuilder WithEmptyModifiers()
    {
        return WithModifiers(Enumerable.Empty<FieldModifier>());
    }

    public FieldBuilder WithTypeName(string typeName)
    {
        FillConstructorWith(nameof(typeName), typeName);
        return this;
    }

    public FieldBuilder WithName(string name)
    {
        FillConstructorWith(nameof(name), name);
        return this;
    }

    public FieldBuilder WithInitializer(FieldInitializer? initializer)
    {
        FillConstructorWith(nameof(initializer), initializer);
        return this;
    }

    public FieldBuilder WithoutInitializer()
    {
        return WithInitializer(null);
    }
}