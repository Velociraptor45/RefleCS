using RefleCS.Enums;

namespace RefleCS.Nodes;

public class Class
{
    private readonly List<Method> _methods;
    private readonly List<Constructor> _constructors;
    private readonly List<Property> _properties;
    private readonly List<BaseType> _baseTypes;
    private readonly List<ClassModifier> _modifiers;

    public Class(string name)
    {
        Name = name;
        _methods = new List<Method>();
        _constructors = new List<Constructor>();
        _properties = new List<Property>();
        _baseTypes = new List<BaseType>();
        _modifiers = new List<ClassModifier>();
    }

    public Class(IEnumerable<ClassModifier> modifiers, string name, IEnumerable<Constructor> constructors,
        IEnumerable<Property> properties, IEnumerable<Method> methods, IEnumerable<BaseType> baseTypes)
    {
        _modifiers = modifiers.ToList();
        Name = name;
        _baseTypes = baseTypes.ToList();
        _methods = methods.ToList();
        _constructors = constructors.ToList();
        _properties = properties.ToList();
    }

    public IReadOnlyCollection<ClassModifier> Modifiers => _modifiers;

    public string Name { get; }

    public IReadOnlyCollection<Method> Methods => _methods;

    public IReadOnlyCollection<Constructor> Constructors => _constructors;

    public IReadOnlyCollection<Property> Properties => _properties;

    public IReadOnlyCollection<BaseType> BaseTypes => _baseTypes;

    public static Class Public(string name)
    {
        var cls = new Class(name);
        cls._modifiers.Add(ClassModifier.Public);
        return cls;
    }

    public void AddBaseType(BaseType baseType)
    {
        _baseTypes.Add(baseType);
    }

    public void RemoveBaseType(BaseType baseType)
    {
        _baseTypes.Remove(baseType);
    }

    public void AddMethod(Method method)
    {
        _methods.Add(method);
    }

    public void RemoveMethod(Method method)
    {
        _methods.Remove(method);
    }

    public void AddProperty(Property property)
    {
        _properties.Add(property);
    }

    public void RemoveProperty(Property property)
    {
        _properties.Remove(property);
    }

    public void AddConstructor(Constructor constructor)
    {
        _constructors.Add(constructor);
    }

    public void AddModifier(ClassModifier modifier)
    {
        _modifiers.Add(modifier);
    }
}