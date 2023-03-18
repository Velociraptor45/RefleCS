using FluentAssertions;
using ReflecCS.TestKit;
using ReflecCS.TestKit.Common.Customizations;
using RefleCS.Enums;
using RefleCS.Nodes;
using RefleCS.TestKit.Nodes;
using RefleCS.TestTools.Exceptions;

namespace RefleCS.Tests.Nodes;

public class PropertyTests
{
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void ChangeName_WithEmptyName_ShouldThrow(string name)
    {
        // Arrange
        var sut = new TestBuilder<Property>().Create();

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
        var sut = new TestBuilder<Property>().Create();

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
        var sut = new TestBuilder<Property>().Create();

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
        var sut = new TestBuilder<Property>().Create();

        // Act
        sut.ChangeTypeName(returnTypeName);

        // Assert
        sut.TypeName.Should().Be(returnTypeName);
    }

    public class AddModifier
    {
        private readonly AddModifierFixture _fixture;

        public AddModifier()
        {
            _fixture = new AddModifierFixture();
        }

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
            private readonly PropertyBuilder _builder;

            public AddModifierFixture()
            {
                _builder = new PropertyBuilder();
            }

            public PropertyModifier? Modifier { get; private set; }

            public void SetupModifier()
            {
                Modifier = new TestBuilder<PropertyModifier>().Create();
            }

            public void SetupInitialDifferentModifier()
            {
                TestPropertyNotSetException.ThrowIfNull(Modifier);

                var builder = new TestBuilder<PropertyModifier>();
                builder.Customize(
                    new EnumExclusionCustomization<PropertyModifier>(new List<PropertyModifier> { Modifier.Value }));

                var modifiers = builder.CreateMany(1);

                _builder.WithModifiers(modifiers);
            }

            public void SetupInitialSameModifier()
            {
                TestPropertyNotSetException.ThrowIfNull(Modifier);

                _builder.WithModifiers(new List<PropertyModifier> { Modifier.Value });
            }

            public Property CreateSut()
            {
                return _builder.Create();
            }
        }
    }

    public class RemoveModifier
    {
        private readonly RemoveModifierFixture _fixture;

        public RemoveModifier()
        {
            _fixture = new RemoveModifierFixture();
        }

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
            private readonly PropertyBuilder _builder;

            public RemoveModifierFixture()
            {
                _builder = new PropertyBuilder();
            }

            public PropertyModifier? Modifier { get; private set; }

            public void SetupInitialDuplicatedModifiers()
            {
                var modifier = new TestBuilder<PropertyModifier>().Create();

                _builder.WithModifiers(new List<PropertyModifier> { modifier, modifier });
            }

            public void SetupModifierToRemove(Property cls)
            {
                Modifier = cls.Modifiers.ElementAt(1);
            }

            public Property CreateSut()
            {
                return _builder.Create();
            }
        }
    }

    public class AddPropertyAccessor
    {
        private readonly AddPropertyAccessorFixture _fixture;

        public AddPropertyAccessor()
        {
            _fixture = new AddPropertyAccessorFixture();
        }

        [Fact]
        public void AddPropertyAccessor_ShouldAddPropertyAccessor()
        {
            // Arrange
            var sut = _fixture.CreateSut();
            _fixture.SetupPropertyAccessor();
            var accessorCount = sut.Accessors.Count;

            TestPropertyNotSetException.ThrowIfNull(_fixture.PropertyAccessor);

            // Act
            sut.AddAccessor(_fixture.PropertyAccessor);

            // Assert
            sut.Accessors.Should().Contain(_fixture.PropertyAccessor);
            sut.Accessors.Should().HaveCount(accessorCount + 1);
        }

        private class AddPropertyAccessorFixture
        {
            private readonly PropertyBuilder _builder;

            public AddPropertyAccessorFixture()
            {
                _builder = new PropertyBuilder();
            }

            public PropertyAccessor? PropertyAccessor { get; private set; }

            public void SetupPropertyAccessor()
            {
                PropertyAccessor = new PropertyAccessorBuilder().Create();
            }

            public Property CreateSut()
            {
                return _builder.Create();
            }
        }
    }

    public class RemovePropertyAccessor
    {
        private readonly RemovePropertyAccessorFixture _fixture;

        public RemovePropertyAccessor()
        {
            _fixture = new RemovePropertyAccessorFixture();
        }

        [Fact]
        public void RemovePropertyAccessor_ShouldRemovePropertyAccessor()
        {
            // Arrange
            _fixture.SetupInitialPropertyAccessors();
            var sut = _fixture.CreateSut();
            _fixture.SetupPropertyAccessorToRemove(sut);
            var accessorCount = sut.Accessors.Count;

            TestPropertyNotSetException.ThrowIfNull(_fixture.PropertyAccessor);

            // Act
            sut.RemoveAccessor(_fixture.PropertyAccessor);

            // Assert
            sut.Accessors.Should().HaveCount(accessorCount - 1);
            sut.Accessors.Should().NotContain(_fixture.PropertyAccessor);
        }

        private class RemovePropertyAccessorFixture
        {
            private readonly PropertyBuilder _builder;

            public RemovePropertyAccessorFixture()
            {
                _builder = new PropertyBuilder();
            }

            public PropertyAccessor? PropertyAccessor { get; private set; }

            public void SetupInitialPropertyAccessors()
            {
                _builder.WithAccessors(new PropertyAccessorBuilder().CreateMany(3));
            }

            public void SetupPropertyAccessorToRemove(Property cls)
            {
                PropertyAccessor = cls.Accessors.ElementAt(1);
            }

            public Property CreateSut()
            {
                return _builder.Create();
            }
        }
    }
}