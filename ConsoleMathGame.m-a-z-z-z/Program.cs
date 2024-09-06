using ConsoleMathGame.m_a_z_z_z;
using ConsoleMathGame.m_a_z_z_z.Model;
using System.Security.AccessControl;

// var declarations
GameEngine gameEngine = new GameEngine();
gameEngine.OnReturnRequested += () => StartProgram();   // I cant lie, chat GPT showed me the wizardry on this line

void StartProgram()
{
    var mainMenuSelection = Menu.MainMenu();
    var gameMenuSelection = "";

    switch (mainMenuSelection)
    {
        case "Play Game":
            gameMenuSelection = Menu.GameMenu();
            break;
        case "View Highscores":
            Helper.ViewHighScores(Helper.games);
            break;
        case "Quit":
            Environment.Exit(0);
            break;
        default:
            Environment.Exit(1);
            break;
    }

    switch (gameMenuSelection)
    {
        case "Addition":
            Game additionGame = new Game(GameMode.Addition);
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
        default:
            break;
    }
}

StartProgram();



