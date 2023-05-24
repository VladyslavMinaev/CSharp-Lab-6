using System.IO;

namespace ServerApp.Utils;

public class FileManager
{
    public string Read(string path)
    {
        using StreamReader streamReader = new(path);
        return streamReader.ReadToEnd();
    }

    public void Write(string path, string content)
    {
        using StreamWriter streamWriter = new(path);
        streamWriter.Write(content);
    }
}