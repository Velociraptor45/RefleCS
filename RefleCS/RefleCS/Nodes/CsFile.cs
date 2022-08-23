namespace RefleCS.Nodes;

public class CsFile
{
    public CsFile(IEnumerable<Using> usings, Namespace nmsp)
    {
        Usings = usings.ToList();
        Nmsp = nmsp;
    }

    public IReadOnlyCollection<Using> Usings { get; }
    public Namespace Nmsp { get; }
}