using FluentAssertions;
using RefleCS.Nodes;
using RefleCS.TestTools.Exceptions;

namespace RefleCS.Tests.Nodes;

public class CsFileTests
{
    public class AddUsing
    {
        private readonly AddUsingFixture _fixture = new();

        [Fact]
        public void AddUsing_WithExistingUsing_ShouldNotAddUsing()
        {
            // Arrange
            _fixture.SetupNamespaceEmpty();
            _fixture.SetupExistingUsing();
            var sut = _fixture.CreateSut();

            TestPropertyNotSetException.ThrowIfNull(_fixture.ExistingUsing);
            TestPropertyNotSetException.ThrowIfNull(_fixture.ExpectedResult);

            // Act
            var result = sut.AddUsing(_fixture.ExistingUsing);

            // Assert
            result.Should().Be(sut);
            sut.Usings.Should().BeEquivalentTo(_fixture.ExpectedResult);
        }

        [Fact]
        public void AddUsing_WithNonExistingUsing_ShouldAddUsing()
        {
            // Arrange
            _fixture.SetupNamespaceEmpty();
            _fixture.SetupNonExistingUsing();
            var sut = _fixture.CreateSut();

            var list = sut.Usings;

            TestPropertyNotSetException.ThrowIfNull(_fixture.NonExistingUsing);
            TestPropertyNotSetException.ThrowIfNull(_fixture.ExpectedResult);

            // Act
            var result = sut.AddUsing(_fixture.NonExistingUsing);

            // Assert
            result.Should().Be(sut);
            sut.Usings.Should().BeEquivalentTo(_fixture.ExpectedResult);
            ReferenceEquals(sut.Usings, list).Should().BeTrue();
        }

        private sealed class AddUsingFixture : CsFileFixture
        {
            public Using? ExistingUsing { get; private set; }
            public Using? NonExistingUsing { get; private set; }
            public IReadOnlyCollection<Using>? ExpectedResult { get; private set; }

            public void SetupExistingUsing()
            {
                Usings = new List<Using>
                {
                    new("a"),
                    new("b"),
                };

                ExistingUsing = new("a");

                ExpectedResult = new List<Using>
                {
                    new("a"),
                    new("b"),
                };
            }

            public void SetupNonExistingUsing()
            {
                Usings = new List<Using>
                {
                    new("a"),
                    new("b"),
                };

                NonExistingUsing = new("c");

                ExpectedResult = new List<Using>
                {
                    new("a"),
                    new("b"),
                    new("c"),
                };
            }
        }
    }

    public class RemoveUsing
    {
        private readonly RemoveUsingFixture _fixture = new();

        [Fact]
        public void RemoveUsing_WithExistingUsing_ShouldRemoveUsing()
        {
            // Arrange
            _fixture.SetupNamespaceEmpty();
            _fixture.SetupExistingUsing();
            var sut = _fixture.CreateSut();

            TestPropertyNotSetException.ThrowIfNull(_fixture.ExistingUsing);
            TestPropertyNotSetException.ThrowIfNull(_fixture.ExpectedResult);

            // Act
            var result = sut.RemoveUsing(_fixture.ExistingUsing);

            // Assert
            result.Should().Be(sut);
            sut.Usings.Should().BeEquivalentTo(_fixture.ExpectedResult);
        }

        [Fact]
        public void RemoveUsing_WithNonExistingUsing_ShouldNotRemoveUsing()
        {
            // Arrange
            _fixture.SetupNamespaceEmpty();
            _fixture.SetupNonExistingUsing();
            var sut = _fixture.CreateSut();

            var list = sut.Usings;

            TestPropertyNotSetException.ThrowIfNull(_fixture.NonExistingUsing);
            TestPropertyNotSetException.ThrowIfNull(_fixture.ExpectedResult);

            // Act
            var result = sut.RemoveUsing(_fixture.NonExistingUsing);

            // Assert
            result.Should().Be(sut);
            sut.Usings.Should().BeEquivalentTo(_fixture.ExpectedResult);
            ReferenceEquals(sut.Usings, list).Should().BeTrue();
        }

        private sealed class RemoveUsingFixture : CsFileFixture
        {
            public Using? ExistingUsing { get; private set; }
            public Using? NonExistingUsing { get; private set; }
            public IReadOnlyCollection<Using>? ExpectedResult { get; private set; }

            public void SetupExistingUsing()
            {
                Usings = new List<Using>
                {
                    new("a"),
                    new("b"),
                };

                ExistingUsing = new("a");

                ExpectedResult = new List<Using>
                {
                    new("b"),
                };
            }

            public void SetupNonExistingUsing()
            {
                Usings = new List<Using>
                {
                    new("a"),
                    new("b"),
                };

                NonExistingUsing = new("c");

                ExpectedResult = new List<Using>
                {
                    new("a"),
                    new("b"),
                };
            }
        }
    }

    public class OrderUsingsAsc
    {
        private readonly OrderUsingsAscFixture _fixture = new();

        [Fact]
        public void OrderUsingsAsc_WithMultipleUsings_ShouldOrderUsings()
        {
            // Arrange
            _fixture.SetupUnorderedUsings();
            _fixture.SetupNamespaceEmpty();
            var sut = _fixture.CreateSut();

            TestPropertyNotSetException.ThrowIfNull(_fixture.ExpectedResult);

            // Act
            var result = sut.OrderUsingsAsc();

            // Assert
            result.Should().Be(sut);
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
            var result = sut.OrderUsingsAsc();

            // Assert
            result.Should().Be(sut);
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
        private readonly OrderUsingsDescFixture _fixture = new();

        [Fact]
        public void OrderUsingsDesc_WithMultipleUsings_ShouldOrderUsings()
        {
            // Arrange
            _fixture.SetupUnorderedUsings();
            _fixture.SetupNamespaceEmpty();
            var sut = _fixture.CreateSut();

            TestPropertyNotSetException.ThrowIfNull(_fixture.ExpectedResult);

            // Act
            var result = sut.OrderUsingsDesc();

            // Assert
            result.Should().Be(sut);
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
            var result = sut.OrderUsingsDesc();

            // Assert
            result.Should().Be(sut);
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
        protected List<Using>? Usings;
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