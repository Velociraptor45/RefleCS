﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using RefleCS.Enums;
using RefleCS.Extensions;

namespace RefleCS.Converters;

internal class ModifierConverter
{
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

    private T ToModifier<T>(SyntaxToken modifier) where T : Enum
    {
        // todo handle parsing failure
        return (T)Enum.Parse(typeof(T), modifier.ValueText, true);
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

    private SyntaxTokenList ToNode<T>(IEnumerable<T> modifiers) where T : Enum
    {
        return SyntaxFactory.TokenList()
            .AddRange(modifiers.Select(m => SyntaxFactory.Token(m.GetSyntaxKind())));
    }
}