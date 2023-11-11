using RefleCS.Nodes;

namespace RefleCS;

public interface ICsFileHandler
{
    CsFile? FromFile(string filePath);

    CsFile? FromCode(string content);

    void SaveOrReplace(CsFile csFile, string filePath);
}