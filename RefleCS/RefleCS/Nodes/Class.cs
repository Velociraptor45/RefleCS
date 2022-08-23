using RefleCS.Enums;

namespace RefleCS.Nodes;

public class Class
{
    public Class(IEnumerable<Modifier> modifiers, string name, IEnumerable<Constructor> constructors,
        IEnumerable<Property> properties, IEnumerable<Method> methods)
    {
        Modifiers = modifiers.ToList();
        Name = name;
        Methods = methods.ToList();
        Constructors = constructors.ToList();
        Properties = properties.ToList();
    }

    public IReadOnlyCollection<Modifier> Modifiers { get; }
    public string Name { get; }
    public IReadOnlyCollection<Method> Methods { get; }
    public IReadOnlyCollection<Constructor> Constructors { get; }
    public IReadOnlyCollection<Property> Properties { get; }
}