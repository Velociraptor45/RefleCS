using RefleCS.Enums;

namespace RefleCS.Nodes;

public class Property
{
    public Property(IEnumerable<Modifier> modifiers, string type, string name, IEnumerable<Accessor> accessors)
    {
        Modifiers = modifiers.ToList();
        TypeName = type;
        Name = name;
        Accessors = accessors.ToList();
    }

    public IReadOnlyCollection<Modifier> Modifiers { get; }
    public string TypeName { get; }
    public string Name { get; }
    public IReadOnlyCollection<Accessor> Accessors { get; }
}