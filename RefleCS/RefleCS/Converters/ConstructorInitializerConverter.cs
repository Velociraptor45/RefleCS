using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RefleCS.Extensions;
using RefleCS.Nodes;

namespace RefleCS.Converters;

internal class ConstructorInitializerConverter
{
    private readonly ModifierConverter _modifierConverter = new();
    private readonly ArgumentConverter _argumentConverter = new();

    public ConstructorInitializer ToConstructorInitializer(ConstructorInitializerSyntax initializer)
    {
        var type = _modifierConverter.ToConstructorInitializerType(initializer.ThisOrBaseKeyword);
        var args = _argumentConverter.ToArgument(initializer.ArgumentList.Arguments);
        return new ConstructorInitializer(type, args);
    }

    public ConstructorInitializerSyntax ToNode(ConstructorInitializer initializer)
    {
        var kind = initializer.Type.GetSyntaxKind();
        var args = _argumentConverter.ToNode(initializer.Arguments);
        var argsList = SyntaxFactory.ArgumentList()
            .AddArguments(args.ToArray());
        return SyntaxFactory.ConstructorInitializer(kind, argsList);
    }
}