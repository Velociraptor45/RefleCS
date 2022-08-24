using RefleCS.Enums;

namespace RefleCS.Nodes;

public class Method
{
    public Method(IEnumerable<Comment> leadingComments, IEnumerable<MethodModifier> modifiers, string returnTypeName,
        string name, IEnumerable<Parameter> parameters, IEnumerable<Statement> statements)
    {
        Modifiers = modifiers.ToList();
        LeadingComments = leadingComments.ToList();
        ReturnTypeName = returnTypeName;
        Name = name;
        Parameters = parameters.ToList();
        Statements = statements.ToList();
    }

    public IReadOnlyCollection<Comment> LeadingComments { get; }
    public IReadOnlyCollection<MethodModifier> Modifiers { get; }
    public string ReturnTypeName { get; }
    public string Name { get; }
    public IReadOnlyCollection<Parameter> Parameters { get; }
    public IReadOnlyCollection<Statement> Statements { get; }

    public static Method NewPublic(string returnTypeName, string name, IEnumerable<Parameter> parameters,
        IEnumerable<Statement> statements)
    {
        return new Method(
            Enumerable.Empty<Comment>(),
            new List<MethodModifier>
            {
                MethodModifier.Public
            },
            returnTypeName,
            name,
            parameters,
            statements);
    }
}