using System;
using System.IO;

namespace FileEx
{
    public class FileControl : IFileControl
    {
        private readonly string _folderPath;
        public FileControl(string folderPath)
        {
            _folderPath = folderPath;
        }

        public void ListFiles()
        {
            Console.Clear();
            Console.WriteLine("Verfügbare Dateien:");
            foreach (var file in Directory.GetFiles(_folderPath))
            {
                Console.WriteLine($"  {file}");
            }
        }
        public void CreateFile(string fileName)
        {
            string fullPath = Path.Combine(_folderPath, fileName);
            if (!File.Exists(fullPath))
            {
                File.Create(fullPath).Close();
                Console.WriteLine($"Datei {fileName} wurde erstellt.");
            }
            else
            {
                Console.WriteLine("Datei existiert bereits.");
            }
        }

        public void WriteFile(string fileName, string content)
        {
            string fullPath = Path.Combine(_folderPath, fileName);
            if (File.Exists(fullPath))
            {
                File.AppendAllText(fullPath, content + Environment.NewLine);
                Console.WriteLine("✅ Datei wurde beschrieben.");
            }
            else
            {
                Console.WriteLine("Die Datei existiert nicht.");
            }
        }

        public void ReadFileContent(string fileName)
        {
            string fullPath = Path.Combine(_folderPath, fileName);
            if (File.Exists(fullPath))
            {
                string content = File.ReadAllText(fullPath);
                string information = string.IsNullOrEmpty(content) ? "Die Datei hat keinen Inhalt." : $"Die Datei hat diesen Inhalt:\n{content}";
                Console.WriteLine(information);
            }
            else
            {
                Console.WriteLine("Die Datei wurde nicht gefunden.");
            }
        }

        public void DeleteFile(string fileName)
        {
            string fullPath = Path.Combine(_folderPath, fileName);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
                Console.WriteLine("Datei wurde gelöscht.");
            }
            else
            {
                Console.WriteLine("Die Datei wurde nicht gefunden.");
            }
        }

        public void DeleteFileContent(string fileName)
        {
            string fullPath = Path.Combine(_folderPath, fileName);
            if (File.Exists(fullPath))
            {
                File.WriteAllText(fullPath, string.Empty);
                Console.WriteLine("✅ Der Inhalt der Datei wurde gelöscht.");
            }
            else
            {
                Console.WriteLine("⚠ Die angegebene Datei existiert nicht.");
            }
        }
    }
}
