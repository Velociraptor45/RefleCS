namespace RefleCS.Nodes;

public class CsFile
{
    private readonly List<Using> _usings;

    public CsFile(IEnumerable<Using> usings, Namespace nmsp)
    {
        _usings = usings.ToList();
        Nmsp = nmsp;
    }

    public IReadOnlyCollection<Using> Usings => _usings;

    public Namespace Nmsp { get; }

    public void AddUsing(Using usng)
    {
        if (_usings.Contains(usng))
            return;

        _usings.Add(usng);
    }

    public void RemoveUsing(Using usng)
    {
        _usings.Remove(usng);
    }

    public void OrderUsingsAsc()
    {
        _usings.Sort((obj1, obj2) => string.Compare(obj1.Value, obj2.Value, StringComparison.Ordinal));
    }

    public void OrderUsingsDesc()
    {
        _usings.Sort((obj1, obj2) => string.Compare(obj2.Value, obj1.Value, StringComparison.Ordinal));
    }
}