namespace RefleCS.Nodes;

public class Namespace
{
    public Namespace(string name, IEnumerable<Class> classes)
    {
        Name = name;
        Classes = classes;
    }

    public string Name { get; }
    public IEnumerable<Class> Classes { get; }
}