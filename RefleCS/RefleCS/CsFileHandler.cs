﻿using Microsoft.CodeAnalysis;
using RefleCS.Converters;
using RefleCS.Nodes;

namespace RefleCS;

/// <inheritdoc/>
public class CsFileHandler : ICsFileHandler
{
    private static readonly CsFileConverter _converter = new();

    /// <inheritdoc/>
    public CsFile? FromFile(string filePath)
    {
        return _converter.ToCsFileFromPath(filePath);
    }

    /// <inheritdoc/>
    public CsFile? FromCode(string content)
    {
        return _converter.ToCsFileFromContent(content);
    }

    /// <inheritdoc/>
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