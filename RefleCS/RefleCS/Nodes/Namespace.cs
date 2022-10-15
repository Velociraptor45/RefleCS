namespace RefleCS.Nodes;

public class Namespace
{
    private readonly List<Class> _classes;

    public Namespace(string name) : this(name, Enumerable.Empty<Class>())
    {
    }

    public Namespace(string name, IEnumerable<Class> classes)
    {
        Name = name;
        _classes = classes.ToList();
    }

    public string Name { get; }

    public IReadOnlyCollection<Class> Classes => _classes;

    public void AddClass(Class cls)
    {
        _classes.Add(cls);
    }

    public void RemoveClass(Class cls)
    {
        _classes.Remove(cls);
    }
}