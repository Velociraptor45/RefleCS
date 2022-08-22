// See https://aka.ms/new-console-template for more information

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using RefleCS;

Console.WriteLine("Hello, World!");

var content = @"using System;
namespace MyApp;

public class App
{
    public App(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}";

var tree = CSharpSyntaxTree.ParseText(content);
var root = tree.GetRoot();
var nmsp = root.DescendantNodes().OfType<FileScopedNamespaceDeclarationSyntax>().First();

var classes = new List<Class>();
foreach (var cls in nmsp.DescendantNodes().OfType<ClassDeclarationSyntax>())
{
    var properties = new List<Property>();
    foreach (var property in cls.DescendantNodes().OfType<PropertyDeclarationSyntax>())
    {
        var typeName = ((PredefinedTypeSyntax)property.Type).Keyword.Text;
        var accessors = new List<Accessor>();
        foreach (var accessor in property.AccessorList.Accessors)
        {
            accessors.Add(accessor.Kind() == SyntaxKind.GetAccessorDeclaration
                ? Accessor.Get
                : Accessor.Set);
        }
        properties.Add(new Property(typeName, property.Identifier.ToString(), accessors));
    }

    classes.Add(new Class(cls.Identifier.ToString(), properties));
}
var file = new CsFile(new Namespace(nmsp.Name.ToString(), classes));

//tree.GetRoot();

//tree.GetRoot()
//.DescendantNodes().ToList().Add(new NamespaceDeclarationSyntax())

var x = file.ToNode();
var text = x.SyntaxTree.GetRoot().NormalizeWhitespace().GetText();

File.WriteAllText(@"C:\Users\veloc\Documents\Projekte\RefleCS\mycsfile.cs", text.ToString());

Console.WriteLine("");