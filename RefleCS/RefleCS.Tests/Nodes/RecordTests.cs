using FluentAssertions;
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
            private RecordBuilder _builder;

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
}