using System;

namespace FileEx
{
    public static class Menu
    {
        public static void DisplayMenu()
        {
            foreach (MenuOption option in Enum.GetValues(typeof(MenuOption)))
            {
                Console.WriteLine($"{(int)option} - {option}");
            }
            Console.Write("\nBitte eine Option wählen: ");
        }
    }
}