using RefleCS.Enums;

namespace RefleCS.Nodes;

/// <summary>
/// Represents a field.
/// </summary>
public class Field
{
    private readonly List<FieldModifier> _modifiers;

    /// <summary> 
    /// </summary>
    /// <param name="modifiers"></param>
    /// <param name="typeName"></param>
    /// <param name="name"></param>
    /// <param name="initializer"></param>
    public Field(IEnumerable<FieldModifier> modifiers, string typeName, string name, FieldInitializer? initializer)
    {
        _modifiers = modifiers.ToList();
        TypeName = typeName;
        Name = name;
        Initializer = initializer;
    }

    /// <summary>
    /// The modifiers of the field.
    /// </summary>
    public IReadOnlyCollection<FieldModifier> Modifiers => _modifiers;

    /// <summary>
    /// The type name of the field.
    /// </summary>
    public string TypeName { get; private set; }

    /// <summary>
    /// The name of the field.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// The initializer of the field. <c>null</c> if not initialized.
    /// </summary>
    public FieldInitializer? Initializer { get; }
}
