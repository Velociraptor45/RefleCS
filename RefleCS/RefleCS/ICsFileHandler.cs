using RefleCS.Nodes;

namespace RefleCS;

public interface ICsFileHandler
{
    /// <summary>
    /// Returns null if the file's content is not valid C# code or C# code that cannot be converted to a CsFile.
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    CsFile? FromFile(string filePath);

    /// <summary>
    /// Returns null if the content is not valid C# code or C# code that cannot be converted to a CsFile.
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    CsFile? FromCode(string content);

    void SaveOrReplace(CsFile csFile, string filePath);
}