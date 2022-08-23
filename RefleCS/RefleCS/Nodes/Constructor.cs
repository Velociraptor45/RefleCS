using RefleCS.Enums;

namespace RefleCS.Nodes;

public class Constructor
{
    public Constructor(IEnumerable<Modifier> modifiers, string identifier, IEnumerable<Parameter> parameters, IEnumerable<Statement> statements)
    {
        Identifier = identifier;
        Modifiers = modifiers.ToList();
        Statements = statements.ToList();
        Parameters = parameters.ToList();
    }

    public IReadOnlyCollection<Modifier> Modifiers { get; }
    public string Identifier { get; }
    public IReadOnlyCollection<Parameter> Parameters { get; }
    public IReadOnlyCollection<Statement> Statements { get; }
}