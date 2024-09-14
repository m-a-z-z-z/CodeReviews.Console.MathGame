using ConsoleMathGame.m_a_z_z_z;
/* TODO
	- Add random game mode []
	- Add 'Very Hard' game mode with timer []
 */
 
// very minimal, such wow
Helper.OnReturnRequested += () => Menu.HighscoresMenu();	// Subscribe Menu.HighscoresMenu() to OnReturnRequested event

Menu.MainMenu();
Menu.HighscoresMenu();