using ConsoleMathGame.m_a_z_z_z;
using ConsoleMathGame.m_a_z_z_z.Model;

// vars
GameEngine gameEngine = new GameEngine();
string mainMenuSelection;
string gameMenuSelection = "";

mainMenuSelection = Menu.MainMenu();

if (mainMenuSelection == "Play Game")
{
    gameMenuSelection = Menu.GameMenu();
} 
else if (mainMenuSelection == "View Highscores")
{
    // to do
}
else
{
    // to do
}

switch (gameMenuSelection)
{
    case "Addition":
        gameEngine.PlayGame('+');
        break;
    default:
        break;
}