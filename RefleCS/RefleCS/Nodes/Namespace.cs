namespace RefleCS.Nodes;

/// <summary>
/// Represents a namespace. Contains a list of classes and records.
/// </summary>
public class Namespace
{
    private readonly List<Class> _classes;
    private readonly List<Record> _records;

    /// <summary>
    /// </summary>
    /// <param name="name"></param>
    public Namespace(string name) : this(name, Enumerable.Empty<Class>(), Enumerable.Empty<Record>())
    {
    }

    /// <summary>
    /// </summary>
    /// <param name="name"></param>
    /// <param name="classes"></param>
    /// <param name="records"></param>
    public Namespace(string name, IEnumerable<Class> classes, IEnumerable<Record> records)
    {
        Name = name;
        _classes = classes.ToList();
        _records = records.ToList();
    }

    /// <summary>
    /// The name of the namespace.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// The classes in the namespace.
    /// </summary>
    public IReadOnlyCollection<Class> Classes => _classes;

    /// <summary>
    /// The records in the namespace.
    /// </summary>
    public IReadOnlyCollection<Record> Records => _records;

    /// <summary>
    /// Adds a class to the namespace.
    /// </summary>
    /// <param name="cls"></param>
    public Namespace AddClass(Class cls)
    {
        _classes.Add(cls);
        return this;
    }

    /// <summary>
    /// Removes a class from the namespace.
    /// </summary>
    /// <param name="cls"></param>
    public Namespace RemoveClass(Class cls)
    {
        _classes.Remove(cls);
        return this;
    }
}