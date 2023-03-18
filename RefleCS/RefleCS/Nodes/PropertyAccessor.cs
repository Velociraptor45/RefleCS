using RefleCS.Enums;

namespace RefleCS.Nodes;

public class PropertyAccessor
{
    private readonly List<AccessorModifier> _modifiers;

    public PropertyAccessor(Accessor accessor, IEnumerable<AccessorModifier> modifiers)
    {
        Accessor = accessor;
        _modifiers = modifiers.ToList();
    }

    public static PropertyAccessor Public(Accessor accessor)
    {
        return new PropertyAccessor(accessor, new List<AccessorModifier>());
    }

    public Accessor Accessor { get; }

    public IReadOnlyCollection<AccessorModifier> Modifiers => _modifiers;
}