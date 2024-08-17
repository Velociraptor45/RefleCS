using FluentAssertions;
using RefleCS.Enums;
using RefleCS.Nodes;
using RefleCS.TestKit;
using RefleCS.TestKit.Common.Customizations;
using RefleCS.TestKit.Nodes;
using RefleCS.TestTools.Exceptions;

namespace RefleCS.Tests.Nodes;

public class ClassTests
{
    public class AddProperty
    {
        private readonly AddPropertyFixture _fixture = new();

        [Fact]
        public void AddProperty_ShouldAddProperty()
        {
            // Arrange
            var sut = _fixture.CreateSut();
            _fixture.SetupProperty();
            var parameterCount = sut.Properties.Count;

            TestPropertyNotSetException.ThrowIfNull(_fixture.Property);

            // Act
            var result = sut.AddProperty(_fixture.Property);

            // Assert
            result.Should().Be(sut);
            sut.Properties.Should().Contain(_fixture.Property);
            sut.Properties.Should().HaveCount(parameterCount + 1);
        }

        private class AddPropertyFixture
        {
            private readonly ClassBuilder _builder = new();

            public Property? Property { get; private set; }

            public void SetupProperty()
            {
                Property = new PropertyBuilder().Create();
            }

            public Class CreateSut()
            {
                return _builder.Create();
            }
        }
    }

    public class RemoveProperty
    {
        private readonly RemovePropertyFixture _fixture = new();

        [Fact]
        public void RemoveProperty_ShouldRemoveProperty()
        {
            // Arrange
            _fixture.SetupInitialProperties();
            var sut = _fixture.CreateSut();
            _fixture.SetupPropertyToRemove(sut);
            var parameterCount = sut.Properties.Count;

            TestPropertyNotSetException.ThrowIfNull(_fixture.Property);

            // Act
            var result = sut.RemoveProperty(_fixture.Property);

            // Assert
            result.Should().Be(sut);
            sut.Properties.Should().HaveCount(parameterCount - 1);
            sut.Properties.Should().NotContain(_fixture.Property);
        }

        private class RemovePropertyFixture
        {
            private readonly ClassBuilder _builder = new();

            public Property? Property { get; private set; }

            public void SetupInitialProperties()
            {
                _builder
                    .WithProperties(new PropertyBuilder().CreateMany(3));
            }

            public void SetupPropertyToRemove(Class cls)
            {
                Property = cls.Properties.ElementAt(1);
            }

            public Class CreateSut()
            {
                return _builder.Create();
            }
        }
    }

    public class AddBaseType
    {
        private readonly AddBaseTypeFixture _fixture = new();

        [Fact]
        public void AddBaseType_ShouldAddBaseType()
        {
            // Arrange
            var sut = _fixture.CreateSut();
            _fixture.SetupBaseType();
            var parameterCount = sut.BaseTypes.Count;

            TestPropertyNotSetException.ThrowIfNull(_fixture.BaseType);

            // Act
            var result = sut.AddBaseType(_fixture.BaseType);

            // Assert
            result.Should().Be(sut);
            sut.BaseTypes.Should().Contain(_fixture.BaseType);
            sut.BaseTypes.Should().HaveCount(parameterCount + 1);
        }

        private class AddBaseTypeFixture
        {
            private readonly ClassBuilder _builder = new();

            public BaseType? BaseType { get; private set; }

            public void SetupBaseType()
            {
                BaseType = new BaseTypeBuilder().Create();
            }

            public Class CreateSut()
            {
                return _builder.Create();
            }
        }
    }

    public class RemoveBaseType
    {
        private readonly RemoveBaseTypeFixture _fixture = new();

        [Fact]
        public void RemoveBaseType_ShouldRemoveBaseType()
        {
            // Arrange
            _fixture.SetupInitialBaseTypes();
            var sut = _fixture.CreateSut();
            _fixture.SetupBaseTypeToRemove(sut);
            var parameterCount = sut.BaseTypes.Count;

            TestPropertyNotSetException.ThrowIfNull(_fixture.BaseType);

            // Act
            var result = sut.RemoveBaseType(_fixture.BaseType);

            // Assert
            result.Should().Be(sut);
            sut.BaseTypes.Should().HaveCount(parameterCount - 1);
            sut.BaseTypes.Should().NotContain(_fixture.BaseType);
        }

        private class RemoveBaseTypeFixture
        {
            private readonly ClassBuilder _builder = new();

            public BaseType? BaseType { get; private set; }

            public void SetupInitialBaseTypes()
            {
                _builder
                    .WithBaseTypes(new BaseTypeBuilder().CreateMany(3));
            }

            public void SetupBaseTypeToRemove(Class cls)
            {
                BaseType = cls.BaseTypes.ElementAt(1);
            }

            public Class CreateSut()
            {
                return _builder.Create();
            }
        }
    }

    public class RemoveAllBaseTypes
    {
        private readonly RemoveAllBaseTypesFixture _fixture = new();

        [Fact]
        public void RemoveAllBaseTypes_ShouldRemoveBaseType()
        {
            // Arrange
            _fixture.SetupInitialBaseTypes();
            var sut = _fixture.CreateSut();

            // Act
            var result = sut.RemoveAllBaseTypes();

            // Assert
            result.Should().Be(sut);
            sut.BaseTypes.Should().BeEmpty();
        }

        private class RemoveAllBaseTypesFixture
        {
            private readonly ClassBuilder _builder = new();

            public void SetupInitialBaseTypes()
            {
                _builder
                    .WithBaseTypes(new BaseTypeBuilder().CreateMany(3));
            }

            public Class CreateSut()
            {
                return _builder.Create();
            }
        }
    }

    public class AddMethod
    {
        private readonly AddMethodFixture _fixture = new();

        [Fact]
        public void AddMethod_ShouldAddMethod()
        {
            // Arrange
            var sut = _fixture.CreateSut();
            _fixture.SetupMethod();
            var parameterCount = sut.Methods.Count;

            TestPropertyNotSetException.ThrowIfNull(_fixture.Method);

            // Act
            var result = sut.AddMethod(_fixture.Method);

            // Assert
            result.Should().Be(sut);
            sut.Methods.Should().Contain(_fixture.Method);
            sut.Methods.Should().HaveCount(parameterCount + 1);
        }

        private class AddMethodFixture
        {
            private readonly ClassBuilder _builder = new();

            public Method? Method { get; private set; }

            public void SetupMethod()
            {
                Method = new MethodBuilder().Create();
            }

            public Class CreateSut()
            {
                return _builder.Create();
            }
        }
    }

    public class RemoveMethod
    {
        private readonly RemoveMethodFixture _fixture = new();

        [Fact]
        public void RemoveMethod_ShouldRemoveMethod()
        {
            // Arrange
            _fixture.SetupInitialMethods();
            var sut = _fixture.CreateSut();
            _fixture.SetupMethodToRemove(sut);
            var parameterCount = sut.Methods.Count;

            TestPropertyNotSetException.ThrowIfNull(_fixture.Method);

            // Act
            var result = sut.RemoveMethod(_fixture.Method);

            // Assert
            result.Should().Be(sut);
            sut.Methods.Should().HaveCount(parameterCount - 1);
            sut.Methods.Should().NotContain(_fixture.Method);
        }

        private class RemoveMethodFixture
        {
            private readonly ClassBuilder _builder = new();

            public Method? Method { get; private set; }

            public void SetupInitialMethods()
            {
                _builder
                    .WithMethods(new MethodBuilder().CreateMany(3));
            }

            public void SetupMethodToRemove(Class cls)
            {
                Method = cls.Methods.ElementAt(1);
            }

            public Class CreateSut()
            {
                return _builder.Create();
            }
        }
    }

    public class AddConstructor
    {
        private readonly AddConstructorFixture _fixture = new();

        [Fact]
        public void AddConstructor_ShouldAddConstructor()
        {
            // Arrange
            var sut = _fixture.CreateSut();
            _fixture.SetupConstructor();
            var parameterCount = sut.Constructors.Count;

            TestPropertyNotSetException.ThrowIfNull(_fixture.Constructor);

            // Act
            var result = sut.AddConstructor(_fixture.Constructor);

            // Assert
            result.Should().Be(sut);
            sut.Constructors.Should().Contain(_fixture.Constructor);
            sut.Constructors.Should().HaveCount(parameterCount + 1);
        }

        private class AddConstructorFixture
        {
            private readonly ClassBuilder _builder = new();

            public Constructor? Constructor { get; private set; }

            public void SetupConstructor()
            {
                Constructor = new ConstructorBuilder().Create();
            }

            public Class CreateSut()
            {
                return _builder.Create();
            }
        }
    }

    public class RemoveConstructor
    {
        private readonly RemoveConstructorFixture _fixture = new();

        [Fact]
        public void RemoveConstructor_ShouldRemoveConstructor()
        {
            // Arrange
            _fixture.SetupInitialConstructors();
            var sut = _fixture.CreateSut();
            _fixture.SetupConstructorToRemove(sut);
            var parameterCount = sut.Constructors.Count;

            TestPropertyNotSetException.ThrowIfNull(_fixture.Constructor);

            // Act
            var result = sut.RemoveConstructor(_fixture.Constructor);

            // Assert
            result.Should().Be(sut);
            sut.Constructors.Should().HaveCount(parameterCount - 1);
            sut.Constructors.Should().NotContain(_fixture.Constructor);
        }

        private class RemoveConstructorFixture
        {
            private readonly ClassBuilder _builder = new();

            public Constructor? Constructor { get; private set; }

            public void SetupInitialConstructors()
            {
                _builder
                    .WithConstructors(new ConstructorBuilder().CreateMany(3));
            }

            public void SetupConstructorToRemove(Class cls)
            {
                Constructor = cls.Constructors.ElementAt(1);
            }

            public Class CreateSut()
            {
                return _builder.Create();
            }
        }
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
            var parameterCount = sut.Modifiers.Count;

            TestPropertyNotSetException.ThrowIfNull(_fixture.Modifier);

            // Act
            var result = sut.AddModifier(_fixture.Modifier.Value);

            // Assert
            result.Should().Be(sut);
            sut.Modifiers.Should().Contain(_fixture.Modifier.Value);
            sut.Modifiers.Should().HaveCount(parameterCount + 1);
        }

        [Fact]
        public void AddModifier_WithModifierAlreadyExisting_ShouldNotAddModifier()
        {
            // Arrange
            _fixture.SetupModifier();
            _fixture.SetupInitialSameModifier();
            var sut = _fixture.CreateSut();
            var parameterCount = sut.Modifiers.Count;

            TestPropertyNotSetException.ThrowIfNull(_fixture.Modifier);

            // Act
            var result = sut.AddModifier(_fixture.Modifier.Value);

            // Assert
            result.Should().Be(sut);
            sut.Modifiers.Should().Contain(_fixture.Modifier.Value);
            sut.Modifiers.Should().HaveCount(parameterCount);
        }

        private class AddModifierFixture
        {
            private readonly ClassBuilder _builder = new();

            public ClassModifier? Modifier { get; private set; }

            public void SetupModifier()
            {
                Modifier = new TestBuilder<ClassModifier>().Create();
            }

            public void SetupInitialDifferentModifier()
            {
                TestPropertyNotSetException.ThrowIfNull(Modifier);

                var builder = new TestBuilder<ClassModifier>();
                builder.Customize(
                    new EnumExclusionCustomization<ClassModifier>(new List<ClassModifier> { Modifier.Value }));

                var modifiers = builder.CreateMany(1);

                _builder.WithModifiers(modifiers);
            }

            public void SetupInitialSameModifier()
            {
                TestPropertyNotSetException.ThrowIfNull(Modifier);

                _builder.WithModifiers(new List<ClassModifier> { Modifier.Value });
            }

            public Class CreateSut()
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
            var result = sut.RemoveModifier(_fixture.Modifier.Value);

            // Assert
            result.Should().Be(sut);
            sut.Modifiers.Should().BeEmpty();
        }

        private class RemoveModifierFixture
        {
            private readonly ClassBuilder _builder = new();

            public ClassModifier? Modifier { get; private set; }

            public void SetupInitialDuplicatedModifiers()
            {
                var modifier = new TestBuilder<ClassModifier>().Create();

                _builder.WithModifiers(new List<ClassModifier> { modifier, modifier });
            }

            public void SetupModifierToRemove(Class cls)
            {
                Modifier = cls.Modifiers.ElementAt(1);
            }

            public Class CreateSut()
            {
                return _builder.Create();
            }
        }
    }
}