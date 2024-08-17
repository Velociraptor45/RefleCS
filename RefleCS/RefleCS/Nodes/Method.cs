using RefleCS.Enums;

namespace RefleCS.Nodes;

/// <summary>
/// Represents a method. Contains a list of leading comments, modifiers, parameters and statements.
/// </summary>
public class Method
{
    private readonly List<Statement> _statements;
    private readonly List<Parameter> _parameters;
    private readonly List<Comment> _leadingComments;
    private readonly List<MethodModifier> _modifiers;

    /// <summary>
    /// </summary>
    /// <param name="returnTypeName"></param>
    /// <param name="name"></param>
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

    /// <summary>
    /// </summary>
    /// <param name="leadingComments"></param>
    /// <param name="modifiers"></param>
    /// <param name="returnTypeName"></param>
    /// <param name="name"></param>
    /// <param name="parameters"></param>
    /// <param name="statements"></param>
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

    /// <summary>
    /// The leading comments of the method (above the method signature).
    /// </summary>
    public IReadOnlyCollection<Comment> LeadingComments => _leadingComments;

    /// <summary>
    /// The modifiers of the method.
    /// </summary>
    public IReadOnlyCollection<MethodModifier> Modifiers => _modifiers;

    /// <summary>
    /// The return type name of the method.
    /// </summary>
    public string ReturnTypeName { get; private set; }

    /// <summary>
    /// The name of the method.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// The parameters of the method.
    /// </summary>
    public IReadOnlyCollection<Parameter> Parameters => _parameters;

    /// <summary>
    /// The statements of the method.
    /// </summary>
    public IReadOnlyCollection<Statement> Statements => _statements;

    /// <summary>
    /// Creates a new public void method with the specified name.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Method PublicVoid(string name)
    {
        var method = new Method(
            "void",
            name);
        method._modifiers.Add(MethodModifier.Public);
        return method;
    }

    /// <summary>
    /// Creates a new public method with the specified return type name and name.
    /// </summary>
    /// <param name="returnTypeName"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Method Public(string returnTypeName, string name)
    {
        var method = new Method(
            returnTypeName,
            name);
        method._modifiers.Add(MethodModifier.Public);
        return method;
    }

    /// <summary>
    /// Creates a new public method with the specified return type name, name, parameters and statements.
    /// </summary>
    /// <param name="returnTypeName"></param>
    /// <param name="name"></param>
    /// <param name="parameters"></param>
    /// <param name="statements"></param>
    /// <returns></returns>
    public static Method Public(string returnTypeName, string name, IEnumerable<Parameter> parameters,
        IEnumerable<Statement> statements)
    {
        return new Method(
            [],
            new List<MethodModifier>
            {
                MethodModifier.Public
            },
            returnTypeName,
            name,
            parameters,
            statements);
    }

    /// <summary>
    /// Changes the name of the method.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException">Thrown if name is empty</exception>
    public Method ChangeName(string name)
    {
        ValidateName(name);
        Name = name;
        return this;
    }

    /// <summary>
    /// Changes the return type name of the method.
    /// </summary>
    /// <param name="returnTypeName"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException">Thrown if return type name is empty</exception>
    public Method ChangeReturnTypeName(string returnTypeName)
    {
        ValidateReturnTypeName(returnTypeName);
        ReturnTypeName = returnTypeName;
        return this;
    }

    /// <summary>
    /// Adds a leading comment to the method (above the method signature).
    /// </summary>
    /// <param name="comment"></param>
    /// <returns></returns>
    public Method AddLeadingComment(Comment comment)
    {
        _leadingComments.Add(comment);
        return this;
    }

    /// <summary>
    /// Adds a modifier to the method. If the modifier already exists, it will not be added again.
    /// </summary>
    /// <param name="modifier"></param>
    /// <returns></returns>
    public Method AddModifier(MethodModifier modifier)
    {
        if (!_modifiers.Contains(modifier))
            _modifiers.Add(modifier);

        return this;
    }

    /// <summary>
    /// Removes a modifier from the method. If the modifier does not exist, nothing will happen.
    /// </summary>
    /// <param name="modifier"></param>
    /// <returns></returns>
    public Method RemoveModifier(MethodModifier modifier)
    {
        _modifiers.RemoveAll(m => m == modifier);
        return this;
    }

    /// <summary>
    /// Adds multiple parameters to the method.
    /// </summary>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public Method AddParameters(IEnumerable<Parameter> parameters)
    {
        foreach (var parameter in parameters)
        {
            AddParameter(parameter);
        }

        return this;
    }

    /// <summary>
    /// Adds a parameter to the method.
    /// </summary>
    /// <param name="parameter"></param>
    /// <returns></returns>
    public Method AddParameter(Parameter parameter)
    {
        _parameters.Add(parameter);
        return this;
    }

    /// <summary>
    /// Removes a parameter from the method. If the parameter does not exist, nothing will happen.
    /// </summary>
    /// <param name="parameter"></param>
    /// <returns></returns>
    public Method RemoveParameter(Parameter parameter)
    {
        _parameters.Remove(parameter);
        return this;
    }

    /// <summary>
    /// Adds multiple statements to the method.
    /// </summary>
    /// <param name="statements"></param>
    /// <returns></returns>
    public Method AddStatements(IEnumerable<Statement> statements)
    {
        foreach (var statement in statements)
        {
            AddStatement(statement);
        }

        return this;
    }

    /// <summary>
    /// Adds a statement to the method.
    /// </summary>
    /// <param name="statement"></param>
    /// <returns></returns>
    public Method AddStatement(Statement statement)
    {
        _statements.Add(statement);
        return this;
    }

    /// <summary>
    /// Removes a statement from the method. If the statement does not exist, nothing will happen.
    /// </summary>
    /// <param name="statement"></param>
    /// <returns></returns>
    public Method RemoveStatement(Statement statement)
    {
        _statements.Remove(statement);
        return this;
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