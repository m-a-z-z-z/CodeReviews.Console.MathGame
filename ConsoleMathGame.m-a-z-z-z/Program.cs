using ConsoleMathGame.m_a_z_z_z;
using ConsoleMathGame.m_a_z_z_z.Model;

// var declarations
GameEngine gameEngine = new GameEngine();
string? mainMenuSelection;
string? gameMenuSelection = null;

mainMenuSelection = Menu.MainMenu();

switch (mainMenuSelection)
{
    case "Play Game":
        gameMenuSelection = Menu.MainMenu();
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