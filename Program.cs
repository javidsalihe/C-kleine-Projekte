using System;

namespace FileEx
{
    class Program
    {
        static void Main(string[] args)
        {
            int userInput = 0;
            var folderPath = @"/Users/javidsalihe/RiderProjects/ConsoleApplication/FileEx";
            var fileControl = new FileControl(folderPath);
            
            do
            {
                Menu.DisplayMenu();
                if (!int.TryParse(Console.ReadLine(), out userInput) || !Enum.IsDefined(typeof(MenuOption), userInput))
                {
                    Console.WriteLine("\nUngültige Eingabe! Bitte eine Zahl zwischen 1 und 7 eingeben.");
                    continue;
                }

                Console.WriteLine($"\nSie haben gewählt: {(MenuOption)userInput}\n");
                switch ((MenuOption)userInput)
                {
                    case MenuOption.ListFiles:
                        fileControl.ListFiles();
                        break;
                    case MenuOption.CreateFile:
                        Console.Write("Geben Sie den Dateinamen ein: ");
                        string createFileName = Console.ReadLine();
                        fileControl.CreateFile(createFileName);
                        break;
                    case MenuOption.WriteFile:
                        Console.Write("Geben Sie den Dateinamen ein: ");
                        string writeFileName = Console.ReadLine();
                        Console.Write("Geben Sie den Inhalt ein: ");
                        string content = Console.ReadLine();
                        fileControl.WriteFile(writeFileName, content);
                        break;
                    case MenuOption.ReadFile:
                        Console.Write("Geben Sie den Dateinamen ein: ");
                        string readFileName = Console.ReadLine();
                        fileControl.ReadFileContent(readFileName);
                        break;
                    case MenuOption.DeleteFile:
                        Console.Write("Geben Sie den Dateinamen ein: ");
                        string deleteFileName = Console.ReadLine();
                        fileControl.DeleteFile(deleteFileName);
                        break;
                    case MenuOption.DeleteContent:
                        Console.Write("Geben Sie den Dateinamen ein: ");
                        string deleteContentFileName = Console.ReadLine();
                        fileControl.DeleteFileContent(deleteContentFileName);
                        break;
                    case MenuOption.Exit:
                        Console.WriteLine("Programm wird beendet...");
                        break;
                    default:
                        Console.WriteLine("Ungültige Option.");
                        break;
                }
            } while (userInput != (int)MenuOption.Exit);
        }
    }
}
