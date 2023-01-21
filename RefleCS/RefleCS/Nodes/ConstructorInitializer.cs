using RefleCS.Enums;

namespace RefleCS.Nodes;

public class ConstructorInitializer
{
    private readonly List<Argument> _arguments;

    public ConstructorInitializer(ConstructorInitializerType type, IEnumerable<Argument> arguments)
    {
        _arguments = arguments.ToList();
        Type = type;
    }

    public ConstructorInitializerType Type { get; }
    public IReadOnlyCollection<Argument> Arguments => _arguments;
}