using RefleCS.Enums;

namespace RefleCS.Nodes;

public class Class
{
    public Class(IEnumerable<Modifier> modifiers, string name, IEnumerable<Constructor> constructors,
        IEnumerable<Property> properties)
    {
        Modifiers = modifiers.ToList();
        Name = name;
        Constructors = constructors.ToList();
        Properties = properties.ToList();
    }

    public IReadOnlyCollection<Modifier> Modifiers { get; }
    public string Name { get; }
    public IReadOnlyCollection<Constructor> Constructors { get; }
    public IReadOnlyCollection<Property> Properties { get; }
}