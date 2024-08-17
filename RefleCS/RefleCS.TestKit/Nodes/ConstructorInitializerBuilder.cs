using RefleCS.Enums;
using RefleCS.Nodes;

namespace RefleCS.TestKit.Nodes;
public class ConstructorInitializerBuilder : TestBuilderBase<ConstructorInitializer>
{
    public ConstructorInitializerBuilder WithType(ConstructorInitializerType type)
    {
        FillConstructorWith(nameof(type), type);
        return this;
    }

    public ConstructorInitializerBuilder WithArguments(IEnumerable<Argument> arguments)
    {
        FillConstructorWith(nameof(arguments), arguments);
        return this;
    }

    public ConstructorInitializerBuilder WithEmptyArguments()
    {
        return WithArguments(Enumerable.Empty<Argument>());
    }
}