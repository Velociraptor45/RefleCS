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

    /// <summary>
    /// Saves the CsFile to the specified path. If the file already exists, it will be replaced.
    /// </summary>
    /// <param name="csFile"></param>
    /// <param name="filePath"></param>
    /// <exception cref="ArgumentException">Thrown if <paramref name="filePath"/> is empty</exception>
    void SaveOrReplace(CsFile csFile, string filePath);
}