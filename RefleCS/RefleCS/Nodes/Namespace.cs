namespace RefleCS.Nodes;

public class Namespace
{
    private readonly List<Class> _classes;
    private readonly List<Record> _records;

    public Namespace(string name) : this(name, Enumerable.Empty<Class>(), Enumerable.Empty<Record>())
    {
    }

    public Namespace(string name, IEnumerable<Class> classes, IEnumerable<Record> records)
    {
        Name = name;
        _classes = classes.ToList();
        _records = records.ToList();
    }

    public string Name { get; }

    public IReadOnlyCollection<Class> Classes => _classes;
    public IReadOnlyCollection<Record> Records => _records;

    public void AddClass(Class cls)
    {
        _classes.Add(cls);
    }

    public void RemoveClass(Class cls)
    {
        _classes.Remove(cls);
    }
}