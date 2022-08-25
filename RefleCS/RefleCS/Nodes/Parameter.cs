using RefleCS.Enums;

namespace RefleCS.Nodes;

public class Parameter
{
    public Parameter(string typeName, string name)
    {
        Modifiers = new List<ParameterModifier>();
        TypeName = typeName;
        Name = name;
    }

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