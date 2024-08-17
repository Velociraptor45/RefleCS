using RefleCS.Enums;

namespace RefleCS.Nodes;

/// <summary>
/// Represents a parameter.
/// </summary>
public class Parameter
{
    private readonly List<ParameterModifier> _modifiers;

    /// <summary>
    /// </summary>
    /// <param name="typeName"></param>
    /// <param name="name"></param>
    public Parameter(string typeName, string name)
    {
        _modifiers = [];
        TypeName = typeName;
        Name = name;
    }

    /// <summary>
    /// </summary>
    /// <param name="modifiers"></param>
    /// <param name="typeName"></param>
    /// <param name="name"></param>
    public Parameter(IEnumerable<ParameterModifier> modifiers, string typeName, string name)
    {
        _modifiers = modifiers.ToList();
        TypeName = typeName;
        Name = name;
    }

    /// <summary>
    /// The modifiers of the parameter.
    /// </summary>
    public IReadOnlyCollection<ParameterModifier> Modifiers => _modifiers;

    /// <summary>
    /// The type name of the parameter.
    /// </summary>
    public string TypeName { get; private set; }

    /// <summary>
    /// The name of the parameter.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Changes the name of the parameter.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException">Thrown if the name is empty</exception>
    public Parameter ChangeName(string name)
    {
        ValidateName(name);
        Name = name;
        return this;
    }

    /// <summary>
    /// Changes the type name of the parameter.
    /// </summary>
    /// <param name="typeName"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException">Thrown if the type name is empty</exception>
    public Parameter ChangeTypeName(string typeName)
    {
        ValidateTypeName(typeName);
        TypeName = typeName;
        return this;
    }

    /// <summary>
    /// Adds a modifier to the parameter. If the modifier already exists, it will not be added again.
    /// </summary>
    /// <param name="modifier"></param>
    /// <returns></returns>
    public Parameter AddModifier(ParameterModifier modifier)
    {
        if (!_modifiers.Contains(modifier))
            _modifiers.Add(modifier);

        return this;
    }

    /// <summary>
    /// Removes a modifier from the parameter. If the modifier does not exist, nothing will happen.
    /// </summary>
    /// <param name="modifier"></param>
    /// <returns></returns>
    public Parameter RemoveModifier(ParameterModifier modifier)
    {
        _modifiers.RemoveAll(m => m == modifier);
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