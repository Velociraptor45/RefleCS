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
        _usings.Add(usng);
    }
}