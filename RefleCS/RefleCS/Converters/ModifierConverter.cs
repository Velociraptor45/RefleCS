using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using RefleCS.Enums;
using RefleCS.Extensions;

namespace RefleCS.Converters;

internal class ModifierConverter
{
    public Modifier ToModifier(SyntaxToken modifier)
    {
        // todo handle parsing failure
        return (Modifier)Enum.Parse(typeof(Modifier), modifier.ValueText, true);
    }

    public IEnumerable<Modifier> ToModifier(IEnumerable<SyntaxToken> modifiers)
    {
        foreach (var modifier in modifiers)
        {
            yield return ToModifier(modifier);
        }
    }

    public SyntaxTokenList ToNode(IEnumerable<Modifier> modifiers)
    {
        return SyntaxFactory.TokenList()
            .AddRange(modifiers.Select(m => SyntaxFactory.Token(m.GetSyntaxKind())));
    }
}