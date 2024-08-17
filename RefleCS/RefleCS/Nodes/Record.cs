using RefleCS.Enums;

namespace RefleCS.Nodes;

/// <summary>
/// Represents a record.
/// </summary>
public class Record
{
    private readonly List<Method> _methods;
    private readonly List<Constructor> _constructors;
    private readonly List<Property> _properties;
    private readonly List<BaseType> _baseTypes;
    private readonly List<ClassModifier> _modifiers;
    private readonly List<Parameter> _parameters;

    /// <summary>
    /// </summary>
    /// <param name="name"></param>
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

    /// <summary>
    /// </summary>
    /// <param name="modifiers"></param>
    /// <param name="name"></param>
    /// <param name="parameters"></param>
    /// <param name="constructors"></param>
    /// <param name="properties"></param>
    /// <param name="methods"></param>
    /// <param name="baseTypes"></param>
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

    /// <summary>
    /// The modifiers of the record.
    /// </summary>
    public IReadOnlyCollection<ClassModifier> Modifiers => _modifiers;

    /// <summary>
    /// The name of the record.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// The methods of the record.
    /// </summary>
    public IReadOnlyCollection<Method> Methods => _methods;

    /// <summary>
    /// The constructors of the record.
    /// </summary>
    public IReadOnlyCollection<Constructor> Constructors => _constructors;

    /// <summary>
    /// The properties of the record.
    /// </summary>
    public IReadOnlyCollection<Property> Properties => _properties;

    /// <summary>
    /// The base types of the record.
    /// </summary>
    public IReadOnlyCollection<BaseType> BaseTypes => _baseTypes;

    /// <summary>
    /// The parameters of the record.
    /// </summary>
    public IReadOnlyCollection<Parameter> Parameters => _parameters;

    /// <summary>
    /// Creates a public record.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Record Public(string name)
    {
        var cls = new Record(name);
        cls._modifiers.Add(ClassModifier.Public);
        return cls;
    }

    /// <summary>
    /// Adds a base type to the record. Can be a class or an interface.
    /// </summary>
    /// <param name="baseType"></param>
    public void AddBaseType(BaseType baseType)
    {
        _baseTypes.Add(baseType);
    }

    /// <summary>
    /// Removes a base type from the record. If the base type does not exist, nothing will happen.
    /// </summary>
    /// <param name="baseType"></param>
    public void RemoveBaseType(BaseType baseType)
    {
        _baseTypes.Remove(baseType);
    }

    /// <summary>
    /// Removes all base types from the record.
    /// </summary>
    public void RemoveAllBaseTypes()
    {
        _baseTypes.Clear();
    }

    /// <summary>
    /// Adds a method to the record.
    /// </summary>
    /// <param name="method"></param>
    public void AddMethod(Method method)
    {
        _methods.Add(method);
    }

    /// <summary>
    /// Removes a method from the record. If the method does not exist, nothing will happen.
    /// </summary>
    /// <param name="method"></param>
    public void RemoveMethod(Method method)
    {
        _methods.Remove(method);
    }

    /// <summary>
    /// Adds a property to the record.
    /// </summary>
    /// <param name="property"></param>
    public void AddProperty(Property property)
    {
        _properties.Add(property);
    }

    /// <summary>
    /// Removes a property from the record. If the property does not exist, nothing will happen.
    /// </summary>
    /// <param name="property"></param>
    public void RemoveProperty(Property property)
    {
        _properties.Remove(property);
    }

    /// <summary>
    /// Adds a constructor to the record.
    /// </summary>
    /// <param name="constructor"></param>
    public void AddConstructor(Constructor constructor)
    {
        _constructors.Add(constructor);
    }

    /// <summary>
    /// Removes a constructor from the record. If the constructor does not exist, nothing will happen.
    /// </summary>
    /// <param name="constructor"></param>
    public void RemoveConstructor(Constructor constructor)
    {
        _constructors.Remove(constructor);
    }

    /// <summary>
    /// Adds a modifier to the record. If the modifier already exists, it will not be added again.
    /// </summary>
    /// <param name="modifier"></param>
    public void AddModifier(ClassModifier modifier)
    {
        if (!_modifiers.Contains(modifier))
            _modifiers.Add(modifier);

        return;
    }

    /// <summary>
    /// Removes a modifier from the record. If the modifier does not exist, nothing will happen.
    /// </summary>
    /// <param name="modifier"></param>
    public void RemoveModifier(ClassModifier modifier)
    {
        _modifiers.RemoveAll(m => m == modifier);
    }

    /// <summary>
    /// Adds a parameter to the record.
    /// </summary>
    /// <param name="parameter"></param>
    public void AddParameter(Parameter parameter)
    {
        _parameters.Add(parameter);
    }

    /// <summary>
    /// Removes a parameter from the record. If the parameter does not exist, nothing will happen.
    /// </summary>
    /// <param name="parameter"></param>
    public void RemoveParameter(Parameter parameter)
    {
        _parameters.Remove(parameter);
    }
}