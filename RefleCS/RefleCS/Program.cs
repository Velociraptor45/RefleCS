// See https://aka.ms/new-console-template for more information

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using RefleCS.Converters;

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

var csFileConverter = new CsFileConverter();

var tree = CSharpSyntaxTree.ParseText(content);
var file = csFileConverter.ToCsFile(tree);

var text = csFileConverter.ToNode(file).SyntaxTree.GetRoot().NormalizeWhitespace().GetText();

File.WriteAllText(@"H:\Programming\Repositories\RefleCS\RefleCS\mycsfile.cs", text.ToString());

Console.WriteLine("");