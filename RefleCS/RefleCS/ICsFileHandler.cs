using RefleCS.Nodes;

namespace RefleCS;

public interface ICsFileHandler
{
    CsFile FromPath(string filePath);

    CsFile FromContent(string content);

    void SaveOrReplace(CsFile csFile, string filePath);
}