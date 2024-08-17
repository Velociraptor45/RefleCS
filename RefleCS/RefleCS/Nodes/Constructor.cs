using RefleCS.Enums;

namespace RefleCS.Nodes;

/// <summary>
/// Represents a constructor in a class.
/// </summary>
public class Constructor
{
    /// <summary>
    /// </summary>
    /// <param name="modifiers"></param>
    /// <param name="className"></param>
    /// <param name="parameters"></param>
    /// <param name="initializer"></param>
    /// <param name="statements"></param>
    public Constructor(IEnumerable<ConstructorModifier> modifiers, string className, IEnumerable<Parameter> parameters,
        ConstructorInitializer? initializer, IEnumerable<Statement> statements)
    {
        ClassName = className;
        Initializer = initializer;
        Modifiers = modifiers.ToList();
        Statements = statements.ToList();
        Parameters = parameters.ToList();
    }

    /// <summary>
    /// The modifiers of the constructor.
    /// </summary>
    public IReadOnlyCollection<ConstructorModifier> Modifiers { get; }

    /// <summary>
    /// The name of the class the constructor belongs to.
    /// </summary>
    public string ClassName { get; }

    /// <summary>
    /// The initializer of the constructor.
    /// </summary>
    public ConstructorInitializer? Initializer { get; }

    /// <summary>
    /// The parameters of the constructor.
    /// </summary>
    public IReadOnlyCollection<Parameter> Parameters { get; }

    /// <summary>
    /// The statements in the constructor.
    /// </summary>
    public IReadOnlyCollection<Statement> Statements { get; }
}