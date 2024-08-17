using FluentAssertions;
using RefleCS.Enums;
using RefleCS.Nodes;
using RefleCS.TestKit;
using RefleCS.TestKit.Common.Customizations;
using RefleCS.TestKit.Nodes;
using RefleCS.TestTools.Exceptions;

namespace RefleCS.Tests.Nodes;

public class ParameterTests
{
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void ChangeName_WithEmptyName_ShouldThrow(string name)
    {
        // Arrange
        var sut = new TestBuilder<Parameter>().Create();

        // Act
        var func = () => sut.ChangeName(name);

        // Assert
        func.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void ChangeName_WithValidName_ShouldChangeName()
    {
        // Arrange
        var name = new TestBuilder<string>().Create();
        var sut = new TestBuilder<Parameter>().Create();

        // Act
        sut.ChangeName(name);

        // Assert
        sut.Name.Should().Be(name);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void ChangeTypeName_WithEmptyTypeName_ShouldThrow(string returnTypeName)
    {
        // Arrange
        var sut = new TestBuilder<Parameter>().Create();

        // Act
        var func = () => sut.ChangeTypeName(returnTypeName);

        // Assert
        func.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void ChangeTypeName_WithValidTypeName_ShouldChangeTypeName()
    {
        // Arrange
        var returnTypeName = new TestBuilder<string>().Create();
        var sut = new TestBuilder<Parameter>().Create();

        // Act
        sut.ChangeTypeName(returnTypeName);

        // Assert
        sut.TypeName.Should().Be(returnTypeName);
    }

    public class AddModifier
    {
        private readonly AddModifierFixture _fixture = new();

        [Fact]
        public void AddModifier_WithModifierNotAlreadyExisting_ShouldAddModifier()
        {
            // Arrange
            _fixture.SetupModifier();
            _fixture.SetupInitialDifferentModifier();
            var sut = _fixture.CreateSut();
            var modifierCount = sut.Modifiers.Count;

            TestPropertyNotSetException.ThrowIfNull(_fixture.Modifier);

            // Act
            sut.AddModifier(_fixture.Modifier.Value);

            // Assert
            sut.Modifiers.Should().Contain(_fixture.Modifier.Value);
            sut.Modifiers.Should().HaveCount(modifierCount + 1);
        }

        [Fact]
        public void AddModifier_WithModifierAlreadyExisting_ShouldNotAddModifier()
        {
            // Arrange
            _fixture.SetupModifier();
            _fixture.SetupInitialSameModifier();
            var sut = _fixture.CreateSut();
            var modifierCount = sut.Modifiers.Count;

            TestPropertyNotSetException.ThrowIfNull(_fixture.Modifier);

            // Act
            sut.AddModifier(_fixture.Modifier.Value);

            // Assert
            sut.Modifiers.Should().Contain(_fixture.Modifier.Value);
            sut.Modifiers.Should().HaveCount(modifierCount);
        }

        private class AddModifierFixture
        {
            private readonly ParameterBuilder _builder = new();

            public ParameterModifier? Modifier { get; private set; }

            public void SetupModifier()
            {
                Modifier = new TestBuilder<ParameterModifier>().Create();
            }

            public void SetupInitialDifferentModifier()
            {
                TestPropertyNotSetException.ThrowIfNull(Modifier);

                var builder = new TestBuilder<ParameterModifier>();
                builder.Customize(
                    new EnumExclusionCustomization<ParameterModifier>(new List<ParameterModifier> { Modifier.Value }));

                var modifiers = builder.CreateMany(1);

                _builder.WithModifiers(modifiers);
            }

            public void SetupInitialSameModifier()
            {
                TestPropertyNotSetException.ThrowIfNull(Modifier);

                _builder.WithModifiers(new List<ParameterModifier> { Modifier.Value });
            }

            public Parameter CreateSut()
            {
                return _builder.Create();
            }
        }
    }

    public class RemoveModifier
    {
        private readonly RemoveModifierFixture _fixture = new();

        [Fact]
        public void RemoveModifier_WithDuplicatedModifiers_ShouldRemoveModifier()
        {
            // Arrange
            _fixture.SetupInitialDuplicatedModifiers();
            var sut = _fixture.CreateSut();
            _fixture.SetupModifierToRemove(sut);

            TestPropertyNotSetException.ThrowIfNull(_fixture.Modifier);

            // Act
            sut.RemoveModifier(_fixture.Modifier.Value);

            // Assert
            sut.Modifiers.Should().BeEmpty();
        }

        private class RemoveModifierFixture
        {
            private readonly ParameterBuilder _builder = new();

            public ParameterModifier? Modifier { get; private set; }

            public void SetupInitialDuplicatedModifiers()
            {
                var modifier = new TestBuilder<ParameterModifier>().Create();

                _builder.WithModifiers(new List<ParameterModifier> { modifier, modifier });
            }

            public void SetupModifierToRemove(Parameter cls)
            {
                Modifier = cls.Modifiers.ElementAt(1);
            }

            public Parameter CreateSut()
            {
                return _builder.Create();
            }
        }
    }
}