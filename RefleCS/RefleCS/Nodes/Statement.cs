namespace RefleCS.Nodes;

/// <summary>
/// Represents a statement.
/// </summary>
public class Statement
{
    /// <summary>
    /// </summary>
    /// <param name="value"></param>
    public Statement(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The statement as a string.
    /// </summary>
    public string Value { get; }
}