using FluentAssertions;
using Microsoft.CodeAnalysis;
using RefleCS.Converters;
using RefleCS.Nodes;

namespace RefleCS.Tests.Converters;

public class CsFileConverterTests
{
    private readonly CsFileConverter _sut;

    public CsFileConverterTests()
    {
        _sut = new CsFileConverter();
    }

    [Theory]
    [ClassData(typeof(CsFileConverterTestData))]
    public void DoubleConvert(CsFile originalFile)
    {
        var node = _sut.ToNode(originalFile);
        var normalizedNode = node
            .SyntaxTree
            .GetRoot()
            .NormalizeWhitespace()
            .GetText()
            .ToString();

        var convertedFile = _sut.ToCsFileFromContent(normalizedNode);

        convertedFile.Should().BeEquivalentTo(originalFile);
    }
}