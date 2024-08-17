namespace RefleCS.Nodes;

/// <summary>
/// Represents a C# file. Contains a list of using directives and a file-scoped namespace.
/// </summary>
public class CsFile
{
    private readonly List<Using> _usings;

    /// <summary>
    /// </summary>
    /// <param name="usings"></param>
    /// <param name="nmsp"></param>
    public CsFile(IEnumerable<Using> usings, Namespace nmsp)
    {
        _usings = usings.ToList();
        Nmsp = nmsp;
    }

    /// <summary>
    /// A list of using directives in the file.
    /// </summary>
    public IReadOnlyCollection<Using> Usings => _usings;

    /// <summary>
    /// The file-scoped namespace.
    /// </summary>
    public Namespace Nmsp { get; }

    /// <summary>
    /// Adds a using directive to the file. If the using directive already exists, it will not be added again.
    /// </summary>
    /// <param name="usng"></param>
    /// <returns></returns>
    public CsFile AddUsing(Using usng)
    {
        if (!_usings.Contains(usng))
            _usings.Add(usng);

        return this;
    }

    /// <summary>
    /// Removes a using directive from the file. If the using directive does not exist, nothing will happen.
    /// </summary>
    /// <param name="usng"></param>
    /// <returns></returns>
    public CsFile RemoveUsing(Using usng)
    {
        _usings.Remove(usng);
        return this;
    }

    /// <summary>
    /// Orders the using directives in ascending order.
    /// </summary>
    /// <returns></returns>
    public CsFile OrderUsingsAsc()
    {
        _usings.Sort((obj1, obj2) => string.Compare(obj1.Value, obj2.Value, StringComparison.Ordinal));
        return this;
    }

    /// <summary>
    /// Orders the using directives in descending order.
    /// </summary>
    /// <returns></returns>
    public CsFile OrderUsingsDesc()
    {
        _usings.Sort((obj1, obj2) => string.Compare(obj2.Value, obj1.Value, StringComparison.Ordinal));
        return this;
    }
}