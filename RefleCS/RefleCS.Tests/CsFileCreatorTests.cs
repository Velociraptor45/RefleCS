using FluentAssertions;
using RefleCS.Enums;
using RefleCS.Nodes;

namespace RefleCS.Tests;

public class CsFileCreatorTests
{
    [Fact]
    public void FromCode_WithCtor_ShouldReturnExpectedResult()
    {
        // Arrange
        var content = @"using System;
using System.Linq;

namespace MyApp;

public sealed class App
{
    public App(int? id)
    {
        Id = id.Value;
    }
}";

        var expectedResult = new CsFile(
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
                        new List<ClassModifier>
                        {
                            ClassModifier.Public,
                            ClassModifier.Sealed
                        },
                        "App",
                        new List<Constructor>
                        {
                            new(
                                new List<ConstructorModifier>
                                {
                                    ConstructorModifier.Public
                                },
                                "App",
                                new List<Parameter>
                                {
                                    new(
                                        new List<ParameterModifier>(),
                                        "int?",
                                        "id")
                                },
                                new List<Statement>
                                {
                                    new("Id = id.Value;")
                                })
                        },
                        new List<Property>(),
                        new List<Method>(),
                        new List<BaseType>())
                }));

        // Act
        var result = new CsFileHandler().FromCode(content);

        // Assert
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Theory]
    [InlineData("", new MethodModifier[] { })]
    [InlineData("public", new[] { MethodModifier.Public })]
    [InlineData("private", new[] { MethodModifier.Private })]
    [InlineData("protected", new[] { MethodModifier.Protected })]
    [InlineData("internal", new[] { MethodModifier.Internal })]
    [InlineData("private protected", new[] { MethodModifier.Private, MethodModifier.Protected })]
    [InlineData("public async", new[] { MethodModifier.Public, MethodModifier.Async })]
    [InlineData("private async", new[] { MethodModifier.Private, MethodModifier.Async })]
    [InlineData("protected async", new[] { MethodModifier.Protected, MethodModifier.Async })]
    [InlineData("internal async", new[] { MethodModifier.Internal, MethodModifier.Async })]
    [InlineData("private protected async", new[] { MethodModifier.Private, MethodModifier.Protected, MethodModifier.Async })]
    public void FromCode_WithMethod_ShouldReturnExpectedResult(string modifiers, MethodModifier[] expectedModifiers)
    {
        // Arrange
        var content = @$"using System;

namespace MyApp;

public sealed class App
{{
    // another comment ???
    /*
     * my other comment
     */
    {modifiers} void CheckIfTrue(bool bl)
    {{
        return bl;
    }}
}}";

        var expectedResult = new CsFile(
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
                        new List<Property>(),
                        new List<Method>
                        {
                            new(
                                new List<Comment>
                                {
                                    new("// another comment ???"),
                                    new("/*\r\n     * my other comment\r\n     */")
                                },
                                expectedModifiers,
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
                }));

        // Act
        var result = new CsFileHandler().FromCode(content);

        // Assert
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Theory]
    [InlineData("", new ParameterModifier[] { })]
    [InlineData("out", new[] { ParameterModifier.Out })]
    [InlineData("in", new[] { ParameterModifier.In })]
    [InlineData("ref", new[] { ParameterModifier.Ref })]
    [InlineData("ref out", new[] { ParameterModifier.Ref, ParameterModifier.Out })]
    [InlineData("ref in", new[] { ParameterModifier.Ref, ParameterModifier.In })]
    public void FromCode_WithMethodParameter_ShouldReturnExpectedResult(string modifiers,
        ParameterModifier[] expectedModifiers)
    {
        // Arrange
        var content = @$"using System;

namespace MyApp;

public sealed class App
{{
    void CheckIfTrue({modifiers} bool bl)
    {{
        return bl;
    }}
}}";

        var expectedResult = new CsFile(
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
                                        expectedModifiers,
                                        "bool",
                                        "bl")
                                },
                                new List<Statement>
                                {
                                    new("return bl;")
                                })
                        },
                        new List<BaseType>())
                }));

        // Act
        var result = new CsFileHandler().FromCode(content);

        // Assert
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public void FromCode_WithSuperclass_ShouldReturnExpectedResult()
    {
        // Arrange
        var content = @$"using System;

namespace MyApp;

public sealed class App : AnotherApp<int>, IImplement
{{
}}";

        var expectedResult = new CsFile(
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
                        new List<Property>(),
                        new List<Method>(),
                        new List<BaseType>
                        {
                            new("AnotherApp<int>"),
                            new("IImplement")
                        })
                }));

        // Act
        var result = new CsFileHandler().FromCode(content);

        // Assert
        result.Should().BeEquivalentTo(expectedResult);
    }
}