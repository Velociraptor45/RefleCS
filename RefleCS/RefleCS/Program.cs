// See https://aka.ms/new-console-template for more information

using Microsoft.CodeAnalysis;
using RefleCS.Converters;
using RefleCS.Nodes;

Console.WriteLine("Hello, World!");

var content = @"using System;
using System.Linq;

namespace MyApp;

public sealed class App
{
    public App(int? id, IEnumerable<int> enumerables)
    {
        Id = id.Value;
        Ens = enumerables.ToList();
    }

    public protected int Id { get; set; }
    public IReadOnlyCollection<int> Ens { get; }

    // my comment
    // another comment ???
    /*
     * my other comment
     */
    void CheckIfTrue(bool bl, out int x)
    {
        return bl;
    }
}";

var csFileConverter = new CsFileConverter();
var file = csFileConverter.ToCsFileFromContent(content);

var method = Method.NewPublic(
    "int",
    "MyCoolMethod",
    new List<Parameter>(),
    new List<Statement>
    {
        new("Console.WriteLine(\"Hello World\");"),
        new("return 42;")
    });

file.Nmsp.Classes.First().AddMethod(method);

var text = csFileConverter.ToNode(file).SyntaxTree.GetRoot().NormalizeWhitespace().GetText();

File.WriteAllText(@"H:\Programming\Repositories\RefleCS\RefleCS\mycsfile.cs", text.ToString());

Console.WriteLine("");

/*
 * TODO
 * - change to class lib
 * - handle warnings
 */