using RefleCS.Enums;
using RefleCS.Nodes;
using System.Collections;

namespace RefleCS.Tests.Converters;

public class CsFileConverterTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return WithRecord();
        yield return WithClass();
        yield return WithClass_EmptyFieldInitializer();
        yield return WithClass_NoBaseClass();
    }

    private object[] WithRecord()
    {
        return
        [
            new CsFile(
                new List<Using> { new("System") },
                new Namespace(
                    "MyApp",
                    [],
                    new List<Record>
                    {
                        new(
                            new List<ClassModifier> { ClassModifier.Public },
                            "App",
                            new List<Parameter> { new("int", "Id") },
                            new List<Constructor>()
                            {
                                new(
                                    new List<ConstructorModifier>() { ConstructorModifier.Public },
                                    "App",
                                    new List<Parameter> { new("int", "id"), new("string", "name") },
                                    new ConstructorInitializer(
                                        ConstructorInitializerType.This,
                                        new List<Argument> { new("id") }),
                                    new List<Statement>())
                            },
                            new List<Property>
                            {
                                new(
                                    new List<PropertyModifier> { PropertyModifier.Public },
                                    "string",
                                    "Name",
                                    new List<PropertyAccessor> { PropertyAccessor.Public(Accessor.Get) })
                            },
                            new List<Method>(),
                            new List<BaseType>())
                    }))
        ];
    }

    private object[] WithClass()
    {
        return
        [
            new CsFile(
                new List<Using>
                {
                    new("System"),
                    new("System.Linq")
                },
                new Namespace(
                    "MyApp",
                    new List<Class>
                    {
                        new(
                            new List<ClassModifier> { ClassModifier.Private },
                            "MyClass",
                            new List<Constructor>
                            {
                                new(
                                    new List<ConstructorModifier> { ConstructorModifier.Protected },
                                    "MyClass",
                                    new List<Parameter> { new("IEnumerable<int>", "ids") },
                                    new ConstructorInitializer(
                                        ConstructorInitializerType.Base,
                                        new List<Argument> { new("ids") }),
                                    new List<Statement> { new("Console.Log(\"Hello, World!\");") })
                            },
                            new List<Field>
                            {
                                new([FieldModifier.Public], "string", "_myString", new("\"Test\""))
                            },
                            new List<Property>
                            {
                                new(
                                    new List<PropertyModifier> { PropertyModifier.Public },
                                    "IReadOnlyCollection<int>",
                                    "Ids",
                                    new List<PropertyAccessor>
                                    {
                                        PropertyAccessor.Public(Accessor.Get),
                                        PropertyAccessor.Public(Accessor.Set)
                                    })
                            },
                            new List<Method>
                            {
                                new(
                                    new List<Comment> { new("// todo") },
                                    new List<MethodModifier> { MethodModifier.Protected },
                                    "void",
                                    "Next",
                                    new List<Parameter>
                                    {
                                        new(
                                            new List<ParameterModifier> { ParameterModifier.Out },
                                            "int",
                                            "nextVal")
                                    },
                                    new List<Statement> { new("nextVal = Ids.First();") })
                            },
                            new List<BaseType> { new("MyBaseClass") })
                    },
                    []))
        ];
    }

    private object[] WithClass_EmptyFieldInitializer()
    {
        return
        [
            new CsFile(
                new List<Using>
                {
                    new("System"),
                    new("System.Linq")
                },
                new Namespace(
                    "MyApp",
                    new List<Class>
                    {
                        new(
                            new List<ClassModifier> { ClassModifier.Private },
                            "MyClass",
                            new List<Constructor>(),
                            new List<Field>
                            {
                                new([FieldModifier.Public], "string", "_myString", null)
                            },
                            new List<Property>(),
                            new List<Method>(),
                            new List<BaseType> { new("MyBaseClass") })
                    },
                    []))
        ];
    }

    private object[] WithClass_NoBaseClass()
    {
        return
        [
            new CsFile(
                new List<Using>
                {
                    new("System"),
                    new("System.Linq")
                },
                new Namespace(
                    "MyApp",
                    new List<Class>
                    {
                        new(
                            new List<ClassModifier> { ClassModifier.Private },
                            "MyClass",
                            new List<Constructor>(),
                            new List<Field>(),
                            new List<Property>(),
                            new List<Method>(),
                            new List<BaseType>())
                    },
                    []))
        ];
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}