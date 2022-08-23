namespace RefleCS.Nodes;

public class Parameter
{
    public Parameter(string typeName, string identifier)
    {
        TypeName = typeName;
        Identifier = identifier;
    }

    public string TypeName { get; }
    public string Identifier { get; }
}