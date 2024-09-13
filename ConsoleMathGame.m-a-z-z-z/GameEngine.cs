using ConsoleMathGame.m_a_z_z_z.Model;

namespace ConsoleMathGame.m_a_z_z_z;
internal class GameEngine
{	
	internal void PlayGame(char mathOperator, Game game)    // Game is passed in method to keep track of game state as the PlayGame method calls on itself if user chooses to continue playing
	{
		// Var declartion
		Console.CursorVisible = true;   // make console cursor visible again now that we're not in menu and taking input
		Random random = new Random();
		string userAnswer;
		int correctAnswer = 0;
		int firstNum = random.Next(1, 99);
		int secondNum = random.Next(1, 99);

		// Calculate answer
		switch (mathOperator)
		{
			case '+':
				correctAnswer = firstNum + secondNum;
				break;
			case '-':
				correctAnswer = firstNum - secondNum;
				break;
			case '*':
				correctAnswer = firstNum * secondNum;
				break;
			case '/':
				while (firstNum % secondNum != 0)
				{
					firstNum = random.Next(1, 99);
					secondNum = random.Next(1, 99);
				}
				correctAnswer = firstNum / secondNum;
				break;
		}

		// Take user answer
		Console.Write($"{firstNum} {mathOperator} {secondNum} = ? ");
		userAnswer = Console.ReadLine();

		// ensure number was entered
		userAnswer = Helper.ValidateNumber(userAnswer);

		// Case for incorrect answer
		if (int.Parse(userAnswer) != correctAnswer)
		{
			Console.WriteLine($"Incorrect. Final score: {game.Score}");
			Console.WriteLine("Continue? [y/n]");
			var reply = Console.ReadLine().Trim().ToLower();
			
			if (reply == "n" || reply == "no") 
			{
				Helper.AddScoreToLeaderboard(game);	
				Console.Clear();
				Helper.ViewHighScores(game.GameMode);
			}
			game.Score = 0;	// reset if user presses key besides 'y' or 'yes'
		}
		else if (int.Parse(userAnswer) == correctAnswer)	// Case for correct answer 
		{
			game.Score++;
			Console.WriteLine($"\nCorrect!\t Score: {game.Score}");
			Console.WriteLine("Press any key to continue.\n" + "Q to return to menu.");
			var reply = Console.ReadLine().Trim().ToLower();
			if (reply == "q" || reply == "quit") 
			{
				Helper.AddScoreToLeaderboard(game);
				Console.Clear();
				Helper.ViewHighScores(game.GameMode);
			}
		}		
		
		Console.Clear();
		PlayGame(mathOperator, game);   // game is passed in and game state is preserved, keeping track of score and game mode selected
	}

}
