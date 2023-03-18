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
        ValidateName(name);
        ValidateReturnTypeName(returnTypeName);

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
        ValidateName(name);
        ValidateReturnTypeName(returnTypeName);

        _modifiers = modifiers.ToList();
        _leadingComments = leadingComments.ToList();
        ReturnTypeName = returnTypeName;
        Name = name;
        _parameters = parameters.ToList();
        _statements = statements.ToList();
    }

    public IReadOnlyCollection<Comment> LeadingComments => _leadingComments;

    public IReadOnlyCollection<MethodModifier> Modifiers => _modifiers;

    public string ReturnTypeName { get; private set; }
    public string Name { get; private set; }

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

    public void ChangeName(string name)
    {
        ValidateName(name);
        Name = name;
    }

    public void ChangeReturnTypeName(string returnTypeName)
    {
        ValidateReturnTypeName(returnTypeName);
        ReturnTypeName = returnTypeName;
    }

    public void AddLeadingComment(Comment comment)
    {
        _leadingComments.Add(comment);
    }

    public void AddModifier(MethodModifier modifier)
    {
        if (_modifiers.Contains(modifier))
            return;

        _modifiers.Add(modifier);
    }

    public void RemoveModifier(MethodModifier modifier)
    {
        _modifiers.RemoveAll(m => m == modifier);
    }

    public void AddParameter(Parameter parameter)
    {
        _parameters.Add(parameter);
    }

    public void RemoveParameter(Parameter parameter)
    {
        _parameters.Remove(parameter);
    }

    public void AddStatement(Statement statement)
    {
        _statements.Add(statement);
    }

    public void RemoveStatement(Statement statement)
    {
        _statements.Remove(statement);
    }

    private void ValidateReturnTypeName(string returnTypeName)
    {
        if (string.IsNullOrWhiteSpace(returnTypeName))
            throw new ArgumentException("returnTypeName must not be empty", nameof(returnTypeName));
    }

    private void ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("name must not be empty", nameof(name));
    }
}