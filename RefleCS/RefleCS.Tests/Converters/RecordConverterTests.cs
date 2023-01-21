using FluentAssertions;
using RefleCS.Converters;
using Record = RefleCS.Nodes.Record;

namespace RefleCS.Tests.Converters;

public class RecordConverterTests
{
    private readonly RecordConverter _sut;

    public RecordConverterTests()
    {
        _sut = new RecordConverter();
    }

    [Theory]
    [ClassData(typeof(RecordConverterTestData))]
    public void DoubleConvert(Record originalRecord)
    {
        var node = _sut.ToNode(originalRecord);
        var convertedFile = _sut.ToRecord(node);

        convertedFile.Should().BeEquivalentTo(originalRecord);
    }
}