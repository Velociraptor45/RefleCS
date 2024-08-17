using RefleCS.Enums;

namespace RefleCS.Nodes;

/// <summary>
/// Represents a parameter.
/// </summary>
public class Parameter
{
    /// <summary>
    /// </summary>
    /// <param name="typeName"></param>
    /// <param name="name"></param>
    public Parameter(string typeName, string name)
    {
        Modifiers = new List<ParameterModifier>();
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
        Modifiers = modifiers.ToList();
        TypeName = typeName;
        Name = name;
    }

    /// <summary>
    /// The modifiers of the parameter.
    /// </summary>
    public IReadOnlyCollection<ParameterModifier> Modifiers { get; }

    /// <summary>
    /// The type name of the parameter.
    /// </summary>
    public string TypeName { get; }

    /// <summary>
    /// The name of the parameter.
    /// </summary>
    public string Name { get; }
}