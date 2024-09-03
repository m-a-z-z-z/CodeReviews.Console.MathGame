using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMathGame.m_a_z_z_z;

internal class Menu
{
    private static ConsoleKeyInfo key;
    private static int selectedOption;
    private static bool isSelected;
    private static string selectionHighlight = "\u001b[32m";    // Green in UTF
    private static string upArrow = "\u2191";
    private static string downArrow = "\u2193";
    private static string returnArrow = "\u23CE";
    private static string carriageReturnArrow = "\u21B5";

    internal static int MainMenu()
    {
        selectedOption = 1;
        isSelected = false;
        Console.CursorVisible = false;
        (int left, int top) = Console.GetCursorPosition();

        while (!isSelected)
        {
            Console.SetCursorPosition(left, top);

            Console.WriteLine(
                "#####################################\n\n" +
                "\tWelcome to Math Game\n\n" +
                $"\t{(selectedOption == 1 ? selectionHighlight : "")}Play Game\u001b[0m\n" +
                $"\t{(selectedOption == 2 ? selectionHighlight : "")}View Highscorea\u001b[0m\n" +
                $"\t{(selectedOption == 3 ? selectionHighlight : "")}Quit\u001b[0m\n" +
                "\tUse  keys to navigate.\n" +
                "\t↲ to select.\n\n" +
                "#####################################"
            );

            key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.DownArrow:
                    selectedOption = (selectedOption == 4 ? 1 : selectedOption + 1);
                    break;
                case ConsoleKey.UpArrow:
                    selectedOption = (selectedOption == 1 ? 4 : selectedOption - 1);
                    break;
                case ConsoleKey.Enter:
                    isSelected = true;
                    Console.Clear();
                    break;
            } // end of switch
        } // end of while

        return selectedOption;
    } // end of MainMenu()
}
