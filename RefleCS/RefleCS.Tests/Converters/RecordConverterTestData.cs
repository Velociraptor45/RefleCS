using RefleCS.Enums;
using RefleCS.Nodes;
using System.Collections;

namespace RefleCS.Tests.Converters;

public class RecordConverterTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return OnlyParameters();
        yield return WithConstructor();
        yield return WithMethods();
        yield return WithBaseType();
    }

    private static object[] OnlyParameters()
    {
        return new object[]
        {
            new Record(
                new List<ClassModifier> { ClassModifier.Public },
                "App",
                new List<Parameter> { new("int", "Id") },
                new List<Constructor>(),
                new List<Property>(),
                new List<Method>(),
                new List<BaseType>())
        };
    }

    private static object[] WithConstructor()
    {
        return new object[]
        {
            new Record(
                new List<ClassModifier> { ClassModifier.Public },
                "App",
                new List<Parameter> { new("int", "Id") },
                new List<Constructor>
                {
                    new(
                        new List<ConstructorModifier> { ConstructorModifier.Public },
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
                        new List<Accessor> { Accessor.Get })
                },
                new List<Method>(),
                new List<BaseType>())
        };
    }

    private static object[] WithMethods()
    {
        return new object[]
        {
            new Record(
                new List<ClassModifier> { ClassModifier.Public },
                "App",
                new List<Parameter> { new("int", "Id") },
                new List<Constructor>
                {
                    new(
                        new List<ConstructorModifier> { ConstructorModifier.Public },
                        "App",
                        new List<Parameter> { new("int", "id"), new("string", "name") },
                        new ConstructorInitializer(
                            ConstructorInitializerType.This,
                            new List<Argument> { new("id") }),
                        new List<Statement>())
                },
                new List<Property>(),
                new List<Method>
                {
                    new(
                        new List<Comment> { new("// todo next") },
                        new List<MethodModifier> { MethodModifier.Private },
                        "void",
                        "Next",
                        new List<Parameter>
                        {
                            new(
                                new List<ParameterModifier> { ParameterModifier.Out },
                                "int",
                                "nextVal")
                        },
                        new List<Statement> { new("nextVal = Ids.First()") })
                },
                new List<BaseType>())
        };
    }

    private static object[] WithBaseType()
    {
        return new object[]
        {
            new Record(
                new List<ClassModifier> { ClassModifier.Public },
                "App",
                new List<Parameter> { new("int", "Id") },
                new List<Constructor>(),
                new List<Property>(),
                new List<Method>(),
                new List<BaseType>
                {
                    new("MyBaseApp")
                })
        };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}