﻿using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RefleCS.Enums;
using RefleCS.Nodes;

namespace RefleCS.Converters;

internal class PropertyConverter
{
    private readonly AccessorConverter _accessorConverter = new();
    private readonly ModifierConverter _modifierConverter = new();

    public Property ToProperty(PropertyDeclarationSyntax property)
    {
        var typeName = property.Type.ToString();
        var accessors = property.AccessorList is null
            ? Enumerable.Empty<Accessor>()
            : property.AccessorList.Accessors
            .Select(accessor => _accessorConverter.ToAccessor(accessor.Kind()));

        var modifiers = _modifierConverter.ToPropertyModifier(property.Modifiers);
        return new Property(modifiers, typeName, property.Identifier.ToString(), accessors);
    }

    public IEnumerable<Property> ToProperty(IEnumerable<PropertyDeclarationSyntax> properties)
    {
        foreach (var property in properties)
        {
            yield return ToProperty(property);
        }
    }

    public PropertyDeclarationSyntax ToNode(Property property)
    {
        var modifiers = _modifierConverter.ToNode(property.Modifiers);
        var accessors = _accessorConverter.ToNode(property.Accessors);

        var result = SyntaxFactory.PropertyDeclaration(SyntaxFactory.ParseTypeName(property.TypeName), property.Name)
            .WithModifiers(modifiers)
            .WithAccessorList(accessors);

        return result;
    }

    public IEnumerable<PropertyDeclarationSyntax> ToNode(IEnumerable<Property> properties)
    {
        foreach (var property in properties)
        {
            yield return ToNode(property);
        }
    }
}