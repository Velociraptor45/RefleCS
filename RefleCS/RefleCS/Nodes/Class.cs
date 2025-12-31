using RefleCS.Enums;

namespace RefleCS.Nodes;

/// <summary>
/// Represents a class in a namespace.
/// </summary>
public class Class
{
    private readonly List<Method> _methods;
    private readonly List<Constructor> _constructors;
    private readonly List<Field> _fields;
    private readonly List<Property> _properties;
    private readonly List<BaseType> _baseTypes;
    private readonly List<ClassModifier> _modifiers;

    /// <summary>
    /// </summary>
    /// <param name="name"></param>
    public Class(string name)
    {
        Name = name;
        _methods = [];
        _constructors = [];
        _properties = [];
        _baseTypes = [];
        _modifiers = [];
        _fields = [];
    }

    /// <summary>
    /// </summary>
    /// <param name="modifiers"></param>
    /// <param name="name"></param>
    /// <param name="constructors"></param>
    /// <param name="fields"></param>
    /// <param name="properties"></param>
    /// <param name="methods"></param>
    /// <param name="baseTypes"></param>
    public Class(IEnumerable<ClassModifier> modifiers, string name, IEnumerable<Constructor> constructors,
        IEnumerable<Field> fields, IEnumerable<Property> properties, IEnumerable<Method> methods,
        IEnumerable<BaseType> baseTypes)
    {
        _modifiers = modifiers.ToList();
        Name = name;
        _baseTypes = baseTypes.ToList();
        _methods = methods.ToList();
        _constructors = constructors.ToList();
        _properties = properties.ToList();
        _fields = fields.ToList();
    }

    /// <summary>
    /// The modifiers of the class.
    /// </summary>
    public IReadOnlyCollection<ClassModifier> Modifiers => _modifiers;

    /// <summary>
    /// The name of the class.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// The methods in the class.
    /// </summary>
    public IReadOnlyCollection<Method> Methods => _methods;

    /// <summary>
    /// The constructors in the class.
    /// </summary>
    public IReadOnlyCollection<Constructor> Constructors => _constructors;

    /// <summary>
    /// The fields in the class.
    /// </summary>
    public IReadOnlyCollection<Field> Fields => _fields;

    /// <summary>
    /// The properties in the class.
    /// </summary>
    public IReadOnlyCollection<Property> Properties => _properties;

    /// <summary>
    /// The base types of the class. Includes interfaces and classes.
    /// </summary>
    public IReadOnlyCollection<BaseType> BaseTypes => _baseTypes;

    /// <summary>
    /// Returns a new public class with the specified name.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Class Public(string name)
    {
        var cls = new Class(name);
        cls._modifiers.Add(ClassModifier.Public);
        return cls;
    }

    /// <summary>
    /// Adds a base type to the class.
    /// </summary>
    /// <param name="baseType"></param>
    /// <returns></returns>
    public Class AddBaseType(BaseType baseType)
    {
        _baseTypes.Add(baseType);
        return this;
    }

    /// <summary>
    /// Removes a base type from the class.
    /// </summary>
    /// <param name="baseType"></param>
    /// <returns></returns>
    public Class RemoveBaseType(BaseType baseType)
    {
        _baseTypes.Remove(baseType);
        return this;
    }

    /// <summary>
    /// Removes all base types from the class.
    /// </summary>
    /// <returns></returns>
    public Class RemoveAllBaseTypes()
    {
        _baseTypes.Clear();
        return this;
    }

    /// <summary>
    /// Adds a method to the class.
    /// </summary>
    /// <param name="method"></param>
    /// <returns></returns>
    public Class AddMethod(Method method)
    {
        _methods.Add(method);
        return this;
    }

    /// <summary>
    /// Removes a method from the class.
    /// </summary>
    /// <param name="method"></param>
    /// <returns></returns>
    public Class RemoveMethod(Method method)
    {
        _methods.Remove(method);
        return this;
    }

    /// <summary>
    /// Adds a field to the class.
    /// </summary>
    /// <param name="field"></param>
    /// <returns></returns>
    public Class AddField(Field field)
    {
        _fields.Add(field);
        return this;
    }

    /// <summary>
    /// Removes a field from the class.
    /// </summary>
    /// <param name="field"></param>
    /// <returns></returns>
    public Class RemoveField(Field field)
    {
        _fields.Remove(field);
        return this;
    }

    /// <summary>
    /// Adds a property to the class.
    /// </summary>
    /// <param name="property"></param>
    /// <returns></returns>
    public Class AddProperty(Property property)
    {
        _properties.Add(property);
        return this;
    }

    /// <summary>
    /// Removes a property from the class.
    /// </summary>
    /// <param name="property"></param>
    /// <returns></returns>
    public Class RemoveProperty(Property property)
    {
        _properties.Remove(property);
        return this;
    }

    /// <summary>
    /// Adds a constructor to the class.
    /// </summary>
    /// <param name="constructor"></param>
    /// <returns></returns>
    public Class AddConstructor(Constructor constructor)
    {
        _constructors.Add(constructor);
        return this;
    }

    /// <summary>
    /// Removes a constructor from the class.
    /// </summary>
    /// <param name="constructor"></param>
    /// <returns></returns>
    public Class RemoveConstructor(Constructor constructor)
    {
        _constructors.Remove(constructor);
        return this;
    }

    /// <summary>
    /// Adds a modifier to the class.
    /// </summary>
    /// <param name="modifier"></param>
    /// <returns></returns>
    public Class AddModifier(ClassModifier modifier)
    {
        if (!_modifiers.Contains(modifier))
            _modifiers.Add(modifier);

        return this;
    }

    /// <summary>
    /// Removes a modifier from the class.
    /// </summary>
    /// <param name="modifier"></param>
    /// <returns></returns>
    public Class RemoveModifier(ClassModifier modifier)
    {
        _modifiers.RemoveAll(m => m == modifier);
        return this;
    }
}