using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMathGame.m_a_z_z_z;

internal class Menu
{
    // This is menu is overkill but its cool lol
    // Arrow Keys are used to navigate options and Enter to select
    private static ConsoleKeyInfo key;
    private static int highlightedOption;
    private static bool isSelected;
    private static string optionHighlight = "\u001b[32m";    // Green in UTF

    // This is menu is overkill but it's cool lol
    // Arrow Keys are used to navigate options and Enter to select
    internal static string MenuTemplate(string title, params string[] options)
    {
        highlightedOption = 1;
        isSelected = false;
        Console.CursorVisible = false;
        (int left, int top) = Console.GetCursorPosition();

        while (!isSelected)
        {
            Console.SetCursorPosition(left, top);  // Move the cursor back to the starting point to prevent redrawing
            Console.WriteLine("#####################################\n\n" + $"\t{title}\n");

            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"\t{(highlightedOption == i + 1 ? optionHighlight : "")}{options[i]}\u001b[0m");
            }

            Console.WriteLine("\n#####################################");

            
            key = Console.ReadKey(true);  // Read the key input to allow navigation

            switch (key.Key)
            {
                case ConsoleKey.DownArrow:
                    highlightedOption = (highlightedOption == options.Length ? 1 : highlightedOption + 1);
                    break;

                case ConsoleKey.UpArrow:
                    highlightedOption = (highlightedOption == 1 ? options.Length : highlightedOption - 1);
                    break;

                case ConsoleKey.Enter:
                    isSelected = true;
                    Console.Clear();
                    break;
            }
        }

        return options[highlightedOption - 1];  // Return the selected option
    }

    internal static string MainMenu()
    {
        return Menu.MenuTemplate("Welcome to Math Game", "Play Game", "View Highscores", "Quit");
    }

    internal static string GameMenu()
    {
        return Menu.MenuTemplate("Select a game mode", "Addition", "Subtraction", "Multiplication", "Division");
    }

}
