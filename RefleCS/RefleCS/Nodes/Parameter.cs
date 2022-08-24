using RefleCS.Enums;

namespace RefleCS.Nodes;

public class Parameter
{
    public Parameter(IEnumerable<ParameterModifier> modifiers, string typeName, string name)
    {
        Modifiers = modifiers.ToList();
        TypeName = typeName;
        Name = name;
    }

    public IReadOnlyCollection<ParameterModifier> Modifiers { get; }
    public string TypeName { get; }
    public string Name { get; }
}