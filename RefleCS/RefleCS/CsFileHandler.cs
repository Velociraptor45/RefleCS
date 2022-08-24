using Microsoft.CodeAnalysis;
using RefleCS.Converters;
using RefleCS.Nodes;

namespace RefleCS;

public class CsFileHandler : ICsFileHandler
{
    private static readonly CsFileConverter _converter = new();

    public CsFile FromPath(string filePath)
    {
        return _converter.ToCsFileFromPath(filePath);
    }

    public CsFile FromContent(string content)
    {
        return _converter.ToCsFileFromContent(content);
    }

    public void SaveOrReplace(CsFile csFile, string filePath)
    {
        var text = _converter.ToNode(csFile)
            .SyntaxTree
            .GetRoot()
            .NormalizeWhitespace()
            .GetText()
            .ToString();

        if (File.Exists(filePath))
            File.Delete(filePath);

        File.WriteAllText(filePath, text);
    }
}