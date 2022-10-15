using RefleCS.Enums;

namespace RefleCS.Nodes;

public class Method
{
    private readonly List<Statement> _statements;
    private readonly List<Parameter> _parameters;
    private readonly List<Comment> _leadingComments;
    private readonly List<MethodModifier> _modifiers;

    public Method(string returnTypeName, string name)
    {
        _modifiers = new List<MethodModifier>();
        _leadingComments = new List<Comment>();
        ReturnTypeName = returnTypeName;
        Name = name;
        _parameters = new List<Parameter>();
        _statements = new List<Statement>();
    }

    public Method(IEnumerable<Comment> leadingComments, IEnumerable<MethodModifier> modifiers, string returnTypeName,
        string name, IEnumerable<Parameter> parameters, IEnumerable<Statement> statements)
    {
        _modifiers = modifiers.ToList();
        _leadingComments = leadingComments.ToList();
        ReturnTypeName = returnTypeName;
        Name = name;
        _parameters = parameters.ToList();
        _statements = statements.ToList();
    }

    public IReadOnlyCollection<Comment> LeadingComments => _leadingComments;

    public IReadOnlyCollection<MethodModifier> Modifiers => _modifiers;

    public string ReturnTypeName { get; }
    public string Name { get; }

    public IReadOnlyCollection<Parameter> Parameters => _parameters;

    public IReadOnlyCollection<Statement> Statements => _statements;

    public static Method PublicVoid(string name)
    {
        var method = new Method(
            "void",
            name);
        method._modifiers.Add(MethodModifier.Public);
        return method;
    }

    public static Method Public(string returnTypeName, string name)
    {
        var method = new Method(
            returnTypeName,
            name);
        method._modifiers.Add(MethodModifier.Public);
        return method;
    }

    public static Method Public(string returnTypeName, string name, IEnumerable<Parameter> parameters,
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

    public void AddLeadingComment(Comment comment)
    {
        _leadingComments.Add(comment);
    }

    public void AddModifier(MethodModifier modifier)
    {
        _modifiers.Add(modifier);
    }

    public void AddParameter(Parameter parameter)
    {
        _parameters.Add(parameter);
    }

    public void AddStatement(Statement statement)
    {
        _statements.Add(statement);
    }
}