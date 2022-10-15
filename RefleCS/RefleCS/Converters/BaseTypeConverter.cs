using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RefleCS.Nodes;

namespace RefleCS.Converters;

internal class BaseTypeConverter
{
    public IEnumerable<BaseType> ToBaseType(BaseListSyntax baseList)
    {
        return baseList.Types.Select(t => new BaseType(t.ToString()));
    }

    public IEnumerable<BaseTypeSyntax> ToNode(IEnumerable<BaseType> baseTypes)
    {
        return baseTypes.Select(t => SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(t.Value)));
    }
}