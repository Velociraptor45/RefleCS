using FluentAssertions;
using RefleCS.Enums;
using RefleCS.Nodes;

namespace RefleCS.Tests.Nodes;

public class FieldTests
{
    [Theory]
    [InlineData(FieldModifier.Public)]
    [InlineData(FieldModifier.Private)]
    [InlineData(FieldModifier.Protected)]
    [InlineData(FieldModifier.Internal)]
    public void Ctor_WithInitializer_ShouldReturnExpectedResult(FieldModifier modifier)
    {
        // Arrange
        var expectedFieldInitializer = new FieldInitializer("1");

        // Act
        var result = new Field(
            [modifier],
            "int",
            "fieldName",
            expectedFieldInitializer);

        // Assert
        result.Modifiers.Should().BeEquivalentTo([modifier]);
        result.TypeName.Should().Be("int");
        result.Name.Should().Be("fieldName");
        result.Initializer.Should().BeEquivalentTo(expectedFieldInitializer);
    }

    [Fact]
    public void Ctor_WithoutInitializer_ShouldReturnExpectedResult()
    {
        // Act
        var result = new Field(
            [FieldModifier.Public],
            "int",
            "fieldName",
            null);

        // Assert
        result.Modifiers.Should().BeEquivalentTo([FieldModifier.Public]);
        result.TypeName.Should().Be("int");
        result.Name.Should().Be("fieldName");
        result.Initializer.Should().BeNull();
    }
}