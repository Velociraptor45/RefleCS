using RefleCS.Enums;

namespace RefleCS.Nodes;

/// <summary>
/// Represents a constructor initializer (base or this).
/// </summary>
public class ConstructorInitializer
{
    private readonly List<Argument> _arguments;

    /// <summary>
    /// </summary>
    /// <param name="type"></param>
    /// <param name="arguments"></param>
    public ConstructorInitializer(ConstructorInitializerType type, IEnumerable<Argument> arguments)
    {
        _arguments = arguments.ToList();
        Type = type;
    }

    /// <summary>
    /// The type of the constructor initializer (base or this).
    /// </summary>
    public ConstructorInitializerType Type { get; }

    /// <summary>
    /// The arguments of the constructor initializer.
    /// </summary>
    public IReadOnlyCollection<Argument> Arguments => _arguments;
}