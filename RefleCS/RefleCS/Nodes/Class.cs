using RefleCS.Enums;

namespace RefleCS.Nodes;

public class Class
{
    private readonly List<Method> _methods;
    private readonly List<Constructor> _constructors;
    private readonly List<Property> _properties;

    public Class(IEnumerable<ClassModifier> modifiers, string name, IEnumerable<Constructor> constructors,
        IEnumerable<Property> properties, IEnumerable<Method> methods)
    {
        Modifiers = modifiers.ToList();
        Name = name;
        _methods = methods.ToList();
        _constructors = constructors.ToList();
        _properties = properties.ToList();
    }

    public IReadOnlyCollection<ClassModifier> Modifiers { get; }

    public string Name { get; }

    public IReadOnlyCollection<Method> Methods => _methods;

    public IReadOnlyCollection<Constructor> Constructors => _constructors;

    public IReadOnlyCollection<Property> Properties => _properties;

    public void AddMethod(Method method)
    {
        _methods.Add(method);
    }

    public void AddProperty(Property property)
    {
        _properties.Add(property);
    }

    public void AddConstructor(Constructor constructor)
    {
        _constructors.Add(constructor);
    }
}