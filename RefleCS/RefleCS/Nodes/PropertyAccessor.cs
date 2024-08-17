using RefleCS.Enums;

namespace RefleCS.Nodes;

/// <summary>
/// Represents a property accessor.
/// </summary>
public class PropertyAccessor
{
    private readonly List<AccessorModifier> _modifiers;

    /// <summary>
    /// </summary>
    /// <param name="accessor"></param>
    /// <param name="modifiers"></param>
    public PropertyAccessor(Accessor accessor, IEnumerable<AccessorModifier> modifiers)
    {
        Accessor = accessor;
        _modifiers = modifiers.ToList();
    }

    /// <summary>
    /// The accessor of the property.
    /// </summary>
    public Accessor Accessor { get; }

    /// <summary>
    /// The modifiers of the accessor.
    /// </summary>
    public IReadOnlyCollection<AccessorModifier> Modifiers => _modifiers;

    /// <summary>
    /// Creates a public property accessor.
    /// </summary>
    /// <param name="accessor"></param>
    /// <returns></returns>
    public static PropertyAccessor Public(Accessor accessor)
    {
        return new PropertyAccessor(accessor, new List<AccessorModifier>());
    }
}