using RefleCS.Enums;

namespace RefleCS.Nodes;

public class Constructor
{
    public Constructor(IEnumerable<ConstructorModifier> modifiers, string className, IEnumerable<Parameter> parameters,
        ConstructorInitializer? initializer, IEnumerable<Statement> statements)
    {
        ClassName = className;
        Initializer = initializer;
        Modifiers = modifiers.ToList();
        Statements = statements.ToList();
        Parameters = parameters.ToList();
    }

    public IReadOnlyCollection<ConstructorModifier> Modifiers { get; }
    public string ClassName { get; }
    public ConstructorInitializer? Initializer { get; }
    public IReadOnlyCollection<Parameter> Parameters { get; }
    public IReadOnlyCollection<Statement> Statements { get; }
}