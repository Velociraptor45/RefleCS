using RefleCS.Enums;

namespace RefleCS.Nodes;

/// <summary>
/// Represents a property.
/// </summary>
public class Property
{
    private readonly List<PropertyModifier> _modifiers;
    private readonly List<PropertyAccessor> _accessors;

    /// <summary>
    /// </summary>
    /// <param name="modifiers"></param>
    /// <param name="typeName"></param>
    /// <param name="name"></param>
    /// <param name="accessors"></param>
    public Property(IEnumerable<PropertyModifier> modifiers, string typeName, string name,
        IEnumerable<PropertyAccessor> accessors)
    {
        ValidateName(name);
        ValidateTypeName(typeName);

        _modifiers = modifiers.ToList();
        TypeName = typeName;
        Name = name;
        _accessors = accessors.ToList();
    }

    /// <summary>
    /// The modifiers of the property.
    /// </summary>
    public IReadOnlyCollection<PropertyModifier> Modifiers => _modifiers;

    /// <summary>
    /// The type name of the property.
    /// </summary>
    public string TypeName { get; private set; }

    /// <summary>
    /// The name of the property.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// The accessors of the property.
    /// </summary>
    public IReadOnlyCollection<PropertyAccessor> Accessors => _accessors;

    /// <summary>
    /// Creates a public property with a public getter, but no setter.
    /// </summary>
    /// <param name="typeName"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Property PublicGetOnly(string typeName, string name)
    {
        return new Property(
            new List<PropertyModifier> { PropertyModifier.Public },
            typeName,
            name,
            new List<PropertyAccessor>
            {
                PropertyAccessor.Public(Accessor.Get)
            });
    }

    /// <summary>
    /// Creates a public property with a public getter and a private setter.
    /// </summary>
    /// <param name="typeName"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Property PublicGetPrivateSet(string typeName, string name)
    {
        return new Property(
            new List<PropertyModifier> { PropertyModifier.Public },
            typeName,
            name,
            new List<PropertyAccessor>
            {
                PropertyAccessor.Public(Accessor.Get),
                new(Accessor.Set, new List<AccessorModifier> { AccessorModifier.Private })
            });
    }

    /// <summary>
    /// Changes the name of the property.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException">Thrown if the name is empty</exception>
    public Property ChangeName(string name)
    {
        ValidateName(name);
        Name = name;
        return this;
    }

    /// <summary>
    /// Changes the type name of the property.
    /// </summary>
    /// <param name="typeName"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException">Thrown if the type name is empty</exception>
    public Property ChangeTypeName(string typeName)
    {
        ValidateTypeName(typeName);
        TypeName = typeName;
        return this;
    }

    /// <summary>
    /// Adds a modifier to the property. If the modifier already exists, it will not be added again.
    /// </summary>
    /// <param name="modifier"></param>
    /// <returns></returns>
    public Property AddModifier(PropertyModifier modifier)
    {
        if (!_modifiers.Contains(modifier))
            _modifiers.Add(modifier);

        return this;
    }

    /// <summary>
    /// Removes a modifier from the property. If the modifier does not exist, nothing will happen.
    /// </summary>
    /// <param name="modifier"></param>
    /// <returns></returns>
    public Property RemoveModifier(PropertyModifier modifier)
    {
        _modifiers.RemoveAll(m => m == modifier);
        return this;
    }

    /// <summary>
    /// Adds an accessor to the property. If the accessor already exists, it will not be added again.
    /// </summary>
    /// <param name="accessor"></param>
    /// <returns></returns>
    public Property AddAccessor(PropertyAccessor accessor)
    {
        if (!_accessors.Contains(accessor))
            _accessors.Add(accessor);

        return this;
    }

    /// <summary>
    /// Removes an accessor from the property. If the accessor does not exist, nothing will happen.
    /// </summary>
    /// <param name="accessor"></param>
    /// <returns></returns>
    public Property RemoveAccessor(PropertyAccessor accessor)
    {
        _accessors.Remove(accessor);
        return this;
    }

    private void ValidateTypeName(string typeName)
    {
        if (string.IsNullOrWhiteSpace(typeName))
            throw new ArgumentException("typeName must not be empty", nameof(typeName));
    }

    private void ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("name must not be empty", nameof(name));
    }
}