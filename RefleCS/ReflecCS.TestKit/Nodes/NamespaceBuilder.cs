using RefleCS.Nodes;
using ReflecCS.TestKit;

namespace RefleCS.TestKit.Nodes;
public class NamespaceBuilder : TestBuilderBase<Namespace>
{
    public NamespaceBuilder WithName(string name)
    {
        FillConstructorWith(nameof(name), name);
        return this;
    }

    public NamespaceBuilder WithClasses(IEnumerable<Class> classes)
    {
        FillConstructorWith(nameof(classes), classes);
        return this;
    }

    public NamespaceBuilder WithEmptyClasses()
    {
        return WithClasses(Enumerable.Empty<Class>());
    }

    public NamespaceBuilder WithRecords(IEnumerable<Record> records)
    {
        FillConstructorWith(nameof(records), records);
        return this;
    }

    public NamespaceBuilder WithEmptyRecords()
    {
        return WithRecords(Enumerable.Empty<Record>());
    }
}