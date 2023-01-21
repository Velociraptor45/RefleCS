using RefleCS.Enums;
using RefleCS.Nodes;
using ReflecCS.TestKit;

namespace RefleCS.TestKit.Nodes;
public class MethodBuilder : TestBuilderBase<Method>
{
    public MethodBuilder WithReturnTypeName(string returnTypeName)
    {
        FillConstructorWith(nameof(returnTypeName), returnTypeName);
        return this;
    }

    public MethodBuilder WithName(string name)
    {
        FillConstructorWith(nameof(name), name);
        return this;
    }

    public MethodBuilder WithLeadingComments(IEnumerable<Comment> leadingComments)
    {
        FillConstructorWith(nameof(leadingComments), leadingComments);
        return this;
    }

    public MethodBuilder WithEmptyLeadingComments()
    {
        return WithLeadingComments(Enumerable.Empty<Comment>());
    }

    public MethodBuilder WithModifiers(IEnumerable<MethodModifier> modifiers)
    {
        FillConstructorWith(nameof(modifiers), modifiers);
        return this;
    }

    public MethodBuilder WithEmptyModifiers()
    {
        return WithModifiers(Enumerable.Empty<MethodModifier>());
    }

    public MethodBuilder WithParameters(IEnumerable<Parameter> parameters)
    {
        FillConstructorWith(nameof(parameters), parameters);
        return this;
    }

    public MethodBuilder WithEmptyParameters()
    {
        return WithParameters(Enumerable.Empty<Parameter>());
    }

    public MethodBuilder WithStatements(IEnumerable<Statement> statements)
    {
        FillConstructorWith(nameof(statements), statements);
        return this;
    }

    public MethodBuilder WithEmptyStatements()
    {
        return WithStatements(Enumerable.Empty<Statement>());
    }
}