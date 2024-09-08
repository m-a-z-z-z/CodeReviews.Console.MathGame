namespace ConsoleMathGame.m_a_z_z_z;

// This is menu is overkill but it's cool lol
// Arrow Keys are used to navigate options and Enter to select
internal class Menu
{
	private static ConsoleKeyInfo key;
	private static int highlightedOption;
	private static bool isSelected;
	private static string optionHighlight = "\u001b[32m";    // Green in UTF

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

			// Loop through options array to print values for the menu and highlight the current option that will be selected if user presses enter
			for (int i = 0; i < options.Length; i++)
			{
				Console.WriteLine($"\t{(highlightedOption == i + 1 ? optionHighlight : "")}{options[i]}\u001b[0m");
			}

			Console.WriteLine("\n#####################################");
						
			key = Console.ReadKey(true);  // Read the key input to allow navigation and selection

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
