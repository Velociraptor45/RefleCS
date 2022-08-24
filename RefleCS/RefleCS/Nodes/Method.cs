using RefleCS.Enums;

namespace RefleCS.Nodes;

public class Method
{
    public Method(IEnumerable<Comment> leadingComments, IEnumerable<MethodModifier> modifiers, string returnTypeName, string identifier,
        IEnumerable<Parameter> parameters, IEnumerable<Statement> statements)
    {
        Modifiers = modifiers.ToList();
        LeadingComments = leadingComments.ToList();
        ReturnTypeName = returnTypeName;
        Identifier = identifier;
        Parameters = parameters.ToList();
        Statements = statements.ToList();
    }

    public IReadOnlyCollection<Comment> LeadingComments { get; }
    public IReadOnlyCollection<MethodModifier> Modifiers { get; }
    public string ReturnTypeName { get; }
    public string Identifier { get; }
    public IReadOnlyCollection<Parameter> Parameters { get; }
    public IReadOnlyCollection<Statement> Statements { get; }
}