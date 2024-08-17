using FluentAssertions;
using RefleCS.Nodes;
using RefleCS.TestKit;
using RefleCS.TestTools.Exceptions;

namespace RefleCS.Tests.Nodes;

public class NamespaceTests
{
    public class AddClass
    {
        private readonly AddClassFixture _fixture = new();

        [Fact]
        public void AddClass_WithValidData_ShouldAddClass()
        {
            // Arrange
            _fixture.SetupClass();
            var sut = _fixture.CreateSut();

            TestPropertyNotSetException.ThrowIfNull(_fixture.Class);

            // Act
            var result = sut.AddClass(_fixture.Class);

            // Assert
            result.Should().Be(result);
            sut.Classes.Should().Contain(_fixture.Class);
        }

        private sealed class AddClassFixture : NamespaceFixture
        {
            public Class? Class { get; private set; }

            public void SetupClass()
            {
                Class = new TestBuilder<Class>().Create();
            }
        }
    }

    public class RemoveClass
    {
        private readonly RemoveClassFixture _fixture = new();

        [Fact]
        public void RemoveClass_WithValidData_ShouldRemoveClass()
        {
            // Arrange
            _fixture.SetupNamespaceContainingClass();
            var sut = _fixture.CreateSut();

            TestPropertyNotSetException.ThrowIfNull(_fixture.Class);

            // Act
            var result = sut.RemoveClass(_fixture.Class);

            // Assert
            result.Should().Be(result);
            sut.Classes.Should().NotContain(_fixture.Class);
        }

        private sealed class RemoveClassFixture : NamespaceFixture
        {
            public Class? Class { get; private set; }

            public void SetupNamespaceContainingClass()
            {
                Class = new TestBuilder<Class>().Create();
                Classes.Add(Class);
            }
        }
    }

    private abstract class NamespaceFixture
    {
        protected readonly List<Class> Classes = new();
        protected string Name = string.Empty;

        public Namespace CreateSut()
        {
            return new Namespace(Name, Classes, Enumerable.Empty<Record>());
        }
    }
}