using RefleCS.Enums;

namespace RefleCS.Nodes;

public class Constructor
{
    public Constructor(IEnumerable<ConstructorModifier> modifiers, string identifier, IEnumerable<Parameter> parameters,
        IEnumerable<Statement> statements)
    {
        Identifier = identifier;
        Modifiers = modifiers.ToList();
        Statements = statements.ToList();
        Parameters = parameters.ToList();
    }

    public IReadOnlyCollection<ConstructorModifier> Modifiers { get; }
    public string Identifier { get; }
    public IReadOnlyCollection<Parameter> Parameters { get; }
    public IReadOnlyCollection<Statement> Statements { get; }
}