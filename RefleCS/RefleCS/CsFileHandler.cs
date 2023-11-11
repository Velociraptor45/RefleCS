using Microsoft.CodeAnalysis;
using RefleCS.Converters;
using RefleCS.Nodes;

namespace RefleCS;

public class CsFileHandler : ICsFileHandler
{
    private static readonly CsFileConverter _converter = new();

    /// <summary>
    /// Returns null if the file's content is not valid C# code or C# code that cannot be converted to a CsFile.
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public CsFile? FromFile(string filePath)
    {
        return _converter.ToCsFileFromPath(filePath);
    }

    /// <summary>
    /// Returns null if the content is not valid C# code or C# code that cannot be converted to a CsFile.
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public CsFile? FromCode(string content)
    {
        return _converter.ToCsFileFromContent(content);
    }

    /// <summary>
    /// Saves the CsFile to the specified path. If the file already exists, it will be replaced.
    /// </summary>
    /// <param name="csFile"></param>
    /// <param name="filePath"></param>
    /// <exception cref="ArgumentException">Thrown if <paramref name="filePath"/> is empty</exception>
    public void SaveOrReplace(CsFile csFile, string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(filePath));

        var text = _converter.ToNode(csFile)
            .SyntaxTree
            .GetRoot()
            .NormalizeWhitespace()
            .GetText()
            .ToString();

        var fileInfo = new FileInfo(filePath);
        if (!fileInfo.Directory!.Exists)
            fileInfo.Directory.Create();

        if (fileInfo.Exists)
            fileInfo.Delete();

        File.WriteAllText(filePath, text);
    }
}