using ConsoleMathGame.m_a_z_z_z.Model;

namespace ConsoleMathGame.m_a_z_z_z;

// This is menu is overkill but it's cool lol
// Arrow Keys are used to navigate options and Enter to select
internal class Menu
{
	public static event Action OnReturnRequested;
	
	// Logic for the menu. Menu options can be passed in as strings, making this reusable
	internal static string MenuTemplate(string title, params string[] options)
	{
		ConsoleKeyInfo key;
		int highlightedOption;
		bool isSelected;
		string optionHighlight = "\u001b[32m";    // Green in UTF
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
	
	internal static void GameMenu()
	{
		GameEngine gameEngine = new GameEngine();
		Difficulty difficulty = new Difficulty();
		var gameMode = Menu.MenuTemplate("Select a game mode", "Addition", "Subtraction", "Multiplication", "Division", "Return to main menu");
		
		switch (gameMode)
		{
			case "Addition":
				difficulty = Menu.DifficultyMenu();
				Game additionGame = new Game(GameMode.Addition, difficulty);    // Game objects used to track game state
				gameEngine.PlayGame(additionGame);
				break;
			case "Subtraction":
				difficulty = Menu.DifficultyMenu();
				Game subtractionGame = new Game(GameMode.Subtraction, difficulty);
				gameEngine.PlayGame(subtractionGame);
				break;
			case "Multiplication":
				difficulty = Menu.DifficultyMenu();
				Game multiplicationGame = new Game(GameMode.Multiplication, difficulty);
				gameEngine.PlayGame(multiplicationGame);
				break;
			case "Division":
				difficulty = Menu.DifficultyMenu();
				Game divisionGame = new Game(GameMode.Division, difficulty);
				gameEngine.PlayGame(divisionGame);
				break;
			case "Return to main menu":
				OnReturnRequested?.Invoke();	// invoke Menu.OnReturnRequested += () => ProgramStart() in Main
				break;
			default:
				Console.Error.WriteLine("Sheeeiiit, something went wrong. We got our best code monkeys workin on it.");
				Environment.Exit(1);
				break;
		}
	}
	
	internal static void HighscoresMenu() 
	{
		var gameMode = Menu.MenuTemplate("Select game mode to view highscores in", "Addition", "Subtraction", "Multiplication", "Division", "Return to main menu");

		switch (gameMode) 
		{
			case "Addition":
				Console.Clear();
				Helper.ViewHighScores(GameMode.Addition);
				break;
			case "Subtraction":
				Console.Clear();
				Helper.ViewHighScores(GameMode.Subtraction);
				break;
			case "Multiplication":
				Console.Clear();
				Helper.ViewHighScores(GameMode.Multiplication);
				break;
			case "Division":
				Console.Clear();
				Helper.ViewHighScores(GameMode.Division);
				break;
			case "Return to main menu":
				Console.Clear();
				OnReturnRequested?.Invoke();	// invoke Menu.OnReturnRequested += () => ProgramStart() in Main
				break;
			default:
				Console.Error.WriteLine("Sheeeiiit, something went wrong. We got our best code monkeys workin on it.");
				Environment.Exit(1);
				break;				
		}
	}
	
	internal static Difficulty DifficultyMenu() 
	{
		var difficulty = Menu.MenuTemplate("Select Difficulty", "Easy", "Medium", "Hard");
		
		switch (difficulty) 
		{
			case "Easy":
				return Difficulty.Easy;
			case "Medium":
				return Difficulty.Medium;
			case "Hard":
				return Difficulty.Hard;
			default:
				return Difficulty.Easy;				
		}
	}
}
