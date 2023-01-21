using FluentAssertions;
using ReflecCS.TestKit;
using ReflecCS.TestKit.Common.Customizations;
using RefleCS.Enums;
using RefleCS.Nodes;
using RefleCS.TestKit.Nodes;
using RefleCS.TestTools.Exceptions;

namespace RefleCS.Tests.Nodes;

public class RecordTests
{
    public class AddParameter
    {
        private readonly AddParameterFixture _fixture;

        public AddParameter()
        {
            _fixture = new AddParameterFixture();
        }

        [Fact]
        public void AddParameter_ShouldAddParameter()
        {
            // Arrange
            var sut = _fixture.CreateSut();
            _fixture.SetupParameter();
            var parameterCount = sut.Parameters.Count;

            TestPropertyNotSetException.ThrowIfNull(_fixture.Parameter);

            // Act
            sut.AddParameter(_fixture.Parameter);

            // Assert
            sut.Parameters.Should().Contain(_fixture.Parameter);
            sut.Parameters.Should().HaveCount(parameterCount + 1);
        }

        private class AddParameterFixture
        {
            private readonly RecordBuilder _builder;

            public AddParameterFixture()
            {
                _builder = new RecordBuilder();
            }

            public Parameter? Parameter { get; private set; }

            public void SetupParameter()
            {
                Parameter = new ParameterBuilder().Create();
            }

            public Record CreateSut()
            {
                return _builder.Create();
            }
        }
    }

    public class RemoveParameter
    {
        private readonly RemoveParameterFixture _fixture;

        public RemoveParameter()
        {
            _fixture = new RemoveParameterFixture();
        }

        [Fact]
        public void RemoveParameter_ShouldRemoveParameter()
        {
            // Arrange
            _fixture.SetupInitialParameters();
            var sut = _fixture.CreateSut();
            _fixture.SetupParameterToRemove(sut);
            var parameterCount = sut.Parameters.Count;

            TestPropertyNotSetException.ThrowIfNull(_fixture.Parameter);

            // Act
            sut.RemoveParameter(_fixture.Parameter);

            // Assert
            sut.Parameters.Should().HaveCount(parameterCount - 1);
            sut.Parameters.Should().NotContain(_fixture.Parameter);
        }

        private class RemoveParameterFixture
        {
            private readonly RecordBuilder _builder;

            public RemoveParameterFixture()
            {
                _builder = new RecordBuilder();
            }

            public Parameter? Parameter { get; private set; }

            public void SetupInitialParameters()
            {
                _builder
                    .WithParameters(new ParameterBuilder().CreateMany(3));
            }

            public void SetupParameterToRemove(Record recrd)
            {
                Parameter = recrd.Parameters.ElementAt(1);
            }

            public Record CreateSut()
            {
                return _builder.Create();
            }
        }
    }

    public class AddProperty
    {
        private readonly AddPropertyFixture _fixture;

        public AddProperty()
        {
            _fixture = new AddPropertyFixture();
        }

        [Fact]
        public void AddProperty_ShouldAddProperty()
        {
            // Arrange
            var sut = _fixture.CreateSut();
            _fixture.SetupProperty();
            var parameterCount = sut.Properties.Count;

            TestPropertyNotSetException.ThrowIfNull(_fixture.Property);

            // Act
            sut.AddProperty(_fixture.Property);

            // Assert
            sut.Properties.Should().Contain(_fixture.Property);
            sut.Properties.Should().HaveCount(parameterCount + 1);
        }

        private class AddPropertyFixture
        {
            private readonly RecordBuilder _builder;

            public AddPropertyFixture()
            {
                _builder = new RecordBuilder();
            }

            public Property? Property { get; private set; }

            public void SetupProperty()
            {
                Property = new PropertyBuilder().Create();
            }

            public Record CreateSut()
            {
                return _builder.Create();
            }
        }
    }

    public class RemoveProperty
    {
        private readonly RemovePropertyFixture _fixture;

        public RemoveProperty()
        {
            _fixture = new RemovePropertyFixture();
        }

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
            sut.RemoveProperty(_fixture.Property);

            // Assert
            sut.Properties.Should().HaveCount(parameterCount - 1);
            sut.Properties.Should().NotContain(_fixture.Property);
        }

        private class RemovePropertyFixture
        {
            private readonly RecordBuilder _builder;

            public RemovePropertyFixture()
            {
                _builder = new RecordBuilder();
            }

            public Property? Property { get; private set; }

            public void SetupInitialProperties()
            {
                _builder
                    .WithProperties(new PropertyBuilder().CreateMany(3));
            }

            public void SetupPropertyToRemove(Record recrd)
            {
                Property = recrd.Properties.ElementAt(1);
            }

            public Record CreateSut()
            {
                return _builder.Create();
            }
        }
    }

    public class AddBaseType
    {
        private readonly AddBaseTypeFixture _fixture;

        public AddBaseType()
        {
            _fixture = new AddBaseTypeFixture();
        }

        [Fact]
        public void AddBaseType_ShouldAddBaseType()
        {
            // Arrange
            var sut = _fixture.CreateSut();
            _fixture.SetupBaseType();
            var parameterCount = sut.BaseTypes.Count;

            TestPropertyNotSetException.ThrowIfNull(_fixture.BaseType);

            // Act
            sut.AddBaseType(_fixture.BaseType);

            // Assert
            sut.BaseTypes.Should().Contain(_fixture.BaseType);
            sut.BaseTypes.Should().HaveCount(parameterCount + 1);
        }

        private class AddBaseTypeFixture
        {
            private readonly RecordBuilder _builder;

            public AddBaseTypeFixture()
            {
                _builder = new RecordBuilder();
            }

            public BaseType? BaseType { get; private set; }

            public void SetupBaseType()
            {
                BaseType = new BaseTypeBuilder().Create();
            }

            public Record CreateSut()
            {
                return _builder.Create();
            }
        }
    }

    public class RemoveBaseType
    {
        private readonly RemoveBaseTypeFixture _fixture;

        public RemoveBaseType()
        {
            _fixture = new RemoveBaseTypeFixture();
        }

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
            sut.RemoveBaseType(_fixture.BaseType);

            // Assert
            sut.BaseTypes.Should().HaveCount(parameterCount - 1);
            sut.BaseTypes.Should().NotContain(_fixture.BaseType);
        }

        private class RemoveBaseTypeFixture
        {
            private readonly RecordBuilder _builder;

            public RemoveBaseTypeFixture()
            {
                _builder = new RecordBuilder();
            }

            public BaseType? BaseType { get; private set; }

            public void SetupInitialBaseTypes()
            {
                _builder
                    .WithBaseTypes(new BaseTypeBuilder().CreateMany(3));
            }

            public void SetupBaseTypeToRemove(Record recrd)
            {
                BaseType = recrd.BaseTypes.ElementAt(1);
            }

            public Record CreateSut()
            {
                return _builder.Create();
            }
        }
    }

    public class RemoveAllBaseTypes
    {
        private readonly RemoveAllBaseTypesFixture _fixture;

        public RemoveAllBaseTypes()
        {
            _fixture = new RemoveAllBaseTypesFixture();
        }

        [Fact]
        public void RemoveAllBaseTypes_ShouldRemoveBaseType()
        {
            // Arrange
            _fixture.SetupInitialBaseTypes();
            var sut = _fixture.CreateSut();

            // Act
            sut.RemoveAllBaseTypes();

            // Assert
            sut.BaseTypes.Should().BeEmpty();
        }

        private class RemoveAllBaseTypesFixture
        {
            private readonly RecordBuilder _builder;

            public RemoveAllBaseTypesFixture()
            {
                _builder = new RecordBuilder();
            }

            public void SetupInitialBaseTypes()
            {
                _builder
                    .WithBaseTypes(new BaseTypeBuilder().CreateMany(3));
            }

            public Record CreateSut()
            {
                return _builder.Create();
            }
        }
    }

    public class AddMethod
    {
        private readonly AddMethodFixture _fixture;

        public AddMethod()
        {
            _fixture = new AddMethodFixture();
        }

        [Fact]
        public void AddMethod_ShouldAddMethod()
        {
            // Arrange
            var sut = _fixture.CreateSut();
            _fixture.SetupMethod();
            var parameterCount = sut.Methods.Count;

            TestPropertyNotSetException.ThrowIfNull(_fixture.Method);

            // Act
            sut.AddMethod(_fixture.Method);

            // Assert
            sut.Methods.Should().Contain(_fixture.Method);
            sut.Methods.Should().HaveCount(parameterCount + 1);
        }

        private class AddMethodFixture
        {
            private readonly RecordBuilder _builder;

            public AddMethodFixture()
            {
                _builder = new RecordBuilder();
            }

            public Method? Method { get; private set; }

            public void SetupMethod()
            {
                Method = new MethodBuilder().Create();
            }

            public Record CreateSut()
            {
                return _builder.Create();
            }
        }
    }

    public class RemoveMethod
    {
        private readonly RemoveMethodFixture _fixture;

        public RemoveMethod()
        {
            _fixture = new RemoveMethodFixture();
        }

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
            sut.RemoveMethod(_fixture.Method);

            // Assert
            sut.Methods.Should().HaveCount(parameterCount - 1);
            sut.Methods.Should().NotContain(_fixture.Method);
        }

        private class RemoveMethodFixture
        {
            private readonly RecordBuilder _builder;

            public RemoveMethodFixture()
            {
                _builder = new RecordBuilder();
            }

            public Method? Method { get; private set; }

            public void SetupInitialMethods()
            {
                _builder
                    .WithMethods(new MethodBuilder().CreateMany(3));
            }

            public void SetupMethodToRemove(Record recrd)
            {
                Method = recrd.Methods.ElementAt(1);
            }

            public Record CreateSut()
            {
                return _builder.Create();
            }
        }
    }

    public class AddConstructor
    {
        private readonly AddConstructorFixture _fixture;

        public AddConstructor()
        {
            _fixture = new AddConstructorFixture();
        }

        [Fact]
        public void AddConstructor_ShouldAddConstructor()
        {
            // Arrange
            var sut = _fixture.CreateSut();
            _fixture.SetupConstructor();
            var parameterCount = sut.Constructors.Count;

            TestPropertyNotSetException.ThrowIfNull(_fixture.Constructor);

            // Act
            sut.AddConstructor(_fixture.Constructor);

            // Assert
            sut.Constructors.Should().Contain(_fixture.Constructor);
            sut.Constructors.Should().HaveCount(parameterCount + 1);
        }

        private class AddConstructorFixture
        {
            private readonly RecordBuilder _builder;

            public AddConstructorFixture()
            {
                _builder = new RecordBuilder();
            }

            public Constructor? Constructor { get; private set; }

            public void SetupConstructor()
            {
                Constructor = new ConstructorBuilder().Create();
            }

            public Record CreateSut()
            {
                return _builder.Create();
            }
        }
    }

    public class RemoveConstructor
    {
        private readonly RemoveConstructorFixture _fixture;

        public RemoveConstructor()
        {
            _fixture = new RemoveConstructorFixture();
        }

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
            sut.RemoveConstructor(_fixture.Constructor);

            // Assert
            sut.Constructors.Should().HaveCount(parameterCount - 1);
            sut.Constructors.Should().NotContain(_fixture.Constructor);
        }

        private class RemoveConstructorFixture
        {
            private readonly RecordBuilder _builder;

            public RemoveConstructorFixture()
            {
                _builder = new RecordBuilder();
            }

            public Constructor? Constructor { get; private set; }

            public void SetupInitialConstructors()
            {
                _builder
                    .WithConstructors(new ConstructorBuilder().CreateMany(3));
            }

            public void SetupConstructorToRemove(Record recrd)
            {
                Constructor = recrd.Constructors.ElementAt(1);
            }

            public Record CreateSut()
            {
                return _builder.Create();
            }
        }
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
            var parameterCount = sut.Modifiers.Count;

            TestPropertyNotSetException.ThrowIfNull(_fixture.Modifier);

            // Act
            sut.AddModifier(_fixture.Modifier.Value);

            // Assert
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
            sut.AddModifier(_fixture.Modifier.Value);

            // Assert
            sut.Modifiers.Should().Contain(_fixture.Modifier.Value);
            sut.Modifiers.Should().HaveCount(parameterCount);
        }

        private class AddModifierFixture
        {
            private readonly RecordBuilder _builder;

            public AddModifierFixture()
            {
                _builder = new RecordBuilder();
            }

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

            public Record CreateSut()
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
            private readonly RecordBuilder _builder;

            public RemoveModifierFixture()
            {
                _builder = new RecordBuilder();
            }

            public ClassModifier? Modifier { get; private set; }

            public void SetupInitialDuplicatedModifiers()
            {
                var modifier = new TestBuilder<ClassModifier>().Create();

                _builder.WithModifiers(new List<ClassModifier> { modifier, modifier });
            }

            public void SetupModifierToRemove(Record recrd)
            {
                Modifier = recrd.Modifiers.ElementAt(1);
            }

            public Record CreateSut()
            {
                return _builder.Create();
            }
        }
    }
}