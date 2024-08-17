using FluentAssertions;
using RefleCS.Enums;
using RefleCS.Nodes;
using RefleCS.TestKit;
using RefleCS.TestKit.Common.Customizations;
using RefleCS.TestKit.Nodes;
using RefleCS.TestTools.Exceptions;

namespace RefleCS.Tests.Nodes;

public class MethodTests
{
    [Fact]
    public void PublicVoid_ShouldReturnExpectedResult()
    {
        // Arrange
        var name = "MyMethod";
        var expectedResult = new Method(
            new List<Comment>(),
            new List<MethodModifier> { MethodModifier.Public },
            "void",
            name,
            new List<Parameter>(),
            new List<Statement>());

        // Act
        var result = Method.PublicVoid(name);

        // Assert
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public void Public_WithoutParametersOrStatements_ShouldReturnExpectedResult()
    {
        // Arrange
        var name = "MyMethod";
        var returnType = "int";
        var expectedResult = new Method(
            new List<Comment>(),
            new List<MethodModifier> { MethodModifier.Public },
            returnType,
            name,
            new List<Parameter>(),
            new List<Statement>());

        // Act
        var result = Method.Public(returnType, name);

        // Assert
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public void Public_WithParametersAndStatements_ShouldReturnExpectedResult()
    {
        // Arrange
        var name = "MyMethod";
        var returnType = "int";
        var parameters = new List<Parameter>
            {
                new("string", "MyParam")
            };
        var statements = new List<Statement>
            {
                new("Console.WriteLine(\"Test\")")
            };
        var expectedResult = new Method(
            new List<Comment>(),
            new List<MethodModifier> { MethodModifier.Public },
            returnType,
            name,
            parameters,
            statements);

        // Act
        var result = Method.Public(returnType, name, parameters, statements);

        // Assert
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void ChangeName_WithEmptyName_ShouldThrow(string name)
    {
        // Arrange
        var sut = new TestBuilder<Method>().Create();

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
        var sut = new TestBuilder<Method>().Create();

        // Act
        sut.ChangeName(name);

        // Assert
        sut.Name.Should().Be(name);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void ChangeReturnTypeName_WithEmptyReturnTypeName_ShouldThrow(string returnTypeName)
    {
        // Arrange
        var sut = new TestBuilder<Method>().Create();

        // Act
        var func = () => sut.ChangeReturnTypeName(returnTypeName);

        // Assert
        func.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void ChangeReturnTypeName_WithValidReturnTypeName_ShouldChangeReturnTypeName()
    {
        // Arrange
        var returnTypeName = new TestBuilder<string>().Create();
        var sut = new TestBuilder<Method>().Create();

        // Act
        sut.ChangeReturnTypeName(returnTypeName);

        // Assert
        sut.ReturnTypeName.Should().Be(returnTypeName);
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
            private readonly MethodBuilder _builder;

            public AddModifierFixture()
            {
                _builder = new MethodBuilder();
            }

            public MethodModifier? Modifier { get; private set; }

            public void SetupModifier()
            {
                Modifier = new TestBuilder<MethodModifier>().Create();
            }

            public void SetupInitialDifferentModifier()
            {
                TestPropertyNotSetException.ThrowIfNull(Modifier);

                var builder = new TestBuilder<MethodModifier>();
                builder.Customize(
                    new EnumExclusionCustomization<MethodModifier>(new List<MethodModifier> { Modifier.Value }));

                var modifiers = builder.CreateMany(1);

                _builder.WithModifiers(modifiers);
            }

            public void SetupInitialSameModifier()
            {
                TestPropertyNotSetException.ThrowIfNull(Modifier);

                _builder.WithModifiers(new List<MethodModifier> { Modifier.Value });
            }

            public Method CreateSut()
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
            private readonly MethodBuilder _builder;

            public RemoveModifierFixture()
            {
                _builder = new MethodBuilder();
            }

            public MethodModifier? Modifier { get; private set; }

            public void SetupInitialDuplicatedModifiers()
            {
                var modifier = new TestBuilder<MethodModifier>().Create();

                _builder.WithModifiers(new List<MethodModifier> { modifier, modifier });
            }

            public void SetupModifierToRemove(Method cls)
            {
                Modifier = cls.Modifiers.ElementAt(1);
            }

            public Method CreateSut()
            {
                return _builder.Create();
            }
        }
    }

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
            private readonly MethodBuilder _builder;

            public AddParameterFixture()
            {
                _builder = new MethodBuilder();
            }

            public Parameter? Parameter { get; private set; }

            public void SetupParameter()
            {
                Parameter = new ParameterBuilder().Create();
            }

            public Method CreateSut()
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
            private readonly MethodBuilder _builder;

            public RemoveParameterFixture()
            {
                _builder = new MethodBuilder();
            }

            public Parameter? Parameter { get; private set; }

            public void SetupInitialParameters()
            {
                _builder
                    .WithParameters(new ParameterBuilder().CreateMany(3));
            }

            public void SetupParameterToRemove(Method cls)
            {
                Parameter = cls.Parameters.ElementAt(1);
            }

            public Method CreateSut()
            {
                return _builder.Create();
            }
        }
    }

    public class AddStatement
    {
        private readonly AddStatementFixture _fixture;

        public AddStatement()
        {
            _fixture = new AddStatementFixture();
        }

        [Fact]
        public void AddStatement_ShouldAddStatement()
        {
            // Arrange
            var sut = _fixture.CreateSut();
            _fixture.SetupStatement();
            var statementCount = sut.Statements.Count;

            TestPropertyNotSetException.ThrowIfNull(_fixture.Statement);

            // Act
            sut.AddStatement(_fixture.Statement);

            // Assert
            sut.Statements.Should().Contain(_fixture.Statement);
            sut.Statements.Should().HaveCount(statementCount + 1);
        }

        private class AddStatementFixture
        {
            private readonly MethodBuilder _builder;

            public AddStatementFixture()
            {
                _builder = new MethodBuilder();
            }

            public Statement? Statement { get; private set; }

            public void SetupStatement()
            {
                Statement = new StatementBuilder().Create();
            }

            public Method CreateSut()
            {
                return _builder.Create();
            }
        }
    }

    public class RemoveStatement
    {
        private readonly RemoveStatementFixture _fixture;

        public RemoveStatement()
        {
            _fixture = new RemoveStatementFixture();
        }

        [Fact]
        public void RemoveStatement_ShouldRemoveStatement()
        {
            // Arrange
            _fixture.SetupInitialStatements();
            var sut = _fixture.CreateSut();
            _fixture.SetupStatementToRemove(sut);
            var statementCount = sut.Statements.Count;

            TestPropertyNotSetException.ThrowIfNull(_fixture.Statement);

            // Act
            sut.RemoveStatement(_fixture.Statement);

            // Assert
            sut.Statements.Should().HaveCount(statementCount - 1);
            sut.Statements.Should().NotContain(_fixture.Statement);
        }

        private class RemoveStatementFixture
        {
            private readonly MethodBuilder _builder;

            public RemoveStatementFixture()
            {
                _builder = new MethodBuilder();
            }

            public Statement? Statement { get; private set; }

            public void SetupInitialStatements()
            {
                _builder
                    .WithStatements(new StatementBuilder().CreateMany(3));
            }

            public void SetupStatementToRemove(Method cls)
            {
                Statement = cls.Statements.ElementAt(1);
            }

            public Method CreateSut()
            {
                return _builder.Create();
            }
        }
    }
}