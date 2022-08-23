using RefleCS.Enums;

namespace RefleCS.Nodes;

public class Parameter
{
    public Parameter(IEnumerable<ParameterModifier> modifiers, string typeName, string identifier)
    {
        Modifiers = modifiers.ToList();
        TypeName = typeName;
        Identifier = identifier;
    }

    public IReadOnlyCollection<ParameterModifier> Modifiers { get; }
    public string TypeName { get; }
    public string Identifier { get; }
}