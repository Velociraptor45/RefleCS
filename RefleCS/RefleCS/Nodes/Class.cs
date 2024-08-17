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

    public Class AddBaseType(BaseType baseType)
    {
        _baseTypes.Add(baseType);
        return this;
    }

    public Class RemoveBaseType(BaseType baseType)
    {
        _baseTypes.Remove(baseType);
        return this;
    }

    public Class RemoveAllBaseTypes()
    {
        _baseTypes.Clear();
        return this;
    }

    public Class AddMethod(Method method)
    {
        _methods.Add(method);
        return this;
    }

    public Class RemoveMethod(Method method)
    {
        _methods.Remove(method);
        return this;
    }

    public Class AddProperty(Property property)
    {
        _properties.Add(property);
        return this;
    }

    public Class RemoveProperty(Property property)
    {
        _properties.Remove(property);
        return this;
    }

    public Class AddConstructor(Constructor constructor)
    {
        _constructors.Add(constructor);
        return this;
    }

    public Class RemoveConstructor(Constructor constructor)
    {
        _constructors.Remove(constructor);
        return this;
    }

    public Class AddModifier(ClassModifier modifier)
    {
        if (!_modifiers.Contains(modifier))
            _modifiers.Add(modifier);

        return this;
    }

    public Class RemoveModifier(ClassModifier modifier)
    {
        _modifiers.RemoveAll(m => m == modifier);
        return this;
    }
}