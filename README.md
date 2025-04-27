# RefleCS

![Nuget](https://img.shields.io/nuget/dt/RefleCS)

## Description
RefleCS is a library that sits in front of the Roslyn C# parser and makes it easier to create new or edit existing C# files that are outside of an Assembly context.

Though basic work is done, RefleCS is still missing some CS language features. If you encounter any, please file an issue.

## Examples

### Create new file

You can create a new file by creating an instance of `CsFile` and saving it via the `CsFileHandler`

```C#
var file = new CsFile(
    new List<Using>
    {
        new("System")
    },
    new Namespace(
        "MyApp",
        new List<Class>
        {
            new(
                new List<ClassModifier>
                {
                    ClassModifier.Public,
                    ClassModifier.Sealed
                },
                "App",
                new List<Constructor>(),
                new List<Field>(),
                new List<Property>(),
                new List<Method>
                {
                    new(
                        new List<Comment>(),
                        new List<MethodModifier>(),
                        "void",
                        "CheckIfTrue",
                        new List<Parameter>
                        {
                            new(
                                "bool",
                                "bl")
                        },
                        new List<Statement>
                        {
                            new("return bl;")
                        })
                },
                new List<BaseType>())
        },
        Enumerable.Empty<Record>()));

new CsFileHandler().SaveOrReplace(file, @"C:/Temp/mycsfile.cs");
```

This will create the following file content:

```C#
using System;

namespace MyApp;

public sealed class App
{
    void CheckIfTrue(bool bl)
    {
        return bl;
    }
}
```

However, after creation of a `CsFile`, it's still possible to edit classes, methods, etc. For example by adding a new parameterless constructor:

```C#
file.Nmsp.Classes.First()
    .AddConstructor(
        new Constructor(
            new List<ConstructorModifier>() { ConstructorModifier.Public },
            "App",
            new List<Parameter>(),
            null,
            new List<Statement>() { new("Console.WriteLine(\"Ctor called!\");") }
        ));
```

### Edit an existing file

You can create a `CsFile` instance from an existing file in the file system
```C#
CsFile file = new CsFileHandler().FromPath(@"C:/Temp/mycsfile.cs");
```

or from C# code already loaded as a string

```C#
var csCode = @"using System;
namespace MyApp;
public class App {}";

CsFile file = new CsFileHandler().FromContent(csCode);
```

Then you can edit the `CsFile` and save it.

```C#
file.Nmsp.Classes.First()
    .AddConstructor(
        new Constructor(
            new List<ConstructorModifier>() { ConstructorModifier.Public },
            "App",
            new List<Parameter>(),
            null,
            new List<Statement>() { new("Console.WriteLine(\"Ctor called!\");") }
        ));

new CsFileHandler().SaveOrReplace(file, @"C:/Temp/mycsfile.cs");
```
