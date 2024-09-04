using ConsoleMathGame.m_a_z_z_z;
using ConsoleMathGame.m_a_z_z_z.Model;

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
            // TODO
            //Implement viewing highscores
            throw new NotImplementedException();
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
            gameEngine.PlayGame('+');
            break;
        case "Subtraction":
            gameEngine.PlayGame('-');
            break;
        case "Multiplication":
            gameEngine.PlayGame('*');
            break;
        case "Division":
            gameEngine.PlayGame('/');
            break;
        default:
            break;
    }
}

StartProgram();



