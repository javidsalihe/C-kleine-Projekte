using System;
namespace FileEx
{
    public interface IFileControl
    {
        void CreateFile(string fileName);
        void WriteFile(string fileName, string content);
        void ReadFileContent(string fileName);
        void DeleteFile(string fileName);
        void DeleteFileContent(string fileName);
        void ListFiles();
    }
}