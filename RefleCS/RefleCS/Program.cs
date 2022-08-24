// See https://aka.ms/new-console-template for more information

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using RefleCS.Converters;

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

var tree = CSharpSyntaxTree.ParseText(content);
var file = csFileConverter.ToCsFile(tree);

var text = csFileConverter.ToNode(file).SyntaxTree.GetRoot().NormalizeWhitespace().GetText();

File.WriteAllText(@"H:\Programming\Repositories\RefleCS\RefleCS\mycsfile.cs", text.ToString());

Console.WriteLine("");

/*
 * TODO
 * - add method
 * - change to class lib
 * - handle warnings
 */