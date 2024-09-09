using ConsoleMathGame.m_a_z_z_z;
using ConsoleMathGame.m_a_z_z_z.Model;

// var declarations
List<Game> gamesToPrint = new List<Game>();
GameEngine gameEngine = new GameEngine();
gameEngine.OnReturnRequested += () => ProgramStart();   // I cant lie, chat GPT showed me the wizardry on this line
Helper.OnReturnRequested += () => ShowHighscoresMenu();

ProgramStart();

void ProgramStart() 
{
	switch (Menu.MainMenu()) 
	{
		case "Play Game":
			ShowGameMenu();
			break;
		case "View Highscores":
			ShowHighscoresMenu();
			break;
		case "Quit":
			Environment.Exit(0);
			break;
	}
	
}

void ShowGameMenu() 
{
	switch (Menu.GameMenu())
	{
		case "Addition":
			Game additionGame = new Game(GameMode.Addition);    // Game objects used to track game state
			gameEngine.PlayGame('+', additionGame);
			break;
		case "Subtraction":
			Game subtractionGame = new Game(GameMode.Subtraction);
			gameEngine.PlayGame('-', subtractionGame);
			break;
		case "Multiplication":
			Game multiplicationGame = new Game(GameMode.Multiplication);
			gameEngine.PlayGame('*', multiplicationGame);
			break;
		case "Division":
			Game divisionGame = new Game(GameMode.Division);
			gameEngine.PlayGame('/', divisionGame);
			break;
		case "Return to main menu":
			ProgramStart();
			break;
		default:
			Console.Error.WriteLine("Sheeeiiit, something went wrong. We got our best code monkeys workin on it.");
			Environment.Exit(1);
			break;
	}
}

void ShowHighscoresMenu() 
{
	switch (Menu.HighscoresMenu())
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
			ProgramStart();
			break;
		default:
			Console.Error.WriteLine("Sheeeiiit, something went wrong. We got our best code monkeys workin on it.");
			Environment.Exit(1);
			break;
	}
}