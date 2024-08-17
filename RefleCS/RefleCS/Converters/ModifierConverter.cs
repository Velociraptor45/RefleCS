using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using RefleCS.Enums;
using RefleCS.Extensions;

namespace RefleCS.Converters;

internal class ModifierConverter
{
    public ConstructorInitializerType ToConstructorInitializerType(SyntaxToken modifier)
    {
        return ToModifier<ConstructorInitializerType>(modifier);
    }

    public IEnumerable<ConstructorInitializerType> ToConstructorInitializerType(IEnumerable<SyntaxToken> modifiers)
    {
        foreach (var modifier in modifiers)
        {
            yield return ToConstructorInitializerType(modifier);
        }
    }

    public ClassModifier ToClassModifier(SyntaxToken modifier)
    {
        return ToModifier<ClassModifier>(modifier);
    }

    public IEnumerable<ClassModifier> ToClassModifier(IEnumerable<SyntaxToken> modifiers)
    {
        foreach (var modifier in modifiers)
        {
            yield return ToClassModifier(modifier);
        }
    }

    public ConstructorModifier ToConstructorModifier(SyntaxToken modifier)
    {
        return ToModifier<ConstructorModifier>(modifier);
    }

    public IEnumerable<ConstructorModifier> ToConstructorModifier(IEnumerable<SyntaxToken> modifiers)
    {
        foreach (var modifier in modifiers)
        {
            yield return ToConstructorModifier(modifier);
        }
    }

    public PropertyModifier ToPropertyModifier(SyntaxToken modifier)
    {
        return ToModifier<PropertyModifier>(modifier);
    }

    public IEnumerable<PropertyModifier> ToPropertyModifier(IEnumerable<SyntaxToken> modifiers)
    {
        foreach (var modifier in modifiers)
        {
            yield return ToPropertyModifier(modifier);
        }
    }

    public MethodModifier ToMethodModifier(SyntaxToken modifier)
    {
        return ToModifier<MethodModifier>(modifier);
    }

    public IEnumerable<MethodModifier> ToMethodModifier(IEnumerable<SyntaxToken> modifiers)
    {
        foreach (var modifier in modifiers)
        {
            yield return ToMethodModifier(modifier);
        }
    }

    public ParameterModifier ToParameterModifier(SyntaxToken modifier)
    {
        return ToModifier<ParameterModifier>(modifier);
    }

    public IEnumerable<ParameterModifier> ToParameterModifier(IEnumerable<SyntaxToken> modifiers)
    {
        foreach (var modifier in modifiers)
        {
            yield return ToParameterModifier(modifier);
        }
    }

    public AccessorModifier ToAccessorModifier(SyntaxToken modifier)
    {
        return ToModifier<AccessorModifier>(modifier);
    }

    public IEnumerable<AccessorModifier> ToAccessorModifier(IEnumerable<SyntaxToken> modifiers)
    {
        foreach (var modifier in modifiers)
        {
            yield return ToAccessorModifier(modifier);
        }
    }

    private T ToModifier<T>(SyntaxToken modifier) where T : Enum
    {
        if (!Enum.TryParse(typeof(T), modifier.ValueText, true, out var result))
            throw new InvalidOperationException($"Could not find {typeof(T).Name} for {modifier.ValueText}");

        return (T)result!;
    }

    public SyntaxToken ToNode(ConstructorInitializerType modifier)
    {
        return ToNode<ConstructorInitializerType>(modifier);
    }

    public SyntaxTokenList ToNode(IEnumerable<ClassModifier> modifiers)
    {
        return ToNode<ClassModifier>(modifiers);
    }

    public SyntaxTokenList ToNode(IEnumerable<ConstructorModifier> modifiers)
    {
        return ToNode<ConstructorModifier>(modifiers);
    }

    public SyntaxTokenList ToNode(IEnumerable<PropertyModifier> modifiers)
    {
        return ToNode<PropertyModifier>(modifiers);
    }

    public SyntaxTokenList ToNode(IEnumerable<ParameterModifier> modifiers)
    {
        return ToNode<ParameterModifier>(modifiers);
    }

    public SyntaxTokenList ToNode(IEnumerable<MethodModifier> modifiers)
    {
        return ToNode<MethodModifier>(modifiers);
    }

    public SyntaxTokenList ToNode(IEnumerable<AccessorModifier> modifiers)
    {
        return ToNode<AccessorModifier>(modifiers);
    }

    private SyntaxTokenList ToNode<T>(IEnumerable<T> modifiers) where T : Enum
    {
        return SyntaxFactory.TokenList().AddRange(modifiers.Select(ToNode));
    }

    private SyntaxToken ToNode<T>(T modifier) where T : Enum
    {
        return SyntaxFactory.Token(modifier.GetSyntaxKind());
    }
}