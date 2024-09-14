using ConsoleMathGame.m_a_z_z_z;
using ConsoleMathGame.m_a_z_z_z.Model;

/* TODO
	- Score reset if user gets answer wrong [x]
	- Check score against top 10 scores in category when a user gets an answer wrong, and add it to leaderboard if it beats any [x]
	- Random mode will present player with questions from all operations []
	- Difficulty setting
		- (Easy) no timer, integers from 1 - 12 only []
		- (Medium) Answer questions with timer, ints 1- 12 []
		- (Hard) Timer, and ints 1 - 99 []
		- (Very hard) Same as hard, but random mode []
 */

// var declarations
List<Game> gamesToPrint = new List<Game>();
GameEngine gameEngine = new GameEngine();
Helper.OnReturnRequested += () => ShowHighscoresMenu();	// Subscribe ShowHighscoresMenu to OnReturnRequested event

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