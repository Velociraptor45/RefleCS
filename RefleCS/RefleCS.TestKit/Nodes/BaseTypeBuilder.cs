using RefleCS.Nodes;

namespace RefleCS.TestKit.Nodes;
public class BaseTypeBuilder : TestBuilderBase<BaseType>
{
    public BaseTypeBuilder WithValue(string Value)
    {
        FillConstructorWith(nameof(Value), Value);
        return this;
    }
}