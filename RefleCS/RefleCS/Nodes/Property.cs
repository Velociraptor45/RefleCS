using RefleCS.Enums;

namespace RefleCS.Nodes;

public class Property
{
    private readonly List<PropertyModifier> _modifiers;
    private readonly List<Accessor> _accessors;

    public Property(IEnumerable<PropertyModifier> modifiers, string typeName, string name,
        IEnumerable<Accessor> accessors)
    {
        ValidateName(name);
        ValidateTypeName(typeName);

        _modifiers = modifiers.ToList();
        TypeName = typeName;
        Name = name;
        _accessors = accessors.ToList();
    }

    public IReadOnlyCollection<PropertyModifier> Modifiers => _modifiers;

    public string TypeName { get; private set; }
    public string Name { get; private set; }

    public IReadOnlyCollection<Accessor> Accessors => _accessors;

    public Property ChangeName(string name)
    {
        ValidateName(name);
        Name = name;
        return this;
    }

    public Property ChangeTypeName(string typeName)
    {
        ValidateTypeName(typeName);
        TypeName = typeName;
        return this;
    }

    public Property AddModifier(PropertyModifier modifier)
    {
        if (_modifiers.Contains(modifier))
            return this;

        _modifiers.Add(modifier);
        return this;
    }

    public Property RemoveModifier(PropertyModifier modifier)
    {
        _modifiers.RemoveAll(m => m == modifier);
        return this;
    }

    public Property AddAccessor(Accessor accessor)
    {
        if (_accessors.Contains(accessor))
            return this;

        _accessors.Add(accessor);
        return this;
    }

    public Property RemoveAccessor(Accessor accessor)
    {
        _accessors.RemoveAll(m => m == accessor);
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