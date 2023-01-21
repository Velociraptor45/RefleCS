using RefleCS.Enums;

namespace RefleCS.Nodes;

public class Record
{
    private readonly List<Method> _methods;
    private readonly List<Constructor> _constructors;
    private readonly List<Property> _properties;
    private readonly List<BaseType> _baseTypes;
    private readonly List<ClassModifier> _modifiers;
    private readonly List<Parameter> _parameters;

    public Record(string name)
    {
        Name = name;
        _methods = new List<Method>();
        _constructors = new List<Constructor>();
        _properties = new List<Property>();
        _baseTypes = new List<BaseType>();
        _modifiers = new List<ClassModifier>();
        _parameters = new List<Parameter>();
    }

    public Record(IEnumerable<ClassModifier> modifiers, string name, IEnumerable<Parameter> parameters,
        IEnumerable<Constructor> constructors, IEnumerable<Property> properties, IEnumerable<Method> methods,
        IEnumerable<BaseType> baseTypes)
    {
        _parameters = parameters.ToList();
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
    public IReadOnlyCollection<Parameter> Parameters => _parameters;

    public static Record Public(string name)
    {
        var cls = new Record(name);
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

    public void RemoveAllBaseTypes()
    {
        _baseTypes.Clear();
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

    public void RemoveConstructor(Constructor constructor)
    {
        _constructors.Remove(constructor);
    }

    public void AddModifier(ClassModifier modifier)
    {
        if (_modifiers.Contains(modifier))
            return;

        _modifiers.Add(modifier);
    }

    public void RemoveModifier(ClassModifier modifier)
    {
        _modifiers.RemoveAll(m => m == modifier);
    }

    public void AddParameter(Parameter parameter)
    {
        _parameters.Add(parameter);
    }

    public void RemoveParameter(Parameter parameter)
    {
        _parameters.Remove(parameter);
    }
}