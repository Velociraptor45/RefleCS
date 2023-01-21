using RefleCS.Enums;
using RefleCS.Nodes;
using ReflecCS.TestKit;

namespace RefleCS.TestKit.Nodes;
public class ConstructorBuilder : TestBuilderBase<Constructor>
{
    public ConstructorBuilder WithModifiers(IEnumerable<ConstructorModifier> modifiers)
    {
        FillConstructorWith(nameof(modifiers), modifiers);
        return this;
    }

    public ConstructorBuilder WithEmptyModifiers()
    {
        return WithModifiers(Enumerable.Empty<ConstructorModifier>());
    }

    public ConstructorBuilder WithClassName(string className)
    {
        FillConstructorWith(nameof(className), className);
        return this;
    }

    public ConstructorBuilder WithParameters(IEnumerable<Parameter> parameters)
    {
        FillConstructorWith(nameof(parameters), parameters);
        return this;
    }

    public ConstructorBuilder WithEmptyParameters()
    {
        return WithParameters(Enumerable.Empty<Parameter>());
    }

    public ConstructorBuilder WithInitializer(ConstructorInitializer? initializer)
    {
        FillConstructorWith(nameof(initializer), initializer);
        return this;
    }

    public ConstructorBuilder WithoutInitializer()
    {
        return WithInitializer(null);
    }

    public ConstructorBuilder WithStatements(IEnumerable<Statement> statements)
    {
        FillConstructorWith(nameof(statements), statements);
        return this;
    }

    public ConstructorBuilder WithEmptyStatements()
    {
        return WithStatements(Enumerable.Empty<Statement>());
    }
}