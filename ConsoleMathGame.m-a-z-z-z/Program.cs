using ConsoleMathGame.m_a_z_z_z;
using ConsoleMathGame.m_a_z_z_z.Model;

/* TODO
	- Score reset if user gets answer wrong [x]
	- Check score against top 10 scores in category when a user gets an answer wrong, and add it to leaderboard if it beats any [x]
	- Random mode will present player with questions from all operations []
	- Difficulty setting
		- (Easy) no timer, integers from 1 - 12 only [x]
		- (Medium) Answer questions with timer, ints 1- 12 []
		- (Hard) Timer, and ints 1 - 99 []
		- (Very hard) Same as hard, but random mode []
 */

// var declarations
Helper.OnReturnRequested += () => Menu.HighscoresMenu();	// Subscribe ShowHighscoresMenu to OnReturnRequested event
Menu.OnReturnRequested += () => ProgramStart();

ProgramStart();

void ProgramStart() 
{
	switch (Menu.MainMenu()) 
	{
		case "Play Game":
			Menu.GameMenu();
			break;
		case "View Highscores":
			Menu.HighscoresMenu();
			break;
		case "Quit":
			Environment.Exit(0);
			break;
	}	
}