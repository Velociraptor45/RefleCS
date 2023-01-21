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
}