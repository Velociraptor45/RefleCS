using FluentAssertions;
using RefleCS.Nodes;
using RefleCS.TestTools.Exceptions;
using Record = RefleCS.Nodes.Record;

namespace RefleCS.Tests.Nodes;

public class CsFileTests
{
    public class OrderUsingsAsc
    {
        private readonly OrderUsingsAscFixture _fixture;

        public OrderUsingsAsc()
        {
            _fixture = new OrderUsingsAscFixture();
        }

        [Fact]
        public void OrderUsingsAsc_WithMultipleUsings_ShouldOrderUsings()
        {
            // Arrange
            _fixture.SetupUnorderedUsings();
            _fixture.SetupNamespaceEmpty();
            var sut = _fixture.CreateSut();

            TestPropertyNotSetException.ThrowIfNull(_fixture.ExpectedResult);

            // Act
            sut.OrderUsingsAsc();

            // Assert
            sut.Usings.Should().BeEquivalentTo(_fixture.ExpectedResult, cfg => cfg.WithStrictOrdering());
        }

        [Fact]
        public void OrderUsingsAsc_WithMultipleUsings_ShouldRetainSameListReference()
        {
            // Arrange
            _fixture.SetupUnorderedUsings();
            _fixture.SetupNamespaceEmpty();
            var sut = _fixture.CreateSut();

            TestPropertyNotSetException.ThrowIfNull(_fixture.ExpectedResult);

            var list = sut.Usings;

            // Act
            sut.OrderUsingsAsc();

            // Assert
            ReferenceEquals(sut.Usings, list).Should().BeTrue();
        }

        private sealed class OrderUsingsAscFixture : CsFileFixture
        {
            public IReadOnlyCollection<Using>? ExpectedResult { get; private set; }

            public void SetupUnorderedUsings()
            {
                Usings = new List<Using>
                {
                    new("aa"),
                    new("a"),
                    new("1a"),
                    new("b"),
                };

                ExpectedResult = new List<Using>
                {
                    new("1a"),
                    new("a"),
                    new("aa"),
                    new("b"),
                };
            }
        }
    }

    public class OrderUsingsDesc
    {
        private readonly OrderUsingsDescFixture _fixture;

        public OrderUsingsDesc()
        {
            _fixture = new OrderUsingsDescFixture();
        }

        [Fact]
        public void OrderUsingsDesc_WithMultipleUsings_ShouldOrderUsings()
        {
            // Arrange
            _fixture.SetupUnorderedUsings();
            _fixture.SetupNamespaceEmpty();
            var sut = _fixture.CreateSut();

            TestPropertyNotSetException.ThrowIfNull(_fixture.ExpectedResult);

            // Act
            sut.OrderUsingsDesc();

            // Assert
            sut.Usings.Should().BeEquivalentTo(_fixture.ExpectedResult, cfg => cfg.WithStrictOrdering());
        }

        [Fact]
        public void OrderUsingsDesc_WithMultipleUsings_ShouldRetainSameListReference()
        {
            // Arrange
            _fixture.SetupUnorderedUsings();
            _fixture.SetupNamespaceEmpty();
            var sut = _fixture.CreateSut();

            TestPropertyNotSetException.ThrowIfNull(_fixture.ExpectedResult);

            var list = sut.Usings;

            // Act
            sut.OrderUsingsDesc();

            // Assert
            ReferenceEquals(sut.Usings, list).Should().BeTrue();
        }

        private sealed class OrderUsingsDescFixture : CsFileFixture
        {
            public IReadOnlyCollection<Using>? ExpectedResult { get; private set; }

            public void SetupUnorderedUsings()
            {
                Usings = new List<Using>
                {
                    new("aa"),
                    new("a"),
                    new("1a"),
                    new("b"),
                };

                ExpectedResult = new List<Using>
                {
                    new("b"),
                    new("aa"),
                    new("a"),
                    new("1a"),
                };
            }
        }
    }

    private abstract class CsFileFixture
    {
        public List<Using>? Usings;
        private Namespace? _namespace;

        public CsFile CreateSut()
        {
            TestPropertyNotSetException.ThrowIfNull(_namespace);
            TestPropertyNotSetException.ThrowIfNull(Usings);

            return new CsFile(Usings, _namespace);
        }

        public void SetupNamespaceEmpty()
        {
            _namespace = new Namespace("MyNamespace", new List<Class>(), Enumerable.Empty<Record>());
        }
    }
}